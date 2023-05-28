using BudHillFMS.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace BudHillFMS.Models;

public class Role : IdentityRole<int>
{
    public string? RoleDescription { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}