using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;

using System.Windows;
using System.Windows.Input;

namespace NavigationDemo
{
    public class NavCommandItem : ICommand, INotifyPropertyChanged
    {
        #region Fields
        private NavScroller _navScroller;
        private Uri _uri;
        private bool _active;
        #endregion //Fields

        #region .ctor
        static NavCommandItem(){}
        public NavCommandItem(NavScroller parent, Uri uri)
        {
            _navScroller = parent;
            _uri = uri;
            _navScroller.UriChanged += new NavEventHandler(_navScroller_UriChanged);
        }
        #endregion //.ctor

        #region Methods
        bool ICommand.CanExecute(object parameter)
        {
            return true;
        }
        void ICommand.Execute(object parameter)
        {
            if (parameter != null && parameter.ToString() == "close")
            {
                _navScroller.Close(_uri);
            }
            else
            {
                _navScroller.Navigate(_uri);
            }
        }
        private void _navScroller_UriChanged(object sender, NavEventArgs e)
        {
            if (_uri == e.Uri)
                Active = true;
            else
                Active = false;
        }
        #endregion //Methods

        #region Events
        public event EventHandler CanExecuteChanged;
        #endregion

        #region Properties
        public bool Active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value;
                    OnPropertyChanged("Active");
                }
            }
        }
        public Uri Uri
        {
            get { return _uri; }
        }
        public string Title
        {
            get { return _uri.ToString(); }
        }
        #endregion //Properties

        #region INotifyPropertyChanged
        public void OnPropertyChanged(string name)
        {
            try
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
            catch(Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
