using System.Windows.Media;

namespace AstralNovastrom.Utilities
{
    public static class ColorHelper
    {
        public static Color FromHex(string hex)
        {
            if (hex.StartsWith("#"))
                hex = hex.Substring(1);

            byte a = 255;
            byte r = 0;
            byte g = 0;
            byte b = 0;

            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                r = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                g = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
                b = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            }
            else if (hex.Length == 6)
            {
                r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            }

            return Color.FromArgb(a, r, g, b);
        }

        public static string ToHex(Color color)
        {
            return $"#{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        public static Color Lerp(Color from, Color to, double t)
        {
            return Color.FromArgb(
                (byte)(from.A + (to.A - from.A) * t),
                (byte)(from.R + (to.R - from.R) * t),
                (byte)(from.G + (to.G - from.G) * t),
                (byte)(from.B + (to.B - from.B) * t)
            );
        }

        public static SolidColorBrush GetBrushFromHex(string hex)
        {
            return new SolidColorBrush(FromHex(hex));
        }
    }
}