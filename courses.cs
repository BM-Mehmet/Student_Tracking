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
    
    public partial class courses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public courses()
        {
            this.groups = new HashSet<groups>();
            this.program = new HashSet<program>();
        }
    
        public int id { get; set; }
        public string course_name { get; set; }
        public Nullable<bool> is_group_enabled { get; set; }
        public Nullable<int> semester_id { get; set; }
        public Nullable<bool> is_visible { get; set; }
        public Nullable<bool> is_alone_enabled { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<groups> groups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<program> program { get; set; }
    }
}
