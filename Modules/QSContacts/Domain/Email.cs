﻿using System;
using QSOrmProject;
using System.Data.Bindings;

namespace QSContacts
{
	[OrmSubjectAttributes("E-mail")]
	public class Email
	{
		public virtual int Id { get; set; }
		public virtual string Address { get; set; }
		public virtual EmailType EmailType { get; set; }

		public Email ()
		{
			Address = String.Empty;
		}
	}
}

