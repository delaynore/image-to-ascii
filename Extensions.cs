using System.Drawing;

namespace AsciiImage.Extensions
{
    public static class Extensions
    {
        public static Bitmap ToGrayscale(this Bitmap bitmap)
        {
            var grayscale = new Bitmap(bitmap.Width, bitmap.Height);
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var pixel = bitmap.GetPixel(x, y);
                    var color = Rgb2Gray(pixel);
                    grayscale.SetPixel(x, y, color);
                }
            }
            return grayscale;
        }

        public static Bitmap ToSize(this Bitmap bitmap, Size size)
        {
            return new Bitmap(bitmap, size);
        }

        public static Color Rgb2Gray(Color rgb)
        {
            var gray = Convert.ToInt32(0.299 * rgb.R + 0.587 * rgb.G + 0.114 * rgb.B);
            return Color.FromArgb(rgb.A, gray, gray, gray);
        }
    }
}
