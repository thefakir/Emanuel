using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emanuel.Models;

namespace Emanuel.DataAccess
{
    class ChurchFromDB:IChurch
    {
        private readonly EmanuelEntities EmanuelDBEntitiesInstance;
        public ChurchFromDB()
        { 
            EmanuelDBEntitiesInstance = new EmanuelEntities();
        }

        public ChurchModel GetChurchInfoByPastorCode(int code)
        {
            var churchInfo = (from church in EmanuelDBEntitiesInstance.Churches
                              where church.Pastor.Code == code
                              select new ChurchModel
                              {   
                                  Name = church.Name,
                                  Address = church.Adress,
                                  Zone = new ZoneModel { ID = church.Zone.ZoneId, zoneNumber = church.Zone.ZoneNumber },
                                  Pastor = new PastorModel
                                  {
                                      ID = church.Pastor.PastorId,
                                      Name = church.Pastor.Name,
                                      LastName = church.Pastor.LastName,
                                      BirthDay = church.Pastor.BirthDay,
                                      Code = church.Pastor.Code,
                                      PresentationDate = church.Pastor.PresentationDate,
                                      CellNumber = church.Pastor.CellNumber,
                                      MaritalStatus = new MaritalStatusModel
                                      {
                                          ID = church.Pastor.MaritalStatu.MaritalStatusId,
                                          MaritalStatus = church.Pastor.MaritalStatu.Status,
                                      },
                                      MinisteralLevel = new MinisteralLevelModel
                                      {
                                          ID = church.Pastor.MinisteralLevel.MinisteralLevelId,
                                          MinisteralLevel = church.Pastor.MinisteralLevel.MinisteralLevel1
                                      }


                                  },
                              }).ToList();

            if (churchInfo.Any())
                return churchInfo.First();

            return null;
        }
    }
}
