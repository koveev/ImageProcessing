using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mallenom.ImageProcessing
{
    public partial class Form1 : Form
    {
        private static Bitmap _newBitmap;
		private static float _contrast = 0;

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
            if (newImage.Image == null || ImageProccessingAsync._taskStatusRunning == true) return;

            processedImage.Visible = true;
            trackBarContrast.Enabled = newImage.Visible = false;

            Image img = processedImage.Image;
            processedImage.Image = await ImageProccessingAsync.GradientProccessing(_newBitmap, newImage.Image);

            if (img != null) img.Dispose();
        }
		
        private async void TrackBarContrastMouseUp(object sender, MouseEventArgs e)
        {
            processedImage.Image = await ImageProccessingAsync.ContrastProccessing(_newBitmap, _contrast);
        }

        private async void TrackBarContrastScroll(object sender, EventArgs e)
        {
            if (_newBitmap == null || ImageProccessingAsync._taskStatusRunning == true) return;

            _contrast = 0.04f * trackBarContrast.Value;
            Image img = processedImage.Image;
            processedImage.Image = await ImageProccessingAsync.ContrastProccessing(_newBitmap, _contrast);
            
            if (img != null) img.Dispose();
        }

        private void SaveAsMenuItemClick(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;

            processedImage.Image.Save(saveFileDialog.FileName);
        }
	}   
}
