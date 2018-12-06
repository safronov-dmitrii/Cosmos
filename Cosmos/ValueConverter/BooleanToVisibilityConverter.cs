using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Cosmos
{
    [ValueConversion(typeof(Visibility), typeof(bool))]
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public static BooleanToVisibilityConverter Instance = new BooleanToVisibilityConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                return ((bool)value) ? Visibility.Visible : Visibility.Hidden;
            else
                return ((bool)value) ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
