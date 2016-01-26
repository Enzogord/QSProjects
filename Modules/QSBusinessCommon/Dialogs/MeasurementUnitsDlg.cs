﻿using System;
using QSBusinessCommon.Domain;
using QSOrmProject;
using QSValidation;

namespace QSBusinessCommon
{
	public partial class MeasurementUnitsDlg : OrmGtkDialogBase<MeasurementUnits>
	{
		private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger ();

		public MeasurementUnitsDlg ()
		{
			this.Build ();
			UoWGeneric = UnitOfWorkFactory.CreateWithNewRoot<MeasurementUnits>();
			ConfigureDlg ();
		}

		public MeasurementUnitsDlg (int id)
		{
			this.Build ();
			UoWGeneric = UnitOfWorkFactory.CreateForRoot<MeasurementUnits> (id);
			ConfigureDlg ();
		}

		public MeasurementUnitsDlg (MeasurementUnits sub): this(sub.Id) {}


		private void ConfigureDlg ()
		{
			entryName.Binding.AddBinding (Entity, e => e.Name, w => w.Text).InitializeFromSource ();
			dataentryOKEI.Binding.AddBinding (Entity, e => e.OKEI, w => w.Text).InitializeFromSource ();
			spinDigits.Binding.AddBinding (Entity, e => e.Digits, w => w.ValueAsInt).InitializeFromSource ();
		}

		public override bool Save ()
		{
			var valid = new QSValidator<MeasurementUnits> (UoWGeneric.Root);
			if (valid.RunDlgIfNotValid ((Gtk.Window)this.Toplevel))
				return false;

			logger.Info ("Сохраняем единицы измерения...");
			UoWGeneric.Save();
			return true;
		}

	}
}
