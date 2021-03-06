using System;
using System.IO;
using System.Xml;
using NLog;

namespace QSProjectsLib
{
	public class ViewReportExt
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();
		public string Params = "";
		private string TempReportPath;
		private string reportName;
		private string reportPath;
		private XmlDocument xmlDoc;

		public ViewReportExt(string ReportName, bool UserVar = false)
		{
			reportName = ReportName;
	
			reportPath = System.IO.Path.Combine( Directory.GetCurrentDirectory(), "Reports", ReportName + ".rdl");
			TempReportPath = System.IO.Path.Combine (System.IO.Path.GetTempPath (), reportName + ".rdl");
			xmlDoc = new XmlDocument();
			xmlDoc.Load(reportPath);

			foreach (XmlNode node in xmlDoc.GetElementsByTagName("ConnectString"))
			{
				if(UserVar)
					node.InnerText = QSMain.ConnectionString + ";Allow User Variables=True";
				else
					node.InnerText = QSMain.ConnectionString;
			}
		}

		public string GetCommandText(string dataSetName)
		{
			XmlNode command = xmlDoc.SelectSingleNode ("/Report/DataSets/DataSet[@Name='Data']/Query/CommandText");

			if (command != null)
				return command.InnerText;
			else
				return "";
		}

		public void SetCommandText(string dataSetName, string value)
		{
			XmlNode command = xmlDoc.SelectSingleNode ("/Report/DataSets/DataSet[@Name='Data']/Query/CommandText");

			if (command != null)
				command.InnerText = value;
		}

		public void SaveToTemp(){
			xmlDoc.Save(TempReportPath);
		}

		public void Run()
		{
			logger.Debug("Report:{0} Parameters:{1}", reportName, Params);
			string arg = "-r \"" + TempReportPath +"\" -p \"" + Params + "\"";
			System.Diagnostics.Process.Start ("RdlReader.exe", arg);
		}

		public static void Run(string ReportName, string Params, bool UserVar = false)
		{
			ViewReportExt viewext = new ViewReportExt (ReportName, UserVar);
			viewext.Params = Params;
			viewext.SaveToTemp ();
			viewext.Run ();
		}

		public static void RunWithSubreports(string ReportName, string Params, string[] subReportNames, bool UserVar=false)
		{
			foreach (string subReportName in subReportNames) {
				ViewReportExt subReport = new ViewReportExt (subReportName, UserVar);
				subReport.Params = Params;
				subReport.SaveToTemp();
			}
			ViewReportExt report = new ViewReportExt (ReportName, UserVar);
			report.Params = Params;
			report.SaveToTemp ();
			report.Run ();
		}
	}
}

