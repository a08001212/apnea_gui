using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apnea_gui
{

    public partial class Form1 : Form
    {
        private void new_apnea_video_process_thread(){
            video_process = new ApneaVideoProcess(video_file_path);
        }
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
            label1.Text = "分析中...";
            Thread thread1 = new Thread(new_apnea_video_process_thread);
            thread1.Start();
            thread1.Join();
            label1.Text = "分析結束";

        }

        private void save_to_csv_click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() != DialogResult.OK) return;
            string save_file_name = dlg.FileName;
            video_process.write_to_csv(save_file_name);
            label1.Text = $"儲存至 \"{save_file_name}\" ";
        }
    }
}
