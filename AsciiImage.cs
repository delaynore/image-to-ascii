using System.Drawing;
using AsciiImage.Extensions;

namespace AsciiImage
{
    public class AsciiImageConverter
    {
        public IGradient Gradient { get; init; }
        public Bitmap Bitmap { get; init; }
        public const int MAX_WIDTH = 1000;
        public const int MAX_HEIGHT = 1000;

        private const double ConsoleCoef = 10d / 18;
        public AsciiImageConverter(Bitmap bitmap, IGradient gradient)
        {
            Bitmap = bitmap;
            Gradient = gradient;
        }

        private static int Map(int value, Range from, Range to)
        {
            var ratio = (double)(value - from.Start.Value) / (from.End.Value - from.Start.Value);
            return (int)(to.Start.Value + (ratio * (to.End.Value - to.Start.Value)));
        }

        private Size ProcessSize()
        {
            var ratio = Math.Round((double)Bitmap.Height / Bitmap.Width, 2);

            int width, height;

            if (Bitmap.Width > MAX_WIDTH)
            {
                width = MAX_WIDTH;
                height = (int)(MAX_WIDTH * ratio);
            }
            else if (Bitmap.Height > MAX_HEIGHT)
            {
                width = (int)(MAX_WIDTH * (1 / ratio));
                height = MAX_HEIGHT;
            }
            else
            {
                width = Bitmap.Width;
                height = Bitmap.Height;
            }

            return new Size(width, (int)(height * ConsoleCoef));
        }

        public char[][] GetAsciiImage()
        {
            var grayscale = Bitmap.ToGrayscale().ToSize(ProcessSize());

            var _asciiImage = new char[grayscale.Height][];
            for (int y = 0; y < grayscale.Height; y++)
            {
                _asciiImage[y] = new char[grayscale.Width];
                for (int x = 0; x < grayscale.Width; x++)
                {
                    var index = Map(grayscale.GetPixel(x, y).R, new Range(0, 255), Gradient.GetRange());
                    _asciiImage[y][x] = Gradient[index];
                }
            }
            return _asciiImage;
        }

        public static char[][] Convert(Bitmap bitmap, IGradient gradient)
        {
            return new AsciiImageConverter(bitmap, gradient).GetAsciiImage();
        }

        public static char[][] Convert(Bitmap bitmap)
        {
            return new AsciiImageConverter(bitmap, AsciiImage.Gradient.Default).GetAsciiImage();
        }
    }
}
