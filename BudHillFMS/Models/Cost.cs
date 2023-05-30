using System;
using System.Collections.Generic;

namespace BudHillFMS.Models
{
    public partial class Cost
    {
        public int CostId { get; set; }
        public string? CostDescription { get; set; }
        public decimal? CostAmount { get; set; }
        public int FarmId { get; set; }
        public int? CategoryId { get; set; }
        public string CostName { get; set; } = null!;
        public DateTime? CostDate { get; set; }
        public bool Coststatus { get; set; }

        public virtual CostCategory? Category { get; set; }
        public virtual Farm? Farm { get; set; } 
    }
}
