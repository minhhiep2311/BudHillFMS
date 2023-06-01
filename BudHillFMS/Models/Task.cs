using System;
using System.Collections.Generic;

namespace BudHillFMS.Models
{
    public partial class Task
    {
        public Task()
        {
            Subtasks = new HashSet<Subtask>();
        }

        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public string? TaskDescription { get; set; }
        public int FarmId { get; set; }
        public int FieldId { get; set; }
        public DateTime TaskDate { get; set; }
        public DateTime? DuaDate { get; set; }
        public string? TaskStatus { get; set; }
        public bool TaskCheck { get; set; }

        public virtual Farm? Farm { get; set; } 
        public virtual Field? Field { get; set; } 
        public virtual ICollection<Subtask> Subtasks { get; set; }
    }
}
