using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YUVDecoder
{
    public partial class Settings : Form
    {
        public string  yuvFormat = "";
        public string frameSize = "";
        public Settings()
        {
            InitializeComponent();

            loadItems();
        }

        private void loadItems()
        {
            List<Tuple<string, int>> yuvDataSource = new List<Tuple<string, int>>();
            yuvDataSource.Add(new Tuple<string, int>("4:2:0 8-bit", (int)FileInfo.yuvType.y420));
            yuvDataSource.Add(new Tuple<string, int>("4:2:2 8-bit", (int)FileInfo.yuvType.y422));
            yuvDataSource.Add(new Tuple<string, int>("4:4:4 8-bit", (int)FileInfo.yuvType.y444));

            yuvCB.DisplayMember = "Item1";
            yuvCB.ValueMember = "Item2";
            yuvCB.DataSource = yuvDataSource;
            yuvCB.SelectedValue = (int)FileInfo.yuv;

            List<Tuple<string, int>> sizeDataSource = new List<Tuple<string, int>>();
            sizeDataSource.Add(new Tuple<string, int>("Custom Size", 0));
            sizeDataSource.Add(new Tuple<string, int>("QCIF (176, 144)", 1));
            sizeDataSource.Add(new Tuple<string, int>("QVGA (320, 240)", 2));
            sizeDataSource.Add(new Tuple<string, int>("WQVGA (416, 240)", 3));
            sizeDataSource.Add(new Tuple<string, int>("CIF (352, 288)", 4));
            sizeDataSource.Add(new Tuple<string, int>("VGA (640, 880)", 5));
            sizeDataSource.Add(new Tuple<string, int>("WVGA (832, 480)", 6));
            sizeDataSource.Add(new Tuple<string, int>("4CIF (704, 576)", 7));
            sizeDataSource.Add(new Tuple<string, int>("ITU R.BT601 (720, 576)", 8));
            sizeDataSource.Add(new Tuple<string, int>("720i/p (1280, 720)", 9));
            sizeDataSource.Add(new Tuple<string, int>("1080i/p (1920, 720)", 10));
            sizeDataSource.Add(new Tuple<string, int>("4k (3840, 2160)", 11));
            sizeDataSource.Add(new Tuple<string, int>("XGA (1024, 768)", 12));
            sizeDataSource.Add(new Tuple<string, int>("XGA+ (1280, 960)", 13));
            

            sizeCB.DisplayMember = "Item1";
            sizeCB.ValueMember = "Item2";
            sizeCB.DataSource = sizeDataSource;
            sizeCB.SelectedValue = FileInfo.sizeType;
            sizeWidht.Value = FileInfo.weight;
            sizeHeight.Value = FileInfo.height;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            switch (yuvCB.SelectedIndex)
            {
                case 0:
                    FileInfo.yuv = FileInfo.yuvType.y420;
                    break;
                case 1:
                    FileInfo.yuv = FileInfo.yuvType.y422;
                    break;
                case 2:
                    FileInfo.yuv = FileInfo.yuvType.y444;
                    break;
                default:
                    break;
            }

            switch (sizeCB.SelectedIndex)
            {
                case 0:
                    FileInfo.sizeType = sizeCB.SelectedIndex;
                    if (sizeHeight.Value == 0 || sizeWidht.Value == 0)
                    {
                        return;
                    }
                    FileInfo.weight = (int) sizeWidht.Value;
                    FileInfo.height = (int) sizeHeight.Value;
                    break;
                default:
                    FileInfo.sizeType = sizeCB.SelectedIndex;
                    FileInfo.weight = Convert.ToInt32(((List<Tuple<string,int>>)sizeCB.DataSource)[sizeCB.SelectedIndex].Item1.Split('(')[1].Split(',')[0]);
                    FileInfo.height = Convert.ToInt32(((List<Tuple<string, int>>)sizeCB.DataSource)[sizeCB.SelectedIndex].Item1.Split('(')[1].Split(',')[1].Split(')')[0]);
                    break;
            }

            yuvFormat = ((List<Tuple<string, int>>) yuvCB.DataSource)[yuvCB.SelectedIndex].Item1;
            frameSize = $"{FileInfo.weight}x{FileInfo.height}";
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void sizeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (sizeCB.SelectedIndex)
            {
                case 0:
                    sizeWidht.Value = 0;
                    sizeHeight.Value = 0;
                    break;
                default:
                    sizeWidht.Value = Convert.ToInt32(((List<Tuple<string, int>>)sizeCB.DataSource)[sizeCB.SelectedIndex].Item1.Split('(')[1].Split(',')[0]);
                    sizeHeight.Value = Convert.ToInt32(((List<Tuple<string, int>>)sizeCB.DataSource)[sizeCB.SelectedIndex].Item1.Split('(')[1].Split(',')[1].Split(')')[0]);
                    break;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Hide();
        }
    }
}
