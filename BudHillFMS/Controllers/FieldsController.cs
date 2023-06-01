using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudHillFMS.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BudHillFMS.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace BudHillFMS.Controllers
{
    public class FieldsController : Controller
    {
        private readonly FarmManagementSystemContext _context;
        public INotyfService _notyfService;
        public FieldsController(FarmManagementSystemContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Fields
        public async Task<IActionResult> Index(int? farmId)
        {
            ViewData["DanhSachFarm"] = new SelectList(_context.Farms, "FarmId", "FarmName");

            var farmManagementSystemContext = _context.Fields
                .Include(e => e.Farm)
                 .Where(p => farmId == null || p.FarmId == farmId)
                .OrderBy(t => t.FieldStatus == true);
            return View(await farmManagementSystemContext.ToListAsync());
        }

        // GET: Fields/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fields == null)
            {
                return NotFound();
            }

            var @field = await _context.Fields
                .Include(e => e.Farm)
                .FirstOrDefaultAsync(m => m.FieldId == id);
            if (@field == null)
            {
                return NotFound();
            }

            return View(@field);
        }

        // GET: Fields/Create
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult Create()
        {
            ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmName");
            return View();
        }

        // POST: Fields/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Create([Bind("FieldId,FieldName,FarmId,FieldArea,FieldStatus")] Field @field)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@field);
                await _context.SaveChangesAsync();
                _notyfService.Success("Tạo mới thành công!");
                return RedirectToAction(nameof(Index));
            }
            ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmName", @field.FarmId);
            return View(@field);
        }

        // GET: Fields/Edit/5
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fields == null)
            {
                return NotFound();
            }

            var @field = await _context.Fields.FindAsync(id);
            if (@field == null)
            {
                return NotFound();
            }
            ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmName", @field.FarmId);
            return View(@field);
        }

        // POST: Fields/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Edit(int id, [Bind("FieldId,FieldName,FarmId,FieldArea,FieldStatus")] Field @field)
        {
            if (id != @field.FieldId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@field);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Cập nhật thành công!");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FieldExists(@field.FieldId))
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
            ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmName", @field.FarmId);
            return View(@field);
        }

        // GET: Fields/Delete/5
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fields == null)
            {
                return NotFound();
            }

            var @field = await _context.Fields
                .Include(e => e.Farm)
                .FirstOrDefaultAsync(m => m.FieldId == id);
            if (@field == null)
            {
                return NotFound();
            }

            return View(@field);
        }

        // POST: Fields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fields == null)
            {
                return Problem("Entity set 'FarmManagementSystemContext.Fields'  is null.");
            }
            var @field = await _context.Fields.FindAsync(id);
            if (@field != null)
            {
                _context.Fields.Remove(@field);
            }
            
            await _context.SaveChangesAsync();
            _notyfService.Success("Xóa thành công!");
            return RedirectToAction(nameof(Index));
        }

        private bool FieldExists(int id)
        {
          return (_context.Fields?.Any(e => e.FieldId == id)).GetValueOrDefault();
        }
    }
}
