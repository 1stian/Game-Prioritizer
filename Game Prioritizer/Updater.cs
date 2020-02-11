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

        public Boolean checkUpdate()
        {
            main.sendLogData(1, "Checking for updates.");
            return doAsync().Result;
        }

        public async Task<bool> doAsync(){
            try
            {
                WebClient client = new WebClient();
                Stream stream = client.OpenRead("https://realnaits.com/projects/gameoptimizer/version.txt");
                StreamReader reader = new StreamReader(stream);
                String content = reader.ReadToEnd();

                var current = new Version(Form1.getVersion().ToString());
                var newVersion = new Version(content);

                var result = current.CompareTo(newVersion);
                if (result < 0)
                {
                    return true;
                }
                return false;
            }catch(Exception e)
            {
                main.sendLogData(3, "Message: " + e);
                return false;
            }
        }
    }
}
