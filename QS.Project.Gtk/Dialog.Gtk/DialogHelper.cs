﻿using System;
using Gtk;
using QS.DomainModel.Entity;
using QS.Tdi;

namespace QS.Dialog.Gtk
{
	public static class DialogHelper
	{
		public static IEntityDialog FindParentEntityDialog(Widget child)
		{
			if(child.Parent == null)
				return null;
			else if(child.Parent is IEntityDialog)
				return child.Parent as IEntityDialog;
			else if(child.Parent.IsTopLevel)
				return null;
			else
				return FindParentEntityDialog(child.Parent);
		}

		public static ISingleUoWDialog FindParentUowDialog(Widget child)
		{
			if(child.Parent == null)
				return null;
			else if(child.Parent is ISingleUoWDialog)
				return child.Parent as ISingleUoWDialog;
			else if(child.Parent.IsTopLevel)
				return null;
			else
				return FindParentUowDialog(child.Parent);
		}

		public static ITdiTab FindParentTab(Widget child)
		{
			if(child.Parent is ITdiTab)
				return child.Parent as ITdiTab;
			else if(child.Parent.IsTopLevel)
				return null;
			else
				return FindParentTab(child.Parent);
		}

		public static string GenerateDialogHashName<TEntity>(int id) where TEntity : IDomainObject
		{
			return GenerateDialogHashName(typeof(TEntity), id);
		}

		public static string GenerateDialogHashName(Type clazz, int id)
		{
			if(!typeof(IDomainObject).IsAssignableFrom(clazz))
				throw new ArgumentException("Тип должен реализовывать интерфейс IDomainObject", "clazz");

			return String.Format("{0}_{1}", clazz.Name, id);
		}
	}
}
