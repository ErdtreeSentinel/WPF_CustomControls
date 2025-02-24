using System;
using System.Globalization;
using System.Windows.Data;

namespace WPF_CustomControls.Converters
{
    public class SubtractConverter : IValueConverter
    {
        public double SubtractValue { get; set; } = 2.0;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double d)
            {
                return d - SubtractValue;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
