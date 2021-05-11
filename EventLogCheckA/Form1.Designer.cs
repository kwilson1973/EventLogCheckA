namespace EventLogCheckA
{
    partial class EventLogCheck
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtoutput = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Startgetlog = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.exitTSM = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.HourOfDay = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtoutput
            // 
            this.txtoutput.Location = new System.Drawing.Point(25, 94);
            this.txtoutput.Name = "txtoutput";
            this.txtoutput.Size = new System.Drawing.Size(75, 29);
            this.txtoutput.TabIndex = 7;
            this.txtoutput.Text = "txtoutput";
            this.txtoutput.UseVisualStyleBackColor = true;
            this.txtoutput.Click += new System.EventHandler(this.txtoutput_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "DebugUse";
            // 
            // Startgetlog
            // 
            this.Startgetlog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Startgetlog.Font = new System.Drawing.Font("新細明體", 12F);
            this.Startgetlog.Location = new System.Drawing.Point(25, 42);
            this.Startgetlog.Name = "Startgetlog";
            this.Startgetlog.Size = new System.Drawing.Size(91, 30);
            this.Startgetlog.TabIndex = 7;
            this.Startgetlog.Text = "Start";
            this.Startgetlog.UseVisualStyleBackColor = false;
            this.Startgetlog.Click += new System.EventHandler(this.Startgetlog_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionTSM,
            this.exitTSM});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(291, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionTSM
            // 
            this.optionTSM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingTSM});
            this.optionTSM.Name = "optionTSM";
            this.optionTSM.Size = new System.Drawing.Size(57, 20);
            this.optionTSM.Text = "option";
            // 
            // SettingTSM
            // 
            this.SettingTSM.Name = "SettingTSM";
            this.SettingTSM.Size = new System.Drawing.Size(112, 22);
            this.SettingTSM.Text = "setting";
            this.SettingTSM.Click += new System.EventHandler(this.SettingTSM_Click);
            // 
            // exitTSM
            // 
            this.exitTSM.Name = "exitTSM";
            this.exitTSM.Size = new System.Drawing.Size(39, 20);
            this.exitTSM.Text = "exit";
            this.exitTSM.Click += new System.EventHandler(this.exitTSM_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 14F);
            this.label1.Location = new System.Drawing.Point(208, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "/24";
            // 
            // HourOfDay
            // 
            this.HourOfDay.AutoSize = true;
            this.HourOfDay.Font = new System.Drawing.Font("新細明體", 14F);
            this.HourOfDay.Location = new System.Drawing.Point(177, 48);
            this.HourOfDay.Name = "HourOfDay";
            this.HourOfDay.Size = new System.Drawing.Size(18, 19);
            this.HourOfDay.TabIndex = 4;
            this.HourOfDay.Text = "0";
            // 
            // EventLogCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 135);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Startgetlog);
            this.Controls.Add(this.txtoutput);
            this.Controls.Add(this.HourOfDay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EventLogCheck";
            this.Text = "EventLogCheck";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button txtoutput;
        private System.Windows.Forms.DataGridViewTextBoxColumn a;
        private System.Windows.Forms.DataGridViewTextBoxColumn b;
        private System.Windows.Forms.DataGridViewTextBoxColumn c;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionTSM;
        private System.Windows.Forms.ToolStripMenuItem SettingTSM;
        private System.Windows.Forms.ToolStripMenuItem exitTSM;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button Startgetlog;
        public System.Windows.Forms.Label HourOfDay;
    }
}

