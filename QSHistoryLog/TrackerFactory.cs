﻿using System;
using System.Linq;
using NHibernate.Proxy;
using QS.DomainModel.Tracking;
using QSOrmProject;

namespace QSHistoryLog
{
	public class TrackerFactory : ITrackerFactory
	{
		public TrackerFactory()
		{
		}

		public IObjectTracker<TEntity> Create<TEntity>(TEntity root, TrackerCreateOption option)
			where TEntity : class, IDomainObject, new()
		{
			if(HistoryMain.ObjectsDesc.Any(x => x.ObjectType == typeof(TEntity)))
				return new ObjectTracker<TEntity>(root, option);
			else
				return null;
		}

		public IDeleteTracker CreateDeleteTracker()
		{
			return new DeleteTracker();
		}

		public IObjectTracker CreateTracker(object root, TrackerCreateOption option)
		{
			var rootType = root.GetType();
			//Здесь проверям наличие IProxy, интерфейс INHibernateProxy оставлен навсякий случай, так как в объекте с перехватом загрузки его нет.
			if(rootType.GetInterface(typeof(NHibernate.Proxy.DynamicProxy.IProxy).FullName) != null || rootType.GetInterface(typeof(INHibernateProxy).FullName) != null)
				rootType = rootType.BaseType;

			if(HistoryMain.ObjectsDesc.All(x => x.ObjectType != rootType))
				return null;

			var trackerType = typeof(ObjectTracker<>).MakeGenericType(rootType);
			return (IObjectTracker)Activator.CreateInstance(trackerType, root, option);
		}

		public bool NeedTrace(Type type)
		{
			return HistoryMain.ObjectsDesc.Any(x => x.ObjectType == type);
		}
	}
}
