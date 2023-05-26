using System;
using System.Collections.Generic;

namespace BudHillFMS.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Timekeepings = new HashSet<Timekeeping>();
        }

        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeAddress { get; set; }
        public string? EmployeePhone { get; set; }
        public string? EmployeeEmail { get; set; }
        public int FarmId { get; set; }
        public string? Position { get; set; }

        public virtual Farm? Farm { get; set; } 
        public virtual ICollection<Timekeeping> Timekeepings { get; set; }
    }
}
