﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EmanuelEntities : DbContext
    {
        public EmanuelEntities()
            : base("name=EmanuelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Church> Churches { get; set; }
        public DbSet<MaritalStatu> MaritalStatus { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Meeting_Pastor> Meeting_Pastor { get; set; }
        public DbSet<MeetingType> MeetingTypes { get; set; }
        public DbSet<MinisteralLevel> MinisteralLevels { get; set; }
        public DbSet<Observation> Observations { get; set; }
        public DbSet<Pastor> Pastors { get; set; }
        public DbSet<Zone> Zones { get; set; }
    }
}
