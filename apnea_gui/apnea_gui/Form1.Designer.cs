﻿namespace apnea_gui
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.open_file_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comList = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.rr_rate_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.rr_rate_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // open_file_btn
            // 
            this.open_file_btn.Location = new System.Drawing.Point(1903, 427);
            this.open_file_btn.Name = "open_file_btn";
            this.open_file_btn.Size = new System.Drawing.Size(192, 75);
            this.open_file_btn.TabIndex = 0;
            this.open_file_btn.Text = "載入影片";
            this.open_file_btn.UseVisualStyleBackColor = true;
            this.open_file_btn.Click += new System.EventHandler(this.open_file_btn_click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.button1.Location = new System.Drawing.Point(1903, 589);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 75);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save to CSV";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.save_to_csv_click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 887);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "請載入影片";
            // 
            // comList
            // 
            this.comList.FormattingEnabled = true;
            this.comList.Location = new System.Drawing.Point(1903, 80);
            this.comList.Name = "comList";
            this.comList.Size = new System.Drawing.Size(193, 21);
            this.comList.TabIndex = 4;
            this.comList.Text = "無";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1904, 126);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(192, 75);
            this.button3.TabIndex = 5;
            this.button3.Text = "開始錄影";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.button2.Location = new System.Drawing.Point(1904, 262);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(192, 75);
            this.button2.TabIndex = 6;
            this.button2.Text = "停止錄影";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // rr_rate_chart
            // 
            this.rr_rate_chart.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.rr_rate_chart.CausesValidation = false;
            chartArea1.Name = "ChartArea1";
            this.rr_rate_chart.ChartAreas.Add(chartArea1);
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.rr_rate_chart.Legends.Add(legend1);
            this.rr_rate_chart.Location = new System.Drawing.Point(12, 13);
            this.rr_rate_chart.Name = "rr_rate_chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.rr_rate_chart.Series.Add(series1);
            this.rr_rate_chart.Size = new System.Drawing.Size(1868, 857);
            this.rr_rate_chart.TabIndex = 3;
            this.rr_rate_chart.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            this.rr_rate_chart.Titles.Add(title1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(2107, 975);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.comList);
            this.Controls.Add(this.rr_rate_chart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.open_file_btn);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.rr_rate_chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataVisualization.Charting.Chart rr_rate_chart;

        private System.Windows.Forms.Button button3;

        private System.Windows.Forms.ComboBox comList;

        private System.Windows.Forms.Button open_file_btn;

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}