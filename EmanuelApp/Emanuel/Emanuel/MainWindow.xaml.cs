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
using Emanuel.View;

namespace Emanuel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainView mainPanel;
        public static AssistControl assistControl;
        public static MainWindow instance;
        public static Events events;
        public static EventForm eventForm;
        public static EventReport assistReport;
        public MainWindow()
        {   
            InitializeComponent();
           

            instance = this;
            events = new Events();
            eventForm = new EventForm();
            mainPanel = new MainView();
            assistControl = new AssistControl();
            assistReport = new EventReport();

            this.Content = mainPanel;
           
        }

        public void UseMainView()
        {
        this.Content = mainPanel;
        }
        public void UseAsisstControlPanel(int code, int meetingID)
        {
            this.Content = assistControl;
            assistControl.FillInPastorformation(code, meetingID);
        }
        public void UseEventsPanel()
        {
            this.Content = events;
            
        }
        public void UseEventFormPanel()
        {
            this.Content = eventForm;

        }
        private void btnCreateEvent_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new EventForm();
        }
        public void UseAsisstReportPanel(int meetingId)
        {
            this.Content = assistReport;
            assistReport.InitializeData(meetingId);

        }
        
    }
}
