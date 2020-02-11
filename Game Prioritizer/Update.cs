using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Prioritizer
{
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();

            WebClient client = new WebClient();

            client.DownloadProgressChanged += Client_DownloadProgressChanged;
            client.DownloadFileCompleted += Client_DownloadFileCompleted;
            Uri url = new Uri("https://realnaits.com/projects/gameoptimizer/update.zip");
            client.DownloadFileAsync(url, Form1.WORK_DIR + "\\update.zip");
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.Close();
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes * 100;

            progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());

        }
    }
}
