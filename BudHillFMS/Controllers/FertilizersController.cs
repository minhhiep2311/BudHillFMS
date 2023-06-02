using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BudHillFMS.Areas.Identity.Data;
using BudHillFMS.Models;

namespace BudHillFMS.Controllers;

public class FertilizersController : Controller
{
    private readonly FarmManagementSystemContext _context;

    public FertilizersController(FarmManagementSystemContext context)
    {
        _context = context;
    }

    // GET: Fertilizers
    public async Task<IActionResult> Index(int? warhouseId)
    {
        ViewData["DanhSachKho"] = new SelectList(_context.Warehouses, "WarehouseId", "WarehouseName");
        var farmManagementSystemContext = _context.Fertilizers
           .Include(f => f.Warehouse)
           .Where(p => warhouseId == null || p.WarehouseId == warhouseId); ;
        return View(await farmManagementSystemContext.ToListAsync());
    }

    // GET: Fertilizers/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Fertilizers == null)
        {
            return NotFound();
        }

        var fertilizer = await _context.Fertilizers
           .Include(f => f.Warehouse)
           .FirstOrDefaultAsync(m => m.FertilizerId == id);
        if (fertilizer == null)
        {
            return NotFound();
        }

        return View(fertilizer);
    }

    // GET: Fertilizers/Create
    public IActionResult Create()
    {
        ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "WarehouseId", "WarehouseId");
        return View();
    }

    // POST: Fertilizers/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("FertilizerId,FertilizerName,FertilizerType,FertilizerQuantity,WarehouseId,QuantityUsed,FertilizerImport")] Fertilizer fertilizer)
    {
        if (ModelState.IsValid)
        {
            _context.Add(fertilizer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "WarehouseId", "WarehouseId", fertilizer.WarehouseId);
        return View(fertilizer);
    }

    // GET: Fertilizers/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.Fertilizers == null)
        {
            return NotFound();
        }

        var fertilizer = await _context.Fertilizers.FindAsync(id);
        if (fertilizer == null)
        {
            return NotFound();
        }
        ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "WarehouseId", "WarehouseId", fertilizer.WarehouseId);
        return View(fertilizer);
    }

    // POST: Fertilizers/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("FertilizerId,FertilizerName,FertilizerType,FertilizerQuantity,WarehouseId,QuantityUsed,FertilizerImport")] Fertilizer fertilizer)
    {
        if (id != fertilizer.FertilizerId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(fertilizer);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FertilizerExists(fertilizer.FertilizerId))
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
        ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "WarehouseId", "WarehouseId", fertilizer.WarehouseId);
        return View(fertilizer);
    }

    // GET: Fertilizers/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Fertilizers == null)
        {
            return NotFound();
        }

        var fertilizer = await _context.Fertilizers
           .Include(f => f.Warehouse)
           .FirstOrDefaultAsync(m => m.FertilizerId == id);
        if (fertilizer == null)
        {
            return NotFound();
        }

        return View(fertilizer);
    }

    // POST: Fertilizers/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Fertilizers == null)
        {
            return Problem("Entity set 'FarmManagementSystemContext.Fertilizers'  is null.");
        }
        var fertilizer = await _context.Fertilizers.FindAsync(id);
        if (fertilizer != null)
        {
            _context.Fertilizers.Remove(fertilizer);
        }
            
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool FertilizerExists(int id)
    {
        return (_context.Fertilizers?.Any(e => e.FertilizerId == id)).GetValueOrDefault();
    }
}