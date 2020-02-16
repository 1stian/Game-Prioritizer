using System;
using System.IO;
using System.Xml.Serialization;

namespace Game_Prioritizer
{
    class Settings
    {
        private Form1 main;
        public Settings(Form1 form1)
        {
            this.main = form1;
        }

        Data data = new Data();

        //Load and save
        public void LoadSettings()
        {
            if (File.Exists(Form1.APPDATA + "\\data.xml"))
            {
                data = XmlDataReader(Form1.APPDATA + "\\data.xml");
                main.lastLoc = data.Location;
                main.lastSize = data.Size;
                main.checkStartup.Checked = data.Startup;
                main.checkMini.Checked = data.Minimized;
                main.checkAuto.Checked = data.AutoRun;
                main.checkTray.Checked = data.Tray;
                main.CHECK_INTERVAL = data.Interval;
            }            
        }

        public void SaveSettings()
        {
            Boolean startup = false;
            Boolean mini = false;
            Boolean auto = false;
            Boolean tray = false;

            if (main.checkStartup.Checked == true)
            {
                startup = true;
            }
            if (main.checkMini.Checked == true)
            {
                mini = true;
            }
            if (main.checkAuto.Checked == true)
            {
                auto = true;
            }
            if (main.checkTray.Checked == true)
            {
                tray = true;
            }

            data.Size = main.lastSize;
            data.Location = main.lastLoc;
            data.Startup = startup;
            data.Minimized = mini;
            data.AutoRun = auto;
            data.Tray = tray;
            data.Interval = main.CHECK_INTERVAL;

            XmlDataWriter(data, Form1.APPDATA + "\\data.xml");
        }


        //Writer and reader!
        public static void XmlDataWriter(object obj, string filename)
        {
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            TextWriter writer = new StreamWriter(filename);
            sr.Serialize(writer, obj);
            writer.Close();
        }

        public static Data XmlDataReader(string filename)
        {
            Data obj = new Data();
            XmlSerializer xs = new XmlSerializer(typeof(Data));
            FileStream reader = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);

            try
            {
                obj = (Data)xs.Deserialize(reader);
                reader.Close();
                return obj;
            }
            catch(Exception e)
            {
                reader.Close();
                return obj;
            }
            reader.Close();
            return obj;
        }
    }
}
