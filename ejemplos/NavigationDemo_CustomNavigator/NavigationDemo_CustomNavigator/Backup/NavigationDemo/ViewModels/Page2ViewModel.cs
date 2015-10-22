using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Navigation;
using System.Windows;
using System.Windows.Input;

using Onyx;
using Onyx.ComponentModel;
using Onyx.Windows;

namespace NavigationDemo
{
    public class Page2ViewModel : ViewModel
    {
        public Page2ViewModel(View view)
            : base(view)
        {
            this.CommandBindings.Add(new CommandBinding(NavCommand, this.NavCommandExecute, new CanExecuteRoutedEventHandler(this.NavCommandCanExecute)));
        }

        #region NavCommand
        /// <summary>
        /// 
        /// </summary>
        private static readonly RoutedUICommand navCommand = new System.Windows.Input.RoutedUICommand("nav", "NavCommand", typeof(Page2ViewModel));
        /// <summary>
        /// 
        /// </summary>
        public static RoutedUICommand NavCommand
        {
            get { return navCommand; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NavCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void NavCommandExecute(object sender, ExecutedRoutedEventArgs args)
        {
            NavigationService service = NavigationService.GetNavigationService(this.View.ViewElement);

            try
            {
                // We use absolute Uri path, since it should be valid in both cases when run from local or remote assemblies
                Uri uri = new Uri("pack://application:,,,/NavigationDemo;component/" + args.Parameter.ToString(), UriKind.Absolute);
                service.Navigate(uri);
            }
            catch (Exception ex)
            {
            }
        }
        #endregion //navCommand
    }
}
