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
        byte[] buffer;
        MemoryStream memory;
        static byte[][] frames;
        private static Bitmap[] bitmaps;

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

                Bitmap firstFrame = renderFrame(frames[0], FileInfo.width, FileInfo.height);
                bitmaps = new Bitmap[frames.Length];
                menuStrip1.Enabled = false;
                label1.Visible = true;
                await Task.Run(() =>
                {
                    for (int i = 0; i < frames.Length; i++)
                    {
                        bitmaps[i] = renderFrame(frames[i], FileInfo.width, FileInfo.height);
                    }
                });
                label1.Visible = false;
                menuStrip1.Enabled = true;
                saveFile.Enabled = true;
                playButton.Enabled = true;
                pictureBox.Image = firstFrame;
            }
        }

        private static Bitmap renderFrame(byte[] yuv, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int index = y * width + x;

                    byte value = clip(yuv[index]);

                    Color c = Color.FromArgb(value, value, value);

                    bitmap.SetPixel(x, y, c);
                }
            }
            return bitmap;
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
            int frameLenght = (int)(buffer.Length / frameCount);
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
            menuStrip1.Enabled = false;

            for (int i = 0; i < bitmaps.Length; i++)
            {
                pictureBox.Image = bitmaps[i];
                await Task.Delay(20);
            }

            menuStrip1.Enabled = true;
        }

        private void saveFile_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.SelectedPath + "\\";
                saveBitmaps(path);
            }
        }

        private async void saveBitmaps(string path)
        {
            
            label1.Visible = true;
            menuStrip1.Enabled = false;
            await Task.Run(() =>
            {
                for (int i = 0; i < bitmaps.Length; i++)
                    bitmaps[i].Save(path + $"{fileName.Text}_" + (i + 1) + ".bmp", ImageFormat.Bmp);
            });
            label1.Visible = false;
            menuStrip1.Enabled = true;
            MessageBox.Show(this, "Kaydedildi.");
        }
    }
}
