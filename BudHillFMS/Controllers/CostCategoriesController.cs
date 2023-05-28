using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudHillFMS.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BudHillFMS.Models;

namespace BudHillFMS.Controllers
{
    public class CostCategoriesController : Controller
    {
        private readonly FarmManagementSystemContext _context;

        public CostCategoriesController(FarmManagementSystemContext context)
        {
            _context = context;
        }

        // GET: CostCategories
        public async Task<IActionResult> Index()
        {
              return _context.CostCategories != null ? 
                          View(await _context.CostCategories.ToListAsync()) :
                          Problem("Entity set 'FarmManagementSystemContext.CostCategories'  is null.");
        }

        // GET: CostCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CostCategories == null)
            {
                return NotFound();
            }

            var costCategory = await _context.CostCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (costCategory == null)
            {
                return NotFound();
            }

            return View(costCategory);
        }

        // GET: CostCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CostCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,CategoryDescription")] CostCategory costCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(costCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(costCategory);
        }

        // GET: CostCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CostCategories == null)
            {
                return NotFound();
            }

            var costCategory = await _context.CostCategories.FindAsync(id);
            if (costCategory == null)
            {
                return NotFound();
            }
            return View(costCategory);
        }

        // POST: CostCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName,CategoryDescription")] CostCategory costCategory)
        {
            if (id != costCategory.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(costCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CostCategoryExists(costCategory.CategoryId))
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
            return View(costCategory);
        }

        // GET: CostCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CostCategories == null)
            {
                return NotFound();
            }

            var costCategory = await _context.CostCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (costCategory == null)
            {
                return NotFound();
            }

            return View(costCategory);
        }

        // POST: CostCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CostCategories == null)
            {
                return Problem("Entity set 'FarmManagementSystemContext.CostCategories'  is null.");
            }
            var costCategory = await _context.CostCategories.FindAsync(id);
            if (costCategory != null)
            {
                _context.CostCategories.Remove(costCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CostCategoryExists(int id)
        {
          return (_context.CostCategories?.Any(e => e.CategoryId == id)).GetValueOrDefault();
        }
    }
}
