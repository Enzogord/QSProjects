﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using NLog;
using QSProjectsLib;
using System.ServiceModel.Syndication;

namespace QSSupportLib
{
	public static class MainNewsFeed
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		public static List<NewsFeed> NewsFeeds;

		public static void LoadReadFeed()
		{
			logger.Info ("Читаем таблицу прочитанных пользователем новостей...");
			string sql = "SHOW TABLES LIKE 'read_news'";
			DbCommand cmd = QSMain.ConnectionDB.CreateCommand();
			cmd.CommandText = sql;
			if(cmd.ExecuteScalar () == null)
			{// Таблица не создана создаем.
				logger.Info ("Таблицы с новостями нет в БД, создаем...");
				cmd.CommandText = "CREATE TABLE `read_news` ( " +
				"`id` INT UNSIGNED NOT NULL AUTO_INCREMENT," +
				"`user_id` INT UNSIGNED NULL," +
				"`feed_id` VARCHAR(64) NOT NULL," +
				"`items` TEXT NULL DEFAULT NULL," +
				"PRIMARY KEY (`id`)," +
				"INDEX `fk_read_news_user_id_idx` (`user_id` ASC)," +
				"CONSTRAINT `fk_read_news_user_id`" +
				"  FOREIGN KEY (`user_id`)" +
				"  REFERENCES `users` (`id`)" +
				"  ON DELETE CASCADE" +
				"  ON UPDATE CASCADE)";
				cmd.ExecuteNonQuery ();
			}

			if (NewsFeeds == null)
				NewsFeeds = new List<NewsFeed> ();

			sql = "SELECT * FROM `read_news` WHERE user_id = @user_id";
			cmd = QSMain.ConnectionDB.CreateCommand();
			cmd.CommandText = sql;

			DbParameter param = cmd.CreateParameter();
			param.ParameterName = "@user_id";
			param.Value = QSMain.User.id;
			cmd.Parameters.Add(param);

			using (DbDataReader rdr = cmd.ExecuteReader())
			{
				while (rdr.Read())
				{
					NewsFeed feed = NewsFeeds.Find (f => f.Id == DBWorks.GetString (rdr, "feed_id", ""));
					if (feed != null) {
						feed.FirstRead = false;
						feed.DataBaseId = DBWorks.GetInt (rdr, "id", -1);
						string[] items = DBWorks.GetString (rdr, "items", "").Split (',');
						feed.ReadItems = new List<string> (items);
					} else
						logger.Warn ("В базе найден feed_id={0}, но в программе он не настроен.", DBWorks.GetString (rdr, "feed_id", ""));
				}
			}
			logger.Info ("Ok");
		}

		public static bool ItemIsRead(SyndicationItem synitem)
		{
			NewsFeed feed = NewsFeeds.Find (f => f.Id == synitem.SourceFeed.Id);
			if (feed.FirstRead) {
				feed.ReadItems.Add (synitem.Id);
				return true;
			}
			return feed.ReadItems.Exists (i => i == synitem.Id);
		}

		public static void SaveFirstRead()
		{
			NewsFeeds.FindAll (f => f.FirstRead).ForEach(delegate(NewsFeed feed) {
				logger.Info ("Сохраняем новый feed({0})...", feed.Title);
				string sql = "INSERT INTO read_news (user_id, feed_id, items) " +
					"VALUES (@user_id, @feed_id, @items)";
				DbCommand cmd = QSMain.ConnectionDB.CreateCommand();
				cmd.CommandText = sql;

				DbParameter param = cmd.CreateParameter();
				param.ParameterName = "@user_id";
				param.Value = QSMain.User.id;
				cmd.Parameters.Add(param);

				param = cmd.CreateParameter();
				param.ParameterName = "@feed_id";
				param.Value = feed.Id;
				cmd.Parameters.Add(param);

				param = cmd.CreateParameter();
				param.ParameterName = "@items";
				param.Value = String.Join (",", feed.ReadItems);
				cmd.Parameters.Add(param);

				cmd.ExecuteNonQuery ();
				feed.FirstRead = false;
			});
		}

		public static void UpdateFeedReads(NewsFeed feed)
		{
			if (feed.FirstRead)
				throw new InvalidOperationException ("Нельзя обновить новый фид с FirstRead = true");
			logger.Info ("Обновляем прочитанные новости...");
			string sql = "UPDATE read_news SET items = @items WHERE id = @id";
			DbCommand cmd = QSMain.ConnectionDB.CreateCommand();
			cmd.CommandText = sql;

			DbParameter param = cmd.CreateParameter();
			param.ParameterName = "@id";
			param.Value = feed.DataBaseId;
			cmd.Parameters.Add(param);

			param = cmd.CreateParameter();
			param.ParameterName = "@items";
			param.Value = String.Join (",", feed.ReadItems);
			cmd.Parameters.Add(param);

			cmd.ExecuteNonQuery ();
			logger.Info ("Ok");
		}
	}
}
