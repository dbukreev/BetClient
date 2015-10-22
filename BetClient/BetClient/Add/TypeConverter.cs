using System;
using System.Globalization;
using System.Windows.Data;

namespace BetClient.Add
{
	public class TypeConverter : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{

			return (string)values[1] + "  —  " + (string)values[2];
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}