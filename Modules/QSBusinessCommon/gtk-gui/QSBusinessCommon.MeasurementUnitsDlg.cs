
// This file has been generated by the GUI designer. Do not modify.
namespace QSBusinessCommon
{
	public partial class MeasurementUnitsDlg
	{
		private global::Gtk.UIManager UIManager;

		private global::Gtk.VBox vbox3;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Button buttonSave;

		private global::Gtk.Button buttonCancel;

		private global::Gtk.Table datatable1;

		private global::Gamma.GtkWidgets.yEntry dataentryOKEI;

		private global::Gamma.GtkWidgets.yEntry entryName;

		private global::Gtk.Label label1;

		private global::Gtk.Label label10;

		private global::Gtk.Label label11;

		private global::Gamma.GtkWidgets.ySpinButton spinDigits;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget QSBusinessCommon.MeasurementUnitsDlg
			Stetic.BinContainer w1 = global::Stetic.BinContainer.Attach(this);
			this.UIManager = new global::Gtk.UIManager();
			global::Gtk.ActionGroup w2 = new global::Gtk.ActionGroup("Default");
			this.UIManager.InsertActionGroup(w2, 0);
			this.Name = "QSBusinessCommon.MeasurementUnitsDlg";
			// Container child QSBusinessCommon.MeasurementUnitsDlg.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonSave = new global::Gtk.Button();
			this.buttonSave.CanFocus = true;
			this.buttonSave.Name = "buttonSave";
			this.buttonSave.UseUnderline = true;
			this.buttonSave.Label = global::Mono.Unix.Catalog.GetString("Сохранить");
			global::Gtk.Image w3 = new global::Gtk.Image();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-save", global::Gtk.IconSize.Menu);
			this.buttonSave.Image = w3;
			this.hbox4.Add(this.buttonSave);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonSave]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.buttonCancel = new global::Gtk.Button();
			this.buttonCancel.CanFocus = true;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.UseUnderline = true;
			this.buttonCancel.Label = global::Mono.Unix.Catalog.GetString("Отменить");
			global::Gtk.Image w5 = new global::Gtk.Image();
			w5.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-revert-to-saved", global::Gtk.IconSize.Menu);
			this.buttonCancel.Image = w5;
			this.hbox4.Add(this.buttonCancel);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.buttonCancel]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			this.vbox3.Add(this.hbox4);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.hbox4]));
			w7.Position = 0;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.datatable1 = new global::Gtk.Table(((uint)(3)), ((uint)(2)), false);
			this.datatable1.Name = "datatable1";
			this.datatable1.RowSpacing = ((uint)(6));
			this.datatable1.ColumnSpacing = ((uint)(6));
			// Container child datatable1.Gtk.Table+TableChild
			this.dataentryOKEI = new global::Gamma.GtkWidgets.yEntry();
			this.dataentryOKEI.CanFocus = true;
			this.dataentryOKEI.Name = "dataentryOKEI";
			this.dataentryOKEI.IsEditable = true;
			this.dataentryOKEI.MaxLength = 3;
			this.dataentryOKEI.InvisibleChar = '●';
			this.datatable1.Add(this.dataentryOKEI);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.datatable1[this.dataentryOKEI]));
			w8.TopAttach = ((uint)(2));
			w8.BottomAttach = ((uint)(3));
			w8.LeftAttach = ((uint)(1));
			w8.RightAttach = ((uint)(2));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.entryName = new global::Gamma.GtkWidgets.yEntry();
			this.entryName.CanFocus = true;
			this.entryName.Name = "entryName";
			this.entryName.IsEditable = true;
			this.entryName.MaxLength = 10;
			this.entryName.InvisibleChar = '●';
			this.datatable1.Add(this.entryName);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.datatable1[this.entryName]));
			w9.LeftAttach = ((uint)(1));
			w9.RightAttach = ((uint)(2));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.Xalign = 1F;
			this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Код ОКЕИ:");
			this.datatable1.Add(this.label1);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.datatable1[this.label1]));
			w10.TopAttach = ((uint)(2));
			w10.BottomAttach = ((uint)(3));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label10 = new global::Gtk.Label();
			this.label10.Name = "label10";
			this.label10.Xalign = 1F;
			this.label10.LabelProp = global::Mono.Unix.Catalog.GetString("Знаков после запятой:");
			this.label10.Justify = ((global::Gtk.Justification)(1));
			this.datatable1.Add(this.label10);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.datatable1[this.label10]));
			w11.TopAttach = ((uint)(1));
			w11.BottomAttach = ((uint)(2));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.label11 = new global::Gtk.Label();
			this.label11.Name = "label11";
			this.label11.Xalign = 1F;
			this.label11.LabelProp = global::Mono.Unix.Catalog.GetString("Название:");
			this.datatable1.Add(this.label11);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.datatable1[this.label11]));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child datatable1.Gtk.Table+TableChild
			this.spinDigits = new global::Gamma.GtkWidgets.ySpinButton(0, 5, 1);
			this.spinDigits.CanFocus = true;
			this.spinDigits.Name = "spinDigits";
			this.spinDigits.Adjustment.PageIncrement = 10;
			this.spinDigits.ClimbRate = 1;
			this.spinDigits.Numeric = true;
			this.spinDigits.ValueAsDecimal = 0m;
			this.spinDigits.ValueAsInt = 0;
			this.datatable1.Add(this.spinDigits);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.datatable1[this.spinDigits]));
			w13.TopAttach = ((uint)(1));
			w13.BottomAttach = ((uint)(2));
			w13.LeftAttach = ((uint)(1));
			w13.RightAttach = ((uint)(2));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox3.Add(this.datatable1);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.datatable1]));
			w14.Position = 1;
			w14.Expand = false;
			w14.Fill = false;
			this.Add(this.vbox3);
			if((this.Child != null)) {
				this.Child.ShowAll();
			}
			w1.SetUiManager(UIManager);
			this.Hide();
		}
	}
}
