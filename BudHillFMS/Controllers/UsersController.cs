﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BudHillFMS.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace BudHillFMS.Controllers;

[Authorize(Roles = "Admin")]
public class UsersController : Controller
{
    private readonly FarmManagementSystemContext _context;

    public UsersController(FarmManagementSystemContext context)
    {
        _context = context;
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
        ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name");
        return View();
    }

    // POST: Users/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("UserId,Username,Password,FirstName,LastName,Email,RoleId,FarmId")] User user)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmName", user.FarmId);
            // ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", user.Role);
            return View(user);
        }
        catch (Exception)
        {
            return RedirectToAction("Error", "Home");
        }
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

        ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmName", user.FarmId);
        // ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", user.RoleId);
        return View(user);
    }

    // POST: Users/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,
        [Bind("UserId,Username,Password,FirstName,LastName,Email,RoleId,FarmId")]
        User user)
    {
        if (id != user.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmName", user.FarmId);
        // ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", user.RoleId);
        return View(user);
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
        return RedirectToAction(nameof(Index));
    }

    private bool UserExists(int id)
    {
        return _context.Users.Any(e => e.Id == id);
    }
}