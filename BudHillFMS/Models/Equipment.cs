using System;
using System.Collections.Generic;

namespace BudHillFMS.Models
{
    public partial class Equipment
    {
        public int EquipmentId { get; set; }
        public string? EquipmentName { get; set; }
        public string? EquipmentType { get; set; }
        public int FarmId { get; set; }
        public int EquipmentQuantity { get; set; }
        public int? EquipmentUsed { get; set; }

        public virtual Farm Farm { get; set; } = null!;
    }
}
