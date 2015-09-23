using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace IBoxCorp.PrinterService
{
    internal static class ImageConverter
    {
        public static void ResizeToRatio(string srcImagePath, string dstImagePath, double aspectRatio)
        {
            var image = Image.FromFile(srcImagePath);

            var newHeight = 0;
            var newWidth = 0;
            if (image.Height > image.Width)
            {
                newHeight = image.Height;
                newWidth = (int)(newHeight / aspectRatio);
            }
            else
            {
                newWidth = image.Width;
                newHeight = (int)(newWidth / aspectRatio);
            }

            var newImage = ResizeToRatio(image, newHeight, newWidth);
            newImage.Save(dstImagePath);
        }

        private static Image ResizeToRatio(Image image, int newHeight, int newWidth)
        {
            var rect = new Rectangle(0, 0, newWidth, newHeight);
            var newImage = new Bitmap(newWidth, newHeight);

            newImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, rect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return newImage;
        }
    }
}
