﻿using System;
using Gtk;
using NHibernate;
using NHibernate.Proxy;
using QSTDI;
using NLog;
using System.ComponentModel;

namespace QSOrmProject
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class EntryReference : Gtk.Bin
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		private bool sensitive = true;
		public bool CanEditReference = true;
		private System.Type subjectType;
		public event EventHandler Changed;

		//TODO Реализовать удаление
		//TODO Реализовать удобный выбор через подбор

		[Browsable (false)]
		public new bool Sensitive
		{
			get {
				return sensitive;
			}
			set {
				if (sensitive == value)
					return;
				sensitive = value;
				buttonEdit.Sensitive = entryObject.Sensitive = sensitive;
				buttonOpen.Sensitive = sensitive && CanEditReference && subject != null;
			}
		}

		private object subject;
		public object Subject
		{
			get
			{
				return subject;
			}
			set
			{
				if (subject == value)
					return;
				subject = value;
				UpdateWidget();
				OnChanged();
			}
		}

		public System.Type SubjectType
		{
			get
			{
				return subjectType;
			}
			set
			{
				if(subjectType != null)
				{
					OrmObjectMaping map = OrmMain.GetObjectDiscription(subjectType);
					map.ObjectUpdated -= OnExternalObjectUpdated;
				}
				subjectType = value;
				if(subjectType != null)
				{
					OrmObjectMaping map = OrmMain.GetObjectDiscription(subjectType);
					map.ObjectUpdated += OnExternalObjectUpdated;;
				}
			}
		}

		private void OnExternalObjectUpdated (object sender, OrmObjectUpdatedEventArgs e)
		{
			if(e.Subject.Equals(Subject))
			{
				IOrmDialog dlg = OrmMain.FindMyDialog(this);
				if (dlg != null)
					dlg.Session.Refresh(Subject);

				UpdateWidget();
				OnChanged();
			}
		}

		private void UpdateWidget()
		{
			buttonOpen.Sensitive = CanEditReference && subject != null;
			if(subject == null || displayFields == null)
			{
				entryObject.Text = String.Empty;
				return;
			}

			object[] values = new object[displayFields.Length];
			for(int i = 0; i < displayFields.Length; i++)
			{
				values[i] = subjectType.GetProperty(displayFields[i]).GetValue(Subject, null);
			}
			entryObject.Text = String.Format(DisplayFormatString, values);
		}

		private string[] displayFields;
		public string[] DisplayFields
		{
			get
			{
				return displayFields;
			}
			set
			{
				displayFields = value;
			}
		}

		private string displayFormatString;
		public string DisplayFormatString
		{
			get
			{
				return (displayFormatString == null || displayFormatString == String.Empty) 
					? "{0}" : displayFormatString;
			}
			set
			{
				displayFormatString = value;
			}
		}

		public EntryReference()
		{
			this.Build();
		}

		protected void OnButtonEditClicked(object sender, EventArgs e)
		{
			ITdiTab mytab = TdiHelper.FindMyTab(this);
			if (mytab == null)
			{
				logger.Warn("Родительская вкладка не найдена.");
				return;
			}
				
			IOrmDialog dlg = OrmMain.FindMyDialog(this);
			ISession session;
			if (dlg != null)
				session = dlg.Session;
			else
				session = OrmMain.Sessions.OpenSession();

			var criteria = session.CreateCriteria(subjectType);

			OrmReference SelectDialog = new OrmReference(subjectType, session, criteria);
			SelectDialog.Mode = OrmReferenceMode.Select;
			SelectDialog.CanEdit = CanEditReference;
			SelectDialog.ObjectSelected += OnSelectDialogObjectSelected;
			mytab.TabParent.AddSlaveTab(mytab, SelectDialog);
		}

		void OnSelectDialogObjectSelected (object sender, OrmReferenceObjectSectedEventArgs e)
		{
			Subject = e.Subject;
		}

		protected void OnButtonOpenClicked(object sender, EventArgs e)
		{
			if(OrmMain.GetObjectDiscription(SubjectType).SimpleDialog)
			{
				OrmSimpleDialog.RunSimpleDialog(this.Toplevel as Window, SubjectType, Subject);
				return;
			}

			ITdiTab mytab = TdiHelper.FindMyTab(this);
			if (mytab == null)
			{
				logger.Warn("Родительская вкладка не найдена.");
				return;
			}

			ITdiTab dlg = mytab.TabParent.OnCreateDialogWidget(new TdiOpenObjDialogEventArgs(Subject));
			mytab.TabParent.AddTab(dlg, mytab);
		}

		protected virtual void OnChanged()
		{
			if (Changed != null)
				Changed(this, EventArgs.Empty);
		}
	}
}

