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
        Bitmap newBitmap;
        float contrast = 0;

        public Form1()
        {
            InitializeComponent();

            trackBarContast.Enabled = saveAsToolStripMenuItem.Enabled = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                menuStrip1.Enabled = false;

                pictureBox1.Image = null;
                pictureBox1.Image =  newBitmap  =  new Bitmap(openFileDialog1.FileName);

                menuStrip1.Enabled = saveAsToolStripMenuItem.Enabled = true;
            }
        }

        private void contrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;

            trackBarContast.Enabled = true;
        }

        private async void gradientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;

            trackBarContast.Enabled = false;

            await Task.Run(() => { GradientProccessing(newBitmap); });
        }

        /// <summary>Изменяет контраст.</summary>
        private void ContrastProcessing(Bitmap newBitmap)
        {
            Invoke(new Action(() =>
            {
                contrast = 0.04f * trackBarContast.Value;

                Bitmap bm = new Bitmap(newBitmap.Width, newBitmap.Height);
                Graphics g = Graphics.FromImage(bm);
                ImageAttributes ia = new ImageAttributes();

                ColorMatrix cm = new ColorMatrix(new float[][]{
                                        new float[] { contrast, 0f, 0f, 0f, 0f },
                                        new float[] { 0f, contrast, 0f, 0f, 0f },
                                        new float[] { 0f, 0f, contrast, 0f, 0f },
                                        new float[] { 0f,0f, 0f, 1f, 0f },
                                        new float[] { 0.001f, 0.001f, 0.001f, 0f, 1f } });

                ia.SetColorMatrix(cm);

                g.DrawImage(newBitmap, new Rectangle(0, 0, newBitmap.Width, newBitmap.Height), 0, 0, newBitmap.Width, newBitmap.Height, GraphicsUnit.Pixel, ia);

                g.Dispose();
                ia.Dispose();

                pictureBox1.Image = bm;
        }));

        }
        /// <summary>Накладывает градиент.</summary>
        private void GradientProccessing(Bitmap newBitmap)
        {
            if (newBitmap == null & pictureBox1.Image == null) return;

            Bitmap bm = new Bitmap(newBitmap.Width, newBitmap.Height);
            Graphics g = Graphics.FromImage(bm);

            g.DrawImage(pictureBox1.Image, new Rectangle(0, 0, newBitmap.Width, newBitmap.Height), 0, 0, newBitmap.Width, newBitmap.Height, GraphicsUnit.Pixel);


            LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(0, 0, newBitmap.Width, newBitmap.Height),
                Color.FromArgb(128, Color.Black),
                Color.FromArgb(128, Color.White),
                LinearGradientMode.ForwardDiagonal);

            g.FillRectangle(brush, 0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height);

            pictureBox1.Image = bm;

            brush.Dispose();
        }

  

        private async void trackBarContast_Scroll(object sender, EventArgs e)
        {
            if (newBitmap == null) return;

            await Task.Run(() => { ContrastProcessing(newBitmap); });
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            
            pictureBox1.Image.Save(saveFileDialog1.FileName);
        }
    }
}
