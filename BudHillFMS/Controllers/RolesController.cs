using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BudHillFMS.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using BudHillFMS.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BudHillFMS.Controllers;

[Authorize(Roles = "Admin")]
public class RolesController : Controller
{
    private readonly FarmManagementSystemContext _context;
    private readonly INotyfService _notyfService;
    private readonly RoleManager<Role> _roleManager;

    public RolesController(FarmManagementSystemContext context,
        INotyfService notyfService,
        RoleManager<Role> roleManager)
    {
        _context = context;
        _notyfService = notyfService;
        _roleManager = roleManager;
    }

    // GET: Roles
    public async Task<IActionResult> Index()
    {
        return View(await _context.Roles.ToListAsync());
    }

    // GET: Roles/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var role = await _context.Roles
           .FirstOrDefaultAsync(m => m.Id == id);
        if (role == null)
            return NotFound();

        return View(role);
    }

    // GET: Roles/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Roles/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,RoleName,RoleDescription,NormalizedName")] Role role)
    {
        if (!ModelState.IsValid)
            return View(role);

        _context.Add(role);
        await _context.SaveChangesAsync();
        _notyfService.Success("Tạo mới thành công!");
        return RedirectToAction(nameof(Index));
    }

    // GET: Roles/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var role = await _context.Roles.FindAsync(id);
        if (role == null)
            return NotFound();

        return View(role);
    }

    // POST: Roles/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,
        [Bind("Id,Name,RoleDescription,NormalizedName,ConcurrencyStamp")]
        Role role)
    {
        if (id != role.Id)
            return NotFound();

        if (!ModelState.IsValid)
            return View();


        try
        {
            _context.Update(role);
            await _context.SaveChangesAsync();
            _notyfService.Success("Cập nhật thành công!");
        }
        catch (DbUpdateConcurrencyException)
        {
            if (RoleExists(role.Id))
                throw;

            _notyfService.Success("Có lỗi xảy ra!");
            return NotFound();
        }

        return RedirectToAction(nameof(Index));
    }

    // GET: Roles/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var role = await _context.Roles
           .FirstOrDefaultAsync(m => m.Id == id);
        if (role == null)
            return NotFound();

        return View(role);
    }

    // POST: Roles/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var role = await _roleManager.FindByIdAsync(id.ToString());
        if (role == null)
            return RedirectToAction(nameof(Index));

        await _roleManager.DeleteAsync(role);
        _notyfService.Success("Xóa thành công!");

        return RedirectToAction(nameof(Index));
    }

    private bool RoleExists(int id)
    {
        return _context.Roles.Any(e => e.Id == id);
    }
}