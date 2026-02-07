using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace AstralNovastrom.src.Utilities
{
    public static class Extensions
    {
        public static T Clamp<T>(this T value, T min, T max) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0) return min;
            if (value.CompareTo(max) > 0) return max;
            return value;
        }

        public static double Map(this double value, double fromMin, double fromMax, double toMin, double toMax)
        {
            return (value - fromMin) * (toMax - toMin) / (fromMax - fromMin) + toMin;
        }

        public static string ToFormattedString(this double value, int decimalPlaces = 2)
        {
            return value.ToString($"F{decimalPlaces}");
        }

        public static string ToPercentageString(this double value, int decimalPlaces = 1)
        {
            return (value * 100).ToString($"F{decimalPlaces}") + "%";
        }

        public static string ToTimeString(this TimeSpan timeSpan)
        {
            if (timeSpan.Hours > 0)
                return $"{timeSpan.Hours}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
            else if (timeSpan.Minutes > 0)
                return $"{timeSpan.Minutes}:{timeSpan.Seconds:D2}";
            else
                return $"{timeSpan.Seconds}.{timeSpan.Milliseconds / 10:D2}";
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }

        public static bool IsVisibleToUser(this UIElement element)
        {
            if (!element.IsVisible)
                return false;

            Rect bounds = element.TransformToAncestor(Application.Current.MainWindow).TransformBounds(new Rect(0, 0, element.RenderSize.Width, element.RenderSize.Height));
            Rect windowBounds = new Rect(0, 0, Application.Current.MainWindow.ActualWidth, Application.Current.MainWindow.ActualHeight);

            return bounds.IntersectsWith(windowBounds);
        }

        public static T? FindVisualParent<T>(this DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);
            if (parentObject == null) return null;

            if (parentObject is T parent) return parent;
            else return FindVisualParent<T>(parentObject);
        }

        public static T? FindVisualChild<T>(this DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is T tChild) return tChild;
                else
                {
                    T? childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null) return childOfChild;
                }
            }
            return null;
        }

        public static void ApplyShadow(this UIElement element, Color color, double blurRadius = 10, double shadowDepth = 5)
        {
            element.Effect = new DropShadowEffect
            {
                Color = color,
                BlurRadius = blurRadius,
                ShadowDepth = shadowDepth
            };
        }

        public static void RemoveShadow(this UIElement element)
        {
            element.Effect = null;
        }
    }
}
