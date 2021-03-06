﻿using System;
using System.Linq;

namespace QSOrmProject.RepresentationModel
{
	/// <summary>
	/// Базовый клас презентационной модели с подпиской на обновления только для типа TEntity
	/// </summary>
	public abstract class RepresentationModelEntityBase<TEntity, TNode> : RepresentationModelBase<TNode>, IRepresentationModel
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger ();

		public Type ObjectType {
			get { return typeof(TEntity); }
		}

		/// <summary>
		/// Запрос у модели о необходимости обновления списка если объект изменился.
		/// </summary>
		/// <returns><c>true</c>, если небходимо обновлять список.</returns>
		/// <param name="updatedSubject">Обновившийся объект</param>
		protected abstract bool NeedUpdateFunc (TEntity updatedSubject);

		/// <summary>
		/// Создает новый базовый клас и подписывается на обновления для типа TEntity, при этом конструкторе необходима реализация NeedUpdateFunc (TEntity updatedSubject)
		/// </summary>
		protected RepresentationModelEntityBase ()
		{
			var description = OrmMain.GetObjectDescription<TEntity> ();
			if (description != null)
				description.ObjectUpdatedGeneric += OnExternalUpdate;
			else
				logger.Warn ("Невозможно подписаться на обновления класа {0}. Не найден класс маппинга.", typeof(TEntity));
		}

		void OnExternalUpdate (object sender, QSOrmProject.UpdateNotification.OrmObjectUpdatedGenericEventArgs<TEntity> e)
		{
			if (!UoW.IsAlive)
			{
				logger.Warn ("Получена нотификация о внешнем обновлении данные в {0}, в тот момент когда сессия уже закрыта. Возможно RepresentationModel, осталась в памяти при закрытой сессии.",
				this);
				return;
			}
				
			if (e.UpdatedSubjects.Any (NeedUpdateFunc))
				UpdateNodes ();
		}

		public void Destroy()
		{
			logger.Debug("{0} called Destroy()", this.GetType());
			var description = OrmMain.GetObjectDescription<TEntity> ();
			if (description != null)
				description.ObjectUpdatedGeneric -= OnExternalUpdate;
		}
	}
}

