using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Emanuel.Models;
using Emanuel.ViewModel;

namespace Emanuel
{
    /// <summary>
    /// Interaction logic for Events.xaml
    /// </summary>
    public partial class Events : UserControl
    {
        public List<MeetingModel> events;
        private readonly MeetingViewModel eventViewModel = new MeetingViewModel();
      
        public Events()
        {
            InitializeComponent();

            //MeetingModel one = new MeetingModel
            //{
            //    MeetingId = 1,
            //    Description = "Willa",
            //    Title = "Cather",
            //    StarMeeting = DateTime.Now,
            //    EndMeeting = DateTime.Now,
            //    MeetingType = "AYUNO",
            //    MeetingTypeId = 1
            //};
           
            dgMeetings.ItemsSource = eventViewModel.GetMeetings();
        }
    }
    
}
