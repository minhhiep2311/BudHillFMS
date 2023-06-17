using System;
using System.Collections.Generic;

namespace BudHillFMS.Models
{
    public partial class Product
    {
        public Product()
        {
            Diaries = new HashSet<Diary>();
            WarehouseProducts = new HashSet<WarehouseProduct>();
        }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int FieldId { get; set; }
        public decimal? Price { get; set; }
        public int? Class { get; set; }
        public DateTime? SowingDate { get; set; }
        public DateTime? HarvestDate { get; set; }
        public bool ProductStatus { get; set; }

        public string? ProductProcess { get; set; }

        public virtual Field? Field { get; set; } 
        public virtual ICollection<Diary> Diaries { get; set; }
        public virtual ICollection<WarehouseProduct> WarehouseProducts { get; set; }
    }
}
