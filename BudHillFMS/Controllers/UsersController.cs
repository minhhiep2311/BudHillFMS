using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BudHillFMS.Areas.Identity.Data;
using BudHillFMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace BudHillFMS.Controllers;

[Authorize(Roles = "Admin")]
public class UsersController : Controller
{
    private readonly FarmManagementSystemContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly INotyfService _notyfService;

    public UsersController(FarmManagementSystemContext context,
        UserManager<User> userManager,
        RoleManager<Role> roleManager,
        INotyfService notyfService)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
        _notyfService = notyfService;
    }

    // GET: Users
    public async Task<IActionResult> Index()
    {
        ViewData["QuyenTruyCap"] = new SelectList(_context.Roles, "Id", "Name");
        ViewData["DanhSachFarm"] = new SelectList(_context.Farms, "FarmId", "FarmName");

        var farmManagementSystemContext = _context.Users.Include(u => u.Farm);
        return View(await farmManagementSystemContext.ToListAsync());
    }

    // GET: Users/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = await _context.Users
           .Include(u => u.Farm)
           .FirstOrDefaultAsync(m => m.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    // GET: Users/Create
    public IActionResult Create()
    {
        ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmName");
        ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "RoleDescription");

        return View();
    }

    // POST: Users/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(int roleId,
        [Bind("UserName,FirstName,LastName,Email,RoleId,FarmId")]
        User user)
    {
        if (ModelState.IsValid)
        {
            var result = await _userManager.CreateAsync(user, "123456");

            if (result.Succeeded)
            {
                var createdUser = await _userManager.FindByNameAsync(user.UserName);
                var role = await _roleManager.FindByIdAsync(roleId.ToString());

                var addRoleResult = await _userManager.AddToRoleAsync(createdUser, role.Name);
                if (addRoleResult.Succeeded)
                    return RedirectToAction(nameof(Index));

                await _userManager.DeleteAsync(createdUser);
                ModelState.AddModelError(string.Empty, addRoleResult.Errors.FirstOrDefault()!.Description);

                ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmName", user.FarmId);
                ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "RoleDescription");

                return View(user);
            }

            ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault()!.Description);
        }

        ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmName", user.FarmId);
        ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "RoleDescription");

        return View(user);
    }

    // GET: Users/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        var rolesName = await _userManager.GetRolesAsync(user);
        var role = await _roleManager.FindByNameAsync(rolesName.Count > 0 ? rolesName[0] : null);

        ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmName", user.FarmId);
        ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "RoleDescription", role.Id);
        return View(user);
    }

    // POST: Users/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,
        int roleId,
        [Bind("Id,UserName,FirstName,LastName,Email,FarmId")]
        User request)
    {
        if (id != request.Id)
        {
            return NotFound();
        }

        var user = await _userManager.FindByIdAsync(id.ToString());
        var oldRolesName = await _userManager.GetRolesAsync(user);
        var oldRole = await _roleManager.FindByNameAsync(oldRolesName.Count > 0 ? oldRolesName[0] : null);

        if (!ModelState.IsValid || user == null)
        {
            ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmName", request.FarmId);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "RoleDescription", oldRole.Id);

            return View(request);
        }

        try
        {
            // _context.ChangeTracker.Clear();
            // _context.Entry(user).State = EntityState.Detached;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.FarmId = request.FarmId;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmName", request.FarmId);
                ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "RoleDescription", oldRole.Id);

                return View(request);
            }

            user = await _userManager.FindByIdAsync(user.Id.ToString());
            var newRole = await _roleManager.FindByIdAsync(roleId.ToString());

            if (!oldRolesName.Contains(newRole.Name))
            {
                await _userManager.AddToRoleAsync(user, newRole.Name);

                if (oldRolesName.Count > 0)
                {
                    await _userManager.RemoveFromRoleAsync(user, oldRolesName[0]);
                }
            }
            
            await _context.SaveChangesAsync();
            _notyfService.Success("Cập nhật thành công!");
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(request.Id))
            {
                return NotFound();
            }

            throw;
        }

        return RedirectToAction(nameof(Index));
    }

    // GET: Users/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = await _context.Users
           .Include(u => u.Farm)
           .FirstOrDefaultAsync(m => m.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    // POST: Users/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
        }

        await _context.SaveChangesAsync();
        _notyfService.Success("Xóa thành công!");
        return RedirectToAction(nameof(Index));
    }

    private bool UserExists(int id)
    {
        return _context.Users.Any(e => e.Id == id);
    }
}