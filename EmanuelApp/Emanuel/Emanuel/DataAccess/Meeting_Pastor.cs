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
    
    public partial class Meeting_Pastor
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> ChecInTime { get; set; }
        public Nullable<System.DateTime> DepartTime { get; set; }
        public string Comment { get; set; }
        public int ObservationId { get; set; }
        public int PastorId { get; set; }
        public int MeetingId { get; set; }
    
        public virtual Meeting Meeting { get; set; }
        public virtual Observation Observation { get; set; }
        public virtual Pastor Pastor { get; set; }
    }
}
