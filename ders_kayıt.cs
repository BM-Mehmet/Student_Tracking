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
    
    public partial class ders_kayıt
    {
        public int id { get; set; }
        public Nullable<int> student_id { get; set; }
        public Nullable<int> course_id { get; set; }
        public string enrollment_status { get; set; }
        public Nullable<System.DateTime> enrollment_date { get; set; }
    
        public virtual students students { get; set; }
        public virtual courses courses { get; set; }
    }
}
