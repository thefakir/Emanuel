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
using Emanuel.Models;
using Emanuel.ViewModel;

namespace Emanuel.View
{
    /// <summary>
    /// Interaction logic for AssistControl.xaml
    /// </summary>
    public partial class AssistControl : UserControl
    {
        private ChurchModel churchModel;
        private int MeetingId;
        public AssistControl()
        {
            InitializeComponent();
        }
        public void FillInPastorformation(int code, int meetingId)
        {
            ChurchViewModel church = new ChurchViewModel();
            churchModel = church.GetChurchByPastorCode(code);
            this.MeetingId = meetingId; 
            lblPastorName.Content = churchModel.Pastor.Name + " " + churchModel.Pastor.LastName;
            lblMaritalStatus.Content = churchModel.Pastor.MaritalStatus.MaritalStatus;
            lblCelNumber.Content = churchModel.Pastor.CellNumber;
            lblMinisteralLvel.Content = churchModel.Pastor.MinisteralLevel.MinisteralLevel;
            lblPresentarionDate.Content = churchModel.Pastor.PresentationDate.ToString();
            lblBirthDay.Content = churchModel.Pastor.BirthDay.ToString();

            lblChurchName.Content = churchModel.Name;
            lblChurchAddress.Content = churchModel.Address;
            lblZoneNumber.Content = churchModel.Zone.zoneNumber.ToString();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.instance.UseEventsPanel();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            MeetingViewModel meetingViewModel = new MeetingViewModel();
            AssistControlModel ac = new AssistControlModel
            {
                PastorId = churchModel.Pastor.ID,
                CheckInTime = DateTime.Now,
                DepartTime = null,
                Comment = "",
                ObservationId = 1,
                MeetingId =MeetingId

            };

            meetingViewModel.LogAssistControl(ac);
        }
    }
}
