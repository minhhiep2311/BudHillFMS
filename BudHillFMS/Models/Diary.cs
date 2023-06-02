using System;
using System.Collections.Generic;


namespace BudHillFMS.Models
{
    public partial class Diary
    {
        public int DiaryId { get; set; }
        public DateTime EntryDate { get; set; }
        public int FieldId { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string? DiarySubject { get; set; }
        public string? DiaryCategory { get; set; }

        public virtual Field? Field { get; set; } 
        public virtual Product? Product { get; set; } 
    }
}
