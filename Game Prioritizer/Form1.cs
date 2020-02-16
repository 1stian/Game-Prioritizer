using Microsoft.Win32;
using System;
using System.Activities;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace Game_Prioritizer
{
    public partial class Form1 : Form
    {
        public System.Drawing.Point lastLoc;
        public System.Drawing.Size lastSize;

        Settings settings;
        Updater updater;
        Run run;
        Log log;

        //Directories
        public static string APPDATA;
        public static string EXEC_PATH;
        public static string WORK_DIR;

        //ArrayList for class Run
        public ArrayList games = new ArrayList();

        //Localtimer
        Timer upCheck = new Timer();

        //User settings
        public double CHECK_INTERVAL = 10;

        public Form1()
        {
            //Normal Initialize
            InitializeComponent();

            //THIS
            run = new Run(this);
            settings = new Settings(this);
            log = new Log(this);
            updater = new Updater(this);

            //Creating directory
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string specificFolder = Path.Combine(folder, "GamePrioritizer");
            Directory.CreateDirectory(specificFolder);
            if (!System.IO.File.Exists(specificFolder + "\\data.xml"))
            {
                System.IO.File.Create(specificFolder + "\\data.xml").Dispose();
            }
            APPDATA = specificFolder.ToString();

            //EXEC PATH
            EXEC_PATH = System.Reflection.Assembly.GetEntryAssembly().Location;
            //WORK
            WORK_DIR = Path.GetDirectoryName(Application.ExecutablePath);

            //Getting version
            toolLabelVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            //Filling changelog
            GrabChangeLog();

            //Checking for update
            pictureUpdate.Visible = false;
            CheckForUpdate();

            //ListBox settings
            gameList.FormattingEnabled = true;
            gameList.HorizontalScrollbar = true;
            gameList.ScrollAlwaysVisible = true;

            //Loading and so on..
            LoadGameList();
            settings.LoadSettings();
            textBoxCheckInterval.Text = CHECK_INTERVAL.ToString();

            //Initialize external timers
            run.InitTimer();
            log.InitTimer();

            //AutoStart
            AutoStart();

            //Init localtimer
            upCheck.Interval = 1800000;
            upCheck.Start();
            upCheck.Tick += UpCheck_Tick;
        }

        private void UpCheck_Tick(object sender, EventArgs e)
        {
            CheckForUpdate();
        }

        public Boolean CheckForUpdate()
        {
            if (updater.CheckUpdate())
            {
                SendLogData(1, "Found new update. Version: " + updater.version);
                pictureUpdate.Visible = true;
                return true;
            }

            return false;
        }

        public static Version GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version;
        }

        public Boolean ReEnableAdd
        {
            set { this.buttonAdd.Enabled = true; }
        }

        public Boolean ReEnableEdit
        {
            set { this.buttonEdit.Enabled = true; }
        }

        public void SetGameText(string name, Color color)
        {
            if (labelGameRunning.InvokeRequired)
            {

                labelGameRunning.Invoke((MethodInvoker)(() => labelGameRunning.Text = name));
                labelGameRunning.Invoke((MethodInvoker)(() => labelGameRunning.ForeColor = Color.Green));
            }
            else
            {
                labelGameRunning.ForeColor = color;
                labelGameRunning.Text = name;
            }
        }

        public void AppendLog(string msg)
        {
            log.AppendLogFile(msg);
        }

        public string GetGameText()
        {
            return labelGameRunning.Text;
        }

        public void AddGame(String name, String path, ProcessPriorityClass priority)
        {
            if (name == null || path == null)
            {
                MessageBox.Show("Something wrong happened while adding the game... Please try again. " +
                    "If the problem repeats itself, please contact the creator of this application.",
                    "Something went wrong...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            gameList.Items.AddRange(new object[] {
                name + ", " + priority.ToString() + ", " + path,
            });
            UpdateChecker();
            SendLogData(1, "Added: " + name + " to game list.");
        }

        public void UpdateChecker()
        {
            if (gameList.Items.Count > 0)
            {
                for (int i = 0; i < gameList.Items.Count; i++)
                {
                    games.Add(gameList.Items[i].ToString());
                }
            }
        }

        public void SaveGameList()
        {
            string sPath = APPDATA + "\\gameList.txt";

            try
            {
                StreamWriter SaveFile = new StreamWriter(sPath);
                foreach (var item in gameList.Items)
                {
                    SaveFile.WriteLine(item.ToString());
                }

                SaveFile.Close();
                SendLogData(1, "Game list saved.");
            }
            catch (Exception e)
            {
                SendLogData(3, "Message: " + e);
            }
        }

        public void LoadGameList()
        {
            try
            {
                string lPath = APPDATA + "\\gameList.txt";
                string line;
                StreamReader LoadFile = new StreamReader(lPath);
                while ((line = LoadFile.ReadLine()) != null)
                {
                    String[] split = line.Split(',');

                    String name = split[0];
                    String path = split[2].TrimStart(' ');

                    ProcessPriorityClass pri = ProcessPriorityClass.Normal;

                    String priority = split[1].TrimStart(' ');
                    if (priority == "High" || priority == "high")
                    {
                        pri = ProcessPriorityClass.High;
                    }
                    if (priority == "AboveNormal" || priority == "abovenormal")
                    {
                        pri = ProcessPriorityClass.AboveNormal;
                    }
                    if (priority == "Normal" || priority == "normal")
                    {
                        pri = ProcessPriorityClass.Normal;
                    }

                    AddGame(name, path, pri);
                }

                foreach (string game in gameList.Items)
                {
                    string[] split = game.Split(' ');
                    string name = split[0];
                }

                LoadFile.Close();
                SendLogData(1, "Game list loaded.");
            }
            catch (Exception e)
            {
                SendLogData(3, "gameList.txt file couldn't be found.. Might be first time using this application.");
            }
        }

        public void RemoveGame()
        {
            SendLogData(1, "Removed: " + gameList.SelectedItem.ToString() + " from game list.");
            if (gameList.SelectedItems == null)
            {
                return;
            }

            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(gameList);
            selectedItems = gameList.SelectedItems;

            for (int i = selectedItems.Count - 1; i >= 0; i--)
                gameList.Items.Remove(selectedItems[i]);

            UpdateChecker();
        }

        public void RemoveGameAt(int row)
        {
            gameList.Items.RemoveAt(row);
            SendLogData(1, "Removed: " + gameList.SelectedItem.ToString() + " from game list.");
            UpdateChecker();
        }

        public void OpenWebsite()
        {
            System.Diagnostics.Process.Start("https://realnaits.com/");
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            buttonAdd.Enabled = false;
            Add addForm = new Add();
            addForm.Show();
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (gameList.SelectedItem == null)
            {
                MessageBox.Show("Something wrong happened while editing the game... Please try again. " +
                    "If the problem repeats itself, please contact the creator of this application.",
                    "Something went wrong...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String selected = gameList.SelectedItem.ToString();
            String[] split = selected.Split(',');

            String name = split[0];
            String path = split[2];
            int row = gameList.SelectedIndex;
            ProcessPriorityClass pri = ProcessPriorityClass.Normal;

            String priority = split[1].TrimStart(' ');
            if (priority == "High" || priority == "high")
            {
                pri = ProcessPriorityClass.High;
            }
            if (priority == "AboveNormal" || priority == "abovenormal")
            {
                pri = ProcessPriorityClass.AboveNormal;
            }
            if (priority == "Normal" || priority == "normal")
            {
                pri = ProcessPriorityClass.Normal;
            }

            buttonEdit.Enabled = false;
            Edit edit = new Edit(name.TrimStart(' '), path.TrimStart(' '), pri, row);
            edit.Show();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (gameList.SelectedItem == null)
            {
                MessageBox.Show("Something wrong happened while deleting the game... Please try again. " +
                    "If the problem repeats itself, please contact the creator of this application.",
                    "Something went wrong...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dr = MessageBox.Show("You sure you want to remove " + gameList.SelectedItem.ToString().Split(',')[0], "Confirm", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                RemoveGame();
            }
        }

        private void PictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenWebsite();
        }

        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(gameList);
            selectedItems = gameList.SelectedItems;

            for (int i = selectedItems.Count - 1; i >= 0; i--)
                gameList.Items.Remove(selectedItems[i]);
        }

        private void ToolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            OpenWebsite();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            lastSize = this.Size;

            if (this.WindowState != FormWindowState.Minimized)
            {
                lastLoc = this.Location;
            }
            SaveGameList();
            settings.SaveSettings();
            SendLogData(1, "Exited");
            log.SaveToFile();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            Start();
        }
        public void Start()
        {
            if (gameList.Items.Count < 1)
            {
                MessageBox.Show("You must add a game before you can start.", "Error!", MessageBoxButtons.OK);
                return;
            }

            //updateChecker();

            run.StartTimers();
            pictureStatus.BackColor = Color.Green;
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        public void Stop()
        {
            run.StopTimers();
            pictureStatus.BackColor = Color.DarkRed;
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }

        private void PictureUpdate_Click(object sender, EventArgs e)
        {
            StartUpdater();
        }

        public void StartUpdater()
        {
            DialogResult dr = MessageBox.Show("Do you want to update?", "Update?", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                Process.Start(WORK_DIR + "\\Game Prioritizer Updater.exe");
                this.Close();
            }
        }

        private void PictureStatus_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();

            if (pictureStatus.BackColor == Color.Green)
            {
                tt.SetToolTip(this.pictureStatus, "Status: Running");
            }
            else
            {
                tt.SetToolTip(this.pictureStatus, "Status: Stopped");
            }
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Size = lastSize;
            this.Location = lastLoc;

            if (checkMini.Checked == true && checkStartup.Checked == true)
            {
                WindowState = FormWindowState.Minimized;
                Hide();
            }
        }

        public void AutoStart()
        {
            if (checkAuto.Checked)
            {
                Start();
            }
        }

        private void CheckStartup_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (checkStartup.Checked)
            {
                rk.SetValue("GamePrioritizer", EXEC_PATH);
            }
            else
            {
                rk.DeleteValue("GamePrioritizer", false);
            }
        }

        /// <summary>
        /// Sending data to log.
        /// </summary>
        /// <param name="type">Info=1|Warning=2|Error=3</param>
        /// <param name="msg">String message</param>
        public void SendLogData(int type, string msg)
        {
            log.PrintLog(type, msg);
        }

        private void TextLog_VisibleChanged(object sender, EventArgs e)
        {
            if (textLog.Visible)
            {
                textLog.SelectionStart = textLog.TextLength;
                textLog.ScrollToCaret();
            }
        }

        private void ButtonOpenDataDir_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", APPDATA);
        }

        private void ButtonOpenLog_Click(object sender, EventArgs e)
        {
            Process.Start(APPDATA + "\\log.txt");
        }

        private void ButtonClearLog_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you really want to clear the log file?", "Clear log file", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                System.IO.File.WriteAllText(APPDATA + "\\log.txt", String.Empty);
                textLog.Clear();
            }
        }

        private void NotifMenuOpen_Click(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void NotifMenuCheckUpdate_Click(object sender, EventArgs e)
        {
            if (CheckForUpdate())
            {
                StartUpdater();
            }
        }

        private void NotifMenuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenGitHub();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            OpenGitHub();
        }

        public void OpenGitHub()
        {
            Process.Start("https://github.com/realNaits/Game-Prioritizer");
        }

        public void GrabChangeLog()
        {
            WebClient client = new WebClient();
            try
            {
                client.DownloadFile("https://realnaits.com/projects/gameoptimizer/Changelog.txt", APPDATA + "\\Changelog.txt");
                String content = File.ReadAllText(APPDATA + "\\Changelog.txt");
                textBoxChangeLog.Text = content;
            }
            catch (Exception e)
            {
                SendLogData(2, e.ToString());
            }
        }

        //Only accept numbers for check interval and max lengt is two.
        private void TextBoxCheckInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxCheckInterval.MaxLength = 2;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //Checking if check interval has a value, if not it stops the timer.
        private void TextBoxCheckInterval_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCheckInterval.TextLength == 0)
            {
                CHECK_INTERVAL = ConvertSecondsToMilliseconds(double.Parse("10"));
                run.tm.Interval = (int)CHECK_INTERVAL;
            }

            try
            {
                CHECK_INTERVAL = double.Parse(textBoxCheckInterval.Text);
                run.tm.Interval = ConvertSecondsToMilliseconds(CHECK_INTERVAL);
            }
            catch (Exception ex)
            {
                CHECK_INTERVAL = 10;
                run.tm.Interval = ConvertSecondsToMilliseconds(CHECK_INTERVAL);
            }
        }

        public double ConvertSecondsToMilliseconds(double seconds)
        {
            return TimeSpan.FromSeconds(seconds).TotalMilliseconds;
        }
    }
}
