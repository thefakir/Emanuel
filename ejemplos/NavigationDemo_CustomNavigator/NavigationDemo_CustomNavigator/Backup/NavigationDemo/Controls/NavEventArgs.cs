using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavigationDemo
{
    public delegate void NavEventHandler(object sender, NavEventArgs e);

    public class NavEventArgs : EventArgs
    {
        private Uri _uri;
        
        public NavEventArgs() { }
        public NavEventArgs(Uri uri) 
        {
            _uri = uri;
        }

        public Uri Uri
        {
            get { return _uri; }
            set
            {
                if (_uri != value)
                    _uri = value;
            }
        }
    }
}
