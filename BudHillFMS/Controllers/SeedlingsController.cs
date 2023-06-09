﻿using BudHillFMS.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BudHillFMS.Models;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace BudHillFMS.Controllers;

public class SeedlingsController : Controller
{
    private readonly FarmManagementSystemContext _context;
    private readonly INotyfService _notyfService;

    public SeedlingsController(FarmManagementSystemContext context, INotyfService notyfService)
    {
        _context = context;
        _notyfService = notyfService;
    }

    // GET: Seedlings
    public async Task<IActionResult> Index()
    {
        var seedlings = _context.Seedlings.OrderByDescending(s => s.SeedlingStart);

        return View(await seedlings.ToListAsync());
    }

    // GET: Seedlings/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var seedling = await _context.Seedlings
           .FirstOrDefaultAsync(m => m.SeedlingId == id);
        if (seedling == null)
        {
            return NotFound();
        }

        return View(seedling);
    }

    // GET: Seedlings/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Seedlings/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("SeedlingId,SeedlingName,SeedlingDescription,SeedlingStart")] Seedling seedling)
    {
        if (ModelState.IsValid)
        {
            _context.Add(seedling);
            await _context.SaveChangesAsync();
            _notyfService.Success("Tạo mới thành công!");
            return RedirectToAction(nameof(Index));
        }

        return View(seedling);
    }

    // GET: Seedlings/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var seedling = await _context.Seedlings.FindAsync(id);
        if (seedling == null)
        {
            return NotFound();
        }

        return View(seedling);
    }

    // POST: Seedlings/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,
        [Bind("SeedlingId,SeedlingName,SeedlingDescription,SeedlingStart")] Seedling seedling)
    {
        if (id != seedling.SeedlingId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(seedling);
                await _context.SaveChangesAsync();
                _notyfService.Success("Cập nhật thành công!");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeedlingExists(seedling.SeedlingId))
                {
                    _notyfService.Success("Có lỗi xảy ra!");
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        return View(seedling);
    }

    // GET: Seedlings/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var seedling = await _context.Seedlings
           .FirstOrDefaultAsync(m => m.SeedlingId == id);
        if (seedling == null)
        {
            return NotFound();
        }

        return View(seedling);
    }

    // POST: Seedlings/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var seedling = await _context.Seedlings.FindAsync(id);
        if (seedling != null)
        {
            _context.Seedlings.Remove(seedling);
        }

        await _context.SaveChangesAsync();
        _notyfService.Success("Xóa thành công!");
        return RedirectToAction(nameof(Index));
    }

    private bool SeedlingExists(int id)
    {
        return _context.Seedlings.Any(e => e.SeedlingId == id);
    }
}