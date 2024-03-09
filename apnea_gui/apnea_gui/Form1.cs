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

            label1.Invoke(new Action(() => label1.Text = @"分析中..."));
            video_process = new ApneaVideoProcess(video_file_path);

            label1.Invoke(new Action(() => label1.Text = @"分析結束"));

        }
        private string video_file_path;
        private ApneaVideoProcess video_process;
        public Form1()
        {
            InitializeComponent();
        }

        private void opeen_file_btn_click(object sender, EventArgs e)
        {
            if (label1.Text == @"分析中...")
            {
                MessageBox.Show("其他影片正在分析中");
                return;
            }
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() != DialogResult.OK) return;
            video_file_path = dlg.FileName;
            Thread thread1 = new Thread(new_apnea_video_process_thread);
            thread1.Start();

            // label1.Text = "分析中...";
            // video_process = new ApneaVideoProcess(video_file_path);
            // label1.Text = "分析結束";

        }

        private void save_to_csv_click(object sender, EventArgs e)
        {
            //if (label1.Text != @"分析結束")
            //{
                //MessageBox.Show("請分析影片或等待影片分析結束");
                //return;
            //}

            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() != DialogResult.OK) return;
            string save_file_name = dlg.FileName;
            video_process.write_to_csv(save_file_name);
            label1.Text = $"儲存至 \"{save_file_name}\" ";
        }
    }
}
