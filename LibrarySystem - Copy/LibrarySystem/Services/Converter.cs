using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Data;


namespace LibrarySystem.Services
{
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string gender = value as string;
            string parameterString = parameter as string;

            return gender == parameterString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isChecked = (bool)value;
            string parameterString = parameter as string;

            if (isChecked)
            {
                return parameterString;
            }
            else
            {
                // You might want to handle the case when the radio button is unchecked.
                return null;
            }
        }
    }
}
