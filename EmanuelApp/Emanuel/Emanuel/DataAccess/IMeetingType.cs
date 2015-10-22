using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emanuel.Models;

namespace Emanuel.DataAccess
{
    interface IMeetingType
    {
        IList<MeetingTypeModel> GetMeetingType();
    }
}
