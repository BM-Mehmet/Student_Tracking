﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentTracking
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StudentTrackingDB : DbContext
    {
        public StudentTrackingDB()
            : base("name=StudentTrackingDB")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<courses> courses { get; set; }
        public virtual DbSet<group_requests> group_requests { get; set; }
        public virtual DbSet<groups> groups { get; set; }
        public virtual DbSet<program> program { get; set; }
        public virtual DbSet<semesters> semesters { get; set; }
        public virtual DbSet<students> students { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<teachers> teachers { get; set; }
    }
}
