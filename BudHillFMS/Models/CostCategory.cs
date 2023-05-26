using System;
using System.Collections.Generic;

namespace BudHillFMS.Models
{
    public partial class CostCategory
    {
        public CostCategory()
        {
            Costs = new HashSet<Cost>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? CategoryDescription { get; set; }

        public virtual ICollection<Cost> Costs { get; set; }
    }
}
