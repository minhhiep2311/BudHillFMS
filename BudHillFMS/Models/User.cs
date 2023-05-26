using System;
using System.Collections.Generic;

namespace BudHillFMS.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int RoleId { get; set; }
        public int? FarmId { get; set; }

        public virtual Farm? Farm { get; set; }
        public virtual Role? Role { get; set; } 
    }
}
