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
    
    public partial class groups
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public groups()
        {
            this.group_memberships = new HashSet<group_memberships>();
            this.group_requests = new HashSet<group_requests>();
            this.students = new HashSet<students>();
            this.TeacherRequests = new HashSet<TeacherRequests>();
        }
    
        public int id { get; set; }
        public string group_name { get; set; }
        public int program_id { get; set; }
        public Nullable<int> course_id { get; set; }
        public Nullable<int> leader_student_id { get; set; }
        public Nullable<bool> is_visible { get; set; }
        public string description { get; set; }
        public Nullable<bool> is_single_member { get; set; }
    
        public virtual courses courses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<group_memberships> group_memberships { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<group_requests> group_requests { get; set; }
        public virtual program program { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<students> students { get; set; }
        public virtual students students1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeacherRequests> TeacherRequests { get; set; }
    }
}
