//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Emanuel.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Observation
    {
        public Observation()
        {
            this.Meeting_Pastor = new HashSet<Meeting_Pastor>();
        }
    
        public int ObservationId { get; set; }
        public string Observation1 { get; set; }
    
        public virtual ICollection<Meeting_Pastor> Meeting_Pastor { get; set; }
    }
}
