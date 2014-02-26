﻿using System;
using Gtk;

namespace QSWidgetLib
{
	public class MenuItemId<I> : MenuItem
	{
		public I ID;

		public MenuItemId(string label) : base (label) {}
		public MenuItemId() : base () {}
	}

	public class ButtonId<I> : Button
	{
		public I ID;

		public ButtonId() : base () {}
	}

}