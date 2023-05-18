﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace CeleryApp.Misc
{
	public static class Miscellaneous
	{
		public static T GetTemplateChild<T>(this Control e, string name) where T : FrameworkElement
		{
			return e.Template.FindName(name, e) as T;
		}
	}
}
