using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BudHillFMS.Models;

namespace BudHillFMS.Controllers
{
    public class SeedlingsController : Controller
    {
        private readonly FarmManagementSystemContext _context;

        public SeedlingsController(FarmManagementSystemContext context)
        {
            _context = context;
        }

        // GET: Seedlings
        public async Task<IActionResult> Index()
        {
              return _context.Seedlings != null ? 
                          View(await _context.Seedlings.ToListAsync()) :
                          Problem("Entity set 'FarmManagementSystemContext.Seedlings'  is null.");
        }

        // GET: Seedlings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Seedlings == null)
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
        public async Task<IActionResult> Create([Bind("SeedlingId,SeedlingName,SeedlingDescription,SeedlingStart")] Seedling seedling)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seedling);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seedling);
        }

        // GET: Seedlings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Seedlings == null)
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
        public async Task<IActionResult> Edit(int id, [Bind("SeedlingId,SeedlingName,SeedlingDescription,SeedlingStart")] Seedling seedling)
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
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeedlingExists(seedling.SeedlingId))
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
            return View(seedling);
        }

        // GET: Seedlings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Seedlings == null)
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
            if (_context.Seedlings == null)
            {
                return Problem("Entity set 'FarmManagementSystemContext.Seedlings'  is null.");
            }
            var seedling = await _context.Seedlings.FindAsync(id);
            if (seedling != null)
            {
                _context.Seedlings.Remove(seedling);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeedlingExists(int id)
        {
          return (_context.Seedlings?.Any(e => e.SeedlingId == id)).GetValueOrDefault();
        }
    }
}
