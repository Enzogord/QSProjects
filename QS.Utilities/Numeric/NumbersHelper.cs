﻿using System;
namespace QS.Utilities.Numeric
{
	public static class NumbersHelper
	{
		public static int Clamp(this int value, int min, int max)
		{
			if(value < min) { return min; }
			if(value > max) { return max; }
			return value;
		}

		public static decimal Clamp(this decimal value, decimal min, decimal max)
		{
			if(value < min) { return min; }
			if(value > max) { return max; }
			return value;
		}
	}
}
