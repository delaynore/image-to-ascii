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
                    var avg = (pixel.R + pixel.G + pixel.B) / 3;
                    var color = Color.FromArgb(pixel.A, avg, avg, avg);
                    grayscale.SetPixel(x, y, color);
                }
            }
            return grayscale;
        }

        public static Bitmap ToSize(this Bitmap bitmap, Size size)
        {
            return new Bitmap(bitmap, size);
        }

    }
}
