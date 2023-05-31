using System;
using System.Collections.Generic;

namespace BudHillFMS.Models
{
    public partial class Fertilizer
    {
        public int FertilizerId { get; set; }
        public string? FertilizerName { get; set; }
        public string? FertilizerType { get; set; }
        public int FertilizerQuantity { get; set; }
        public int WarehouseId { get; set; }
        public int? QuantityUsed { get; set; }
        public DateTime? FertilizerImport { get; set; }

        public virtual Warehouse? Warehouse { get; set; }
    }
}
