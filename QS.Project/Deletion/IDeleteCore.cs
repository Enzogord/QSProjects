﻿using System;
using QS.DomainModel.UoW;

namespace QS.Deletion
{
	internal interface IDeleteCore
	{
		IUnitOfWork UoW { get; }
		int CountReferenceItems { get; }

		void ExecuteSql(String sql, uint id);
		void AddExcuteOperation(string text);
	}
}
