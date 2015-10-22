using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Windows.Navigation;

namespace testUnit
{
    public partial class TestForm : Form
    {
        private NavigationWindow nw;
        private Uri uri;

        public TestForm()
        {
            InitializeComponent();

            nw = new NavigationWindow();

            try
            {
                uri = new Uri("pack://application:,,,/NavigationDemo;component/Page1.xaml", UriKind.Absolute);
                nw.Navigate(uri);
                nw.Show();
            }
            catch (Exception ex) {}
        }

        private void button_page1_Click(object sender, EventArgs e)
        {
            try
            {
                uri = new Uri("pack://application:,,,/NavigationDemo;component/Page1.xaml", UriKind.RelativeOrAbsolute);
                nw.Navigate(uri);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button_page2_Click(object sender, EventArgs e)
        {
            try
            {
                uri = new Uri("pack://application:,,,/NavigationDemo;component/Page2.xaml", UriKind.RelativeOrAbsolute);
                nw.Navigate(uri);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button_page3_Click(object sender, EventArgs e)
        {
            try
            {
                uri = new Uri("pack://application:,,,/NavigationDemo;component/Page3.xaml", UriKind.RelativeOrAbsolute);
                nw.Navigate(uri);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
