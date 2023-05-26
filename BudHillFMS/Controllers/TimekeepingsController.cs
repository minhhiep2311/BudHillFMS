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
    public class TimekeepingsController : Controller
    {
        private readonly FarmManagementSystemContext _context;

        public TimekeepingsController(FarmManagementSystemContext context)
        {
            _context = context;
        }

        // GET: Timekeepings
        public async Task<IActionResult> Index()
        {
            var farmManagementSystemContext = _context.Timekeepings.Include(t => t.Employee);
            return View(await farmManagementSystemContext.ToListAsync());
        }

        // GET: Timekeepings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Timekeepings == null)
            {
                return NotFound();
            }

            var timekeeping = await _context.Timekeepings
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.TimekeepingId == id);
            if (timekeeping == null)
            {
                return NotFound();
            }

            return View(timekeeping);
        }

        // GET: Timekeepings/Create
        public IActionResult Create()
        {
            
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName");
            return View();
        }

        // POST: Timekeepings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimekeepingId,EmployeeId,CheckIn,CheckOut,TimekeepingDate")] Timekeeping timekeeping)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timekeeping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", timekeeping.EmployeeId);
            return View(timekeeping);
        }

        // GET: Timekeepings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Timekeepings == null)
            {
                return NotFound();
            }

            var timekeeping = await _context.Timekeepings.FindAsync(id);
            if (timekeeping == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", timekeeping.EmployeeId);
            return View(timekeeping);
        }

        // POST: Timekeepings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimekeepingId,EmployeeId,CheckIn,CheckOut,TimekeepingDate")] Timekeeping timekeeping)
        {
            if (id != timekeeping.TimekeepingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timekeeping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimekeepingExists(timekeeping.TimekeepingId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeName", timekeeping.EmployeeId);
            return View(timekeeping);
        }

        // GET: Timekeepings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Timekeepings == null)
            {
                return NotFound();
            }

            var timekeeping = await _context.Timekeepings
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.TimekeepingId == id);
            if (timekeeping == null)
            {
                return NotFound();
            }

            return View(timekeeping);
        }

        // POST: Timekeepings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Timekeepings == null)
            {
                return Problem("Entity set 'FarmManagementSystemContext.Timekeepings'  is null.");
            }
            var timekeeping = await _context.Timekeepings.FindAsync(id);
            if (timekeeping != null)
            {
                _context.Timekeepings.Remove(timekeeping);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimekeepingExists(int id)
        {
          return (_context.Timekeepings?.Any(e => e.TimekeepingId == id)).GetValueOrDefault();
        }
    }
}
