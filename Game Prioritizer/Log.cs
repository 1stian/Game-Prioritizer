using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Prioritizer
{
    public class Log
    {

        private Form1 main;
        public Log(Form1 form1)
        {
            this.main = form1;
        }

        Timer saveTimer = new Timer();
        public void InitTimer()
        {
            saveTimer.Tick += SaveTimer_Tick;
            saveTimer.Interval = 20000;
            saveTimer.Start();
        }

        private void SaveTimer_Tick(object sender, EventArgs e)
        {
            SaveToFile();
        }

        /// <summary>
        /// Sending data to log.
        /// </summary>
        /// <param name="type">Info=1|Warning=2|Error=3</param>
        /// <param name="msg">String message</param>
        public void PrintLog(int type, string msg)
        {
            switch (type){
                case 1:
                    if (main.textLog.InvokeRequired)
                    {
                        main.textLog.Invoke((MethodInvoker)(() => main.textLog.AppendText(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") 
                            + " - " + msg + Environment.NewLine)));
                        AppendLogFile(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + " - " + msg + Environment.NewLine);
                    }
                    else
                    {
                        main.textLog.AppendText(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + " - " + msg + Environment.NewLine);
                        AppendLogFile(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + " - " + msg + Environment.NewLine);
                    }
                    break;
                case 2:
                    if (main.textLog.InvokeRequired)
                    {
                        main.textLog.Invoke((MethodInvoker)(() => main.textLog.AppendText(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")
                            + " - Warning! " + msg + Environment.NewLine)));
                        AppendLogFile(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + " - Warning! " + msg + Environment.NewLine);
                    }
                    else
                    {
                        main.textLog.AppendText(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + " - Warning! " + msg + Environment.NewLine);
                        AppendLogFile(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + " - Warning! " + msg + Environment.NewLine);
                    }
                    break;
                case 3:
                    if (main.textLog.InvokeRequired)
                    {
                        main.textLog.Invoke((MethodInvoker)(() => main.textLog.AppendText(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")
                            + " - Error! " + msg + Environment.NewLine)));
                        AppendLogFile(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + " - Error! " + msg + Environment.NewLine);
                    }
                    else
                    {
                        main.textLog.AppendText(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + " - Error! " + msg + Environment.NewLine);
                        AppendLogFile(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + " - Error! " + msg + Environment.NewLine);
                    }
                    break;
            }
        }

        public StringBuilder sb = new StringBuilder();
        public void AppendLogFile(string msg)
        {
            sb.Append(msg);
        }

        public void SaveToFile()
        {
            File.AppendAllText(Form1.APPDATA + "\\log.txt", sb.ToString());
            sb.Clear();
        }
    }
}
