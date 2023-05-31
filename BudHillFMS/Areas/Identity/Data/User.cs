using BudHillFMS.Models;
using Microsoft.AspNetCore.Identity;

namespace BudHillFMS.Areas.Identity.Data;

public sealed class User : IdentityUser<int>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? FarmId { get; set; }
    public Farm? Farm { get; set; }
}