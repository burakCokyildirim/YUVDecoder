using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YUVDecoder
{
    public partial class HomePage : Form
    {
        byte[] buffer = null;
        MemoryStream memory = null;
        static byte[][] frames = null;
        private static Bitmap[] bitmaps = null;

        public HomePage()
        {
            InitializeComponent();
        }

        private async void openFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "YUV Files (*.yuv)|*.yuv";
            dialog.ShowDialog();
            if (File.Exists(dialog.FileName))
            {
                fileName.Text = dialog.SafeFileName;
                buffer = File.ReadAllBytes(dialog.FileName);
                memory = new MemoryStream(buffer);
                parseBuffer();
                
                Bitmap a = c420(frames[0], FileInfo.width, FileInfo.height);
                bitmaps = new Bitmap[frames.Length];
                menuStrip1.Enabled = false;
                label1.Visible = true;
                await Task.Run(() =>
                {
                    for (int i = 0; i < frames.Length; i++)
                    {
                        bitmaps[i] = c420(frames[i], FileInfo.width, FileInfo.height);
                    }
                });
                label1.Visible = false;
                menuStrip1.Enabled = true;
                pictureBox.Image = a;
            }
        }

        static Bitmap c420(byte[] yuv, int width, int height)
        {
            double[,] converter = new double[3, 3] { { 1, 0, 1.4022 }, { 1, -0.3456, -0.7145 }, { 1, 1.771, 0 } };

            byte[] rgb = new byte[frames[0].Length * 3];

            int uIndex = width * height;
            int vIndex = uIndex + ((width * height) >> 2);
            int gIndex = width * height;
            int bIndex = gIndex * 2;

            int temp = 0;
            
            Bitmap bm = new Bitmap(width, height);

            int r = 0;
            int g = 0;
            int b = 0;


            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {

                    temp = (int)(yuv[y * width + x] + (yuv[vIndex + (y / 2) * (width / 2) + x / 2] - 128) * converter[0, 2]);
                    rgb[y * width + x] = clip(temp);
                    
                    temp = (int)(yuv[y * width + x] + (yuv[uIndex + (y / 2) * (width / 2) + x / 2] - 128) * converter[1, 1] + (yuv[vIndex + (y / 2) * (width / 2) + x / 2] - 128) * converter[1, 2]);
                    rgb[gIndex + y * width + x] = clip(temp);

                    temp = (int)(yuv[y * width + x] + (yuv[uIndex + (y / 2) * (width / 2) + x / 2] - 128) * converter[2, 1]);
                    rgb[bIndex + y * width + x] = clip(temp);
                    Color c = Color.FromArgb(rgb[y * width + x], rgb[gIndex + y * width + x], rgb[bIndex + y * width + x]);
                    bm.SetPixel(x, y, c);
                }
            }
            return bm;

        }
        private static byte clip(float input)
        {
            if (input < 0) input = 0;
            if (input > 255) input = 255;
            return (byte)Math.Abs(input);
        }

        private void parseBuffer()
        {
            double yuvRate = 3.0 / 2.0;
            switch (FileInfo.yuv)
            {
                case FileInfo.yuvType.y420:
                    yuvRate = 3.0 / 2.0;
                    break;
                case FileInfo.yuvType.y422:
                    yuvRate = 2.0;
                    break;
                case FileInfo.yuvType.y444:
                    yuvRate = 3.0;
                    break;
            }
            double frameCount = buffer.Length / (FileInfo.width * FileInfo.height * yuvRate);
            int frameLenght = (int) (buffer.Length / frameCount);
            frames = new byte[(int)frameCount][];
            for (int i = 0; i < (int)frameCount; i++)
            {
                frames[i] = new byte[frameLenght];
                memory.Read(frames[i], 0, frameLenght);
            }
        }

        private void settings_Click(object sender, EventArgs e)
        {
            Settings frm = new Settings();
            Enabled = false;
            switch (frm.ShowDialog())
            {
                case DialogResult.OK:
                    yuvFormatLabel.Text = frm.yuvFormat;
                    frameSizeLabel.Text = frm.frameSize;
                    Enabled = true;
                    break;
                case DialogResult.Cancel:
                    Enabled = true;
                    break;
            }
        }

        private async void playButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < bitmaps.Length; i++)
            {
                pictureBox.Image = bitmaps[i];
                await Task.Delay(20);
            }
        }
    }
}

