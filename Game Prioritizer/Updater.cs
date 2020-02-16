using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Game_Prioritizer
{
    class Updater
    {
        private Form1 main;
        public Updater(Form1 form1)
        {
            this.main = form1;
        }

        public string version = "0.0.0.0";

        public Boolean CheckUpdate()
        {
            main.SendLogData(1, "Checking for updates.");
            return DoAsync().Result;
        }

        public async Task<bool> DoAsync(){
            try
            {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead("https://realnaits.com/projects/gameoptimizer/v2.txt");
                StreamReader reader = new StreamReader(stream);
                String content = reader.ReadToEnd();

                var current = new Version(Form1.GetVersion().ToString());
                var newVersion = new Version(content);

                var result = current.CompareTo(newVersion);
                if (result < 0)
                {
                    version = result.ToString();
                    return true;
                }
                return false;
            }catch(Exception e)
            {
                main.SendLogData(3, "Message: " + e);
                return false;
            }
        }
    }
}
