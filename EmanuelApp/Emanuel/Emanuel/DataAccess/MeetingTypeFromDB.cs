using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Emanuel.Models;

namespace Emanuel.DataAccess
{
    class MeetingTypeFromDB:IMeetingType
    {
        private readonly EmanuelEntities EmanuelDBEntitiesInstance;

        public MeetingTypeFromDB()
        {
            EmanuelDBEntitiesInstance = new EmanuelEntities();
        }
        public IList<MeetingTypeModel> GetMeetingType()
        {
            try
            {
                List<MeetingType> test = EmanuelDBEntitiesInstance.MeetingTypes.ToList();
                var meetingTypes = (from mt in EmanuelDBEntitiesInstance.MeetingTypes
                                    select new MeetingTypeModel()
                                    {
                                        ID = mt.MeetingTypeId,
                                        Type = mt.MeetingType1
                                    }).ToList();
                return meetingTypes;
            }catch  (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }
    }
}
