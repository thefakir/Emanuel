using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emanuel.Models
{
   public class PastorModel
    {
       public int ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public int Code { get;set; }
        public string CellNumber { get; set; }
        public DateTime PresentationDate { get; set; }
        public MaritalStatusModel MaritalStatus { get; set; }
        public MinisteralLevelModel MinisteralLevel {get;set;}
    }
}
