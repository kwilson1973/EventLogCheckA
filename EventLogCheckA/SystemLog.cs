using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace EventLogCheckA
{
    public class SystemLog
    {
        DateTime DTstart, DTend;
        BindingSource bs = new BindingSource();
        CurrencyManager CM;
        StringBuilder eventout = new StringBuilder();
        //StringBuilder ALLMsg = new StringBuilder();
        IniManager IniManager = new IniManager("./setting.ini");
        EventLog tLog = new EventLog();
        private string Connect = "";
        private string LogName = "";
        private string path = "";
        private string Computer = "";
        int filenumber = 0;
        string nodename = "";
        StreamWriter streamwriter;

        public SystemLog(string LogName, string Computer, string path, DateTime DTstart, DateTime DTend) {
            string RDtime = IniManager.ReadIniFile(Computer, LogName + "_Lasttime", "");     
            nodename= IniManager.ReadIniFile("Main", "Nodename", "");
            this.LogName = LogName;
            this.path = path;
            this.Computer = Computer;
            //Connect = IniManager.ReadIniFile(Computer, "Connect", "").Substring(0, 8); //Test Use
            Connect = IniManager.ReadIniFile(Computer, "Connect", "");
            this.DTstart = DTstart;
            this.DTend = DTend;
            if (RDtime != "") this.DTstart = Convert.ToDateTime(RDtime);
            GetLogData();
            txtoutput();
        }
        private void GetLogData() { 
            tLog.MachineName = ".";
            if (Connect != "") tLog.MachineName = Connect;
            tLog.Log = LogName;
            
            if (LogName != "Security")
            {
                var AppLogEntries =
                            from EventLogEntry e2 in tLog.Entries
                            where (e2.TimeGenerated > DTstart && e2.TimeGenerated < DTend) //&& (e2.EntryType.ToString() == "Error" || e2.EntryType.ToString() == "Warning")
                            orderby e2.TimeGenerated descending
                            select new
                            {
                                Type = typeprocess(e2.EntryType.ToString()),
                                NodeTime = e2.TimeGenerated.ToString("yyyy-MM-dd HH:mm:ss"),
                                Source = e2.Source,
                                Category = e2.Category,
                                ID = e2.EventID,
                                User = e2.UserName,
                                Msg = e2.Message,
                            };
                try
                {
                    bs.DataSource = AppLogEntries.ToList();
                }
                catch (UnauthorizedAccessException) { MessageBox.Show("UnauthorizedAccess", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); Process.GetCurrentProcess().Kill(); Application.Exit(); }
                catch (SecurityException) { MessageBox.Show("admin please", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); Process.GetCurrentProcess().Kill(); Application.Exit(); }
                catch (IOException) {
                    MessageBox.Show("can't find net path", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    EventLogCheck.eventLogCheck.timersTimer.Stop();
                    EventLogCheck.eventLogCheck.StartSwitch = true;
                    EventLogCheck.eventLogCheck.BeginInvoke(new Action(() => EventLogCheck.eventLogCheck.Startgetlog.Text = "Start"));
                    EventLogCheck.eventLogCheck.hourofday = -1;
                    Process.GetCurrentProcess().Kill();
                    Application.Exit();
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); Process.GetCurrentProcess().Kill(); Application.Exit(); }

            }
            else {
                var AppLogEntries =
                     from EventLogEntry e2 in tLog.Entries
                     where e2.TimeGenerated > DTstart && e2.TimeGenerated < DTend
                     orderby e2.TimeGenerated descending
                     select new
                     {
                         Type = typeprocess(e2.EntryType.ToString()),
                         NodeTime = e2.TimeGenerated.ToString("yyyy-MM-dd HH:mm:ss"),
                         Source = e2.Source,
                         Category = e2.Category,
                         ID = e2.EventID,
                         User = e2.UserName,
                         Msg = e2.Message,
                     };
                try
                {
                    bs.DataSource = AppLogEntries.ToList();
                }
                catch (SecurityException) { MessageBox.Show("admin please", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit(); }
                catch (IOException) { MessageBox.Show("can't find net path", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); EventLogCheck.eventLogCheck.timersTimer.Stop(); EventLogCheck.eventLogCheck.StartSwitch = true; EventLogCheck.eventLogCheck.BeginInvoke(new Action(() => EventLogCheck.eventLogCheck.Startgetlog.Text = "Start")); EventLogCheck.eventLogCheck.hourofday = -1; }

            }
        }
        private string typeprocess(string type)
        {
            switch (type)
            {
                //case "Information":  return type;
                case "Error":  return type;
                case "Warning":  return type;
                //case "0":  return "Critical";
                case "SuccessAudit":  return type;
                case "FailureAudit":  return type;
                default: return type;
            }

        }
        private void txtoutput() {
            if (bs.CurrencyManager.List.Count > 0 )
            {
                CM = bs.CurrencyManager;
                //當檔案不存在才新增
                //各筆Scada傳輸格式內容
                //使用StreamWriter寫入txt檔案
                string eachline;
                string[] eachlogdetail;
                string eachlogmsg;
                int  batch=100;
                string temppath = path + "\\" + Computer + DateTime.Today.ToString("_yyyy_MM_dd_");
                string savepath;
                for (int i = CM.List.Count-1 ; i >= 0; i--)
                {      
                    eachline = CM.List[i].ToString().Trim(' ', '{', '}').Replace("\t", "").Replace("\r", "");
                    eachlogdetail = eachline.Substring(0, eachline.IndexOf("Msg = ")).Replace("\n", "").Replace(" ", "").Replace(",", "; ").Trim().Split(' ');
                    eachlogmsg = eachline.Substring(eachline.IndexOf("Msg = "), 6).Replace(" ", "") + eachline.Substring(eachline.IndexOf("Msg = ") + 6, eachline.Length - eachline.IndexOf("Msg = ") - 6).Replace("\n", " ");
                    //eventout.Clear();
                    eventout.Remove(0, eventout.Length);
                    eventout.Append("[WinSysEvt2];");
                    eventout.Append("EvtLog=" + LogName + ";");
                    eventout.Append(eachlogdetail[0]);
                    eventout.Append("NodeName=" + nodename + ";");
                    eventout.Append(eachlogdetail[1].Insert(19, " "));
                    eventout.Append(eachlogdetail[2]);
                    eventout.Append(eachlogdetail[3]);
                    eventout.Append(eachlogdetail[4]);
                    eventout.Append(eachlogdetail[5]);
                    eventout.Append("ComputerName=" + Connect + ";");
                    eventout.Append(eachlogmsg + ";");
                    eventout.Append("Version=EventLog20200826;" + "\r\n");
                    EventLogCheck.eventLogCheck.ALLMsg.Append(eventout);
                    EventLogCheck.eventLogCheck.batchcount++;
                    if (EventLogCheck.eventLogCheck.batchcount % batch == 0) {
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
                            streamwriter.WriteLine(EventLogCheck.eventLogCheck.ALLMsg);
                            streamwriter.Close();
                        }
                        EventLogCheck.eventLogCheck.ALLMsg.Remove(0, EventLogCheck.eventLogCheck.ALLMsg.Length);
                    }
                }                
                filenumber = 0;
                //紀錄當前最新一筆資料日期
                try
                {
                    DTstart = Convert.ToDateTime(CM.List[0].ToString().Substring(CM.List[0].ToString().IndexOf("NodeTime = ") + 11, 19));
                }
                catch (ArgumentOutOfRangeException) { }
                IniManager.WriteIniFile(Computer, LogName + "_Lasttime", DTstart);
                //Logdata.DataSource = null;
                //Logdata.Dispose();
                bs.DataSource = null;
                bs.Dispose();
            }
        }
    }
}
