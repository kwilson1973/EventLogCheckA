using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EventLogCheckA
{
    public partial class setting : Form
    {
        public setting()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
            Nodename = IniManager.ReadIniFile("Main", "Nodename", "No Data");
            Logfolder = IniManager.ReadIniFile("Main", "Logfolder", "No Data");
            ConnectItem = IniManager.ReadIniFile("Main", "ConnectItem", "");
            txtNodename.Text = Nodename;
            txtLogfolder.Text = Logfolder;
            ConnectList.Items.Clear();
            if (ConnectItem != "")
            {
                Allcomputer.AddRange(ConnectItem.Split(';'));
                ConnectList.Items.AddRange(Allcomputer.ToArray());
            }
            else ConnectItem = null;
            IsApplication = Boolean.Parse(IniManager.ReadIniFile("Main", "IsApplication", "false"));
            IsSystem = Boolean.Parse(IniManager.ReadIniFile("Main", "IsSystem", "false"));
            IsSecurity = Boolean.Parse(IniManager.ReadIniFile("Main", "IsSecurity", "false"));
            OpenApplication.Checked = IsApplication;
            OpenSystem.Checked = IsSystem;
            OpenSecurity.Checked = IsSecurity;
        }
        IniManager IniManager = new IniManager("./setting.ini");
        public string Nodename, Logfolder,ConnectItem;
        //public StringBuilder Allcomputer=new StringBuilder();
        List<string> Allcomputer = new List<string>();
        public List<string> Addcomputer = new List<string>();
        public List<string> Removecomputer = new List<string>();
        public bool IsApplication, IsSystem, IsSecurity;
        //使用視窗設定資料夾路徑
        private string FolderSet()
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.ShowDialog(this);
            return fb.SelectedPath.ToString();
        }
        private void btmFindLogFolder_Click(object sender, EventArgs e)
        {
            Logfolder = FolderSet();
            if (Logfolder != "")
            {
                txtLogfolder.Text = Logfolder;
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
        private void setting_Load(object sender, EventArgs e)
        {
        }

        private void txtLogfolder_TextChanged(object sender, EventArgs e)
        {
            Logfolder = txtLogfolder.Text ;
        }

        private void txtRemoveconnect_Click(object sender, EventArgs e)
        {
            if (ConnectList.SelectedIndex != -1)
            {
                Removecomputer.Add(ConnectList.SelectedItem.ToString());
                Addcomputer.Remove(ConnectList.SelectedItem.ToString());
                ConnectList.Items.Remove(ConnectList.SelectedItem);
            }
            else { MessageBox.Show("Select item", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void OpenApplication_CheckedChanged(object sender, EventArgs e)
        {
            if (OpenApplication.Checked) IsApplication = true;
            else IsApplication = false;
        }

        private void OpenSystem_CheckedChanged(object sender, EventArgs e)
        {
            if (OpenSystem.Checked) IsSystem = true;
            else IsSystem = false;
        }

        private void OpenSecurity_CheckedChanged(object sender, EventArgs e)
        {
            if (OpenSecurity.Checked) IsSecurity = true;
            else IsSecurity = false;
        }

        private void txtAddconnect_Click(object sender, EventArgs e)
        {

            if (txtConnect.Text.Trim() != "" && !Allcomputer.Contains(txtConnect.Text.Trim()))
            {
                ConnectList.Items.Add(txtConnect.Text.Trim());
                Addcomputer.Add(txtConnect.Text.Trim());
                Removecomputer.Remove(txtConnect.Text.Trim());
                txtConnect.Text = "";
            }
            else {
                MessageBox.Show("Target exists", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConnectList_Click(object sender, EventArgs e)
        {

        }

    }
}
