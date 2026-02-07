using System;
using System.Windows;
using System.Windows.Data;
using AstralNovastrom.src.Models;

namespace AstralNovastrom.src.Converters
{
    public class LogStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is LogType logType)
            {
                return logType switch
                {
                    LogType.Info => Application.Current.FindResource("LogInfo"),
                    LogType.Warning => Application.Current.FindResource("LogWarning"),
                    LogType.Critical => Application.Current.FindResource("LogCritical"),
                    _ => Application.Current.FindResource("LogInfo")
                };
            }
            return Application.Current.FindResource("LogInfo");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
