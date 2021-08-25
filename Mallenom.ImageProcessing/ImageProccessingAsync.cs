using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace Mallenom.ImageProcessing
{
    public class ImageProccessingAsync
    {
        private static object _locker = new object();
        public static bool _taskStatusRunning { get; private set; }

        /// <summary>Накладывает градиент.</summary>
        public static async Task<Bitmap> GradientProccessing(Bitmap sourceBitmap, Image sourceImage)
        {
            _taskStatusRunning = true;

            var task = await Task.Run(() =>
            {
                lock (_locker)
                {
                    Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
                    Graphics graphics = Graphics.FromImage(resultBitmap);

                    graphics.DrawImage(
                            sourceImage,
                            new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height),
                            0,
                            0,
                            sourceBitmap.Width,
                            sourceBitmap.Height,
                            GraphicsUnit.Pixel);

                    LinearGradientBrush brush = new LinearGradientBrush(
                            new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height),
                            Color.FromArgb(128, Color.Black),
                            Color.FromArgb(128, Color.White),
                            LinearGradientMode.ForwardDiagonal);

                    graphics.FillRectangle(brush, 0, 0, sourceImage.Width, sourceImage.Height);

                    brush.Dispose();
                    graphics.Dispose();

                    return resultBitmap;
                }
            });
            _taskStatusRunning = false;
            return task;
        }

        // <summary>Изменяет контраст.</summary>
        public static async Task<Bitmap> ContrastProccessing(Bitmap sourceBitmap, float contrast)
        {
            _taskStatusRunning = true;
            var task = await Task.Run(() =>
            {
                lock (_locker)
                {
                    Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
                    Graphics graphics = Graphics.FromImage(resultBitmap);
                    ImageAttributes imageAttributes = new ImageAttributes();
                    ColorMatrix colorMatrix = new ColorMatrix(new float[][]{
                                           new float[] { contrast, 0f, 0f, 0f, 0f },
                                           new float[] { 0f, contrast, 0f, 0f, 0f },
                                           new float[] { 0f, 0f, contrast, 0f, 0f },
                                           new float[] { 0f,0f, 0f, 1f, 0f },
                                           new float[] { 0.001f, 0.001f, 0.001f, 0f, 1f } });

                    imageAttributes.SetColorMatrix(colorMatrix);

                    graphics.DrawImage(
                            sourceBitmap,
                            new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height),
                            0,
                            0,
                            sourceBitmap.Width,
                            sourceBitmap.Height,
                            GraphicsUnit.Pixel,
                            imageAttributes);

                    graphics.Dispose();
                    imageAttributes.Dispose();

                    return resultBitmap;
                }
            });
            _taskStatusRunning = false;
            return task;
        }
    }
}
