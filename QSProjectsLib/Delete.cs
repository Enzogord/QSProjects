using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using QSProjectsLib;

namespace QSProjectsLib
{
	public partial class Delete : Gtk.Dialog
	{
		public static Dictionary<string,TableInfo> Tables;

		bool ErrorHappens = false;
		string ErrorString;
		
		TreeStore ObjectsTreeStore;

		public Delete ()
		{
			this.Build ();

			ObjectsTreeStore = new TreeStore(typeof(string), typeof(string));
			treeviewObjects.AppendColumn("Объект", new Gtk.CellRendererText (), "text", 0);

			treeviewObjects.Model = ObjectsTreeStore;
			treeviewObjects.ShowAll ();
		}
		
		public bool RunDeletion(string table, int IntKey, string StrKey)
		{
			int CountReferenceItems = 0;
			bool result = false;
			TableInfo.Params OutParam = new TableInfo.Params(IntKey,StrKey);
			try
			{
				CountReferenceItems = FillObjects (table, new TreeIter(), OutParam);
			}
			catch (Exception ex)
			{
				ErrorHappens = true;
				ErrorString = ex.ToString ();
			}
			if(ErrorHappens)
			{
				MessageDialog md = new MessageDialog (this, DialogFlags.DestroyWithParent,
				                                      MessageType.Error, 
				                                      ButtonsType.Close,
				                                      "ошибка");
				md.UseMarkup = false;
				md.Text = "При выполении поиска зависимостей удаляемого объекта произошла ошибка. Убедитесь что версия базы данных соответствует версии программы. Если версия базы данных правильная, сообщите разработчику об ошибке в программе.\n" + ErrorString;
				md.Run ();
				md.Destroy();
				return false;
			}
			if(CountReferenceItems > 0)
			{
				if(CountReferenceItems < 10)
					treeviewObjects.ExpandAll ();
				this.Title = String.Format("Удалить {0}?", Tables[table].ObjectName);
				result = (ResponseType)this.Run () == ResponseType.Yes;
			}
			else
			{
				this.Hide();
				result = SimpleDialog(Tables[table].ObjectName) == ResponseType.Yes;
			}
			if(result)
				DeleteObjects (table,OutParam);
			return result;
		}

		public bool RunDeletion(string table, int IntKey)
		{
			return RunDeletion (table, IntKey, "");
		}

		public bool RunDeletion(string table, string StrKey)
		{
			return RunDeletion (table, 0, StrKey);
		}

		ResponseType SimpleDialog(string ObjectName)
		{
			MessageDialog md = new MessageDialog (this, DialogFlags.DestroyWithParent,
	                              MessageType.Question, 
                                  ButtonsType.YesNo,"Вы уверены что хотите удалить "+ ObjectName + "?");
			ResponseType result = (ResponseType)md.Run ();
			md.Destroy();
			return result;
		}

		int FillObjects(string Table, TreeIter root, TableInfo.Params ParametersIn)
		{
			TreeIter DeleteIter, ClearIter, GroupIter, ItemIter;
			int Totalcount = 0;
			int DelCount = 0;
			int ClearCount = 0;
			int GroupCount;
			MySqlCommand cmd;
			MySqlDataReader rdr;

			if(!Tables.ContainsKey(Table))
			{
				ErrorString = "Нет описания для таблицы " + Table;
				Console.WriteLine(ErrorString);
				QSMain.OnNewStatusText(ErrorString);
				ErrorHappens = true;
				return 0;
			}
			if(Tables[Table].DeleteItems.Count > 0)
			{
				if(!ObjectsTreeStore.IterIsValid(root))
					DeleteIter = ObjectsTreeStore.AppendNode();
				else
					DeleteIter = ObjectsTreeStore.AppendNode (root);
				foreach(KeyValuePair<string, TableInfo.DeleteDependenceItem> pair in Tables[Table].DeleteItems)
				{
					GroupCount = 0;
					string sql = Tables[pair.Key].SqlSelect + pair.Value.sqlwhere;
					cmd = new MySqlCommand(sql, QSMain.connectionDB);
					if(pair.Value.SqlParam.ParamStr != "")
						cmd.Parameters.AddWithValue(pair.Value.SqlParam.ParamStr, ParametersIn.ParamStr);
					if(pair.Value.SqlParam.ParamInt != "")
						cmd.Parameters.AddWithValue (pair.Value.SqlParam.ParamInt, ParametersIn.ParamInt);
					rdr = cmd.ExecuteReader();
					if(!rdr.HasRows)
					{
						rdr.Close ();
						continue;
					}
					GroupIter = ObjectsTreeStore.AppendNode(DeleteIter);
					int IndexIntParam = 0;
					int IndexStrParam = 0;
					if(Tables[pair.Key].PrimaryKey.ParamInt != "")
						IndexIntParam = rdr.GetOrdinal(Tables[pair.Key].PrimaryKey.ParamInt);
					if(Tables[pair.Key].PrimaryKey.ParamStr != "")
						IndexStrParam = rdr.GetOrdinal(Tables[pair.Key].PrimaryKey.ParamStr);
					List<object[]> ReadedDate = new List<object[]>();
					while(rdr.Read())
					{
						object[] Fields = new object[rdr.FieldCount];
						rdr.GetValues(Fields);
						ReadedDate.Add(Fields);
					}
					rdr.Close ();

					foreach(object[] row in ReadedDate)
					{
						ItemIter = ObjectsTreeStore.AppendValues(GroupIter, String.Format(Tables[pair.Key].DisplayString, row));
						if(Tables[pair.Key].DeleteItems.Count > 0 || Tables[pair.Key].ClearItems.Count > 0)
						{
							TableInfo.Params OutParam = new TableInfo.Params();
							if(Tables[pair.Key].PrimaryKey.ParamInt != "")
								OutParam.ParamInt = Convert.ToInt32(row[IndexIntParam]);
							if(Tables[pair.Key].PrimaryKey.ParamStr != "")
								OutParam.ParamStr = row[IndexStrParam].ToString();
							Totalcount += FillObjects (pair.Key,ItemIter,OutParam);
						}
						GroupCount++;
						Totalcount++;
						DelCount++;
					}
					ObjectsTreeStore.SetValues(GroupIter, Tables[pair.Key].ObjectsName + "(" + GroupCount.ToString() + ")");
				}
				if(DelCount > 0)
					ObjectsTreeStore.SetValues(DeleteIter, String.Format ("Будет удалено ({0}/{1}) объектов:",DelCount,Totalcount));
				else
					ObjectsTreeStore.Remove (ref DeleteIter);
			}

			if(Tables[Table].ClearItems.Count > 0)
			{
				if(!ObjectsTreeStore.IterIsValid(root))
					ClearIter = ObjectsTreeStore.AppendNode();
				else
					ClearIter = ObjectsTreeStore.AppendNode (root);
				foreach(KeyValuePair<string, TableInfo.ClearDependenceItem> pair in Tables[Table].ClearItems)
				{
					GroupCount = 0;
					string sql = Tables[pair.Key].SqlSelect + pair.Value.sqlwhere;
					cmd = new MySqlCommand(sql, QSMain.connectionDB);
					if(pair.Value.SqlParam.ParamStr != "")
						cmd.Parameters.AddWithValue(pair.Value.SqlParam.ParamStr, ParametersIn.ParamStr);
					if(pair.Value.SqlParam.ParamInt != "")
						cmd.Parameters.AddWithValue (pair.Value.SqlParam.ParamInt, ParametersIn.ParamInt);
					rdr = cmd.ExecuteReader();
					if(!rdr.HasRows)
					{
						rdr.Close ();
						continue;
					}
					GroupIter = ObjectsTreeStore.AppendNode(ClearIter);
					
					while(rdr.Read())
					{
						object[] Fields = new object[rdr.FieldCount];
						rdr.GetValues(Fields);
						ItemIter = ObjectsTreeStore.AppendValues(GroupIter, String.Format(Tables[pair.Key].DisplayString,Fields));
						GroupCount++;
						Totalcount++;
						ClearCount++;
					}
					ObjectsTreeStore.SetValues(GroupIter, Tables[pair.Key].ObjectsName + "(" + GroupCount.ToString() + ")");
					rdr.Close ();
				}
				if(ClearCount > 0)
					ObjectsTreeStore.SetValues(ClearIter, String.Format ("Будет очищено ссылок у {0} объектов:",ClearCount));
				else
					ObjectsTreeStore.Remove (ref ClearIter);
			}
			return Totalcount;
		}

		private void DeleteObjects(string Table, TableInfo.Params ParametersIn)
		{
			MySqlCommand cmd;
			MySqlDataReader rdr;
			string sql;
			if(!Tables.ContainsKey(Table))
			{
				ErrorString = "Нет описания для таблицы " + Table;
				Console.WriteLine(ErrorString);
				QSMain.OnNewStatusText(ErrorString);
				ErrorHappens = true;
				return;
			}
			if(Tables[Table].DeleteItems.Count > 0)
			{
				foreach(KeyValuePair<string, TableInfo.DeleteDependenceItem> pair in Tables[Table].DeleteItems)
				{
					if(Tables[pair.Key].DeleteItems.Count > 0 || Tables[pair.Key].ClearItems.Count > 0)
					{
						sql = "SELECT * FROM " +pair.Key + " " + pair.Value.sqlwhere;
						cmd = new MySqlCommand(sql, QSMain.connectionDB);
						if(pair.Value.SqlParam.ParamStr != "")
							cmd.Parameters.AddWithValue(pair.Value.SqlParam.ParamStr, ParametersIn.ParamStr);
						if(pair.Value.SqlParam.ParamInt != "")
							cmd.Parameters.AddWithValue (pair.Value.SqlParam.ParamInt, ParametersIn.ParamInt);
						rdr = cmd.ExecuteReader();
						List<TableInfo.Params> ReadedDate = new List<TableInfo.Params>();
						string IntFieldName = Tables[pair.Key].PrimaryKey.ParamInt;
						string StrFieldName = Tables[pair.Key].PrimaryKey.ParamStr;
						while(rdr.Read())
						{
							TableInfo.Params OutParam = new TableInfo.Params();
							if(IntFieldName != "")
								OutParam.ParamInt = rdr.GetInt32(IntFieldName);
							if(StrFieldName != "")
								OutParam.ParamStr = rdr.GetString(StrFieldName);
							ReadedDate.Add(OutParam);
						}
						rdr.Close ();

						foreach(TableInfo.Params row in ReadedDate)
						{
							DeleteObjects (pair.Key, row);
						}
					}

					sql = "DELETE FROM " + pair.Key + " " + pair.Value.sqlwhere;
					cmd = new MySqlCommand(sql, QSMain.connectionDB);
					if(pair.Value.SqlParam.ParamStr != "")
						cmd.Parameters.AddWithValue(pair.Value.SqlParam.ParamStr, ParametersIn.ParamStr);
					if(pair.Value.SqlParam.ParamInt != "")
						cmd.Parameters.AddWithValue (pair.Value.SqlParam.ParamInt, ParametersIn.ParamInt);
					cmd.ExecuteNonQuery();
				}
			}
			
			if(Tables[Table].ClearItems.Count > 0)
			{
				foreach(KeyValuePair<string, TableInfo.ClearDependenceItem> pair in Tables[Table].ClearItems)
				{
					sql = "UPDATE " + pair.Key + " SET "; 
					bool first = true;
					foreach (string FieldName in pair.Value.ClearFields)
					{
						if(!first)
							sql += ", ";
						sql += FieldName + " = NULL ";
						first = false;
					}
					sql += pair.Value.sqlwhere;
					cmd = new MySqlCommand(sql, QSMain.connectionDB);
					if(pair.Value.SqlParam.ParamStr != "")
						cmd.Parameters.AddWithValue(pair.Value.SqlParam.ParamStr, ParametersIn.ParamStr);
					if(pair.Value.SqlParam.ParamInt != "")
						cmd.Parameters.AddWithValue (pair.Value.SqlParam.ParamInt, ParametersIn.ParamInt);
					cmd.ExecuteNonQuery ();
				}
			}

			sql = "DELETE FROM " + Table + " WHERE ";
			bool FirstKey = true;
			if(Tables[Table].PrimaryKey.ParamInt != "")
			{
				sql += Tables[Table].PrimaryKey.ParamInt + " = @IntParam ";
				FirstKey = false;
			}
			if(Tables[Table].PrimaryKey.ParamStr != "")
			{
				if(!FirstKey)
					sql += "AND ";
				sql += Tables[Table].PrimaryKey.ParamStr + " = @StrParam ";
				FirstKey = false;
			}
			cmd = new MySqlCommand(sql, QSMain.connectionDB);
			if(Tables[Table].PrimaryKey.ParamStr != "")
				cmd.Parameters.AddWithValue("@StrParam", ParametersIn.ParamStr);
			if(Tables[Table].PrimaryKey.ParamInt != "")
				cmd.Parameters.AddWithValue("@IntParam", ParametersIn.ParamInt);
			cmd.ExecuteNonQuery();
		}
	}
}

