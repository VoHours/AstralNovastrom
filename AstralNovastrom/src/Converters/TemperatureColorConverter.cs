using System;
using System.Windows.Data;
using System.Windows.Media;

namespace AstralNovastrom.src.Converters
{
    public class TemperatureColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is double temperature)
            {
                if (temperature >= 100) return new SolidColorBrush(Color.FromArgb(255, 255, 85, 85)); // 红色
                if (temperature >= 80) return new SolidColorBrush(Color.FromArgb(255, 255, 170, 0)); // 橙色
                if (temperature >= 60) return new SolidColorBrush(Color.FromArgb(255, 255, 255, 0)); // 黄色
                if (temperature >= 40) return new SolidColorBrush(Color.FromArgb(255, 0, 255, 136)); // 绿色
                if (temperature >= 20) return new SolidColorBrush(Color.FromArgb(255, 0, 170, 255)); // 蓝色
                return new SolidColorBrush(Color.FromArgb(255, 170, 0, 255)); // 紫色
            }
            return new SolidColorBrush(Color.FromArgb(255, 170, 170, 170));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
