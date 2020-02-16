using System;

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

        private System.Drawing.Point _location;
        public System.Drawing.Point Location
        {
            get { return _location; }
            set { _location = value; }
        }

        private System.Drawing.Size _size;
        public System.Drawing.Size Size
        {
            get { return _size; }
            set { _size = value; }
        }

        private Double _interval;
        public Double Interval
        {
            get { return _interval; }
            set { _interval = value; }
        }
    }
}
