using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YUVDecoder
{
    public partial class Form1 : Form
    {
        public Form1()
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
                FileStream file = new FileStream(dialog.FileName, FileMode.Open);

            }
        }
    }
}
