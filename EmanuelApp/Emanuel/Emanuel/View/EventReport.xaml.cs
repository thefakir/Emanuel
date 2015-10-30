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

namespace Emanuel.View
{
    /// <summary>
    /// Interaction logic for EventReport.xaml
    /// </summary>
    public partial class EventReport : UserControl
    {
   
        private readonly MeetingViewModel eventViewModel = new MeetingViewModel();
        public EventReport()
        {
            InitializeComponent();
           // InitializeData();
        }
        public void InitializeData(int meetingId)
        {
            dgMeetingReport.ItemsSource = eventViewModel.GetMeetingReport(meetingId);
         

        }
    }
}
