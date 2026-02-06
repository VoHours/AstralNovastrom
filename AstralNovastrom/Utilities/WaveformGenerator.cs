using System.Windows.Media;

namespace AstralNovastrom.Utilities
{
    public static class WaveformGenerator
    {
        public static PathGeometry GenerateSineWave(double width, double height, int points, double frequency = 1.0, double amplitude = 0.5)
        {
            PathGeometry geometry = new PathGeometry();
            PathFigure figure = new PathFigure();
            figure.StartPoint = new System.Windows.Point(0, height / 2);

            double step = width / (points - 1);
            for (int i = 1; i < points; i++)
            {
                double x = i * step;
                double y = height / 2 + Math.Sin(i * step * frequency * 0.01) * height * amplitude;
                figure.Segments.Add(new LineSegment(new System.Windows.Point(x, y), true));
            }

            geometry.Figures.Add(figure);
            return geometry;
        }

        public static PathGeometry GenerateTriangleWave(double width, double height, int points, double frequency = 1.0)
        {
            PathGeometry geometry = new PathGeometry();
            PathFigure figure = new PathFigure();
            figure.StartPoint = new System.Windows.Point(0, height / 2);

            double step = width / (points - 1);
            double period = width / frequency;
            for (int i = 1; i < points; i++)
            {
                double x = i * step;
                double phase = (x % period) / period;
                double y;

                if (phase < 0.25)
                    y = height / 2 + phase * 4 * height / 2;
                else if (phase < 0.75)
                    y = height / 2 + (0.5 - phase) * 4 * height / 2;
                else
                    y = height / 2 - (1.0 - phase) * 4 * height / 2;

                figure.Segments.Add(new LineSegment(new System.Windows.Point(x, y), true));
            }

            geometry.Figures.Add(figure);
            return geometry;
        }

        public static PathGeometry GenerateSquareWave(double width, double height, int points, double frequency = 1.0)
        {
            PathGeometry geometry = new PathGeometry();
            PathFigure figure = new PathFigure();
            figure.StartPoint = new System.Windows.Point(0, height / 4);

            double step = width / (points - 1);
            double period = width / frequency;
            for (int i = 1; i < points; i++)
            {
                double x = i * step;
                double phase = (x % period) / period;
                double y = phase < 0.5 ? height / 4 : height * 3 / 4;

                figure.Segments.Add(new LineSegment(new System.Windows.Point(x, y), true));
            }

            geometry.Figures.Add(figure);
            return geometry;
        }

        public static PathGeometry GenerateRandomWave(double width, double height, int points, double randomness = 0.5)
        {
            PathGeometry geometry = new PathGeometry();
            PathFigure figure = new PathFigure();
            figure.StartPoint = new System.Windows.Point(0, height / 2);

            Random random = new Random();
            double step = width / (points - 1);
            double lastY = height / 2;

            for (int i = 1; i < points; i++)
            {
                double x = i * step;
                double y = lastY + (random.NextDouble() - 0.5) * height * randomness;
                y = Math.Max(0, Math.Min(height, y));
                lastY = y;

                figure.Segments.Add(new LineSegment(new System.Windows.Point(x, y), true));
            }

            geometry.Figures.Add(figure);
            return geometry;
        }

        public static PathGeometry GenerateCombinedWave(double width, double height, int points)
        {
            PathGeometry geometry = new PathGeometry();
            PathFigure figure = new PathFigure();
            figure.StartPoint = new System.Windows.Point(0, height / 2);

            double step = width / (points - 1);
            for (int i = 1; i < points; i++)
            {
                double x = i * step;
                double y1 = Math.Sin(i * step * 0.01) * height * 0.2;
                double y2 = Math.Sin(i * step * 0.02) * height * 0.15;
                double y3 = Math.Sin(i * step * 0.005) * height * 0.25;
                double y = height / 2 + y1 + y2 + y3;

                figure.Segments.Add(new LineSegment(new System.Windows.Point(x, y), true));
            }

            geometry.Figures.Add(figure);
            return geometry;
        }
    }
}