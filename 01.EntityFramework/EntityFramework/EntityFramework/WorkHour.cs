//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkHour
    {
        public WorkHour()
        {
            this.WorkHoursLogs = new HashSet<WorkHoursLog>();
            this.WorkHoursLogs1 = new HashSet<WorkHoursLog>();
        }
    
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Nullable<System.DateTime> WorkDate { get; set; }
        public string Tasks { get; set; }
        public int Hours { get; set; }
        public string Comments { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual ICollection<WorkHoursLog> WorkHoursLogs { get; set; }
        public virtual ICollection<WorkHoursLog> WorkHoursLogs1 { get; set; }
    }
}
