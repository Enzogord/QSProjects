﻿using System;
using System.Runtime.CompilerServices;
using QS.DomainModel;
using QS.DomainModel.Entity;
using QS.DomainModel.Tracking;
using QS.DomainModel.UoW;
using QSOrmProject.DomainModel;

namespace QSOrmProject
{
	public static class UnitOfWorkFactory
	{
        /// <summary>
        /// Создаем Unit of Work без корренной сущьности.
        /// </summary>
        /// <returns>UnitOfWork.</returns>
        public static IUnitOfWork CreateWithoutRoot(string userActionTitle = null, [CallerMemberName]string callerMemberName = null, [CallerFilePath]string callerFilePath = null, [CallerLineNumber]int callerLineNumber = 0)
		{
            var title = new UnitOfWorkTitle(userActionTitle, callerMemberName, callerFilePath, callerLineNumber);
            return new UnitOfWorkWithoutRoot(title);
		}

		/// <summary>
		/// Создаем Unit of Work загружая сущность по id.
		/// </summary>
		/// <returns>UnitOfWork.</returns>
		/// <typeparam name="TEntity">Тип объекта доменной модели, должен реализовывать интерфейс IDomainObject.</typeparam>
		public static IUnitOfWorkGeneric<TEntity> CreateForRoot<TEntity>(int id, string userActionTitle = null, [CallerMemberName]string callerMemberName = null, [CallerFilePath]string callerFilePath = null, [CallerLineNumber]int callerLineNumber = 0) where TEntity : class, IDomainObject, new()
		{
            var title = new UnitOfWorkTitle(userActionTitle, callerMemberName, callerFilePath, callerLineNumber);
            var uow = new UnitOfWork<TEntity>(id, title);
			return uow;
		}

		/// <summary>
		/// Создаем Unit of Work с новым экземляром сущности
		/// </summary>
		/// <returns>UnitOfWork.</returns>
		/// <typeparam name="TEntity">Тип объекта доменной модели, должен реализовывать интерфейс IDomainObject.</typeparam>
		public static IUnitOfWorkGeneric<TEntity> CreateWithNewRoot<TEntity>(string userActionTitle = null, [CallerMemberName]string callerMemberName = null, [CallerFilePath]string callerFilePath = null, [CallerLineNumber]int callerLineNumber = 0) where TEntity : class, IDomainObject, new()
		{
            var title = new UnitOfWorkTitle(userActionTitle, callerMemberName, callerFilePath, callerLineNumber);
            var uow = new UnitOfWork<TEntity>(title);
			return uow;
		}

		/// <summary>
		/// Создаем Unit of Work с новым экземляром сущности переданным в виде аргумента
		/// </summary>
		/// <returns>UnitOfWork.</returns>
		/// <typeparam name="TEntity">Тип объекта доменной модели, должен реализовывать интерфейс IDomainObject.</typeparam>
		public static IUnitOfWorkGeneric<TEntity> CreateWithNewRoot<TEntity>(TEntity entity, string userActionTitle = null, [CallerMemberName]string callerMemberName = null, [CallerFilePath]string callerFilePath = null, [CallerLineNumber]int callerLineNumber = 0) where TEntity : class, IDomainObject, new()
		{
            var title = new UnitOfWorkTitle(userActionTitle, callerMemberName, callerFilePath, callerLineNumber);
            var uow = new UnitOfWork<TEntity>(entity, title);
			return uow;
		}

	}
}

