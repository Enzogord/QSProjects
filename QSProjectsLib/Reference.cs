using System;
using System.Collections.Generic;
using Gtk;
using System.Data.Common;
using NLog;

namespace QSProjectsLib
{
	public partial class Reference : Gtk.Dialog
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();
		public static event EventHandler<RunReferenceItemDlgEventArgs> RunReferenceItemDlg;

		bool SimpleMode, SelectMode, CanNew, CanEdit, CanDel;
		string TableRef, nameNode, nameRef;
		public int SelectedID;
		public string SelectedName;
		public object[] SelectedRow;
		public string SqlSelect;
		public List<ColumnInfo> Columns;
		public int NameColumn = 1;
		public int ParentId = -1;
		public string ParentFieldName = "";
		bool NewNode;
		bool RefChanged = false;
		bool DescriptionField = false;
		private int OrdinalColumn;
		
		Gtk.ListStore RefListStore;
		Gtk.TreeModelFilter filter;
		
		Dialog editNode;
		Entry inputNameEntry, inputDiscriptionEntry;
		Label LableName, LableDescription;

		#region Свойства

		/// <summary>
		/// Устанавливаем максимальную длинну имени объекта для простого диалога редактирования.
		/// </summary>
		public int? NameMaxLength { get; set; }

		/// <summary>
		/// Устанавливаем максимальную длинну описания объекта для простого диалога редактирования.
		/// </summary>
		public int? DiscriptionMaxLength { get; set; }

  		#endregion

		public Reference ( bool WithDiscription = false, string orderBy = null)
		{
			this.Build ();
			this.Destroyed += OnDestroyed;

			DescriptionField = WithDiscription;

			Columns = new List<ColumnInfo>();
			Columns.Add( new ColumnInfo("Код", "{0}", false));
			Columns.Add( new ColumnInfo("Название", "{1}"));
			if(WithDiscription)
			{
				SqlSelect = "SELECT id, name, description FROM @tablename ";
				Columns.Add( new ColumnInfo("Описание", "{2}"));
			}
			else
			{
				SqlSelect = "SELECT id, name FROM @tablename ";
			}

			if(!String.IsNullOrWhiteSpace(orderBy))
			{
				SqlSelect += string.Format ("ORDER BY {0} ", orderBy);
			}

			eventboxOrdinalInfo.ModifyBg(StateType.Normal, new Gdk.Color(237, 200, 119));
		}

		// Событие запуска окна справочника
		public class RunReferenceItemDlgEventArgs : EventArgs
		{
			public string TableName { get; set; }
			public int ItemId { get; set; }
			public int ParentId { get; set; }
			public bool NewItem { get; set; }
			public ResponseType Result { get; set; }
		}
		
		internal static ResponseType OnRunReferenceItemDlg(string TableName, bool New, int id, int parentid)
		{
			ResponseType Result = ResponseType.None;
			EventHandler<RunReferenceItemDlgEventArgs> handler = RunReferenceItemDlg;
			if (handler != null)
			{
				RunReferenceItemDlgEventArgs e = new RunReferenceItemDlgEventArgs();
				e.TableName = TableName;
				e.ItemId = id;
				e.NewItem = New;
				e.ParentId = parentid;
				handler(null, e);
				Result = e.Result;
			}
			return Result;
		}

		public bool ReferenceIsChanged
		{
			get{ return RefChanged;}
		}

		private string _OrdinalField = "";
		public string OrdinalField
		{
			get{
				return _OrdinalField;
			}
			set{
				_OrdinalField = value;
				AddOrdinar();
				if(_OrdinalField != "")
				{
					hboxOrdinal.Visible = true;
				}
			}
		}

		public class ColumnInfo
		{
			/// <summary>
			/// Если имя = пустая строка. Колонка не отображается.
			/// </summary>
			public string Name;
			public bool Search;
			public string DisplayFormat;

			public ColumnInfo(string name, string format, bool search = true)
			{
				Name = name;
				DisplayFormat = format;
				Search = search;
			}
		}

		private bool FilterTree (Gtk.TreeModel model, Gtk.TreeIter iter)
		{
			if (entryFilter.Text == "")
				return true;

			string Str;
			for(int i = 0; i < Columns.Count; i++)
			{
				if(Columns[i].Search)
				{
					Str = model.GetValue(iter, i).ToString();
					if (Str.IndexOf (entryFilter.Text, StringComparison.CurrentCultureIgnoreCase) > -1)
						return true;
				}
			}
			return false;
		}
		
		public void FillList(string table, string Nodename, string Refname)
		{
			nameNode = Nodename;
			nameRef = Refname;
			TableRef = table;

			if (RefListStore == null)
				CreateTable();
			
			if(SelectMode)
			{
				this.Title = "Выберите " + nameNode;
			}
			else
			{
				this.Title = nameRef;	
			}
			UpdateList();
		}
		
		protected void UpdateList()
		{
			logger.Info("Получаем таблицу справочника "+ nameRef + "...");
			entryFilter.Text = "";
			QSMain.CheckConnectionAlive();
			try
			{
				string sql = SqlSelect.Replace("@tablename", TableRef);
				DbCommand cmd = QSMain.ConnectionDB.CreateCommand ();
				cmd.CommandText = sql;
				
				using (DbDataReader rdr = cmd.ExecuteReader())
				{
					RefListStore.Clear();
					object[] Values = new object[RefListStore.NColumns];
					while (rdr.Read())
					{
						Values[0] = rdr.GetInt32(0);
						object[] Fields = new object[rdr.FieldCount];
						rdr.GetValues(Fields);
						for(int i = 1; i < Columns.Count; i++)
						{
							Values[i] = String.Format(Columns[i].DisplayFormat, Fields);
						}
						if(_OrdinalField != "")
						{
							Values[OrdinalColumn] = rdr.GetInt32(rdr.GetOrdinal(_OrdinalField));
						}
						RefListStore.AppendValues(Values);
					}
				}
				logger.Info("Ok");
			}
			catch (Exception ex)
			{
				logger.Error(ex, "Ошибка получения таблицы!");
				QSMain.ErrorMessage(this,ex);
			}
			OnTreeviewrefCursorChanged((object)treeviewref,EventArgs.Empty);
			TestOrdinalChanged();
		}
		protected virtual void OnEntryFilterChanged (object sender, System.EventArgs e)
		{
			filter.Refilter ();
			OnTreeviewrefCursorChanged(treeviewref, EventArgs.Empty);
		}
		
		void OnInputEntryChanged (object sender, System.EventArgs e)
		{
			bool CanSave = inputNameEntry.Text != "";
			editNode.SetResponseSensitive(ResponseType.Ok, CanSave);
		}
		
		public void SetMode(bool Simple, bool Select, bool New, bool Edit, bool Del)
		{
			SelectMode = Select;
			SimpleMode = Simple;
			CanNew = New;
			CanEdit = Edit;
			CanDel = Del;
			
			buttonOk.Visible = Select;
			buttonCancel.Visible = Select;
			buttonClose.Visible = !Select;
			addAction1.Sensitive = CanNew;
			editAction1.Sensitive = false;
			removeAction1.Sensitive = false;
		}

		private void CreateTable()
		{
			//Создаем таблицу "Справочника"
			//Первая колонка всегда ID
			int count = _OrdinalField != "" ? Columns.Count + 1 : Columns.Count;
			System.Type[] Types = new System.Type[count];
			Types[0] =	typeof (int); 

			for(int i = 1; i < Columns.Count; i++)
			{
				Types[i] = typeof(string);
			}

			if(_OrdinalField != "")
			{
				OrdinalColumn = count - 1;
				Types[OrdinalColumn] = typeof(int);
			}

			RefListStore = new Gtk.ListStore (Types);

			for(int i = 0; i < Columns.Count; i++)
			{
				if(Columns[i].Name != "")
					treeviewref.AppendColumn (Columns[i].Name , new Gtk.CellRendererText (), "text", i);
			}

			filter = new Gtk.TreeModelFilter (RefListStore, null);
			filter.VisibleFunc = new Gtk.TreeModelFilterVisibleFunc (FilterTree);
			treeviewref.Model = filter;
			treeviewref.ShowAll();
		}
		
		protected virtual void OnAddActionActivated (object sender, System.EventArgs e)
		{
			ResponseType result;
			if(SimpleMode)
			{
				NewNode = true;
				editNode = new Dialog("Новый " + nameNode, this, Gtk.DialogFlags.DestroyWithParent);
				BuildSimpleEditorDialog ();
				editNode.ShowAll();
				result = (ResponseType) editNode.Run ();
				inputNameEntry.Destroy();
				editNode.Destroy ();
			}
			else
			{
				//Вызываем событие в основном приложении для запуска диалога элемента справочника
				result = OnRunReferenceItemDlg (TableRef, true, -1, ParentId);
			}
			
			if (result == ResponseType.Ok)
			{
				UpdateList();
				RefChanged = true;
			}
		}
		
		void on_editnode_response (object obj, ResponseArgs args)
		{
			if(args.ResponseId == ResponseType.Ok)
			{
				logger.Info("Запись " + nameNode + "...");
				string sql, InsertDescriptString, UpdateDescriptString;
				if(DescriptionField)
				{
					if(ParentFieldName == "")
						InsertDescriptString = " (name, description) VALUES (@name, @descript)";
					else
						InsertDescriptString = " (name, description, " + ParentFieldName + ") VALUES (@name, @descript, @parent)";
					UpdateDescriptString = ", description = @descript ";
				}
				else
				{
					if(ParentFieldName == "")
						InsertDescriptString = " (name) VALUES (@name)";
					else
						InsertDescriptString = " (name, " + ParentFieldName + ") VALUES (@name, @parent)";
					UpdateDescriptString = ""; 
				}
				if(NewNode)
				{
					sql = "INSERT INTO " + TableRef + InsertDescriptString;
				}
				else
				{
					sql = "UPDATE " + TableRef + " SET name = @name " + UpdateDescriptString +
						"WHERE id = @id";
				}
				QSMain.CheckConnectionAlive();
				try 
				{
					DbCommand cmd = QSMain.ConnectionDB.CreateCommand ();
					cmd.CommandText = sql;

					DbParameter param = cmd.CreateParameter();
					param.ParameterName = "@id";
					param.Value = SelectedID;
					cmd.Parameters.Add(param);

					param = cmd.CreateParameter();
					param.ParameterName = "@name";
					param.Value = inputNameEntry.Text;
					cmd.Parameters.Add(param);

					if(DescriptionField)
					{
						param = cmd.CreateParameter();
						param.ParameterName = "@descript";
						param.Value = inputDiscriptionEntry.Text;
						cmd.Parameters.Add(param);
					}
					if(ParentFieldName != "")
					{
						param = cmd.CreateParameter();
						param.ParameterName = "@parent";
						param.Value = ParentId;
						cmd.Parameters.Add(param);
					}
					cmd.ExecuteNonQuery();

					if(NewNode && OrdinalField != "")
					{
						cmd = QSMain.ConnectionDB.CreateCommand();
						cmd.CommandText = @"select last_insert_rowid()";
						int ItemId = Convert.ToInt32(cmd.ExecuteScalar());

						cmd = QSMain.ConnectionDB.CreateCommand();
						cmd.CommandText = String.Format("UPDATE {0} SET {1} = @id WHERE id = @id", TableRef, OrdinalField);
						param = cmd.CreateParameter();
						param.ParameterName = "@id";
						param.Value = ItemId;
						cmd.Parameters.Add(param);

						cmd.ExecuteNonQuery();
					}

					logger.Info("Ok");
				} 
				catch (Exception ex) 
				{
					logger.Error(ex, "Ошибка записи {0}!", nameNode);
					QSMain.ErrorMessage(this,ex);
				}
			}
		}

		protected virtual void OnEditActionActivated (object sender, System.EventArgs e)
		{
			ResponseType result;
			TreeIter iter;
			treeviewref.Selection.GetSelected(out iter);
			SelectedID = Convert.ToInt32(filter.GetValue(iter,0));
			string NameOfNode = filter.GetValue(iter,1).ToString();
			string DiscriptionOfNode;
			if(DescriptionField)
				DiscriptionOfNode = filter.GetValue(iter,2).ToString();
			else
				DiscriptionOfNode = "";
			
			if(SimpleMode)
			{
				NewNode = false;
				editNode = new Dialog("Редактирование " + nameNode, this, Gtk.DialogFlags.DestroyWithParent);
				BuildSimpleEditorDialog ();
				inputNameEntry.Text = NameOfNode;
				inputDiscriptionEntry.Text = DiscriptionOfNode;
				editNode.ShowAll();
				result = (ResponseType)editNode.Run ();
				inputNameEntry.Destroy();
				editNode.Destroy ();
			}
			else
			{
				//Вызываем событие в основном приложении для запуска диалога элемента справочника
				result = OnRunReferenceItemDlg (TableRef, false, SelectedID, ParentId);
			}
			
			if(result == ResponseType.Ok)
			{
				UpdateList();
				RefChanged = true;
			}
		}
		
		protected virtual void OnTreeviewrefCursorChanged (object sender, System.EventArgs e)
		{
			bool isSelect = treeviewref.Selection.CountSelectedRows() == 1;
			editAction1.Sensitive = isSelect && CanEdit;
			removeAction1.Sensitive = isSelect && CanDel;
			bool SelectFirst = false, SelectLast = false;
			bool Filtered = entryFilter.Text != "";
			TreeIter iter, SelectIter;
			if (treeviewref.Selection.GetSelected(out SelectIter))
			{
				TreePath SelectPath = RefListStore.GetPath(filter.ConvertIterToChildIter(SelectIter));
				RefListStore.GetIterFirst(out iter);
				SelectFirst = RefListStore.GetPath(iter).Compare(SelectPath) == 0;
				RefListStore.IterNthChild(out iter, RefListStore.IterNChildren() - 1);
				SelectLast = RefListStore.GetPath(iter).Compare(SelectPath) == 0;
			}
			buttonOrdinalUp.Sensitive = isSelect && !Filtered && !SelectFirst;
			buttonOrdinalDown.Sensitive = isSelect && !Filtered && !SelectLast;
			buttonOk.Sensitive = isSelect;
		}
		
		protected virtual void OnButtonOkClicked (object sender, System.EventArgs e)
		{
			TreeIter iter;
			treeviewref.Selection.GetSelected(out iter);
			SelectedID = (int) filter.GetValue(iter,0);
			SelectedName = filter.GetValue(iter, NameColumn).ToString();
			SelectedRow = new object[filter.NColumns];
			for(int i = 0; i < filter.NColumns; i++)
			{
				SelectedRow[i] = filter.GetValue(iter, i);
			}
		}
		
		protected virtual void OnTreeviewrefRowActivated (object o, Gtk.RowActivatedArgs args)
		{
			if(SelectMode)
			{
				buttonOk.Click();
			}
			else
			{
				editAction1.Activate();
			}
		}
		
		protected virtual void OnButtonCleanClicked (object sender, System.EventArgs e)
		{
			entryFilter.Text = "";
		}
		
		protected void OnRemoveActionActivated (object sender, System.EventArgs e)
		{
			TreeIter iter;
			treeviewref.Selection.GetSelected(out iter);
			SelectedID = (int) filter.GetValue(iter, 0);
			bool result;
			if (QSMain.IsOrmDeletionConfigered) {
				result = QSMain.OnOrmDeletion (TableRef, SelectedID);
			} else {
				Delete winDelete = new Delete();
				result = winDelete.RunDeletion (TableRef, SelectedID);
				winDelete.Destroy();
			}

			if(result)
			{
				UpdateList();
				RefChanged = true;
			}
		}
		
		protected void BuildSimpleEditorDialog()
		{
			editNode.Modal = true;
			editNode.AddButton ("Отмена", ResponseType.Cancel);
			editNode.AddButton ("Ok", ResponseType.Ok);
			Gtk.Table editNodeTable = new Table(2,2,false);
			LableName = new Label ("Название:");
			LableName.Justify = Justification.Right;
			LableDescription = new Label ("Описание:");
			LableDescription.Justify = Justification.Right;
			editNodeTable.Attach(LableName,0,1,0,1);
			inputNameEntry = new Entry();
			if (NameMaxLength.HasValue)
				inputNameEntry.MaxLength = NameMaxLength.Value;
			inputNameEntry.WidthRequest = 300;
			editNodeTable.Attach(inputNameEntry,1,2,0,1);
			inputDiscriptionEntry = new Entry();
			editNodeTable.Attach(LableDescription,0,1,1,2);
			editNodeTable.Attach(inputDiscriptionEntry,1,2,1,2);
			if (DiscriptionMaxLength.HasValue)
				inputDiscriptionEntry.MaxLength = DiscriptionMaxLength.Value;
			if(!DescriptionField)
			{
				inputDiscriptionEntry.Sensitive = false;
				LableDescription.Sensitive = false;
			}
			editNode.VBox.Add(editNodeTable);
			editNode.Response += new ResponseHandler (on_editnode_response);
		}
		
		protected void OnDestroyed (object sender, EventArgs e)
		{
			if(RefChanged)
				QSMain.OnReferenceUpdated (TableRef);
		}

		private void AddOrdinar()
		{
			if(_OrdinalField != "")
			{ //Добавляем
				int FromPos = SqlSelect.IndexOf(" FROM ", StringComparison.CurrentCultureIgnoreCase);
				if(!SqlSelect.Substring(0, FromPos).Contains(_OrdinalField))
				{
					SqlSelect = SqlSelect.Insert(FromPos, 
						String.Format(", {0}", _OrdinalField));
				}
			}
		}

		protected void OnButtonOrdinalDownClicked(object sender, EventArgs e)
		{
			TreeIter SelectIter, NextIter;
			treeviewref.Selection.GetSelected(out SelectIter);
			NextIter = SelectIter = filter.ConvertIterToChildIter(SelectIter);
			RefListStore.IterNext(ref NextIter);
			RefListStore.Swap(SelectIter, NextIter);
			OnTreeviewrefCursorChanged(treeviewref, EventArgs.Empty);
			TestOrdinalChanged();
		}

		protected void OnButtonOrdinalUpClicked(object sender, EventArgs e)
		{
			TreeIter SelectIter, BeforeIter;
			treeviewref.Selection.GetSelected(out SelectIter);
			SelectIter = filter.ConvertIterToChildIter(SelectIter);
			TreePath path = RefListStore.GetPath(SelectIter);
			path.Prev();
			RefListStore.GetIter(out BeforeIter, path);
			RefListStore.Swap(SelectIter, BeforeIter);
			OnTreeviewrefCursorChanged(treeviewref, EventArgs.Empty);
			TestOrdinalChanged();
		}

		private void TestOrdinalChanged()
		{
			if (_OrdinalField == "")
				return;
			int OldOrdinal = 0;
			bool Changed = false;
			foreach(object[] row in RefListStore)
			{
				if((int)row[OrdinalColumn] < OldOrdinal)
				{
					Changed = true;
					break;
				}
				OldOrdinal = (int)row[OrdinalColumn];
			}
			eventboxOrdinalInfo.Visible = Changed;
		}

		protected void OnButtonSaveOrdinalClicked(object sender, EventArgs e)
		{
			int[] Numbers = new int[RefListStore.IterNChildren()];
			int n = 0;
			foreach(object[] row in RefListStore)
			{
				Numbers[n] = (int)row[OrdinalColumn];
				n++;
			}
			Array.Sort(Numbers);

			string sql = String.Format("UPDATE {0} SET {1} = @ord WHERE id = @id", TableRef, _OrdinalField);
			DbCommand cmd;
			DbTransaction trans = QSMain.ConnectionDB.BeginTransaction();
			QSMain.CheckConnectionAlive();
			try
			{
				n = 0;
				cmd = QSMain.ConnectionDB.CreateCommand();
				DbParameter paramId = cmd.CreateParameter();
				paramId.ParameterName = "@id";
				cmd.Parameters.Add(paramId);
				DbParameter paramOrd = cmd.CreateParameter();
				paramOrd.ParameterName = "@ord";
				cmd.Parameters.Add(paramOrd);
				cmd.CommandText = sql;
				cmd.Prepare();

				foreach(object[] row in RefListStore)
				{
					if(Numbers[n] != (int) row[OrdinalColumn])
					{
						paramId.Value = row[0];
						paramOrd.Value = Numbers[n];
						cmd.ExecuteNonQuery();
					}
					n++;
				}
				trans.Commit();
				UpdateList();
			}
			catch (Exception ex) 
			{
				trans.Rollback();
				logger.Error(ex, "Ошибка записи последовательности в {0}!", nameRef);
				QSMain.ErrorMessage(this,ex);
			}

		}

	}
}

