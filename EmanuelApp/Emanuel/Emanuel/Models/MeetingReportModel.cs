using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emanuel.Models
{
    public class MeetingReportModel
    {
        public string PastorName{ get; set;}
        public string Church { get; set; }
        public string EventType { get; set; }
        public DateTime StarMeetingTime { get; set; }
        public DateTime CheckinTime { get; set; }
        public string DelayTime { get; set; }
    }
}
