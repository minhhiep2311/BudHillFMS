using System;
using System.Collections.Generic;

namespace BudHillFMS.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            Fertilizers = new HashSet<Fertilizer>();
            WarehouseProducts = new HashSet<WarehouseProduct>();
        }

        public int WarehouseId { get; set; }
        public string? WarehouseName { get; set; }
        public string? WarehouseLocation { get; set; }
        public int FarmId { get; set; }

        public virtual Farm? Farm { get; set; } 
        public virtual ICollection<Fertilizer> Fertilizers { get; set; }
        public virtual ICollection<WarehouseProduct> WarehouseProducts { get; set; }
    }
}
