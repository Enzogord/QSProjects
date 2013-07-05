
// This file has been generated by the GUI designer. Do not modify.
namespace QSWidgetLib
{
	public partial class SelectPeriod
	{
		private global::Gtk.VBox vboxMain;
		private global::Gtk.Label label1;
		private global::Gtk.Table RadiosTable;
		private global::Gtk.HBox hbox1;
		private global::QSWidgetLib.DatePicker StartDate;
		private global::Gtk.Label label2;
		private global::QSWidgetLib.DatePicker EndDate;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget QSWidgetLib.SelectPeriod
			global::Stetic.BinContainer.Attach (this);
			this.Name = "QSWidgetLib.SelectPeriod";
			// Container child QSWidgetLib.SelectPeriod.Gtk.Container+ContainerChild
			this.vboxMain = new global::Gtk.VBox ();
			this.vboxMain.Name = "vboxMain";
			this.vboxMain.Spacing = 6;
			// Container child vboxMain.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.LabelProp = "<b>Выбор периода</b>";
			this.label1.UseMarkup = true;
			this.vboxMain.Add (this.label1);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vboxMain [this.label1]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vboxMain.Gtk.Box+BoxChild
			this.RadiosTable = new global::Gtk.Table (((uint)(1)), ((uint)(2)), false);
			this.RadiosTable.Name = "RadiosTable";
			this.RadiosTable.RowSpacing = ((uint)(6));
			this.RadiosTable.ColumnSpacing = ((uint)(6));
			this.vboxMain.Add (this.RadiosTable);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vboxMain [this.RadiosTable]));
			w2.Position = 1;
			// Container child vboxMain.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.StartDate = new global::QSWidgetLib.DatePicker ();
			this.StartDate.Events = ((global::Gdk.EventMask)(256));
			this.StartDate.Name = "StartDate";
			this.StartDate.Date = new global::System.DateTime (0);
			this.StartDate.IsEditable = true;
			this.StartDate.AutoSeparation = true;
			this.hbox1.Add (this.StartDate);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.StartDate]));
			w3.Position = 0;
			// Container child hbox1.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = "-";
			this.hbox1.Add (this.label2);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.label2]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.EndDate = new global::QSWidgetLib.DatePicker ();
			this.EndDate.Events = ((global::Gdk.EventMask)(256));
			this.EndDate.Name = "EndDate";
			this.EndDate.Date = new global::System.DateTime (0);
			this.EndDate.IsEditable = true;
			this.EndDate.AutoSeparation = true;
			this.hbox1.Add (this.EndDate);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.EndDate]));
			w5.Position = 2;
			this.vboxMain.Add (this.hbox1);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vboxMain [this.hbox1]));
			w6.Position = 2;
			w6.Expand = false;
			w6.Fill = false;
			this.Add (this.vboxMain);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.StartDate.DateChanged += new global::System.EventHandler (this.OnStartDateDateChanged);
			this.EndDate.DateChanged += new global::System.EventHandler (this.OnEndDateDateChanged);
		}
	}
}
