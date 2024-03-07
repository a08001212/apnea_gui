using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apnea_gui
{
    
    public partial class Form1 : Form
    {
        private string video_file_path;
        private ApneaVideoProcess video_process;
        public Form1()
        {
            InitializeComponent();
        }

        private void opeen_file_btn_click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() != DialogResult.OK) return;
            video_file_path = dlg.FileName;
            video_process = new ApneaVideoProcess(video_file_path);
        }

        private void save_to_csv_click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() != DialogResult.OK) return;
            video_process.write_to_csv(dlg.FileName);
        }
    }
}
