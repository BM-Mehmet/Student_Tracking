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
    
    public partial class group_requests
    {
        public int id { get; set; }
        public int group_id { get; set; }
        public int student_id { get; set; }
        public int course_id { get; set; }
        public string status { get; set; }
        public Nullable<bool> is_visible { get; set; }
        public System.DateTime request_date { get; set; }
        public string join_message { get; set; }
        public string reject_reason { get; set; }
    
        public virtual courses courses { get; set; }
        public virtual groups groups { get; set; }
        public virtual students students { get; set; }
    }
}
