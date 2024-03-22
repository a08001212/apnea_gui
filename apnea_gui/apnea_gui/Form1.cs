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
using System.Windows.Forms.DataVisualization.Charting;
 
namespace apnea_gui
{

    public partial class Form1 : Form
    {
        private Thread analyz_video;
        private string video_file_path;
        private ApneaVideoProcess video_process;

        private Series draw_chart(string name, List<Double> data, int fps) {
            Series ret = new Series(name, data.Count + 1);
            ret.ChartType = SeriesChartType.Line;
            ret.IsValueShownAsLabel = false;
            for(int i = 0 / fps; i<data.Count; ++i)
            {
                ret.Points.AddXY((double)i / fps, data[i]);
            }

            return ret;
        }
        private void new_apnea_video_process_thread()
        {
            label1.Invoke(new Action(() => label1.Text = @"分析中..."));
            video_process = new ApneaVideoProcess(video_file_path);
            label1.Invoke(new Action(() =>
            {
                label1.Text = $"分析結束\n共呼吸暫停 {video_process.get_apnea_times()} 次";
            }));
            // draw chart
            Series rr_rate_line = draw_chart("呼吸頻率", video_process.get_rr_rate(), (int)video_process.get_fps());
            Series SD_line = draw_chart("標準差", video_process.get_SD(), 1);
            rr_rate_chart.Invoke(new Action(() =>
            {
                // clear data
                while (rr_rate_chart.Series.Count > 0) { rr_rate_chart.Series.RemoveAt(0); }
                rr_rate_chart.ChartAreas[0].AxisY.Maximum = 0.05;
                rr_rate_chart.ChartAreas[0].AxisY.Minimum = -0.05;
                rr_rate_chart.ChartAreas[0].AxisX.Title = "Times (S)";
                rr_rate_chart.Series.Add(rr_rate_line);
                rr_rate_chart.Series.Add(SD_line);
            }));

        }
        public Form1()
        {
            InitializeComponent();
            rr_rate_chart.Titles.Add("呼吸頻率");
            comList.Items.Add("COM3");
            comList.Items.Add("COM5");
        }

        private void open_file_btn_click(object sender, EventArgs e)
        {
            
            if(analyz_video != null && analyz_video.ThreadState == ThreadState.Running)
            {
                MessageBox.Show("其他影片正在分析中");
                return;
            }
            if(analyz_video != null)
            {
                analyz_video.Abort();
            }
            video_process = null;
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() != DialogResult.OK) return;
            video_file_path = dlg.FileName;

            analyz_video = new Thread(new_apnea_video_process_thread);
            analyz_video.Start();
            
        }

        private void save_to_csv_click(object sender, EventArgs e)
        {
            if (analyz_video == null) {
                MessageBox.Show("請先選擇影片");
                return;

            }
            switch (analyz_video.ThreadState)
            {
                case ThreadState.Running:
                    MessageBox.Show("影片分析中");
                    return;
                case ThreadState.Unstarted:
                    MessageBox.Show("請先選擇影片");
                    return;
            }

            SaveFileDialog dlg = new SaveFileDialog();
            if (dlg.ShowDialog() != DialogResult.OK) return;
            string save_file_name = dlg.FileName;
            if (!video_process.write_to_csv(save_file_name))
            {
                MessageBox.Show("Can't save to csv file.");
                return;
            }

            label1.Text = $"儲存至 \"{save_file_name}\" ";
        }
    }
}
