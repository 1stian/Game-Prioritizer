using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Prioritizer
{
    public class Data
    {
        private Boolean _startup;
        public Boolean Startup
        {
            get { return _startup; }
            set { _startup = value; }
        }

        private Boolean _minimized;
        public Boolean Minimized
        {
            get { return _minimized; }
            set { _minimized = value; }
        }

        private Boolean _autoRun;
        public Boolean AutoRun
        {
            get { return _autoRun; }
            set { _autoRun = value; }
        }

        private Boolean _tray;
        public Boolean Tray
        {
            get { return _tray; }
            set { _tray = value; }
        }
    }
}
