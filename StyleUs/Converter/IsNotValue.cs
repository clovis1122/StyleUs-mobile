using System;
using Xamarin.Forms;

namespace StyleUs.Converter
{
    public class IsNotValue : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) {
                return true;
            }

            return !System.Convert.ToBoolean(value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return System.Convert.ToBoolean(value);
        }
    }
}