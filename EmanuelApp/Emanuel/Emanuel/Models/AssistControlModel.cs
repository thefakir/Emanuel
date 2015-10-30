using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emanuel.Models
{
    public class AssistControlModel
    {
        public DateTime? CheckInTime { get; set; }
        public DateTime? DepartTime { get; set; }
        public string  Comment{ get; set; }
        public int ObservationId { get; set; }
        public int PastorId { get; set; }
        public int MeetingId { get; set;}

    }
}
