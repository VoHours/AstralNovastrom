using System;
using System.Windows;
using System.Windows.Data;

namespace AstralNovastrom.Converters
{
    public class BottomCornersConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is CornerRadius radius)
            {
                return new CornerRadius(0, 0, radius.BottomRight, radius.BottomLeft);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TopCornersConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is CornerRadius radius)
            {
                return new CornerRadius(radius.TopLeft, radius.TopRight, 0, 0);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}