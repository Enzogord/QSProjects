﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Gtk;
using QSProjectsLib;
using QSSupportLib;

namespace QSUpdater.DB
{
	public static class DBUpdater
	{
		static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger ();

		internal static readonly List<UpdateHop> microUpdates = new List<UpdateHop>();

		internal static readonly List<UpdateHop> updates = new List<UpdateHop>();

		/// <summary>
		/// Метод добавит скрипт микрообновление.
		/// </summary>
		/// <param name="source">Изначальная версия</param>
		/// <param name="destination">Версия до которой обновится база</param>
		/// <param name="scriptResource">Имя ресурса скрипта, асамблея ресурса будет подставлена та которая вызовет эту функцию.</param>
		public static void AddMicroUpdate( Version source, Version destination, string scriptResource)
		{
			microUpdates.Add(new UpdateHop
				{
					Source = source,
					Destanation = destination,
					Resource = scriptResource,
					Assembly = Assembly.GetCallingAssembly()
				});
		}

		/// <summary>
		/// Метод добавит скрипт добавит обновление.
		/// </summary>
		/// <param name="source">Изначальная версия</param>
		/// <param name="destination">Версия до которой обновится база</param>
		/// <param name="scriptResource">Имя ресурса скрипта, асамблея ресурса будет подставлена та которая вызовет эту функцию.</param>
		public static void AddUpdate( Version source, Version destination, string scriptResource)
		{
			updates.Add(new UpdateHop
				{
					Source = source,
					Destanation = destination,
					Resource = scriptResource,
					Assembly = Assembly.GetCallingAssembly()
				});
		}

		public static void CheckMicroUpdates()
		{
			Version currentDB, beforeUpdates;
			if(MainSupport.BaseParameters.All.ContainsKey("micro_updates"))
				currentDB = beforeUpdates = Version.Parse(MainSupport.BaseParameters.All["micro_updates"]);
			else 
				currentDB = beforeUpdates = Version.Parse(MainSupport.BaseParameters.Version);

			logger.Info("Проверяем микро обновления базы(текущая версия:{0})", StringWorks.VersionToShortString(currentDB));
		
			while(microUpdates.Exists(u => u.Source == currentDB))
			{
                if (!QSMain.User.Admin)
					NotAdminErrorAndExit(true);
                var update = microUpdates.Find(u => u.Source == currentDB);
				logger.Info("Обновляемся до {0}", StringWorks.VersionToShortString(update.Destanation));
				var trans = QSMain.ConnectionDB.BeginTransaction();
				try
				{
					string sql;
					using(Stream stream = update.Assembly.GetManifestResourceStream(update.Resource))
					{
						if(stream == null)
							throw new InvalidOperationException( String.Format("Ресурс {0} указанный в обновлениях не найден.", update.Resource));
						StreamReader reader = new StreamReader(stream);
						sql = reader.ReadToEnd();
					}

					var cmd = QSMain.ConnectionDB.CreateCommand();
					cmd.CommandText = sql;
					cmd.Transaction = trans;
					cmd.ExecuteNonQuery();
					trans.Commit();
					currentDB = update.Destanation;
				}
				catch(Exception ex)
				{
					trans.Rollback();
					QSMain.ErrorMessageWithLog("Ошибка при обновлении базы..", logger, ex);
					return;
				}
			}

			if(currentDB != beforeUpdates)
				MainSupport.BaseParameters.UpdateParameter(
					QSMain.ConnectionDB, 
					"micro_updates",
					StringWorks.VersionToShortString(currentDB)
				);
		}

        private static void NotAdminErrorAndExit(bool isMicro)
        {
            MessageDialog md = new MessageDialog (null, DialogFlags.DestroyWithParent,
                MessageType.Error, 
                ButtonsType.Close,
				String.Format (
					"Для работы текущей версии программы необходимо провести{0} обновление базы, " +
					"но у вас нет для этого прав. Зайдите в программу под администратором.",
					isMicro ? " микро" : ""
				));
            md.Show ();
            md.Run ();
            md.Destroy ();
            Environment.Exit(1);
        }

		public static void TryUpdate()
		{
			logger.Debug (System.Reflection.Assembly.GetCallingAssembly().FullName);
			Version currentDB = Version.Parse(MainSupport.BaseParameters.Version);
			var appVersion = MainSupport.ProjectVerion.Version;
			if (currentDB.Major == appVersion.Major && currentDB.Minor == appVersion.Minor)
				return;

			var update = updates.Find(u => u.Source == currentDB);
			if(update != null)
			{
				if (!QSMain.User.Admin)
					NotAdminErrorAndExit(false);

				var dlg = new DBUpdateProcess (update);
				dlg.Show ();
				dlg.Run ();
				if(!dlg.Success)
					Environment.Exit(1);
				dlg.Destroy ();

				MainSupport.LoadBaseParameters ();
				if (appVersion.Major != update.Destanation.Major && appVersion.Minor != update.Destanation.Minor)
					TryUpdate ();
			}
			else
			{
				logger.Error ("Версия базы не соответствует программе, но обновление не найдено");
			}
		}
	}

	public class UpdateHop
	{
		public Version Source;
		public Version Destanation;

		public String Resource;
		public Assembly Assembly;
	}
}

