
// This file has been generated by the GUI designer. Do not modify.
namespace QSAttachment
{
	public partial class GetFromScanner
	{
		private global::Gtk.HBox hbox2;
		
		private global::Gtk.Table table1;
		
		private global::Gtk.Button buttonScan;
		
		private global::Gtk.ComboBox comboFormat;
		
		private global::Gtk.ComboBox comboScanner;
		
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.Entry entryFileName;
		
		private global::Gtk.Label labelExtension;
		
		private global::Gtk.Label label1;
		
		private global::Gtk.Label label2;
		
		private global::Gtk.Label label3;
		
		private global::Gtk.Label labelInfo;
		
		private global::Gtk.ProgressBar progressScan;
		
		private global::QSWidgetLib.VImagesList vimageslist1;
		
		private global::Gtk.Button buttonCancel;
		
		private global::Gtk.Button buttonOk;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget QSAttachment.GetFromScanner
			this.Name = "QSAttachment.GetFromScanner";
			this.Title = global::Mono.Unix.Catalog.GetString ("Получение изображений со сканера");
			this.Icon = global::Gdk.Pixbuf.LoadFromResource ("QSAttachment.icons.scanner32.png");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			// Internal child QSAttachment.GetFromScanner.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table (((uint)(6)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.buttonScan = new global::Gtk.Button ();
			this.buttonScan.Sensitive = false;
			this.buttonScan.CanFocus = true;
			this.buttonScan.Name = "buttonScan";
			this.buttonScan.UseUnderline = true;
			this.buttonScan.Label = global::Mono.Unix.Catalog.GetString ("Сканировать");
			global::Gtk.Image w2 = new global::Gtk.Image ();
			w2.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("QSAttachment.icons.scanner32.png");
			this.buttonScan.Image = w2;
			this.table1.Add (this.buttonScan);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1 [this.buttonScan]));
			w3.TopAttach = ((uint)(4));
			w3.BottomAttach = ((uint)(5));
			w3.RightAttach = ((uint)(2));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.comboFormat = global::Gtk.ComboBox.NewText ();
			this.comboFormat.AppendText (global::Mono.Unix.Catalog.GetString ("Одно изображение(JPEG)"));
			this.comboFormat.AppendText (global::Mono.Unix.Catalog.GetString ("Многостраничный документ(PDF)"));
			this.comboFormat.Name = "comboFormat";
			this.comboFormat.Active = 0;
			this.table1.Add (this.comboFormat);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1 [this.comboFormat]));
			w4.TopAttach = ((uint)(1));
			w4.BottomAttach = ((uint)(2));
			w4.LeftAttach = ((uint)(1));
			w4.RightAttach = ((uint)(2));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.comboScanner = global::Gtk.ComboBox.NewText ();
			this.comboScanner.Name = "comboScanner";
			this.table1.Add (this.comboScanner);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1 [this.comboScanner]));
			w5.LeftAttach = ((uint)(1));
			w5.RightAttach = ((uint)(2));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.entryFileName = new global::Gtk.Entry ();
			this.entryFileName.CanFocus = true;
			this.entryFileName.Name = "entryFileName";
			this.entryFileName.IsEditable = true;
			this.entryFileName.InvisibleChar = '●';
			this.hbox1.Add (this.entryFileName);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.entryFileName]));
			w6.Position = 0;
			// Container child hbox1.Gtk.Box+BoxChild
			this.labelExtension = new global::Gtk.Label ();
			this.labelExtension.Name = "labelExtension";
			this.labelExtension.LabelProp = global::Mono.Unix.Catalog.GetString (".jpg");
			this.hbox1.Add (this.labelExtension);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.labelExtension]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			this.table1.Add (this.hbox1);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1 [this.hbox1]));
			w8.TopAttach = ((uint)(2));
			w8.BottomAttach = ((uint)(3));
			w8.LeftAttach = ((uint)(1));
			w8.RightAttach = ((uint)(2));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Формат:");
			this.table1.Add (this.label1);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1 [this.label1]));
			w9.TopAttach = ((uint)(1));
			w9.BottomAttach = ((uint)(2));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Имя файла:");
			this.table1.Add (this.label2);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1 [this.label2]));
			w10.TopAttach = ((uint)(2));
			w10.BottomAttach = ((uint)(3));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Сканер:");
			this.table1.Add (this.label3);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1 [this.label3]));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.labelInfo = new global::Gtk.Label ();
			this.labelInfo.Name = "labelInfo";
			this.labelInfo.LabelProp = global::Mono.Unix.Catalog.GetString ("<span background = \"red\">Внимание!</span> В этом режиме будет сохранено только первое изображение.");
			this.labelInfo.UseMarkup = true;
			this.labelInfo.Wrap = true;
			this.table1.Add (this.labelInfo);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table1 [this.labelInfo]));
			w12.TopAttach = ((uint)(5));
			w12.BottomAttach = ((uint)(6));
			w12.RightAttach = ((uint)(2));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.progressScan = new global::Gtk.ProgressBar ();
			this.progressScan.Name = "progressScan";
			this.table1.Add (this.progressScan);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1 [this.progressScan]));
			w13.TopAttach = ((uint)(3));
			w13.BottomAttach = ((uint)(4));
			w13.RightAttach = ((uint)(2));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			this.hbox2.Add (this.table1);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.table1]));
			w14.Position = 0;
			w14.Expand = false;
			w14.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.vimageslist1 = new global::QSWidgetLib.VImagesList ();
			this.vimageslist1.Events = ((global::Gdk.EventMask)(256));
			this.vimageslist1.Name = "vimageslist1";
			this.hbox2.Add (this.vimageslist1);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.vimageslist1]));
			w15.Position = 1;
			w1.Add (this.hbox2);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(w1 [this.hbox2]));
			w16.Position = 0;
			// Internal child QSAttachment.GetFromScanner.ActionArea
			global::Gtk.HButtonBox w17 = this.ActionArea;
			w17.Name = "dialog1_ActionArea";
			w17.Spacing = 10;
			w17.BorderWidth = ((uint)(5));
			w17.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanDefault = true;
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseStock = true;
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = "gtk-cancel";
			this.AddActionWidget (this.buttonCancel, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w18 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w17 [this.buttonCancel]));
			w18.Expand = false;
			w18.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonOk = new global::Gtk.Button ();
			this.buttonOk.CanDefault = true;
			this.buttonOk.CanFocus = true;
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.UseStock = true;
			this.buttonOk.UseUnderline = true;
			this.buttonOk.Label = "gtk-ok";
			this.AddActionWidget (this.buttonOk, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w19 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w17 [this.buttonOk]));
			w19.Position = 1;
			w19.Expand = false;
			w19.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 552;
			this.DefaultHeight = 283;
			this.labelInfo.Hide ();
			this.Show ();
			this.entryFileName.Changed += new global::System.EventHandler (this.OnEntryFileNameChanged);
			this.comboScanner.Changed += new global::System.EventHandler (this.OnComboScannerChanged);
			this.comboFormat.Changed += new global::System.EventHandler (this.OnCombobox1Changed);
			this.buttonScan.Clicked += new global::System.EventHandler (this.OnButtonScanClicked);
			this.buttonOk.Clicked += new global::System.EventHandler (this.OnButtonOkClicked);
		}
	}
}
