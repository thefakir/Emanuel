using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emanuel.DataAccess;
using Emanuel.Models;

namespace Emanuel.ViewModel
{
    class MeetingTypeViewModel
    {
        private readonly MeetingTypeFromDB _meetingTypeServices = new MeetingTypeFromDB();

        public List<KeyValuePair<int, string>> getMeetingTypes()
        {
            List<MeetingTypeModel> meetingTypes = _meetingTypeServices.GetMeetingType() as List<MeetingTypeModel>;
            List<KeyValuePair<int, string>> res = new List<KeyValuePair<int, string>>();
            res.Add(new KeyValuePair<int, string>(0, "--Seleccione un tipo--"));
            foreach (var mt in meetingTypes)
            {
                res.Add(new KeyValuePair<int, string>(mt.ID, mt.Type));
            }
            return res;
        }
    }
}
