namespace Game_Prioritizer
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureStatus = new System.Windows.Forms.PictureBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.pictureUpdate = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelGameRunning = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gameList = new System.Windows.Forms.ListBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkTray = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkAuto = new System.Windows.Forms.CheckBox();
            this.checkMini = new System.Windows.Forms.CheckBox();
            this.checkStartup = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolLabelVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.notifMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.notifMenuCheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.notifMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.notifMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(666, 347);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureStatus);
            this.tabPage1.Controls.Add(this.buttonStop);
            this.tabPage1.Controls.Add(this.buttonStart);
            this.tabPage1.Controls.Add(this.pictureUpdate);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.labelGameRunning);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.buttonDelete);
            this.tabPage1.Controls.Add(this.buttonEdit);
            this.tabPage1.Controls.Add(this.buttonAdd);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(658, 321);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Games";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureStatus
            // 
            this.pictureStatus.BackColor = System.Drawing.Color.DarkRed;
            this.pictureStatus.Location = new System.Drawing.Point(251, 9);
            this.pictureStatus.Name = "pictureStatus";
            this.pictureStatus.Size = new System.Drawing.Size(18, 18);
            this.pictureStatus.TabIndex = 10;
            this.pictureStatus.TabStop = false;
            this.pictureStatus.MouseHover += new System.EventHandler(this.pictureStatus_MouseHover);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(356, 6);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 9;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(275, 6);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 8;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // pictureUpdate
            // 
            this.pictureUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureUpdate.Image = global::Game_Prioritizer.Properties.Resources.update;
            this.pictureUpdate.Location = new System.Drawing.Point(535, 87);
            this.pictureUpdate.Name = "pictureUpdate";
            this.pictureUpdate.Size = new System.Drawing.Size(115, 96);
            this.pictureUpdate.TabIndex = 7;
            this.pictureUpdate.TabStop = false;
            this.pictureUpdate.Click += new System.EventHandler(this.pictureUpdate_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::Game_Prioritizer.Properties.Resources.N;
            this.pictureBox1.Location = new System.Drawing.Point(535, 189);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            // 
            // labelGameRunning
            // 
            this.labelGameRunning.AutoSize = true;
            this.labelGameRunning.ForeColor = System.Drawing.Color.Red;
            this.labelGameRunning.Location = new System.Drawing.Point(476, 11);
            this.labelGameRunning.Name = "labelGameRunning";
            this.labelGameRunning.Size = new System.Drawing.Size(89, 13);
            this.labelGameRunning.TabIndex = 5;
            this.labelGameRunning.Text = "no game running.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(437, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Active:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.gameList);
            this.groupBox1.Location = new System.Drawing.Point(8, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 265);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Game list";
            // 
            // gameList
            // 
            this.gameList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gameList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameList.Location = new System.Drawing.Point(3, 16);
            this.gameList.Name = "gameList";
            this.gameList.Size = new System.Drawing.Size(515, 246);
            this.gameList.TabIndex = 1;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(170, 6);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(89, 6);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(8, 6);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(658, 321);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkTray);
            this.groupBox3.Location = new System.Drawing.Point(8, 109);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(229, 125);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "General";
            // 
            // checkTray
            // 
            this.checkTray.AutoSize = true;
            this.checkTray.Location = new System.Drawing.Point(9, 19);
            this.checkTray.Name = "checkTray";
            this.checkTray.Size = new System.Drawing.Size(98, 17);
            this.checkTray.TabIndex = 0;
            this.checkTray.Text = "Minimize to tray";
            this.checkTray.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkAuto);
            this.groupBox2.Controls.Add(this.checkMini);
            this.groupBox2.Controls.Add(this.checkStartup);
            this.groupBox2.Location = new System.Drawing.Point(8, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(141, 97);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Startup";
            // 
            // checkAuto
            // 
            this.checkAuto.AutoSize = true;
            this.checkAuto.Location = new System.Drawing.Point(6, 65);
            this.checkAuto.Name = "checkAuto";
            this.checkAuto.Size = new System.Drawing.Size(83, 17);
            this.checkAuto.TabIndex = 2;
            this.checkAuto.Text = "Auto enable";
            this.checkAuto.UseVisualStyleBackColor = true;
            // 
            // checkMini
            // 
            this.checkMini.AutoSize = true;
            this.checkMini.Location = new System.Drawing.Point(6, 42);
            this.checkMini.Name = "checkMini";
            this.checkMini.Size = new System.Drawing.Size(96, 17);
            this.checkMini.TabIndex = 1;
            this.checkMini.Text = "Start minimized";
            this.checkMini.UseVisualStyleBackColor = true;
            // 
            // checkStartup
            // 
            this.checkStartup.AutoSize = true;
            this.checkStartup.Location = new System.Drawing.Point(6, 19);
            this.checkStartup.Name = "checkStartup";
            this.checkStartup.Size = new System.Drawing.Size(114, 17);
            this.checkStartup.TabIndex = 0;
            this.checkStartup.Text = "Start with windows";
            this.checkStartup.UseVisualStyleBackColor = true;
            this.checkStartup.CheckedChanged += new System.EventHandler(this.checkStartup_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(658, 321);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Log";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLabelVersion,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 325);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(666, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "0.0.0.1";
            // 
            // toolLabelVersion
            // 
            this.toolLabelVersion.Name = "toolLabelVersion";
            this.toolLabelVersion.Size = new System.Drawing.Size(40, 17);
            this.toolLabelVersion.Text = "0.0.0.1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.IsLink = true;
            this.toolStripStatusLabel1.LinkColor = System.Drawing.Color.Maroon;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(154, 17);
            this.toolStripStatusLabel1.Text = "naits - https://realnaits.com";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "Game Prioritizer";
            this.notifyIcon1.BalloonTipTitle = "Game Prioritizer";
            this.notifyIcon1.ContextMenuStrip = this.notifMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // notifMenu
            // 
            this.notifMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notifMenuOpen,
            this.notifMenuCheckUpdate,
            this.toolStripSeparator1,
            this.notifMenuExit});
            this.notifMenu.Name = "notifMenu";
            this.notifMenu.Size = new System.Drawing.Size(166, 76);
            // 
            // notifMenuOpen
            // 
            this.notifMenuOpen.Name = "notifMenuOpen";
            this.notifMenuOpen.Size = new System.Drawing.Size(165, 22);
            this.notifMenuOpen.Text = "Open";
            // 
            // notifMenuCheckUpdate
            // 
            this.notifMenuCheckUpdate.Name = "notifMenuCheckUpdate";
            this.notifMenuCheckUpdate.Size = new System.Drawing.Size(165, 22);
            this.notifMenuCheckUpdate.Text = "Check for update";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // notifMenuExit
            // 
            this.notifMenuExit.Name = "notifMenuExit";
            this.notifMenuExit.Size = new System.Drawing.Size(165, 22);
            this.notifMenuExit.Text = "Exit";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 347);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(682, 386);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Prioritizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.notifMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureUpdate;
        private System.Windows.Forms.ToolStripStatusLabel toolLabelVersion;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.PictureBox pictureStatus;
        public System.Windows.Forms.ListBox gameList;
        public System.Windows.Forms.Label labelGameRunning;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.CheckBox checkAuto;
        public System.Windows.Forms.CheckBox checkMini;
        public System.Windows.Forms.CheckBox checkStartup;
        public System.Windows.Forms.CheckBox checkTray;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip notifMenu;
        private System.Windows.Forms.ToolStripMenuItem notifMenuOpen;
        private System.Windows.Forms.ToolStripMenuItem notifMenuCheckUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem notifMenuExit;
    }
}

