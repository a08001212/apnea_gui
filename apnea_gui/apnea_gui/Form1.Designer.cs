
namespace apnea_gui
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
            this.open_file_btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // open_file_btn
            // 
            this.open_file_btn.Location = new System.Drawing.Point(616, 32);
            this.open_file_btn.Name = "open_file_btn";
            this.open_file_btn.Size = new System.Drawing.Size(128, 42);
            this.open_file_btn.TabIndex = 0;
            this.open_file_btn.Text = "Load File";
            this.open_file_btn.UseVisualStyleBackColor = true;
            this.open_file_btn.Click += new System.EventHandler(this.opeen_file_btn_click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.button1.Location = new System.Drawing.Point(616, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save to CSV";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.save_to_csv_click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(45, 363);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "請載入影片";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.open_file_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button open_file_btn;

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

