﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace BetClient.Add
{
	public class CoeffConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{

			return values[0].ToString() + "  /  " + values[1].ToString();
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}