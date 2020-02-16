using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Game_Prioritizer
{
    class Run
    {
        private Form1 main;
        public Run(Form1 form1)
        {
            this.main = form1;
        }

        Hashtable procIDs = new Hashtable();

        public System.Timers.Timer tm = new System.Timers.Timer();

        public void InitTimer()
        {
            tm.Interval = main.ConvertSecondsToMilliseconds(main.CHECK_INTERVAL);
            tm.Elapsed += Tm_Elapsed;
        }

        private void Tm_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CheckGames();
        }

        public void StartTimers()
        {
            tm.Start();
            main.SendLogData(1, "Starting!");
        }

        public void StopTimers()
        {
            tm.Stop();
            main.SendLogData(1, "Stopping!");
        }

        public void ProcessWaiter()
        {
            string key = main.GetGameText();
            Process proc = Process.GetProcessById(Int32.Parse(procIDs[key].ToString()));
            proc.EnableRaisingEvents = true;
            proc.Exited += Proc_Exited;
        }

        private void Proc_Exited(object sender, EventArgs e)
        {
            string key = main.GetGameText();
            if (main.labelGameRunning.InvokeRequired)
            {
                main.labelGameRunning.Invoke((MethodInvoker)(() => main.labelGameRunning.Text = "no game running."));
                main.labelGameRunning.Invoke((MethodInvoker)(() => main.labelGameRunning.ForeColor = Color.Red));
            }

            if (main.textLog.InvokeRequired)
            {
                main.textLog.Invoke((MethodInvoker)(() => main.textLog.AppendText(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")
                    + " - " + "Game exited!" + Environment.NewLine)));
            }

            main.AppendLog(DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss") + " - " + "Game exited!" + Environment.NewLine);
            procIDs.Clear();
            tm.Start();
        }

        public void CheckGames()
        {
            foreach (string game in main.games)
            {
                string[] split = game.Split(',');
                string rawName = split[0];
                string name = rawName.Split('.')[0];
                string pri = split[1].TrimStart(' ');

                ProcessPriorityClass priority = ProcessPriorityClass.Normal;

                if (pri == "High" || pri == "high")
                {
                    priority = ProcessPriorityClass.High;
                }
                if (pri == "AboveNormal" || pri == "abovenormal")
                {
                    priority = ProcessPriorityClass.AboveNormal;
                }
                if (pri == "Normal" || pri == "normal")
                {
                    priority = ProcessPriorityClass.Normal;
                }

                Process[] processes = Process.GetProcessesByName(name);
                foreach (Process proc in processes)
                {
                    proc.PriorityClass = priority;
                    if (!procIDs.ContainsKey(name))
                    {
                        procIDs.Add(proc.ProcessName.ToString(), proc.Id);
                        main.SendLogData(1, "Game found, " + proc.ProcessName.ToString());
                        main.SetGameText(proc.ProcessName.ToString(), Color.Green);
                        ProcessWaiter();
                        tm.Stop();
                    }
                }
            }
        }
    }
}
