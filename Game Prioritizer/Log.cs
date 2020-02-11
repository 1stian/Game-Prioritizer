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
        public void initTimer()
        {
            saveTimer.Tick += SaveTimer_Tick;
            saveTimer.Interval = 20000;
            saveTimer.Start();
        }

        private void SaveTimer_Tick(object sender, EventArgs e)
        {
            saveToFile();
        }

        /// <summary>
        /// Sending data to log.
        /// </summary>
        /// <param name="type">Info=1|Warning=2|Error=3</param>
        /// <param name="msg">String message</param>
        public void printLog(int type, string msg)
        {
            switch (type){
                case 1:
                    main.textLog.AppendText(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + " - " + msg + Environment.NewLine);
                    appendLogFile(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + " - " + msg + Environment.NewLine);
                    break;
                case 2:
                    main.textLog.AppendText(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + " - Warning! " + msg + Environment.NewLine);
                    appendLogFile(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + " - Warning! " + msg + Environment.NewLine);
                    break;
                case 3:
                    main.textLog.AppendText(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + " - Error! " + msg + Environment.NewLine);
                    appendLogFile(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + " - Error! " + msg + Environment.NewLine);
                    break;
            }
        }

        StringBuilder sb = new StringBuilder();
        public void appendLogFile(string msg)
        {
            sb.Append(msg);
        }

        public void saveToFile()
        {
            File.AppendAllText(Form1.APPDATA + "\\log.txt", sb.ToString());
            sb.Clear();
        }
    }
}
