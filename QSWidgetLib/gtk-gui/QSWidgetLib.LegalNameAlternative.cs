
// This file has been generated by the GUI designer. Do not modify.
namespace QSWidgetLib
{
	public partial class LegalNameAlternative
	{
		private global::Gtk.Table table4;

		private global::Gtk.ComboBox comboOwnership;

		private global::Gtk.Entry entryName;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget QSWidgetLib.LegalNameAlternative
			global::Stetic.BinContainer.Attach(this);
			this.Name = "QSWidgetLib.LegalNameAlternative";
			// Container child QSWidgetLib.LegalNameAlternative.Gtk.Container+ContainerChild
			this.table4 = new global::Gtk.Table(((uint)(2)), ((uint)(6)), false);
			this.table4.Name = "table4";
			this.table4.RowSpacing = ((uint)(6));
			this.table4.ColumnSpacing = ((uint)(6));
			// Container child table4.Gtk.Table+TableChild
			this.comboOwnership = global::Gtk.ComboBox.NewText();
			this.comboOwnership.Name = "comboOwnership";
			this.table4.Add(this.comboOwnership);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table4[this.comboOwnership]));
			w1.XOptions = ((global::Gtk.AttachOptions)(4));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table4.Gtk.Table+TableChild
			this.entryName = new global::Gtk.Entry();
			this.entryName.CanFocus = true;
			this.entryName.Name = "entryName";
			this.entryName.IsEditable = true;
			this.entryName.InvisibleChar = '●';
			this.table4.Add(this.entryName);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table4[this.entryName]));
			w2.TopAttach = ((uint)(1));
			w2.BottomAttach = ((uint)(2));
			w2.RightAttach = ((uint)(6));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add(this.table4);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
			this.entryName.Changed += new global::System.EventHandler(this.OnEntryNameChanged);
			this.comboOwnership.Changed += new global::System.EventHandler(this.OnComboOwnershipChanged);
		}
	}
}
