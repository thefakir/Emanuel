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
                    {   ID = me.MeetingId,
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

        public void LogAssistControl(AssistControlModel assistControl)
        {
            Meeting_Pastor mp = new Meeting_Pastor
            {
                ChecInTime = assistControl.CheckInTime,
                DepartTime = assistControl.DepartTime,
                Comment = assistControl.Comment,
                ObservationId = assistControl.ObservationId,
                PastorId = assistControl.PastorId,
                MeetingId = assistControl.MeetingId
            };
            EmanuelDBEntitiesInstance.Meeting_Pastor.Add(mp);
            EmanuelDBEntitiesInstance.SaveChanges();
        }


        public List<MeetingReportModel> GetMeetingReport(int meetingId)
        {
            return (from me in EmanuelDBEntitiesInstance.Meetings
                    join
                    meetingPastor in EmanuelDBEntitiesInstance.Meeting_Pastor on me.MeetingId equals meetingPastor.MeetingId
                    join 
                    pastor in EmanuelDBEntitiesInstance.Pastors on meetingPastor.PastorId equals pastor.PastorId
                    where me.MeetingId == meetingId
                    select new MeetingReportModel
                    {
                        PastorName = pastor.Name +" " +pastor.LastName,
                        Church = pastor.Churches.FirstOrDefault().Name,
                        EventType = me.MeetingType.MeetingType1,
                        StarMeetingTime = me.StarMeetingDate,
                        CheckinTime = meetingPastor.ChecInTime == null ? DateTime.MinValue : (DateTime)meetingPastor.ChecInTime,
                                                
                    }
                        ).ToList();

          
        }
    }
}
