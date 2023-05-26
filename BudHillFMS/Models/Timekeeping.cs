using System;
using System.Collections.Generic;

namespace BudHillFMS.Models
{
    public partial class Timekeeping
    {
        public int TimekeepingId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public DateTime? TimekeepingDate { get; set; }

        public virtual Employee? Employee { get; set; } 
    }
}
