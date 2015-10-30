using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emanuel.DataAccess;
using Emanuel.Models;

namespace Emanuel.ViewModel
{
    public class MeetingViewModel
    {
        private MeetingModel obj = new MeetingModel();
        private MeetingReportModel meetingReport = new MeetingReportModel();
        private MeetingFromDB _meetingService = new MeetingFromDB();

        public string TxtTitle
        {
            get { return obj.Title; }
            set { obj.Title = value; }
        }

        public string TxtDescription
        {
            get { return obj.Description; }
            set { obj.Description = value; }
        }
        public string TxtStarMeetingtDate
        {
            get { return obj.StarMeeting.ToString(); }
            set { obj.StarMeeting = Convert.ToDateTime(value);}
        }
        public string TxtEndMeetingDate
        {
            get { return obj.EndMeeting.ToString(); }
            set { obj.EndMeeting = Convert.ToDateTime(value); }
        }
        public string TxtMeetingTypeId
        {
            get { return obj.MeetingTypeId.ToString(); }
            set { obj.MeetingTypeId = Convert.ToInt32(value); }
        }

        public void CreateEvent()
        {
            _meetingService.CreateMeeting(obj);
        }

        public ObservableCollection<MeetingModel> GetMeetings()
        {
            ObservableCollection<MeetingModel> res = new ObservableCollection<MeetingModel>();

            foreach (var meeting in _meetingService.GetMeetings())
            {
                   res.Add(meeting);
            }

            return res;
        }
        public void LogAssistControl(AssistControlModel ac)
        {
            _meetingService.LogAssistControl(ac);
        }

        public ObservableCollection<MeetingReportModel> GetMeetingReport(int meetingID)
        {
            ObservableCollection<MeetingReportModel> res = new ObservableCollection<MeetingReportModel>();

            foreach (var meeting in _meetingService.GetMeetingReport(meetingID))
            {
                res.Add(meeting);
            }

            return res;
        }
    }
}
