using System;
using System.Collections.Generic;

namespace BudHillFMS.Models
{
    public partial class Seedling
    {
        public int SeedlingId { get; set; }
        public string? SeedlingName { get; set; }
        public string? SeedlingDescription { get; set; }
        public DateTime? SeedlingStart { get; set; }
    }
}
