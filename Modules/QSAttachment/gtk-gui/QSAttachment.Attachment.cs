
// This file has been generated by the GUI designer. Do not modify.
namespace QSAttachment
{
	public partial class Attachment
	{
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.Button buttonAdd;
		
		private global::Gtk.Button buttonScan;
		
		private global::Gtk.Button buttonOpen;
		
		private global::Gtk.Button buttonSave;
		
		private global::Gtk.Button buttonDelete;
		
		private global::Gtk.ScrolledWindow scrolledwindow1;
		
		private global::Gtk.IconView iconviewFiles;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget QSAttachment.Attachment
			global::Stetic.BinContainer.Attach (this);
			this.Name = "QSAttachment.Attachment";
			// Container child QSAttachment.Attachment.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonAdd = new global::Gtk.Button ();
			this.buttonAdd.CanFocus = true;
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.UseUnderline = true;
			this.buttonAdd.Label = global::Mono.Unix.Catalog.GetString ("_Добавить");
			global::Gtk.Image w1 = new global::Gtk.Image ();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-add", global::Gtk.IconSize.Menu);
			this.buttonAdd.Image = w1;
			this.hbox1.Add (this.buttonAdd);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonAdd]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonScan = new global::Gtk.Button ();
			this.buttonScan.CanFocus = true;
			this.buttonScan.Name = "buttonScan";
			this.buttonScan.UseUnderline = true;
			this.buttonScan.Label = global::Mono.Unix.Catalog.GetString ("Со сканера");
			global::Gtk.Image w3 = new global::Gtk.Image ();
			w3.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("QSAttachment.icons.scanner16.png");
			this.buttonScan.Image = w3;
			this.hbox1.Add (this.buttonScan);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonScan]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonOpen = new global::Gtk.Button ();
			this.buttonOpen.Sensitive = false;
			this.buttonOpen.CanFocus = true;
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.UseUnderline = true;
			this.buttonOpen.Label = global::Mono.Unix.Catalog.GetString ("Открыть");
			global::Gtk.Image w5 = new global::Gtk.Image ();
			w5.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-open", global::Gtk.IconSize.Menu);
			this.buttonOpen.Image = w5;
			this.hbox1.Add (this.buttonOpen);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonOpen]));
			w6.Position = 2;
			w6.Expand = false;
			w6.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button ();
			this.buttonSave.Sensitive = false;
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString ("Сохранить на диск");
			global::Gtk.Image w7 = new global::Gtk.Image ();
			w7.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-harddisk", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w7;
			this.hbox1.Add (this.buttonSave);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonSave]));
			w8.Position = 3;
			w8.Expand = false;
			w8.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonDelete = new global::Gtk.Button ();
			this.buttonDelete.Sensitive = false;
			this.buttonDelete.CanFocus = true;
			this.buttonDelete.Name = "buttonDelete";
			this.buttonDelete.UseUnderline = true;
			this.buttonDelete.Label = global::Mono.Unix.Catalog.GetString ("Удалить");
			global::Gtk.Image w9 = new global::Gtk.Image ();
			w9.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-delete", global::Gtk.IconSize.Menu);
			this.buttonDelete.Image = w9;
			this.hbox1.Add (this.buttonDelete);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonDelete]));
			w10.Position = 4;
			w10.Expand = false;
			w10.Fill = false;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w11.Position = 0;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.scrolledwindow1 = new global::Gtk.ScrolledWindow ();
			this.scrolledwindow1.CanFocus = true;
			this.scrolledwindow1.Name = "scrolledwindow1";
			this.scrolledwindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child scrolledwindow1.Gtk.Container+ContainerChild
			this.iconviewFiles = new global::Gtk.IconView ();
			this.iconviewFiles.CanFocus = true;
			this.iconviewFiles.Name = "iconviewFiles";
			this.scrolledwindow1.Add (this.iconviewFiles);
			this.vbox1.Add (this.scrolledwindow1);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.scrolledwindow1]));
			w13.Position = 1;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.buttonAdd.Clicked += new global::System.EventHandler (this.OnButtonAddClicked);
			this.buttonScan.Clicked += new global::System.EventHandler (this.OnButtonScanClicked);
			this.buttonOpen.Clicked += new global::System.EventHandler (this.OnButtonOpenClicked);
			this.buttonSave.Clicked += new global::System.EventHandler (this.OnButtonSaveClicked);
			this.buttonDelete.Clicked += new global::System.EventHandler (this.OnButtonDeleteClicked);
			this.iconviewFiles.SelectionChanged += new global::System.EventHandler (this.OnIconviewFilesSelectionChanged);
			this.iconviewFiles.ItemActivated += new global::Gtk.ItemActivatedHandler (this.OnIconviewFilesItemActivated);
		}
	}
}
