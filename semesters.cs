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
    
    public partial class semesters
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public semesters()
        {
            this.program = new HashSet<program>();
        }
    
        public int id { get; set; }
        public string academic_year { get; set; }
        public Nullable<int> semester { get; set; }
        public Nullable<bool> is_visible { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<program> program { get; set; }
    }
}
