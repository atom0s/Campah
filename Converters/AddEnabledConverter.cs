﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace CampahApp.Converters
{
    public class AddEnabledConverter : IValueConverter
    {
        public object Convert(object value, Type typeTarget, object param, CultureInfo culture)
        {
            return Modes.Stopped == (Modes)value;
        }

        public object ConvertBack(object value, Type typeTarget, object param, CultureInfo culture)
        {
            return null;
        }
    }
}