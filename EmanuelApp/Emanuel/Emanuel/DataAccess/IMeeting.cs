using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emanuel.Models;

namespace Emanuel.DataAccess
{
    interface IMeeting
    {
        void CreateMeeting(MeetingModel meeting);

        void EditMeeting(int meetingId);

        void DeleteMeeting(int meetingId);

        List<MeetingModel> GetMeetings();
    }
}
