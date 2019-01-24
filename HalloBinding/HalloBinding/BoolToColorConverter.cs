using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace HalloBinding
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null) parameter = "pink";
            if (value != null && value is bool b && b)

                return new SolidColorBrush((Color)ColorConverter.ConvertFromString((string)parameter));
            else
                return new SolidColorBrush(Colors.Red);


            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
