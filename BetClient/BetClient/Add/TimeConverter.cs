﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace BetClient.Add
{
	public class TimeConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return "   " + ((string)value).Replace("<div class=\"sc\">", "").Replace("</div>","");
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}