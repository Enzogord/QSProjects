
// This file has been generated by the GUI designer. Do not modify.
namespace QS.HistoryLog.Dialogs
{
	public partial class HistoryView
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.Table table1;

		private global::Gtk.Button buttonSearch;

		private global::Gamma.Widgets.yEnumComboBox comboAction;

		private global::Gamma.Widgets.ySpecComboBox comboProperty;

		private global::Gtk.ComboBox comboUsers;

		private global::Gamma.Widgets.ySpecComboBox datacomboObject;

		private global::Gtk.Entry entrySearchEntity;

		private global::Gtk.Entry entrySearchValue;

		private global::Gtk.Label label3;

		private global::Gtk.Label label4;

		private global::Gtk.Label label5;

		private global::Gtk.Label label6;

		private global::Gtk.Label label8;

		private global::Gtk.Label label9;

		private global::QSWidgetLib.SelectPeriod selectperiod;

		private global::Gtk.VPaned vpaned1;

		private global::Gtk.ScrolledWindow GtkScrolledWindowChangesets;

		private global::Gamma.GtkWidgets.yTreeView datatreeChangesets;

		private global::Gtk.VBox vbox3;

		private global::Gtk.Label label7;

		private global::Gtk.ScrolledWindow GtkScrolledWindow1;

		private global::Gamma.GtkWidgets.yTreeView datatreeChanges;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget QS.HistoryLog.Dialogs.HistoryView
			global::Stetic.BinContainer.Attach(this);
			this.Name = "QS.HistoryLog.Dialogs.HistoryView";
			// Container child QS.HistoryLog.Dialogs.HistoryView.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.table1 = new global::Gtk.Table(((uint)(5)), ((uint)(5)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.buttonSearch = new global::Gtk.Button();
			this.buttonSearch.CanFocus = true;
			this.buttonSearch.Name = "buttonSearch";
			this.buttonSearch.UseUnderline = true;
			global::Gtk.Image w1 = new global::Gtk.Image();
			w1.Pixbuf = global::Stetic.IconLoader.LoadIcon(this, "gtk-find", global::Gtk.IconSize.Menu);
			this.buttonSearch.Image = w1;
			this.table1.Add(this.buttonSearch);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1[this.buttonSearch]));
			w2.TopAttach = ((uint)(3));
			w2.BottomAttach = ((uint)(5));
			w2.LeftAttach = ((uint)(4));
			w2.RightAttach = ((uint)(5));
			w2.XOptions = ((global::Gtk.AttachOptions)(4));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.comboAction = new global::Gamma.Widgets.yEnumComboBox();
			this.comboAction.Name = "comboAction";
			this.comboAction.ShowSpecialStateAll = true;
			this.comboAction.ShowSpecialStateNot = false;
			this.comboAction.UseShortTitle = false;
			this.comboAction.DefaultFirst = false;
			this.table1.Add(this.comboAction);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1[this.comboAction]));
			w3.TopAttach = ((uint)(2));
			w3.BottomAttach = ((uint)(3));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.comboProperty = new global::Gamma.Widgets.ySpecComboBox();
			this.comboProperty.Name = "comboProperty";
			this.comboProperty.AddIfNotExist = false;
			this.comboProperty.DefaultFirst = false;
			this.comboProperty.ShowSpecialStateAll = true;
			this.comboProperty.ShowSpecialStateNot = false;
			this.table1.Add(this.comboProperty);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1[this.comboProperty]));
			w4.TopAttach = ((uint)(3));
			w4.BottomAttach = ((uint)(4));
			w4.LeftAttach = ((uint)(1));
			w4.RightAttach = ((uint)(2));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.comboUsers = new global::Gtk.ComboBox();
			this.comboUsers.Name = "comboUsers";
			this.table1.Add(this.comboUsers);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table1[this.comboUsers]));
			w5.LeftAttach = ((uint)(1));
			w5.RightAttach = ((uint)(2));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.datacomboObject = new global::Gamma.Widgets.ySpecComboBox();
			this.datacomboObject.Name = "datacomboObject";
			this.datacomboObject.AddIfNotExist = false;
			this.datacomboObject.DefaultFirst = false;
			this.datacomboObject.ShowSpecialStateAll = true;
			this.datacomboObject.ShowSpecialStateNot = false;
			this.table1.Add(this.datacomboObject);
			global::Gtk.Table.TableChild w6 = ((global::Gtk.Table.TableChild)(this.table1[this.datacomboObject]));
			w6.TopAttach = ((uint)(1));
			w6.BottomAttach = ((uint)(2));
			w6.LeftAttach = ((uint)(1));
			w6.RightAttach = ((uint)(2));
			w6.XOptions = ((global::Gtk.AttachOptions)(4));
			w6.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.entrySearchEntity = new global::Gtk.Entry();
			this.entrySearchEntity.CanFocus = true;
			this.entrySearchEntity.Name = "entrySearchEntity";
			this.entrySearchEntity.IsEditable = true;
			this.entrySearchEntity.InvisibleChar = '●';
			this.table1.Add(this.entrySearchEntity);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table1[this.entrySearchEntity]));
			w7.TopAttach = ((uint)(3));
			w7.BottomAttach = ((uint)(4));
			w7.LeftAttach = ((uint)(3));
			w7.RightAttach = ((uint)(4));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.entrySearchValue = new global::Gtk.Entry();
			this.entrySearchValue.CanFocus = true;
			this.entrySearchValue.Name = "entrySearchValue";
			this.entrySearchValue.IsEditable = true;
			this.entrySearchValue.InvisibleChar = '●';
			this.table1.Add(this.entrySearchValue);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table1[this.entrySearchValue]));
			w8.TopAttach = ((uint)(4));
			w8.BottomAttach = ((uint)(5));
			w8.LeftAttach = ((uint)(3));
			w8.RightAttach = ((uint)(4));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label3 = new global::Gtk.Label();
			this.label3.Name = "label3";
			this.label3.Xalign = 1F;
			this.label3.LabelProp = global::Mono.Unix.Catalog.GetString("Пользователь:");
			this.table1.Add(this.label3);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table1[this.label3]));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label4 = new global::Gtk.Label();
			this.label4.Name = "label4";
			this.label4.Xalign = 1F;
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString("Действие с объектом:");
			this.table1.Add(this.label4);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table1[this.label4]));
			w10.TopAttach = ((uint)(2));
			w10.BottomAttach = ((uint)(3));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label5 = new global::Gtk.Label();
			this.label5.Name = "label5";
			this.label5.Xalign = 1F;
			this.label5.LabelProp = global::Mono.Unix.Catalog.GetString("Поиск по изменениям:");
			this.table1.Add(this.label5);
			global::Gtk.Table.TableChild w11 = ((global::Gtk.Table.TableChild)(this.table1[this.label5]));
			w11.TopAttach = ((uint)(4));
			w11.BottomAttach = ((uint)(5));
			w11.LeftAttach = ((uint)(2));
			w11.RightAttach = ((uint)(3));
			w11.XOptions = ((global::Gtk.AttachOptions)(4));
			w11.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label6 = new global::Gtk.Label();
			this.label6.Name = "label6";
			this.label6.Xalign = 1F;
			this.label6.LabelProp = global::Mono.Unix.Catalog.GetString("Объект изменений:");
			this.table1.Add(this.label6);
			global::Gtk.Table.TableChild w12 = ((global::Gtk.Table.TableChild)(this.table1[this.label6]));
			w12.TopAttach = ((uint)(1));
			w12.BottomAttach = ((uint)(2));
			w12.XOptions = ((global::Gtk.AttachOptions)(4));
			w12.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label8 = new global::Gtk.Label();
			this.label8.Name = "label8";
			this.label8.Xalign = 1F;
			this.label8.LabelProp = global::Mono.Unix.Catalog.GetString("Реквизит объекта:");
			this.table1.Add(this.label8);
			global::Gtk.Table.TableChild w13 = ((global::Gtk.Table.TableChild)(this.table1[this.label8]));
			w13.TopAttach = ((uint)(3));
			w13.BottomAttach = ((uint)(4));
			w13.XOptions = ((global::Gtk.AttachOptions)(4));
			w13.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label9 = new global::Gtk.Label();
			this.label9.Name = "label9";
			this.label9.Xalign = 1F;
			this.label9.LabelProp = global::Mono.Unix.Catalog.GetString("Поиск по имени объекта:");
			this.table1.Add(this.label9);
			global::Gtk.Table.TableChild w14 = ((global::Gtk.Table.TableChild)(this.table1[this.label9]));
			w14.TopAttach = ((uint)(3));
			w14.BottomAttach = ((uint)(4));
			w14.LeftAttach = ((uint)(2));
			w14.RightAttach = ((uint)(3));
			w14.XOptions = ((global::Gtk.AttachOptions)(4));
			w14.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.selectperiod = new global::QSWidgetLib.SelectPeriod();
			this.selectperiod.Events = ((global::Gdk.EventMask)(256));
			this.selectperiod.Name = "selectperiod";
			this.selectperiod.DateBegin = new global::System.DateTime(0);
			this.selectperiod.DateEnd = new global::System.DateTime(0);
			this.selectperiod.AutoDateSeparation = true;
			this.selectperiod.ShowToday = true;
			this.selectperiod.ShowWeek = true;
			this.selectperiod.ShowMonth = true;
			this.selectperiod.Show3Month = true;
			this.selectperiod.Show6Month = false;
			this.selectperiod.ShowYear = false;
			this.selectperiod.ShowAllTime = false;
			this.selectperiod.ShowCurWeek = false;
			this.selectperiod.ShowCurMonth = false;
			this.selectperiod.ShowCurQuarter = false;
			this.selectperiod.ShowCurYear = false;
			this.table1.Add(this.selectperiod);
			global::Gtk.Table.TableChild w15 = ((global::Gtk.Table.TableChild)(this.table1[this.selectperiod]));
			w15.BottomAttach = ((uint)(3));
			w15.LeftAttach = ((uint)(2));
			w15.RightAttach = ((uint)(4));
			w15.XOptions = ((global::Gtk.AttachOptions)(4));
			w15.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox2.Add(this.table1);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.table1]));
			w16.Position = 0;
			w16.Expand = false;
			w16.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.vpaned1 = new global::Gtk.VPaned();
			this.vpaned1.CanFocus = true;
			this.vpaned1.Name = "vpaned1";
			this.vpaned1.Position = 203;
			// Container child vpaned1.Gtk.Paned+PanedChild
			this.GtkScrolledWindowChangesets = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindowChangesets.Name = "GtkScrolledWindowChangesets";
			this.GtkScrolledWindowChangesets.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindowChangesets.Gtk.Container+ContainerChild
			this.datatreeChangesets = new global::Gamma.GtkWidgets.yTreeView();
			this.datatreeChangesets.CanFocus = true;
			this.datatreeChangesets.Name = "datatreeChangesets";
			this.GtkScrolledWindowChangesets.Add(this.datatreeChangesets);
			this.vpaned1.Add(this.GtkScrolledWindowChangesets);
			global::Gtk.Paned.PanedChild w18 = ((global::Gtk.Paned.PanedChild)(this.vpaned1[this.GtkScrolledWindowChangesets]));
			w18.Resize = false;
			w18.Shrink = false;
			// Container child vpaned1.Gtk.Paned+PanedChild
			this.vbox3 = new global::Gtk.VBox();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.label7 = new global::Gtk.Label();
			this.label7.Name = "label7";
			this.label7.Xalign = 0F;
			this.label7.LabelProp = global::Mono.Unix.Catalog.GetString("Детали изменений:");
			this.vbox3.Add(this.label7);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.label7]));
			w19.Position = 0;
			w19.Expand = false;
			w19.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			this.datatreeChanges = new global::Gamma.GtkWidgets.yTreeView();
			this.datatreeChanges.CanFocus = true;
			this.datatreeChanges.Name = "datatreeChanges";
			this.GtkScrolledWindow1.Add(this.datatreeChanges);
			this.vbox3.Add(this.GtkScrolledWindow1);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.vbox3[this.GtkScrolledWindow1]));
			w21.Position = 1;
			this.vpaned1.Add(this.vbox3);
			global::Gtk.Paned.PanedChild w22 = ((global::Gtk.Paned.PanedChild)(this.vpaned1[this.vbox3]));
			w22.Resize = false;
			w22.Shrink = false;
			this.vbox2.Add(this.vpaned1);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.vpaned1]));
			w23.Position = 1;
			this.Add(this.vbox2);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.selectperiod.DatesChanged += new global::System.EventHandler(this.OnSelectperiodDatesChanged);
			this.entrySearchValue.Activated += new global::System.EventHandler(this.OnEntrySearchActivated);
			this.entrySearchEntity.Activated += new global::System.EventHandler(this.OnEntrySearchEntityActivated);
			this.datacomboObject.ItemSelected += new global::System.EventHandler<Gamma.Widgets.ItemSelectedEventArgs>(this.OnDatacomboObjectItemSelected);
			this.comboUsers.Changed += new global::System.EventHandler(this.OnComboUsersChanged);
			this.comboProperty.ItemSelected += new global::System.EventHandler<Gamma.Widgets.ItemSelectedEventArgs>(this.OnComboPropertyItemSelected);
			this.comboAction.Changed += new global::System.EventHandler(this.OnComboActionChanged);
			this.buttonSearch.Clicked += new global::System.EventHandler(this.OnButtonSearchClicked);
		}
	}
}
