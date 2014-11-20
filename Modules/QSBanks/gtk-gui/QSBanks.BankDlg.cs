
// This file has been generated by the GUI designer. Do not modify.
namespace QSBanks
{
	public partial class BankDlg
	{
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.HBox hbox1;
		
		private global::Gtk.Button buttonSave;
		
		private global::Gtk.Button buttonCancel;
		
		private global::Gtk.DataBindings.DataTable datatableInfo;
		
		private global::Gtk.DataBindings.DataEntry dataentryBik;
		
		private global::Gtk.DataBindings.DataEntry dataentryCity;
		
		private global::Gtk.DataBindings.DataEntry dataentryCorAccount;
		
		private global::Gtk.DataBindings.DataEntry dataentryName;
		
		private global::Gtk.DataBindings.DataEntry dataentryRegion;
		
		private global::Gtk.Label label1;
		
		private global::Gtk.Label label2;
		
		private global::Gtk.Label label3;
		
		private global::Gtk.Label label4;
		
		private global::Gtk.Label label5;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget QSBanks.BankDlg
			global::Stetic.BinContainer.Attach (this);
			this.Name = "QSBanks.BankDlg";
			// Container child QSBanks.BankDlg.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button ();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString ("Сохранить");
			global::Gtk.Image w1 = new global::Gtk.Image ();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w1;
			this.hbox1.Add (this.buttonSave);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonSave]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button ();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString ("Отменить");
			global::Gtk.Image w3 = new global::Gtk.Image ();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w3;
			this.hbox1.Add (this.buttonCancel);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonCancel]));
			w4.Position = 1;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.datatableInfo = new global::Gtk.DataBindings.DataTable (((uint)(5)), ((uint)(2)), false);
			this.datatableInfo.Name = "datatableInfo";
			this.datatableInfo.RowSpacing = ((uint)(6));
			this.datatableInfo.ColumnSpacing = ((uint)(6));
			this.datatableInfo.InheritedDataSource = false;
			this.datatableInfo.InheritedBoundaryDataSource = false;
			this.datatableInfo.InheritedDataSource = false;
			this.datatableInfo.InheritedBoundaryDataSource = false;
			// Container child datatableInfo.Gtk.Table+TableChild
			this.dataentryBik = new global::Gtk.DataBindings.DataEntry ();
			this.dataentryBik.CanFocus = true;
			this.dataentryBik.Name = "dataentryBik";
			this.dataentryBik.IsEditable = true;
			this.dataentryBik.MaxLength = 9;
			this.dataentryBik.InvisibleChar = '●';
			this.dataentryBik.InheritedDataSource = true;
			this.dataentryBik.Mappings = "Bik";
			this.dataentryBik.InheritedBoundaryDataSource = false;
			this.dataentryBik.InheritedDataSource = true;
			this.dataentryBik.Mappings = "Bik";
			this.dataentryBik.InheritedBoundaryDataSource = false;
			this.datatableInfo.Add (this.dataentryBik);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.datatableInfo [this.dataentryBik]));
			w6.TopAttach = ((uint)(1));
			w6.BottomAttach = ((uint)(2));
			w6.LeftAttach = ((uint)(1));
			w6.RightAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableInfo.Gtk.Table+TableChild
			this.dataentryCity = new global::Gtk.DataBindings.DataEntry ();
			this.dataentryCity.CanFocus = true;
			this.dataentryCity.Name = "dataentryCity";
			this.dataentryCity.IsEditable = true;
			this.dataentryCity.MaxLength = 45;
			this.dataentryCity.InvisibleChar = '●';
			this.dataentryCity.InheritedDataSource = true;
			this.dataentryCity.Mappings = "City";
			this.dataentryCity.InheritedBoundaryDataSource = false;
			this.dataentryCity.InheritedDataSource = true;
			this.dataentryCity.Mappings = "City";
			this.dataentryCity.InheritedBoundaryDataSource = false;
			this.datatableInfo.Add (this.dataentryCity);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.datatableInfo [this.dataentryCity]));
			w7.TopAttach = ((uint)(4));
			w7.BottomAttach = ((uint)(5));
			w7.LeftAttach = ((uint)(1));
			w7.RightAttach = ((uint)(2));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableInfo.Gtk.Table+TableChild
			this.dataentryCorAccount = new global::Gtk.DataBindings.DataEntry ();
			this.dataentryCorAccount.CanFocus = true;
			this.dataentryCorAccount.Name = "dataentryCorAccount";
			this.dataentryCorAccount.IsEditable = true;
			this.dataentryCorAccount.MaxLength = 25;
			this.dataentryCorAccount.InvisibleChar = '●';
			this.dataentryCorAccount.InheritedDataSource = true;
			this.dataentryCorAccount.Mappings = "CorAccount";
			this.dataentryCorAccount.InheritedBoundaryDataSource = false;
			this.dataentryCorAccount.InheritedDataSource = true;
			this.dataentryCorAccount.Mappings = "CorAccount";
			this.dataentryCorAccount.InheritedBoundaryDataSource = false;
			this.datatableInfo.Add (this.dataentryCorAccount);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.datatableInfo [this.dataentryCorAccount]));
			w8.TopAttach = ((uint)(2));
			w8.BottomAttach = ((uint)(3));
			w8.LeftAttach = ((uint)(1));
			w8.RightAttach = ((uint)(2));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableInfo.Gtk.Table+TableChild
			this.dataentryName = new global::Gtk.DataBindings.DataEntry ();
			this.dataentryName.CanFocus = true;
			this.dataentryName.Name = "dataentryName";
			this.dataentryName.IsEditable = true;
			this.dataentryName.MaxLength = 200;
			this.dataentryName.InvisibleChar = '●';
			this.dataentryName.InheritedDataSource = true;
			this.dataentryName.Mappings = "Name";
			this.dataentryName.InheritedBoundaryDataSource = false;
			this.dataentryName.InheritedDataSource = true;
			this.dataentryName.Mappings = "Name";
			this.dataentryName.InheritedBoundaryDataSource = false;
			this.datatableInfo.Add (this.dataentryName);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.datatableInfo [this.dataentryName]));
			w9.LeftAttach = ((uint)(1));
			w9.RightAttach = ((uint)(2));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableInfo.Gtk.Table+TableChild
			this.dataentryRegion = new global::Gtk.DataBindings.DataEntry ();
			this.dataentryRegion.CanFocus = true;
			this.dataentryRegion.Name = "dataentryRegion";
			this.dataentryRegion.IsEditable = true;
			this.dataentryRegion.MaxLength = 45;
			this.dataentryRegion.InvisibleChar = '●';
			this.dataentryRegion.InheritedDataSource = true;
			this.dataentryRegion.Mappings = "Region";
			this.dataentryRegion.InheritedBoundaryDataSource = false;
			this.dataentryRegion.InheritedDataSource = true;
			this.dataentryRegion.Mappings = "Region";
			this.dataentryRegion.InheritedBoundaryDataSource = false;
			this.datatableInfo.Add (this.dataentryRegion);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.datatableInfo [this.dataentryRegion]));
			w10.TopAttach = ((uint)(3));
			w10.BottomAttach = ((uint)(4));
			w10.LeftAttach = ((uint)(1));
			w10.RightAttach = ((uint)(2));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableInfo.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label ();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString ("Название:");
			this.datatableInfo.Add (this.label1);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.datatableInfo [this.label1]));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableInfo.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.Xalign = 1F;
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("БИК:");
			this.datatableInfo.Add (this.label2);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.datatableInfo [this.label2]));
			w12.TopAttach = ((uint)(1));
			w12.BottomAttach = ((uint)(2));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableInfo.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label ();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString ("Кор. счет:");
			this.datatableInfo.Add (this.label3);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.datatableInfo [this.label3]));
			w13.TopAttach = ((uint)(2));
			w13.BottomAttach = ((uint)(3));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableInfo.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Регион:");
			this.datatableInfo.Add (this.label4);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.datatableInfo [this.label4]));
			w14.TopAttach = ((uint)(3));
			w14.BottomAttach = ((uint)(4));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatableInfo.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label ();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString ("Город:");
			this.datatableInfo.Add (this.label5);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.datatableInfo [this.label5]));
			w15.TopAttach = ((uint)(4));
			w15.BottomAttach = ((uint)(5));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox1.Add (this.datatableInfo);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.datatableInfo]));
			w16.Position = 1;
			w16.Expand = false;
			w16.Fill = false;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.buttonSave.Clicked += new global::System.EventHandler (this.OnButtonSaveClicked);
			this.buttonCancel.Clicked += new global::System.EventHandler (this.OnButtonCancelClicked);
		}
	}
}
