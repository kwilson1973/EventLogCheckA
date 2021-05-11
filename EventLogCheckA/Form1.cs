using System;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security;
using System.IO;
using System.Net;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Drawing;
using System.Text;

namespace EventLogCheckA
{
    public partial class EventLogCheck : Form
    {
        public static EventLogCheck eventLogCheck;
        public EventLogCheck()
        {
            InitializeComponent();            
            timersTimer.Interval = 3600000;
            //timersTimer.Interval = 10000;
            timersTimer.AutoReset = true;
            timersTimer.Elapsed += TimersTimer_Elapsed;
            eventLogCheck = this;
            SavePath = IniManager.ReadIniFile("Main", "Logfolder", "No Data");
            ConnectAmount = Convert.ToInt32(IniManager.ReadIniFile("Main", "ConnectAmount", "1"));
            AllConnect.AddRange(IniManager.ReadIniFile("Main", "ConnectItem", "No Data").Split(';'));
            IsApplication = Boolean.Parse(IniManager.ReadIniFile("Main", "IsApplication", "false"));
            IsSystem = Boolean.Parse(IniManager.ReadIniFile("Main", "IsSystem", "false"));
            IsSecurity = Boolean.Parse(IniManager.ReadIniFile("Main", "IsSecurity", "false"));
        }
        //宣告每小時次數、計時器、哪台電腦、存檔位置、連線總數、程式碼計時器、電腦總LOG文字、文字檔名稱順序、執行緒。
        public int hourofday = 0;
        public System.Timers.Timer timersTimer = new System.Timers.Timer();
        string Computer = "";
        string SavePath = "";
        int ConnectAmount = 1;
        bool IsApplication, IsSystem, IsSecurity;
        IniManager IniManager = new IniManager("./setting.ini");
        Stopwatch sw = new Stopwatch();
        List<string> AllConnect=new List<string>();
        List<string> AddConnect = new List<string>();
        List<string> RemoveConnect = new List<string>();
        public StringBuilder ALLMsg = new StringBuilder();
        public int batchcount = 0;//SystemLog.cs的batch計數
        StreamWriter streamwriter;
        int filenumber = 0;
        Thread TStartGetLog;
        //取消關閉功能
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }
        
        //Debug用
        private void txtoutput_Click_1(object sender, EventArgs e)
        {
            IniManager.WriteIniFile("Main", "ConnectAmount", 2);
            label2.Text = DateTime.Now.ToString();
            timerange();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        //開始抓取及匯出

        //控制按鈕開關
        public bool StartSwitch = true;
        private void Startgetlog_Click(object sender, EventArgs e)
        {
            //單線程
            /*
            if (StartSwitch)
            {
                timersTimer.Start(); StartSwitch = false; Startgetlog.Text = "Stop";

                timerange();
                systemlog = new SystemLog("Application", Logfolder, Connect, DTstart, DTend);
                systemlog = new SystemLog("System", Logfolder, Connect, DTstart, DTend);
                systemlog = new SystemLog("Security", Logfolder, Connect, DTstart, DTend);
                if (hourofday > 23) hourofday = 0;
                this.HourOfDay.Text = (hourofday += 1).ToString();
            }
            else { timersTimer.Stop(); StartSwitch = true; Startgetlog.Text = "Start"; HourOfDay.Text = "0"; hourofday = 0; }
            */           
            if (StartSwitch)
            {
                Startgetlog.Text = "Stop"; 
                Startgetlog.BackColor=Color.FromArgb(255,128,128);
                StartSwitch = false;
                //開始計時
                timersTimer.Start();
                //多執行緒執行以便主頁面控制
                TStartGetLog = new Thread(StartGetLog);
                TStartGetLog.Start();
            }
            else { Startgetlog.Text = "Start"; Startgetlog.BackColor = Color.FromArgb(128, 255, 128); timersTimer.Stop(); StartSwitch = true; HourOfDay.Text = "0"; hourofday = 0; Thread.Sleep(1000);TStartGetLog.Abort(); }
        }

        private void TimersTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //多執行序執行    
            Thread TStartGetLog = new Thread(StartGetLog);
            TStartGetLog.Start();
            TStartGetLog.Join();
            //單線程
            /*
            timerange();
            systemlog = new SystemLog("Application", Logfolder, Connect, DTstart, DTend);
            systemlog = new SystemLog("System", Logfolder, Connect, DTstart, DTend);
            systemlog = new SystemLog("Security", Logfolder, Connect, DTstart, DTend);
            if (hourofday > 23) hourofday = 0;
            this.BeginInvoke(new Action(() => this.HourOfDay.Text = (hourofday += 1).ToString()));
            */
        }
        private void StartGetLog() {
            //計算每完成一輪花費時間
            sw.Reset();
            sw.Start();

            /*Logout(1);
            if (ConnectAmount >= 2)
            {
                Logout(2);
                if (ConnectAmount == 3) Logout(3);
            }*/

            for (int i = 1; i <= ConnectAmount; i++) {
                Logout(i);
            }
            
            /*//執行緒同步執行多台電腦抓取即匯出
            Thread PC1 = new Thread(Logout);
            Thread PC2 = new Thread(Logout);
            Thread PC3 = new Thread(Logout);
            if (ConnectAmount >= 2)
            {
                Thread.Sleep(10000);//間隔時間
                PC2.Start(2);
                PC2.Join();

                if (ConnectAmount == 3)
                {
                    Thread.Sleep(10000);//間隔時間
                    PC3.Start(3);
                    PC3.Join();

                }
            }*/
            //顯示次數
            if (hourofday > 23) hourofday = 0;
            this.BeginInvoke(new Action(() => this.HourOfDay.Text = (hourofday += 1).ToString()));

            sw.Stop();
            this.BeginInvoke(new Action(() => label2.Text = sw.Elapsed.TotalMilliseconds.ToString()));
        }

        DateTime DTstart, DTend;
        private void timerange() {
            DateTime now = DateTime.Now;
            DTstart = now.AddHours(-1);
            DTend = now.AddHours(1);
           // MessageBox.Show(DTstart + " " + DTend);
        }
        private void threadfunc(object LogName) { new SystemLog(LogName.ToString().Trim(), Computer, SavePath, DTstart, DTend); }

        private void Logout(object number) {
            Computer = AllConnect[(int)number-1];
            try
            {
                timerange();
                Thread Thread_Application = new Thread(threadfunc);
                Thread Thread_Security = new Thread(threadfunc);
                Thread Thread_System = new Thread(threadfunc);
                if (IsApplication) { Thread_Application.Start("Application"); Thread_Application.Join();}
                if (IsSystem) { Thread_System.Start("System"); Thread_System.Join();}
                if (IsSecurity) { Thread_Security.Start("Security"); Thread_Security.Join();}               
                string temppath = SavePath + "\\" + Computer + DateTime.Today.ToString("_yyyy_MM_dd_");
                string savepath;
                if (eventLogCheck.ALLMsg.Length > 0 && !"null".Equals(eventLogCheck.ALLMsg.ToString()) && !"".Equals(eventLogCheck.ALLMsg.ToString()))
                {
                    //檔案存檔位置
                    savepath = temppath + filenumber + ".txt";
                    //當檔名存在檔案編號加一
                    while (File.Exists(savepath))
                    {
                        savepath = temppath + filenumber++ + ".txt";
                    }
                    if (!File.Exists(savepath))
                    {
                        streamwriter = File.AppendText(savepath);
                        streamwriter.WriteLine(eventLogCheck.ALLMsg);
                        streamwriter.Close();
                    }
                }
                eventLogCheck.ALLMsg.Remove(0, eventLogCheck.ALLMsg.Length);
                filenumber = 0;
                batchcount = 0;
                /*
                if (ALLMsg.Length > 0 && !"null".Equals(ALLMsg.ToString()) && !"".Equals(ALLMsg.ToString())) {
                    //檔案存檔位置
                    string temppath = SavePath + "\\" + Computer + DateTime.Today.ToString("_yyyy_MM_dd_");
                    string savepath = temppath + filenumber + ".txt";
                    //當檔名存在檔案編號加一
                    while (File.Exists(savepath))
                    {
                        savepath = temppath + filenumber++ + ".txt";
                    }
                    if (!File.Exists(savepath))
                    {
                        streamwriter = File.AppendText(savepath);
                        streamwriter.WriteLine(ALLMsg);
                        streamwriter.Close();
                    }
                }
                filenumber = 0;
                ALLMsg.Remove(0, ALLMsg.Length);*/
            }
            catch (Exception ex) {  timersTimer.Stop(); }
        }
        
        private void SettingTSM_Click(object sender, EventArgs e)
        {
            setting setform = new setting();
            setform.ShowDialog(this);
            if (setform.DialogResult == DialogResult.OK)
            {
                SavePath = setform.Logfolder;
                ConnectAmount = setform.ConnectList.Items.Count;
                AddConnect = setform.Addcomputer;
                RemoveConnect = setform.Removecomputer;
                if(AddConnect!=null)AllConnect.AddRange(AddConnect);
                foreach (string item in RemoveConnect) AllConnect.Remove(item);
                AllConnect.Remove("");
                IniManager.WriteIniFile("Main", "Logfolder", SavePath);
                IniManager.WriteIniFile("Main", "ConnectAmount", ConnectAmount);
                IniManager.WriteIniFile("Main", "ConnectItem", string.Join(";",AllConnect.ToArray()));               
                for (int i = 0; i < AddConnect.Count; i++) {
                    AddiniComputer(AddConnect[i]);
                }
                for (int i = 0; i < RemoveConnect.Count; i++)
                {
                    removeiniComputer(RemoveConnect[i]);
                }
                IsApplication = setform.IsApplication;
                IsSystem = setform.IsSystem;
                IsSecurity = setform.IsSecurity;
                IniManager.WriteIniFile("Main", "IsApplication", IsApplication);
                IniManager.WriteIniFile("Main", "IsSystem", IsSystem);
                IniManager.WriteIniFile("Main", "IsSecurity", IsSecurity);
                setform.Dispose();
            }
            else if (setform.DialogResult == DialogResult.Cancel)
            {
                setform.Dispose();
            }
        }

        private void AddiniComputer(string computername) {
            IniManager.WriteIniFile(computername, "Connect", computername);
            IniManager.WriteIniFile(computername, "Security_Lasttime", "");
            IniManager.WriteIniFile(computername, "System_Lasttime", "");
            IniManager.WriteIniFile(computername, "Application_Lasttime", "");
        }
        private void removeiniComputer(string computername)
        {
            IniManager.WriteIniFile(computername, null, "");
        }

        private void exitTSM_Click(object sender, EventArgs e)
        {
            DialogResult exit= MessageBox.Show("Do you really want to Exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (exit == DialogResult.OK) {
                Process.GetCurrentProcess().Kill();
                Application.Exit(); 
            }
        }
    }
}