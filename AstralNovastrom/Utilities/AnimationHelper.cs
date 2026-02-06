using System.Windows.Media.Animation;
using System.Windows;

namespace AstralNovastrom.Utilities
{
    public static class AnimationHelper
    {
        public static void StartOpacityAnimation(UIElement element, double from, double to, double duration)
        {
            var animation = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(duration)
            };

            element.BeginAnimation(UIElement.OpacityProperty, animation);
        }

        public static void StartBlinkAnimation(UIElement element, double duration = 1.0)
        {
            var animation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.3,
                Duration = TimeSpan.FromSeconds(duration),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };

            element.BeginAnimation(UIElement.OpacityProperty, animation);
        }

        public static void StartPulseAnimation(UIElement element, double duration = 1.0)
        {
            var scaleXAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 1.05,
                Duration = TimeSpan.FromSeconds(duration),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };

            var scaleYAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 1.05,
                Duration = TimeSpan.FromSeconds(duration),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };

            element.RenderTransform = new System.Windows.Media.ScaleTransform();
            element.BeginAnimation(System.Windows.Media.ScaleTransform.ScaleXProperty, scaleXAnimation);
            element.BeginAnimation(System.Windows.Media.ScaleTransform.ScaleYProperty, scaleYAnimation);
        }

        public static void StartFadeInAnimation(UIElement element, double duration = 0.5)
        {
            var animation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = TimeSpan.FromSeconds(duration)
            };

            element.BeginAnimation(UIElement.OpacityProperty, animation);
        }

        public static void StartSlideInAnimation(UIElement element, double duration = 0.3)
        {
            var opacityAnimation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = TimeSpan.FromSeconds(duration)
            };

            var translateAnimation = new DoubleAnimation
            {
                From = -50,
                To = 0,
                Duration = TimeSpan.FromSeconds(duration)
            };

            element.RenderTransform = new System.Windows.Media.TranslateTransform();
            element.BeginAnimation(UIElement.OpacityProperty, opacityAnimation);
            element.BeginAnimation(System.Windows.Media.TranslateTransform.XProperty, translateAnimation);
        }
    }
}