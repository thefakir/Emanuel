using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Emanuel.ViewModel;
using Xceed.Wpf;


namespace Emanuel
{
    /// <summary>
    /// Interaction logic for EventForm.xaml
    /// </summary>
    public partial class EventForm : UserControl
    {
        public EventForm()
        {
            InitializeComponent();
            FillMeetingTypeCombox();
        }

        #region methods
        public void FillMeetingTypeCombox(){
              MeetingTypeViewModel mt = new MeetingTypeViewModel();
              cbMeetingType.ItemsSource = mt.getMeetingTypes();
              cbMeetingType.SelectedValuePath = "Key";
              cbMeetingType.DisplayMemberPath = "Value";
              cbMeetingType.SelectedValue = 0;
        
        }
        #endregion

        private void btbGoToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Main();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MeetingViewModel m = new MeetingViewModel();
            m.TxtTitle = txtTitle.Text;
            m.TxtDescription = txtDescription.Text;
               TimeSpan starTime = ((DateTime)tpStarTime.Value).TimeOfDay;
               TimeSpan endTime = ((DateTime)tpEndTime.Value).TimeOfDay;
            m.TxtStarMeetingtDate = ((DateTime)dpstarMeetingTime.SelectedDate).Add(starTime).ToString();
            m.TxtEndMeetingDate = ((DateTime)dpEndMeetingTime.SelectedDate).Add(endTime).ToString();
                       
            m.TxtMeetingTypeId = cbMeetingType.SelectedIndex.ToString();

            m.CreateEvent();

            this.Content = new Main();
        }
    }
}
