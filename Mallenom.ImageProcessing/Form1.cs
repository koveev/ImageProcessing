using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mallenom.ImageProcessing
{
    public partial class Form1 : Form
    {
        private Bitmap _newBitmap;
        private float _contrast = 0;
        private static object _locker = new object();
        
        public Form1()
        {
            InitializeComponent();
            trackBarContrast.Enabled = _miSaveAsMenuItem.Enabled = processedImage.Visible = false;
        }

        private void OpenMenuItemClick(object sender, EventArgs e)
        {
            if(_newBitmap != null) _newBitmap.Dispose();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _mnuMenuStrip.Enabled = processedImage.Visible = false;
                newImage.Image = processedImage.Image = null;

                newImage.Image = _newBitmap = new Bitmap(openFileDialog.FileName);

                _mnuMenuStrip.Enabled = _miSaveAsMenuItem.Enabled = newImage.Visible = true;
            }
        }

        private void ContrastMenuItemClick(object sender, EventArgs e)
        {
            if (newImage.Image == null) return;

            newImage.Visible = false;
            trackBarContrast.Enabled = processedImage.Visible = true;
        }

        private async void GradientMenuItemClick(object sender, EventArgs e)
        {
            if (newImage.Image == null) return;

            processedImage.Visible = true;
            trackBarContrast.Enabled = newImage.Visible = false;

            await Task.Run(() => { GradientProccessing(_newBitmap); });
        }

        /// <summary>Изменяет контраст.</summary>
        Task ContrastProccessing(Bitmap newBitmap)
        {  
            var task = new Task(() =>
            { 
                lock (_locker)
                {
                    Bitmap bitmap = new Bitmap(newBitmap.Width, newBitmap.Height);
                    Graphics graphics = Graphics.FromImage(newBitmap);
                    ImageAttributes imageAttributes = new ImageAttributes();
                    ColorMatrix colorMatrix = new ColorMatrix(new float[][]{
                                        new float[] { _contrast, 0f, 0f, 0f, 0f },
                                        new float[] { 0f, _contrast, 0f, 0f, 0f },
                                        new float[] { 0f, 0f, _contrast, 0f, 0f },
                                        new float[] { 0f,0f, 0f, 1f, 0f },
                                        new float[] { 0.001f, 0.001f, 0.001f, 0f, 1f } });


                    imageAttributes.SetColorMatrix(colorMatrix);

                    graphics.DrawImage(
                        newBitmap,
                        new Rectangle(0, 0, newBitmap.Width, newBitmap.Height),
                        0,
                        0,
                        newBitmap.Width,
                        newBitmap.Height,
                        GraphicsUnit.Pixel,
                        imageAttributes);

                    processedImage.Image = newBitmap;

                    graphics.Dispose();
                    imageAttributes.Dispose();
                }
            });
            task.Start();
            return task;
        }

        /// <summary>Накладывает градиент.</summary>
        Task GradientProccessing(Bitmap newBitmap)
        {
            var task = new Task(() =>
            {
                lock (_locker)
                {
                    Bitmap bitmap = new Bitmap(newBitmap.Width, newBitmap.Height);
                    Graphics graphics = Graphics.FromImage(bitmap);

                    graphics.DrawImage(
                        newImage.Image,
                        new Rectangle(0, 0, newBitmap.Width, newBitmap.Height),
                        0,
                        0,
                        newBitmap.Width,
                        newBitmap.Height,
                        GraphicsUnit.Pixel);


                    LinearGradientBrush brush = new LinearGradientBrush(
                        new Rectangle(0, 0, newBitmap.Width, newBitmap.Height),
                        Color.FromArgb(128, Color.Black),
                        Color.FromArgb(128, Color.White),
                        LinearGradientMode.ForwardDiagonal);

                    graphics.FillRectangle(brush, 0, 0, newImage.Image.Width, newImage.Image.Height);

                    processedImage.Image = bitmap;

                    brush.Dispose();
                    graphics.Dispose(); 
                }
            });
            task.Start();
            return task;
        }

        private async void TrackBarContrastScroll(object sender, EventArgs e)
        {
            if (_newBitmap == null) return;

            _contrast = 0.04f * trackBarContrast.Value;
            await ContrastProccessing(_newBitmap);
        }

        private void SaveAsMenuItemClick(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;

            processedImage.Image.Save(saveFileDialog.FileName);
        }
    }
}
