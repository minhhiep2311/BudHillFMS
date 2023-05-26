using System;
using System.Collections.Generic;

namespace BudHillFMS.Models
{
    public partial class Subtask
    {
        public int SubTaskId { get; set; }
        public int? TaskId { get; set; }
        public string? SubtaskName { get; set; }
        public bool? Subtaskstatus { get; set; }

        public virtual Task? Task { get; set; }
    }
}
