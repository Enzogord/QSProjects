
// This file has been generated by the GUI designer. Do not modify.
namespace QSProjectsLib
{
	public partial class Delete
	{
		private global::Gtk.VBox vbox2;
		private global::Gtk.HBox hbox6;
		private global::Gtk.Image image5602;
		private global::Gtk.Label label4;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TreeView treeviewObjects;
		private global::Gtk.Button buttonNo;
		private global::Gtk.Button buttonYes;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget QSProjectsLib.Delete
			this.Name = "QSProjectsLib.Delete";
			this.Title = global::Mono.Unix.Catalog.GetString ("Удаление");
			this.Icon = global::Stetic.IconLoader.LoadIcon (this, "gtk-delete", global::Gtk.IconSize.Dialog);
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			// Internal child QSProjectsLib.Delete.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox6 = new global::Gtk.HBox ();
			this.hbox6.Name = "hbox6";
			this.hbox6.Spacing = 6;
			// Container child hbox6.Gtk.Box+BoxChild
			this.image5602 = new global::Gtk.Image ();
			this.image5602.Name = "image5602";
			this.image5602.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-delete", global::Gtk.IconSize.Dialog);
			this.hbox6.Add (this.image5602);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.image5602]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox6.Gtk.Box+BoxChild
			this.label4 = new global::Gtk.Label ();
			this.label4.Name = "label4";
			this.label4.LabelProp = global::Mono.Unix.Catalog.GetString ("Вы уверены что хотите удалить этот элемент? Вы не сможете его восстановить.\nВместе с ним также будут удалены или очищены ссылки в следующих объектах:");
			this.hbox6.Add (this.label4);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox6 [this.label4]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			this.vbox2.Add (this.hbox6);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hbox6]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.treeviewObjects = new global::Gtk.TreeView ();
			this.treeviewObjects.CanFocus = true;
			this.treeviewObjects.Name = "treeviewObjects";
			this.treeviewObjects.HeadersVisible = false;
			this.GtkScrolledWindow.Add (this.treeviewObjects);
			this.vbox2.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.GtkScrolledWindow]));
			w6.Position = 1;
			w1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(w1 [this.vbox2]));
			w7.Position = 0;
			// Internal child QSProjectsLib.Delete.ActionArea
			global::Gtk.HButtonBox w8 = this.ActionArea;
			w8.Name = "dialog1_ActionArea";
			w8.Spacing = 10;
			w8.BorderWidth = ((uint)(5));
			w8.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonNo = new global::Gtk.Button ();
			this.buttonNo.CanDefault = true;
			this.buttonNo.CanFocus = true;
			this.buttonNo.Name = "buttonNo";
			this.buttonNo.UseUnderline = true;
			// Container child buttonNo.Gtk.Container+ContainerChild
			global::Gtk.Alignment w9 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w10 = new global::Gtk.HBox ();
			w10.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w11 = new global::Gtk.Image ();
			w11.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-no", global::Gtk.IconSize.Menu);
			w10.Add (w11);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w13 = new global::Gtk.Label ();
			w13.LabelProp = global::Mono.Unix.Catalog.GetString ("_Нет");
			w13.UseUnderline = true;
			w10.Add (w13);
			w9.Add (w10);
			this.buttonNo.Add (w9);
			this.AddActionWidget (this.buttonNo, -9);
			global::Gtk.ButtonBox.ButtonBoxChild w17 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w8 [this.buttonNo]));
			w17.Expand = false;
			w17.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.buttonYes = new global::Gtk.Button ();
			this.buttonYes.CanDefault = true;
			this.buttonYes.CanFocus = true;
			this.buttonYes.Name = "buttonYes";
			this.buttonYes.UseUnderline = true;
			// Container child buttonYes.Gtk.Container+ContainerChild
			global::Gtk.Alignment w18 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w19 = new global::Gtk.HBox ();
			w19.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w20 = new global::Gtk.Image ();
			w20.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-yes", global::Gtk.IconSize.Menu);
			w19.Add (w20);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w22 = new global::Gtk.Label ();
			w22.LabelProp = global::Mono.Unix.Catalog.GetString ("_Да");
			w22.UseUnderline = true;
			w19.Add (w22);
			w18.Add (w19);
			this.buttonYes.Add (w18);
			this.AddActionWidget (this.buttonYes, -8);
			global::Gtk.ButtonBox.ButtonBoxChild w26 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w8 [this.buttonYes]));
			w26.Position = 1;
			w26.Expand = false;
			w26.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 654;
			this.DefaultHeight = 513;
			this.Show ();
		}
	}
}