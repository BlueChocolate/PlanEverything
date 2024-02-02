using System.Globalization;
using System.Windows.Data;

namespace PlanEverything.Converters
{
    public class EnumToIntConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Enum ? (int)value : null;
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is int ? (Enum)Enum.ToObject(targetType, value) : null;
        }
    }
}
