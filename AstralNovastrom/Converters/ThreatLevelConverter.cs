using System;
using System.Windows.Data;
using System.Windows.Media;
using AstralNovastrom.Models;

namespace AstralNovastrom.Converters
{
    public class ThreatLevelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is ThreatLevel threatLevel)
            {
                return threatLevel switch
                {
                    ThreatLevel.Low => new SolidColorBrush(Color.FromArgb(255, 0, 255, 136)), // 绿色
                    ThreatLevel.Medium => new SolidColorBrush(Color.FromArgb(255, 255, 255, 0)), // 黄色
                    ThreatLevel.High => new SolidColorBrush(Color.FromArgb(255, 255, 170, 0)), // 橙色
                    ThreatLevel.Critical => new SolidColorBrush(Color.FromArgb(255, 255, 85, 85)), // 红色
                    _ => new SolidColorBrush(Color.FromArgb(255, 170, 170, 170)) // 灰色
                };
            }
            return new SolidColorBrush(Color.FromArgb(255, 170, 170, 170));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}