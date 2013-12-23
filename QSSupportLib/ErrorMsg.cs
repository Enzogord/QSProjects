using System;
using Gtk;

namespace QSSupportLib
{
	public partial class ErrorMsg : Gtk.Dialog
	{
		Exception AppExpeption;

		public ErrorMsg(Window parent, Exception ex)
		{
			if(parent != null)
				this.Parent = parent;
			this.Build();

			AppExpeption = ex;
			textviewError.Buffer.Text = ex.ToString();
		}

		protected void OnButtonCopyClicked(object sender, EventArgs e)
		{
			Gtk.Clipboard clipboard = Gtk.Clipboard.Get(Gdk.Atom.Intern("CLIPBOARD", false));

			string TextMsg = String.Format("Продукт: {0}\nВерсия: {1}\nРедакция: {2}\nОшибка:\n{3}", 
			                               MainSupport.ProjectVerion.Product, 
			                               MainSupport.ProjectVerion.Version.ToString(),
			                               MainSupport.ProjectVerion.Edition,
			                               AppExpeption.ToString());
			clipboard.Text = TextMsg;

		}
	}
}
