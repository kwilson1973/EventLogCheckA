namespace EventLogCheckA
{
    partial class setting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labNodename = new System.Windows.Forms.Label();
            this.txtNodename = new System.Windows.Forms.TextBox();
            this.labLogfolder = new System.Windows.Forms.Label();
            this.txtLogfolder = new System.Windows.Forms.TextBox();
            this.btmFindLogFolder = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labConnect = new System.Windows.Forms.Label();
            this.ConnectList = new System.Windows.Forms.ListBox();
            this.txtConnect = new System.Windows.Forms.TextBox();
            this.txtAddconnect = new System.Windows.Forms.Button();
            this.txtRemoveconnect = new System.Windows.Forms.Button();
            this.OpenApplication = new System.Windows.Forms.CheckBox();
            this.OpenSystem = new System.Windows.Forms.CheckBox();
            this.OpenSecurity = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labNodename
            // 
            this.labNodename.AutoSize = true;
            this.labNodename.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labNodename.Location = new System.Drawing.Point(39, 27);
            this.labNodename.Name = "labNodename";
            this.labNodename.Size = new System.Drawing.Size(75, 13);
            this.labNodename.TabIndex = 0;
            this.labNodename.Text = "LocalName：";
            // 
            // txtNodename
            // 
            this.txtNodename.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtNodename.Location = new System.Drawing.Point(144, 22);
            this.txtNodename.Name = "txtNodename";
            this.txtNodename.ReadOnly = true;
            this.txtNodename.Size = new System.Drawing.Size(166, 22);
            this.txtNodename.TabIndex = 1;
            // 
            // labLogfolder
            // 
            this.labLogfolder.AutoSize = true;
            this.labLogfolder.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labLogfolder.Location = new System.Drawing.Point(39, 58);
            this.labLogfolder.Name = "labLogfolder";
            this.labLogfolder.Size = new System.Drawing.Size(74, 13);
            this.labLogfolder.TabIndex = 0;
            this.labLogfolder.Text = "SaveFolder：";
            // 
            // txtLogfolder
            // 
            this.txtLogfolder.Location = new System.Drawing.Point(144, 53);
            this.txtLogfolder.Name = "txtLogfolder";
            this.txtLogfolder.Size = new System.Drawing.Size(166, 22);
            this.txtLogfolder.TabIndex = 1;
            this.txtLogfolder.TextChanged += new System.EventHandler(this.txtLogfolder_TextChanged);
            // 
            // btmFindLogFolder
            // 
            this.btmFindLogFolder.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btmFindLogFolder.Location = new System.Drawing.Point(316, 52);
            this.btmFindLogFolder.Name = "btmFindLogFolder";
            this.btmFindLogFolder.Size = new System.Drawing.Size(31, 23);
            this.btmFindLogFolder.TabIndex = 2;
            this.btmFindLogFolder.Text = "...";
            this.btmFindLogFolder.UseVisualStyleBackColor = true;
            this.btmFindLogFolder.Click += new System.EventHandler(this.btmFindLogFolder_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("新細明體", 12F);
            this.btnOK.Location = new System.Drawing.Point(58, 224);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 44);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "Confirm";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("新細明體", 12F);
            this.btnCancel.Location = new System.Drawing.Point(194, 224);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 44);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labConnect
            // 
            this.labConnect.AutoSize = true;
            this.labConnect.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.labConnect.Location = new System.Drawing.Point(39, 87);
            this.labConnect.Name = "labConnect";
            this.labConnect.Size = new System.Drawing.Size(62, 13);
            this.labConnect.TabIndex = 0;
            this.labConnect.Text = "Connect ：";
            // 
            // ConnectList
            // 
            this.ConnectList.FormattingEnabled = true;
            this.ConnectList.ItemHeight = 12;
            this.ConnectList.Location = new System.Drawing.Point(144, 109);
            this.ConnectList.Name = "ConnectList";
            this.ConnectList.Size = new System.Drawing.Size(166, 88);
            this.ConnectList.TabIndex = 5;
            this.ConnectList.Click += new System.EventHandler(this.ConnectList_Click);
            // 
            // txtConnect
            // 
            this.txtConnect.Location = new System.Drawing.Point(144, 81);
            this.txtConnect.Name = "txtConnect";
            this.txtConnect.Size = new System.Drawing.Size(166, 22);
            this.txtConnect.TabIndex = 1;
            // 
            // txtAddconnect
            // 
            this.txtAddconnect.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtAddconnect.Location = new System.Drawing.Point(316, 81);
            this.txtAddconnect.Name = "txtAddconnect";
            this.txtAddconnect.Size = new System.Drawing.Size(31, 23);
            this.txtAddconnect.TabIndex = 2;
            this.txtAddconnect.Text = "+";
            this.txtAddconnect.UseVisualStyleBackColor = true;
            this.txtAddconnect.Click += new System.EventHandler(this.txtAddconnect_Click);
            // 
            // txtRemoveconnect
            // 
            this.txtRemoveconnect.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtRemoveconnect.Location = new System.Drawing.Point(316, 109);
            this.txtRemoveconnect.Name = "txtRemoveconnect";
            this.txtRemoveconnect.Size = new System.Drawing.Size(31, 23);
            this.txtRemoveconnect.TabIndex = 2;
            this.txtRemoveconnect.Text = "-";
            this.txtRemoveconnect.UseVisualStyleBackColor = true;
            this.txtRemoveconnect.Click += new System.EventHandler(this.txtRemoveconnect_Click);
            // 
            // OpenApplication
            // 
            this.OpenApplication.AutoSize = true;
            this.OpenApplication.Location = new System.Drawing.Point(42, 125);
            this.OpenApplication.Name = "OpenApplication";
            this.OpenApplication.Size = new System.Drawing.Size(78, 16);
            this.OpenApplication.TabIndex = 6;
            this.OpenApplication.Text = "Application";
            this.OpenApplication.UseVisualStyleBackColor = true;
            this.OpenApplication.CheckedChanged += new System.EventHandler(this.OpenApplication_CheckedChanged);
            // 
            // OpenSystem
            // 
            this.OpenSystem.AutoSize = true;
            this.OpenSystem.Location = new System.Drawing.Point(42, 147);
            this.OpenSystem.Name = "OpenSystem";
            this.OpenSystem.Size = new System.Drawing.Size(57, 16);
            this.OpenSystem.TabIndex = 6;
            this.OpenSystem.Text = "System";
            this.OpenSystem.UseVisualStyleBackColor = true;
            this.OpenSystem.CheckedChanged += new System.EventHandler(this.OpenSystem_CheckedChanged);
            // 
            // OpenSecurity
            // 
            this.OpenSecurity.AutoSize = true;
            this.OpenSecurity.Location = new System.Drawing.Point(42, 169);
            this.OpenSecurity.Name = "OpenSecurity";
            this.OpenSecurity.Size = new System.Drawing.Size(62, 16);
            this.OpenSecurity.TabIndex = 6;
            this.OpenSecurity.Text = "Security";
            this.OpenSecurity.UseVisualStyleBackColor = true;
            this.OpenSecurity.CheckedChanged += new System.EventHandler(this.OpenSecurity_CheckedChanged);
            // 
            // setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 308);
            this.ControlBox = false;
            this.Controls.Add(this.OpenSecurity);
            this.Controls.Add(this.OpenSystem);
            this.Controls.Add(this.OpenApplication);
            this.Controls.Add(this.ConnectList);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtRemoveconnect);
            this.Controls.Add(this.txtAddconnect);
            this.Controls.Add(this.btmFindLogFolder);
            this.Controls.Add(this.txtConnect);
            this.Controls.Add(this.labConnect);
            this.Controls.Add(this.txtLogfolder);
            this.Controls.Add(this.labLogfolder);
            this.Controls.Add(this.txtNodename);
            this.Controls.Add(this.labNodename);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "setting";
            this.Text = "setting";
            this.Load += new System.EventHandler(this.setting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labNodename;
        private System.Windows.Forms.TextBox txtNodename;
        private System.Windows.Forms.Label labLogfolder;
        private System.Windows.Forms.TextBox txtLogfolder;
        private System.Windows.Forms.Button btmFindLogFolder;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labConnect;
        private System.Windows.Forms.TextBox txtConnect;
        private System.Windows.Forms.Button txtAddconnect;
        public System.Windows.Forms.ListBox ConnectList;
        private System.Windows.Forms.Button txtRemoveconnect;
        private System.Windows.Forms.CheckBox OpenApplication;
        private System.Windows.Forms.CheckBox OpenSystem;
        private System.Windows.Forms.CheckBox OpenSecurity;
    }
}