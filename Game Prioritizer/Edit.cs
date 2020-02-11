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
    public partial class Edit : Form
    {
        Form1 form1 = (Form1)Application.OpenForms["Form1"];

        String gameName;
        int gameRow;

        public Edit(String name, String path, System.Diagnostics.ProcessPriorityClass priority, int row)
        {
            InitializeComponent();

            gameName = name;
            gameRow = row;
            labelRow.Text = row.ToString();

            this.Text = name;

            textBoxPath.Text = path;
            comboBoxPriority.Text = priority.ToString();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ProcessPriorityClass pri = ProcessPriorityClass.Normal;

            if (comboBoxPriority.Text == "High" || comboBoxPriority.Text == "high")
            {
                pri = ProcessPriorityClass.High;
            }
            if (comboBoxPriority.Text == "AboveNormal" || comboBoxPriority.Text == "abovenormal")
            {
                pri = ProcessPriorityClass.AboveNormal;
            }
            if (comboBoxPriority.Text == "Normal" || comboBoxPriority.Text == "normal")
            {
                pri = ProcessPriorityClass.Normal;
            }

            form1.removeGameAt(gameRow);
            form1.addGame(gameName, textBoxPath.Text, pri);
            this.Close();
        }

        private void Edit_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.reEnableEdit = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "exe files (*.exe)|*.exe";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = ofd.FileName;
            }
        }
    }
}
