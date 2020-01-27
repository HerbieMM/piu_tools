using System;
using System.Globalization;
using Xamarin.Forms;

namespace piu_tools.Converter
{
    public class ListCountBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is int listCount)
            {
                return listCount > 0;
            }
            else
                return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
