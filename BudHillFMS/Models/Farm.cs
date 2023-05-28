using System;
using System.Collections.Generic;
using BudHillFMS.Areas.Identity.Data;

namespace BudHillFMS.Models
{
    public partial class Farm
    {
        public Farm()
        {
            Costs = new HashSet<Cost>();
            Employees = new HashSet<Employee>();
            Equipment = new HashSet<Equipment>();
            Fields = new HashSet<Field>();
            Tasks = new HashSet<Task>();
            Users = new HashSet<User>();
            Warehouses = new HashSet<Warehouse>();
        }

        public int FarmId { get; set; }
        public string? FarmName { get; set; }
        public string? FarmLocation { get; set; }
        public int? FarmArea { get; set; }
        public int? AreaUsed { get; set; }

        public virtual ICollection<Cost> Costs { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }
        public virtual ICollection<Field> Fields { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
