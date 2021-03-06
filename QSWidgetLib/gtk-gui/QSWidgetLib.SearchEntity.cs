
// This file has been generated by the GUI designer. Do not modify.
namespace QSWidgetLib
{
	public partial class SearchEntity
	{
		private global::Gtk.HBox hbox2;
		
		private global::Gtk.Label label2;
		
		private global::Gtk.Entry entrySearchText;
		
		private global::Gtk.Button buttonClear;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget QSWidgetLib.SearchEntity
			global::Stetic.BinContainer.Attach (this);
			this.Name = "QSWidgetLib.SearchEntity";
			// Container child QSWidgetLib.SearchEntity.Gtk.Container+ContainerChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Поиск:");
			this.hbox2.Add (this.label2);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.label2]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.entrySearchText = new global::Gtk.Entry ();
			this.entrySearchText.TooltipMarkup = "Введите фразу для поиска";
			this.entrySearchText.CanFocus = true;
			this.entrySearchText.Name = "entrySearchText";
			this.entrySearchText.IsEditable = true;
			this.entrySearchText.InvisibleChar = '●';
			this.hbox2.Add (this.entrySearchText);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.entrySearchText]));
			w2.Position = 1;
			// Container child hbox2.Gtk.Box+BoxChild
			this.buttonClear = new global::Gtk.Button ();
			this.buttonClear.TooltipMarkup = "Очистить поисковую фаразу";
			this.buttonClear.CanFocus = true;
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.UseUnderline = true;
			global::Gtk.Image w3 = new global::Gtk.Image ();
			w3.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-clear", global::Gtk.IconSize.Menu);
			this.buttonClear.Image = w3;
			this.hbox2.Add (this.buttonClear);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox2 [this.buttonClear]));
			w4.Position = 2;
			w4.Expand = false;
			w4.Fill = false;
			this.Add (this.hbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.entrySearchText.Changed += new global::System.EventHandler (this.OnEntrySearchTextChanged);
			this.buttonClear.Clicked += new global::System.EventHandler (this.OnButtonClearClicked);
		}
	}
}
