//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class group_memberships
    {
        public int id { get; set; }
        public Nullable<int> group_id { get; set; }
        public Nullable<int> student_id { get; set; }
        public Nullable<System.DateTime> join_date { get; set; }
        public string status { get; set; }
    
        public virtual groups groups { get; set; }
        public virtual students students { get; set; }
    }
}
