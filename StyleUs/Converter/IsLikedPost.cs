using System;
using Xamarin.Forms;

namespace StyleUs.Converter
{
    public class IsLikedPost : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return System.Convert.ToBoolean(value) ? "heart_red.png" : "heart_dark.png";
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return System.Convert.ToString(value) == "heart_red.png" ? "heart_red.png" : "heart_dark.png";
        }
    }
}