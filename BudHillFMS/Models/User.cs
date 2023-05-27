using Microsoft.AspNetCore.Identity;

namespace BudHillFMS.Models;

public partial class User : IdentityUser<int>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int RoleId { get; set; }
    public int? FarmId { get; set; }

    public virtual Farm? Farm { get; set; }
    public virtual Role? Role { get; set; } 
}