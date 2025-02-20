﻿using System.Globalization;
using System.Windows.Data;

namespace QTRHacker.Converters;

internal class InvertBoolConverter : IValueConverter
{
	public static readonly InvertBoolConverter Instance = new();
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return value is bool b ? !b : (object)true;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		return Convert(value, targetType, parameter, culture);
	}
}
