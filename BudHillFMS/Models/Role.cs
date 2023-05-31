using Microsoft.AspNetCore.Identity;

namespace BudHillFMS.Models;

public class Role : IdentityRole<int>
{
    public string? RoleDescription { get; set; }
}