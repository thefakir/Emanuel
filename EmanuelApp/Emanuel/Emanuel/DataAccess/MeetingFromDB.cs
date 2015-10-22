using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emanuel.Models;

namespace Emanuel.DataAccess
{
    public class MeetingFromDB: IMeeting
    {
        private readonly EmanuelEntities EmanuelDBEntitiesInstance;

        public MeetingFromDB()
        {
            EmanuelDBEntitiesInstance = new EmanuelEntities();
        }

        public void CreateMeeting(MeetingModel meeting)
        {
            var meetingDB = new Meeting
            {
                Title = meeting.Title,
                Description = meeting.Description,
                StarMeetingDate = meeting.StarMeeting,
                EndMeetingDate = meeting.EndMeeting,
                MeetingTypeId = meeting.MeetingTypeId
            };

            EmanuelDBEntitiesInstance.Meetings.Add(meetingDB);
            EmanuelDBEntitiesInstance.SaveChanges();
        }

        public void EditMeeting(int meetingId)
        {
            throw new NotImplementedException();
        }

        public void DeleteMeeting(int meetingId)
        {
            throw new NotImplementedException();
        }


        public List<MeetingModel> GetMeetings()
        {
            return (from me in EmanuelDBEntitiesInstance.Meetings
                    select new MeetingModel
                    {
                        MeetingId = me.MeetingId,
                        Title = me.Title,
                        Description = me.Description,
                        StarMeeting = me.StarMeetingDate,
                        EndMeeting = me.EndMeetingDate,
                        MeetingTypeId = me.MeetingId,
                        MeetingType = me.MeetingType.MeetingType1
                    }
                        ).ToList();
        }
    }
}
