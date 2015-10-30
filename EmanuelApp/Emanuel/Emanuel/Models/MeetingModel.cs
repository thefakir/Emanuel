using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emanuel.Models
{
    public class MeetingModel
    {
        public int ID { get; set; }
        public int MeetingId { get; set;}
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StarMeeting { get; set; }
        public DateTime EndMeeting { get; set; }
        public int MeetingTypeId{ get; set;}
        public string MeetingType{ get; set;}
    }
}
