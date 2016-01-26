﻿using System;
using System.ComponentModel.DataAnnotations;
using QSOrmProject;
using QSOrmProject.DomainMapping;

namespace QSBusinessCommon.Domain
{
	[OrmSubject (Gender = QSProjectsLib.GrammaticalGender.Feminine,
		NominativePlural = "единицы измерения",
		Nominative = "единица измерения")]
	public class MeasurementUnits : PropertyChangedBase, IDomainObject
	{
		#region Свойства

		public virtual int Id { get; set; }

		string name;

		[Required (ErrorMessage = "Название должно быть заполнено.")]
		[StringLength (10)]
		[Display (Name = "Название")]
		public virtual string Name {
			get { return name; }
			set { SetField (ref name, value, () => Name); }
		}

		short digits;

		[Display (Name = "Знаков после запятой")]
		public virtual short Digits {
			get { return digits; }
			set { SetField (ref digits, value, () => Digits); }
		}

		string okei;
			
		[StringLength (3)]
		[Display (Name = "Код ОКЕИ")]
		public virtual string OKEI {
			get { return okei; }
			set { SetField (ref okei, value, () => OKEI); }
		}

		#endregion

		#region additions

		public virtual string MakeAmountShortStr(int amount)
		{
			return String.Format ("{0} {1}", amount, Name);
		}

		#endregion

		public MeasurementUnits ()
		{
			Name = String.Empty;
		}

		public static IOrmObjectMapping GetOrmMapping()
		{
			return OrmObjectMapping<MeasurementUnits>.Create ().Dialog<MeasurementUnitsDlg> ().DefaultTableView ()
				.Column("ОКЕИ", i => i.OKEI)
				.SearchColumn ("Наименование", i => i.Name)
				.Column("Точность", i => i.Digits).End ();
		}
	}
}
