
namespace Mallenom.ImageProcessing
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.processedImage = new System.Windows.Forms.PictureBox();
			this.newImage = new System.Windows.Forms.PictureBox();
			this._mnuMenuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this._miSaveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contrastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.gradientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.trackBarContrast = new System.Windows.Forms.TrackBar();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.processedImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.newImage)).BeginInit();
			this._mnuMenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.processedImage);
			this.splitContainer1.Panel1.Controls.Add(this.newImage);
			this.splitContainer1.Panel1.Controls.Add(this._mnuMenuStrip);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Panel2.Controls.Add(this.label1);
			this.splitContainer1.Panel2.Controls.Add(this.trackBarContrast);
			this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
			this.splitContainer1.Size = new System.Drawing.Size(603, 434);
			this.splitContainer1.SplitterDistance = 330;
			this.splitContainer1.TabIndex = 0;
			// 
			// processedImage
			// 
			this.processedImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.processedImage.Location = new System.Drawing.Point(0, 24);
			this.processedImage.Name = "processedImage";
			this.processedImage.Size = new System.Drawing.Size(601, 304);
			this.processedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.processedImage.TabIndex = 3;
			this.processedImage.TabStop = false;
			// 
			// newImage
			// 
			this.newImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.newImage.Location = new System.Drawing.Point(0, 24);
			this.newImage.Name = "newImage";
			this.newImage.Size = new System.Drawing.Size(601, 304);
			this.newImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.newImage.TabIndex = 0;
			this.newImage.TabStop = false;
			// 
			// _mnuMenuStrip
			// 
			this._mnuMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.actionsToolStripMenuItem});
			this._mnuMenuStrip.Location = new System.Drawing.Point(0, 0);
			this._mnuMenuStrip.Name = "_mnuMenuStrip";
			this._mnuMenuStrip.Size = new System.Drawing.Size(601, 24);
			this._mnuMenuStrip.TabIndex = 1;
			this._mnuMenuStrip.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuItem,
            this._miSaveAsMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// openMenuItem
			// 
			this.openMenuItem.Name = "openMenuItem";
			this.openMenuItem.Size = new System.Drawing.Size(112, 22);
			this.openMenuItem.Text = "Open";
			this.openMenuItem.Click += new System.EventHandler(this.OpenMenuItemClick);
			// 
			// _miSaveAsMenuItem
			// 
			this._miSaveAsMenuItem.Name = "_miSaveAsMenuItem";
			this._miSaveAsMenuItem.Size = new System.Drawing.Size(112, 22);
			this._miSaveAsMenuItem.Text = "Save as";
			this._miSaveAsMenuItem.Click += new System.EventHandler(this.SaveAsMenuItemClick);
			// 
			// actionsToolStripMenuItem
			// 
			this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contrastToolStripMenuItem,
            this.gradientToolStripMenuItem});
			this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
			this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.actionsToolStripMenuItem.Text = "Actions";
			// 
			// contrastToolStripMenuItem
			// 
			this.contrastToolStripMenuItem.Name = "contrastToolStripMenuItem";
			this.contrastToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
			this.contrastToolStripMenuItem.Text = "Contrast";
			this.contrastToolStripMenuItem.Click += new System.EventHandler(this.ContrastMenuItemClick);
			// 
			// gradientToolStripMenuItem
			// 
			this.gradientToolStripMenuItem.Name = "gradientToolStripMenuItem";
			this.gradientToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
			this.gradientToolStripMenuItem.Text = "Gradient";
			this.gradientToolStripMenuItem.Click += new System.EventHandler(this.GradientMenuItemClick);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 77);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(0, 13);
			this.label2.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(11, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Contast";
			// 
			// trackBarContrast
			// 
			this.trackBarContrast.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trackBarContrast.AutoSize = false;
			this.trackBarContrast.BackColor = System.Drawing.SystemColors.Control;
			this.trackBarContrast.Location = new System.Drawing.Point(104, 38);
			this.trackBarContrast.Maximum = 50;
			this.trackBarContrast.Name = "trackBarContrast";
			this.trackBarContrast.Size = new System.Drawing.Size(464, 24);
			this.trackBarContrast.TabIndex = 1;
			this.trackBarContrast.TickFrequency = 5;
			this.trackBarContrast.Scroll += new System.EventHandler(this.TrackBarContrastScroll);
			this.trackBarContrast.MouseCaptureChanged += new System.EventHandler(this.TrackBarContrastMouseCaptureChanged);
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Image | *.bmp;*.png;*.jpg";
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "Jpeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(603, 434);
			this.Controls.Add(this.splitContainer1);
			this.MainMenuStrip = this._mnuMenuStrip;
			this.Name = "Form1";
			this.Text = "Image Processing";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.processedImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.newImage)).EndInit();
			this._mnuMenuStrip.ResumeLayout(false);
			this._mnuMenuStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox newImage;
        private System.Windows.Forms.TrackBar trackBarContrast;
        private System.Windows.Forms.MenuStrip _mnuMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contrastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradientToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem _miSaveAsMenuItem;
        private System.Windows.Forms.PictureBox processedImage;
    }
}

