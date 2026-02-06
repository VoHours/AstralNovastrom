using System;
using System.Windows.Data;
using System.Windows.Media;

namespace AstralNovastrom.Converters
{
    public class EfficiencyColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is double efficiency)
            {
                if (efficiency >= 95) return new SolidColorBrush(Color.FromArgb(255, 255, 85, 85)); // 红色
                if (efficiency >= 90) return new SolidColorBrush(Color.FromArgb(255, 255, 170, 0)); // 橙色
                if (efficiency >= 80) return new SolidColorBrush(Color.FromArgb(255, 255, 255, 0)); // 黄色
                if (efficiency >= 70) return new SolidColorBrush(Color.FromArgb(255, 170, 255, 0)); // 黄绿色
                return new SolidColorBrush(Color.FromArgb(255, 0, 255, 136)); // 绿色
            }
            return Brushes.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}