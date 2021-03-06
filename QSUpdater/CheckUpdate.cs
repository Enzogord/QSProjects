﻿using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading;
using Gtk;
using NLog;
using QSMachineConfig;
using QSProjectsLib;
using QSSupportLib;

namespace QSUpdater
{
	[Flags]
	public enum UpdaterFlags
	{
		/// <summary>
		/// Запуск с параметрами по умолчанию.
		/// </summary>
		None = 0,
		/// <summary>
		/// Показать диалог вне зависимости от результата проверки.
		/// </summary>
		ShowAnyway = 1,
		/// <summary>
		/// Запустить диалог в фоновом потоке.
		/// </summary>
		StartInThread = 2,
		/// <summary>
		/// Не продолжать работу без обновления.
		/// </summary>
		UpdateRequired = 4
	}

	public class FlagsHelper
	{
		public static bool IsSet<T> (T flags, T flag) where T: struct
		{
			return (((int)(object)flags & (int)(object)flag) != 0);
		}
	}

	//TODO: Add serial number into updater and into application
	public class CheckUpdate
	{
		static Logger logger = LogManager.GetCurrentClassLogger ();
		static UpdateResult updateResult;
		static Window updateWindow = new Window ("Подождите...");

		static public void StartCheckUpdateThread (UpdaterFlags flags)
		{
			if (FlagsHelper.IsSet (flags, UpdaterFlags.StartInThread)) {
				Thread loadThread = new Thread (() => ThreadWorks (flags));
				loadThread.Start ();
				if (FlagsHelper.IsSet (flags, UpdaterFlags.UpdateRequired))
					loadThread.Join ();
			} else
				ThreadWorks (flags);
		}

		static void ThreadWorks (UpdaterFlags flags)
		{
			string checkVersion = String.Empty, checkResult = String.Empty;
			bool showAnyway = FlagsHelper.IsSet (flags, UpdaterFlags.ShowAnyway);
			bool updateRequired = FlagsHelper.IsSet (flags, UpdaterFlags.UpdateRequired);
			bool isMainThread = !FlagsHelper.IsSet (flags, UpdaterFlags.StartInThread);
			Uri address = new Uri ("http://saas.qsolution.ru:2048/Updater");

			try {
				logger.Info ("Получаем данные от сервера");
				string parameters = String.Format ("product.{0};edition.{1};serial.{2};major.{3};minor.{4};build.{5};revision.{6}",
					                    MainSupport.ProjectVerion.Product,
				                                   MainSupport.ProjectVerion.Edition,
												   MainSupport.BaseParameters.SerialNumber,
				                                   MainSupport.ProjectVerion.Version.Major, 
				                                   MainSupport.ProjectVerion.Version.Minor, 
				                                   MainSupport.ProjectVerion.Version.Build, 
				                                   MainSupport.ProjectVerion.Version.Revision); 
				IUpdateService service = new WebChannelFactory<IUpdateService> (new WebHttpBinding { AllowCookies = true }, address)
					.CreateChannel ();
				updateResult = service.checkForUpdate (parameters);
				if (MachineConfig.ConfigSource.Configs ["Updater"] != null) {
					checkVersion = MachineConfig.ConfigSource.Configs ["Updater"].Get ("NewVersion", String.Empty);
					checkResult = MachineConfig.ConfigSource.Configs ["Updater"].Get ("Check", String.Empty);
				}
				if (showAnyway || (updateResult.HasUpdate &&
				    (checkResult == "True" || checkResult == String.Empty || checkVersion != updateResult.NewVersion))) { 
					if (isMainThread)
						ShowDialog (updateRequired);
					else
						Application.Invoke (delegate {
							ShowDialog (updateRequired);
						});
				}
			} catch (Exception ex) {
				logger.Error (ex, "Ошибка доступа к серверу обновления.");
				if (showAnyway)
					ShowErrorDialog ("Не удалось подключиться к серверу обновлений.\nПожалуйста, повторите попытку позже.");
				if (updateRequired)
					Environment.Exit (1);
			}
		}

		static void ShowDialog (bool updateRequired)
		{
			string message = String.Empty;
			string tempPath = Path.Combine (Path.GetTempPath (), 
				                  String.Format (@"QSInstaller-{0}.exe", Guid.NewGuid ().ToString ().Substring (0, 8)));
			
			bool loadingComplete = false;
			ProgressBar updateProgress;
			updateProgress = new ProgressBar ();
			updateProgress.Text = "Новая версия скачивается, подождите...";
			VBox vbox = new VBox ();
			vbox.PackStart (updateProgress, true, true, 0);
			WebClient webClient = new WebClient ();
			webClient.DownloadFileCompleted += (sender, e) => Application.Invoke (delegate {
				loadingComplete = true;
				var isMapped = updateWindow.IsMapped;
				updateWindow.Destroy ();
				if (isMapped && e.Error == null && !e.Cancelled) {
					logger.Info ("Скачивание обновления завершено. Запускаем установку...");
					Process File = new Process ();
					File.StartInfo.FileName = tempPath;
					try {
						File.Start ();
						Environment.Exit(0);
					} catch (Exception ex) {
						ShowErrorDialog ("Не удалось запустить скачанный файл.");
						logger.Error (ex, "Не удалось запустить скачанный установщик.");
					}
				} else if (e.Error != null)
					ShowErrorDialog ("Не удалось скачать файл.");
				logger.Error (e.Error, "Не удалось скачать файл обновления.");

			});
			webClient.DownloadProgressChanged += (sender, e) => Application.Invoke (delegate {
				updateProgress.Fraction = e.ProgressPercentage / 100.0;
			});
			updateWindow.SetSizeRequest (300, 25); 
			updateWindow.Resizable = false;
			updateWindow.SetPosition (WindowPosition.Center);
			if (updateRequired)
				updateWindow.DeleteEvent += delegate {
					Environment.Exit (0);
				};
			updateWindow.Add (vbox); 

			if (updateResult.HasUpdate && !updateRequired)
				message = String.Format ("<b>Доступна новая версия программы!</b>\n" +
				"Доступная версия: {0} (У вас установлена версия {1})\n" +
				"Вы хотите скачать и установить новую версию?\n\n" +
				(updateResult.UpdateDescription != String.Empty ? "<b>Информация об обновлении:</b>\n{2}" : "{2}"), 
				                         StringWorks.VersionToShortString (updateResult.NewVersion),
				                         StringWorks.VersionToShortString (MainSupport.ProjectVerion.Version),
				                         updateResult.UpdateDescription);
			else if (updateResult.HasUpdate && updateRequired)
				message = String.Format ("<b>Доступна новая версия программы!</b>\n" +
				"Доступная версия: {0} (У вас установлена версия {1})\n" +
				"<b>Для продолжения работы вам необходимо установить данное обновление.</b>\n\n" +
				(updateResult.UpdateDescription != String.Empty ? "<b>Информация об обновлении:</b>\n{2}" : "{2}"), 
				                         StringWorks.VersionToShortString (updateResult.NewVersion),
				                         StringWorks.VersionToShortString (MainSupport.ProjectVerion.Version),
				                         updateResult.UpdateDescription);
			else if (!updateResult.HasUpdate && !updateRequired)
				message = String.Format ("<b>Ваша версия программного продукта: {0}</b>\n\n" +
				"На данный момент это самая последняя версия.\n" +
				                         "Обновление не требуется.", 
				                         StringWorks.VersionToShortString ( MainSupport.ProjectVerion.Version));
			else if (!updateResult.HasUpdate && updateRequired) {
				ShowErrorDialog ("Необходимое обновление программы не найдено.\n" + CheckBaseVersion.TextMessage);
				Environment.Exit (1);
			}

			try {
				UpdaterDialog updaterDialog = new UpdaterDialog (message, updateResult, updateRequired);
				ResponseType result = (ResponseType)updaterDialog.Run ();
				updaterDialog.Destroy ();

				if (result == ResponseType.Ok) {
					updateWindow.ShowAll ();
					logger.Info ("Скачивание обновления началось.");
					logger.Debug ("Скачиваем из {0} в {1}", updateResult.FileLink, tempPath);

					webClient.DownloadFileAsync (new Uri (updateResult.FileLink), tempPath);
					// Ждем окончания загрузки файла не возвращая управление, иначе в процессе скачивания продолжется работа, а это не надо во всех случаях
					while (!loadingComplete)
					{
						if( Gtk.Application.EventsPending ())
							Gtk.Application.RunIteration ();
						else
							Thread.Sleep(50);
					}
				} else if (updateRequired) {
					Environment.Exit (0);
				} else if (updateResult.HasUpdate)
					ConfigFileUpdater (result == ResponseType.Cancel || result == ResponseType.DeleteEvent);
			} catch (Exception ex) {
				logger.Error (ex, "Ошибка доступа к серверу обновления.");
				ShowErrorDialog ("Извините, сервер обновления не работает.");
			}
		}

		static void ShowErrorDialog (string description)
		{
			Window win = new Window ("Ошибка");
			MessageDialog md = new MessageDialog (win, DialogFlags.DestroyWithParent,
				                   MessageType.Error, 
				                   ButtonsType.Ok,
				                   description);
			md.Show ();
			md.Run ();
			md.Destroy ();
		}

		static void ConfigFileUpdater (bool check)
		{
			if (MachineConfig.ConfigSource.Configs ["Updater"] == null)
				MachineConfig.ConfigSource.AddConfig ("Updater");
			MachineConfig.ConfigSource.Configs ["Updater"].Set ("Check", check);
			MachineConfig.ConfigSource.Configs ["Updater"].Set ("NewVersion", updateResult.NewVersion);
			MachineConfig.ConfigSource.Save ();
		}
	}
}