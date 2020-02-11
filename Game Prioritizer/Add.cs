using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Prioritizer
{
    public partial class Add : Form
    {
        Form1 form1 = (Form1)Application.OpenForms["Form1"];

        public Add()
        {
            InitializeComponent();
        }

        private void Add_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.reEnableAdd = true;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "exe files (*.exe)|*.exe";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                gName.Text = ofd.SafeFileName;
                gPath.Text = ofd.FileName;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ProcessPriorityClass pri = ProcessPriorityClass.Normal;

            if (comboBox1.Text == "High" || comboBox1.Text == "high")
            {
                pri = ProcessPriorityClass.High;
            }
            if (comboBox1.Text == "AboveNormal" || comboBox1.Text == "abovenormal")
            {
                pri = ProcessPriorityClass.AboveNormal;
            }
            if (comboBox1.Text == "Normal" || comboBox1.Text == "normal")
            {
                pri = ProcessPriorityClass.Normal;
            }


            form1.addGame(gName.Text, gPath.Text, pri);
            this.Close();
        }
    }
}
