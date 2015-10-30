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
using Emanuel.View;
using Emanuel.ViewModel;
using Microsoft.VisualBasic;

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
            InitializeData();
            
        }

        private void InitializeData()
        {
            dgMeetings.ItemsSource = eventViewModel.GetMeetings();
            FillComboBox();

        }

        private void FillComboBox()
        {

              List<KeyValuePair<int, string>> options = new List<KeyValuePair<int, string>>();
             options.Add(new KeyValuePair<int, string>(0, "--Seleccione una opciono--"));
             options.Add(new KeyValuePair<int, string>(1, "Registrar asistencia"));
             options.Add(new KeyValuePair<int, string>(2, "Ir a asistentes"));

           // List<Key val> options = new List<string> {"Seleccione una opcion", "Registrar asistencia", "ir a asistentes" };
            dgcbc.ItemsSource = options;
            dgcbc.SelectedValuePath = "Key";
            dgcbc.DisplayMemberPath = "Value";
            
            
        }

        #region Events
        private void SomeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            const int REGISTERASISTENCE = 1;
            const int GOASSISTENCESS = 2;
            var comboBox = sender as ComboBox;
            int index = (int)comboBox.SelectedValue;
            var selectedItem = this.dgMeetings.CurrentItem;
            MeetingModel meeting = (MeetingModel)selectedItem;

            switch (index)
            {
                case REGISTERASISTENCE: {
                    var dialog = new InputBox();
                    if (dialog.ShowDialog() == true)
                    {
                        MessageBox.Show("You said: " + dialog.ResponseText + "MEETING ID " + meeting.ID);
                        MainWindow.instance.UseAsisstControlPanel(Convert.ToInt32(dialog.ResponseText), meeting.ID);
                    }
                    
                    
                    break;
                }
                case GOASSISTENCESS:{
                    MainWindow.instance.UseAsisstReportPanel(meeting.ID);

                break;
                }

            }
           

        }
        #endregion

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.instance.UseMainView(); 
        }
    }
    
}
