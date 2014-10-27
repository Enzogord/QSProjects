﻿using System;
using QSOrmProject;

namespace QSBanks
{
	[OrmSubjectAttibutes("Банки")]
	public class Bank
	{
		#region Свойства
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual string Bik { get; set; }
		public virtual string CorAccount { get; set; }
		public virtual string City { get; set; }
		public virtual string Region { get; set; }
		#endregion

		public Bank()
		{
			Name = String.Empty;
			Bik = String.Empty;
			CorAccount = String.Empty;
			City = String.Empty;
			Region = String.Empty;
		}

		public override bool Equals(Object obj)
		{
			Bank accountObj = obj as Bank; 
			if (accountObj == null)
				return false;
			else
				return Id.Equals(accountObj.Id);
		}

		public override int GetHashCode()
		{
			return this.Id.GetHashCode(); 
		}

	}
}
