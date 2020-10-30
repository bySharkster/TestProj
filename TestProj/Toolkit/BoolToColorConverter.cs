using System;
using System.Globalization;
using TestProj.Models;
using Xamarin.Forms;

namespace TestProj.Toolkit
{
    class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return Constants.DarkModeBackgroundColor;
            }
            else
            {
                return Constants.LightModeBackgroundColor;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
