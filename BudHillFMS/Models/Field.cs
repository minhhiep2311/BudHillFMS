using System;
using System.Collections.Generic;

namespace BudHillFMS.Models
{
    public partial class Field
    {
        public Field()
        {
            Diaries = new HashSet<Diary>();
            Products = new HashSet<Product>();
            Tasks = new HashSet<Task>();
        }

        public int FieldId { get; set; }
        public string? FieldName { get; set; }
        public int FarmId { get; set; }
        public int? FieldArea { get; set; }
        public bool FieldStatus { get; set; }

        public virtual Farm? Farm { get; set; } 
        public virtual ICollection<Diary> Diaries { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
