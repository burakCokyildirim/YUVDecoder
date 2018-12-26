using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        byte[][] frames = null;
        public HomePage()
        {
            InitializeComponent();
        }

        private void openFile_Click(object sender, EventArgs e)
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
            }
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
                    yuvRate = 3.0 / 2.0;
                    break;
                case FileInfo.yuvType.y444:
                    yuvRate = 3.0 / 2.0;
                    break;
            }
            double frameCount = buffer.Length / (FileInfo.weight * FileInfo.height * yuvRate);
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
    }
}
