using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BudHillFMS.Models;
using System.Globalization;
using BudHillFMS.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace BudHillFMS.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class CostsController : Controller
    {   
        private readonly FarmManagementSystemContext _context;
        public INotyfService _notyfService;

        public CostsController(FarmManagementSystemContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
      

        // GET: Costs
        public async Task<IActionResult> Index(int? farmId, int? categoryId)
        {
            ViewData["LoaiChiPhi"] = new SelectList(_context.CostCategories, "CategoryId", "CategoryName");
            ViewData["TrangTrai"] = new SelectList(_context.Farms, "FarmId", "FarmName");

            var query = from cost in _context.Costs
                        .Include(c => c.Category)
                        .Include(c => c.Farm)
                        select cost;

            if (farmId != null)
            {
                query = query.Where(c => c.FarmId == farmId);
            }

            if (categoryId != null)
            {
                query = query.Where(c => c.CategoryId == categoryId);
            }

            var farmManagementSystemContext = await query.OrderBy(t => t.Coststatus)
                                                        .ThenByDescending(t => t.CostDate)
                                                        .ToListAsync();

            return View(farmManagementSystemContext);

        }

       
        // GET: Costs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            

            if (id == null || _context.Costs == null)
            {
                return NotFound();
            }

            var cost = await _context.Costs
                .Include(c => c.Category)
                .Include(c => c.Farm)
                .FirstOrDefaultAsync(m => m.CostId == id);
            if (cost == null)
            {
                return NotFound();
            }
            
            return View(cost);
        }

        // GET: Costs/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.CostCategories, "CategoryId", "CategoryName");
            ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmName");
            return View();
        }

        // POST: Costs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CostId,CostDescription,CostAmount,FarmId,CategoryId,CostName,CostDate,Coststatus")] Cost cost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cost);
                await _context.SaveChangesAsync();
                _notyfService.Success("Tạo mới thành công!");
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.CostCategories, "CategoryId", "CategoryName", cost.CategoryId);
            ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmName", cost.FarmId);
            return View(cost);
        }

        // GET: Costs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Costs == null)
            {
                return NotFound();
            }

            var cost = await _context.Costs.FindAsync(id);
            if (cost == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.CostCategories, "CategoryId", "CategoryName", cost.CategoryId);
            ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmName", cost.FarmId);
            return View(cost);
        }

        // POST: Costs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CostId,CostDescription,CostAmount,FarmId,CategoryId,CostName,CostDate,Coststatus")] Cost cost)
        {
            if (id != cost.CostId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cost);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Cập nhật thành công!");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CostExists(cost.CostId))
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
            ViewData["CategoryId"] = new SelectList(_context.CostCategories, "CategoryId", "CategoryName", cost.CategoryId);
            ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmName", cost.FarmId);
            return View(cost);
        }

        // GET: Costs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Costs == null)
            {
                return NotFound();
            }

            var cost = await _context.Costs
                .Include(c => c.Category)
                .Include(c => c.Farm)
                .FirstOrDefaultAsync(m => m.CostId == id);
            if (cost == null)
            {
                return NotFound();
            }

            return View(cost);
        }

        // POST: Costs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Costs == null)
            {
                return Problem("Entity set 'FarmManagementSystemContext.Costs'  is null.");
            }
            var cost = await _context.Costs.FindAsync(id);
            if (cost != null)
            {
                _context.Costs.Remove(cost);
            }
            
            await _context.SaveChangesAsync();
            _notyfService.Success("Xóa thành công!");
            return RedirectToAction(nameof(Index));
        }

        private bool CostExists(int id)
        {
          return (_context.Costs?.Any(e => e.CostId == id)).GetValueOrDefault();
        }
    }
}
