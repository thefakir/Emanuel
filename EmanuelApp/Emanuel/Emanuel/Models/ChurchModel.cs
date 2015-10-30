using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emanuel.Models
{
    class ChurchModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ZoneModel Zone { get; set; }
        public PastorModel Pastor { get; set; }

    }
}
