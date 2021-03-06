using System;
using System.Collections.Generic;
using System.Data.Common;
using NLog;

namespace QSSupportLib
{
	public class BaseParam
	{
		private static Logger logger = LogManager.GetCurrentClassLogger ();

		public string Product {
			get{ return All.ContainsKey ("product_name") ? All ["product_name"] : null; }
		}

		public string Version {
			get{ return All.ContainsKey ("version") ? All ["version"] : null; }
		}

		public string Edition {
			get{ return All.ContainsKey ("edition") ? All ["edition"] : null; }
		}

		public string SerialNumber {
			get{ return All.ContainsKey ("serial_number") ? All ["serial_number"] : null; }
		}

		public Dictionary<string, string> All;

		public BaseParam (DbConnection con)
		{
			All = new Dictionary<string, string> ();
			string sql = "SELECT * FROM base_parameters";
			DbCommand cmd = con.CreateCommand ();
			cmd.CommandText = sql;
			using (DbDataReader rdr = cmd.ExecuteReader ()) {
				while (rdr.Read ()) {
					All.Add (rdr ["name"].ToString (), rdr ["str_value"].ToString ());
				}
			}
		}

		public void UpdateParameter (DbConnection con, string name, string value)
		{
			string sql;
			if (All.ContainsKey (name))
			{
				if(All[name] == value)
					return;

				sql = "UPDATE base_parameters SET str_value = @str_value WHERE name = @name";
			}
			else
				sql = "INSERT INTO base_parameters (name, str_value) VALUES (@name, @str_value)";

			logger.Debug ("Изменяем параметр базы {0}={1}", name, value);
			try {
				DbCommand cmd = con.CreateCommand ();
				cmd.CommandText = sql;
				DbParameter paramName = cmd.CreateParameter ();
				paramName.ParameterName = "@name";
				paramName.Value = name;
				cmd.Parameters.Add (paramName);
				DbParameter paramValue = cmd.CreateParameter ();
				paramValue.ParameterName = "@str_value";
				paramValue.Value = value;
				cmd.Parameters.Add (paramValue);
				cmd.ExecuteNonQuery ();

				if (All.ContainsKey (name))
					All [name] = value;
				else
					All.Add (name, value);

				logger.Debug ("Ок");
			} catch (Exception ex) {
				logger.Error (ex, "Ошибка изменения параметра");
				throw ex;
			}

		}

		public void RemoveParameter (DbConnection con, string name)
		{
			string sql;
			logger.Debug ("Удаляем параметр базы {0}", name);
			if (All.ContainsKey (name))
				sql = "DELETE FROM base_parameters WHERE name = @name";
			else
				throw new ArgumentException ("Нет указанного параметра базы", name);
			try {
				DbCommand cmd = con.CreateCommand ();
				cmd.CommandText = sql;
				DbParameter paramName = cmd.CreateParameter ();
				paramName.ParameterName = "@name";
				paramName.Value = name;
				cmd.Parameters.Add (paramName);
				cmd.ExecuteNonQuery ();

				All.Remove (name);
				logger.Debug ("Ок");
			} catch (Exception ex) {
				logger.Error (ex, "Ошибка удаления параметра");
				throw ex;
			}

		}
	}
}