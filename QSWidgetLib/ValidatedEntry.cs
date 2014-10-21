﻿using System;
using System.Text.RegularExpressions;

namespace QSWidgetLib
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ValidatedEntry : Gtk.Entry
	{
		public enum Validation {
			none,
			numeric,
			email,
			single_word,
			phone
		};

		private Validation validationType;
		public Validation ValidationType {
			get {
				return validationType;
			}
			set { 
				validationType = value;
				switch (validationType) {
				case Validation.numeric:
					this.TextInserted += NumericValidate;
					break;
				case Validation.phone:
					this.MaxLength = 19;
					this.TextInserted += PhoneTextInserted;
					this.TextDeleted += PhoneTextDeleted;
					break;
				case Validation.single_word:
					break;
				case Validation.email:
					this.Changed += EmailValidate;
					break;
				default:
					break;
				}
			}
		}

		public ValidatedEntry () 
		{
			ValidationType = Validation.none;
		}

		protected void PhoneTextInserted (object o, Gtk.TextInsertedArgs args)
		{
			FormatString (o);
			switch (args.Position) {
			case 1:
				args.Position += 1;
				break;
			case 5:
				args.Position += 2;
				break;
			case 10:
				args.Position += 3;
				break;
			case 15:
				args.Position += 3;
				break;
			}
		}

		protected void PhoneTextDeleted (object o, Gtk.TextDeletedArgs args)
		{
			FormatString (o);
			var Entry = o as Gtk.Entry;
			if (args.StartPos > Entry.Text.Length)
				Entry.Position = Entry.Text.Length;
			else
				Entry.Position = args.StartPos;
			if (args.StartPos == 16 && args.EndPos == 17) {			//Backspace
				Entry.Text = Entry.Text.Remove (13, 1);
				Entry.Position = 13;
			} else if (args.StartPos == 11 && args.EndPos == 12) {
				Entry.Text = Entry.Text.Remove (8, 1);
				Entry.Position = 8;
			} else if (args.StartPos == 5 && args.EndPos == 6) {
				Entry.Text = Entry.Text.Remove (3, 1);
				Entry.Position = 3;
			} else if (args.StartPos == 14 && args.EndPos == 15) { 	//Delete
				Entry.Text = Entry.Text.Remove (17, 1);
				Entry.Position = 17;
			} else if (args.StartPos == 9 && args.EndPos == 10) {
				Entry.Text = Entry.Text.Remove (12, 1);
				Entry.Position = 12;
			} else if (args.StartPos == 4 && args.EndPos == 5) {
				Entry.Text = Entry.Text.Remove (6, 1);
				Entry.Position = 6;
			}
		}

		private void FormatString(object o)
		{
			string Number = (o as Gtk.Entry).Text;
			Number = Regex.Replace (Number, "[^0-9]", "");
			if (Number != String.Empty) {
				if (Number.Length > 0)
					Number = Number.Insert (0, "(");
				if (Number.Length > 4)
					Number = Number.Insert (4, ") ");
				if (Number.Length > 9)
					Number = Number.Insert (9, " - ");
				if (Number.Length > 14)
					Number = Number.Insert (14, " - ");
			}
			(o as Gtk.Entry).Text = Number;
		}

		protected void NumericValidate(object sender, Gtk.TextInsertedArgs Args)
		{
			String Text = (sender as Gtk.Entry).Text;
			Text = Regex.Replace (Text, "[^0-9]", "");
			(sender as Gtk.Entry).Text = Text;
		}

		protected void EmailValidate(object sender, System.EventArgs Args)
		{
			String Text = (sender as Gtk.Entry).Text;
			Regex regex = new Regex (@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@" +
							@"[a-zA-Z0-9][a-zA-Z0-9-]{0,61}[a-zA-Z0-9]\.[a-zA-Z0-9][a-zA-Z0-9-]{0,61}[a-zA-Z0-9]$");
			if (!regex.IsMatch(Text))
				(sender as Gtk.Entry).ModifyText(Gtk.StateType.Normal, new Gdk.Color(255,0,0));
			else
				(sender as Gtk.Entry).ModifyText(Gtk.StateType.Normal);
		}
	}
}

