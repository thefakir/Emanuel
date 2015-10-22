using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;

using System.Windows.Input;
using System.ComponentModel;

namespace NavigationDemo
{
    public class NavScroller : ItemsControl
    {
        #region Fields
        private NavigationService _service;
        private ObservableCollection<NavCommandItem> _commands = new ObservableCollection<NavCommandItem>();
        private Uri _current;
        #endregion //Fields

        #region .ctor
        static NavScroller()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
            typeof(NavScroller),
            new FrameworkPropertyMetadata(typeof(NavScroller)));
        }
        public NavScroller()
        {
            DispatcherOperationCallback method = null;

            method = delegate(object unused)
            {
                _service = NavigationService.GetNavigationService(this);
                _service.Navigating += new NavigatingCancelEventHandler(OnNavigating);

                return null;
            };
            this.Dispatcher.BeginInvoke(DispatcherPriority.Send, method, null);

            ItemsSource = Commands;
        }

        #endregion //.ctor

        #region Commands
        private static readonly RoutedUICommand leftCommand = new RoutedUICommand("left", "LeftCommand", typeof(NavScroller));
        public static RoutedUICommand LeftCommand
        {
            get { return leftCommand; }
        }
        private static readonly RoutedUICommand rightCommand = new RoutedUICommand("right", "RightCommand", typeof(NavScroller));
        public static RoutedUICommand RightCommand
        {
            get { return rightCommand; }
        }
        #endregion //Commands

        #region Handlers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnNavigating(object sender, NavigatingCancelEventArgs e)
        {
            try
            {
                NavCommandItem item = NavActivator.Instance.Create(e.Uri,new object[] {this, e.Uri}) as NavCommandItem;
                if (!_commands.Contains(item))
                {
                    _commands.Add(item);
                }
                Current = e.Uri;
            }
            catch(Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="constraint"></param>
        /// <returns></returns>
        protected override Size MeasureOverride(Size constraint)
        {
            FindNavigator();

            return base.MeasureOverride(constraint);
        }
        /// <summary>
        /// 
        /// </summary>
        private void FindNavigator()
        {
            NavDecorator nav = this.Template.FindName("PART_Navigator",this) as NavDecorator;
            if (nav == null)
                return;

            this.CommandBindings.Add(new CommandBinding(LeftCommand, nav.MoveLeft, new CanExecuteRoutedEventHandler(nav.CanLeft)));
            this.CommandBindings.Add(new CommandBinding(RightCommand, nav.MoveRight, new CanExecuteRoutedEventHandler(nav.CanRight)));
        }
        /// <summary>
        /// 
        /// </summary>
        private void ResetCommands()
        {
            _commands.Clear();

            foreach(object item in Items){
                 _commands.Add(new NavCommandItem(this, new Uri(item.ToString(),UriKind.Absolute)));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        public void Navigate(Uri uri)
        {
            if (_service == null)
                throw new ApplicationException();

            _service.Navigate(uri);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        public void Close(Uri uri)
        {
            try
            {
                NavCommandItem item = NavActivator.Instance.Resolve(uri) as NavCommandItem;
                if (_commands.Contains(item))
                {
                    _commands.Remove(item);
                    if (item.Active && _commands.Count > 0)
                    {
                        _service.Navigating -= new NavigatingCancelEventHandler(OnNavigating);
                        _service.Navigate(_commands.Last<NavCommandItem>().Uri);
                        _service.Navigating += new NavigatingCancelEventHandler(OnNavigating);
                    }
                    Current = _commands.Last<NavCommandItem>().Uri;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }
        #endregion //Methods

        #region Properties
        public ObservableCollection<NavCommandItem> Commands
        {
            get { return _commands; }
            set
            {
                if (_commands != value)
                    _commands = value;
            }
        }
        public NavigationService Service 
        {
            get { return _service; }
            set
            {
                if (_service != value)
                    _service = value;
            } 
        }
        public Uri Current
        {
            get { return _current; }
            set
            {
                if (_current != value)
                {
                    _current = value;
                    OnUriChanged(_current);
                }
            }

        }
        #endregion //Properties

        public void OnUriChanged(Uri _uri){
            try
            {
                if (UriChanged != null)
                    UriChanged(this, new NavEventArgs(_uri));
            }
            catch(Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }
        public event NavEventHandler UriChanged;
    }
}
