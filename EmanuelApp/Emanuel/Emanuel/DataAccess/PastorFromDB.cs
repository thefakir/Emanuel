using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emanuel.Models;

namespace Emanuel.DataAccess
{
    public class PastorFromDB:IPastor
    {
        private readonly EmanuelEntities EmanuelDBEntitiesInstance;
        public PastorFromDB()
        { 
            EmanuelDBEntitiesInstance = new EmanuelEntities();
        }


        public PastorModel GetPastorByCode(int code)
        {
            return null;
        }
    }
}
