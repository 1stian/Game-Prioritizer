﻿using System;
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

        public Timer tm = new Timer();
        public Timer off = new Timer();

        public void initTimer()
        {
            tm.Interval = 10000;
            tm.Tick += Tm_Tick;

            off.Interval = 20000;
            off.Tick += Off_Tick;
        }

        public void startTimers()
        {
            tm.Start();
            off.Start();
        }

        public void stopTimers()
        {
            tm.Stop();
            off.Stop();
        }

        private void Off_Tick(object sender, EventArgs e)
        {
            stillRunning();
        }

        public void stillRunning()
        {
            foreach (string item in procIDs.Keys)
            {
                string key = main.getGameText();
                if (key == item)
                {
                    try
                    {
                        if (Process.GetProcessById(Int32.Parse(procIDs[key].ToString())).HasExited)
                        {
                            main.SetGameText("no game running.", Color.Red);
                        }
                    }catch(Exception e)
                    {
                        main.SetGameText("no game running.", Color.Red);
                    }
                }
            }

        }

        private void Tm_Tick(object sender, EventArgs e)
        {
            checkGames();
        }

        public void checkGames()
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
                    }
                    main.SetGameText(proc.ProcessName.ToString(), Color.Green);
                }
            }
        }
    }
}