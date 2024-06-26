﻿using System.Globalization;
using System.Windows.Data;

namespace PlanEverything.Converters
{
    class IsNotNullToVisbilitiyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is not null ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is not null ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
        }
    }
}
