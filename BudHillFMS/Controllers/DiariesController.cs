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
    public class DiariesController : Controller
    {
        private readonly FarmManagementSystemContext _context;

        public DiariesController(FarmManagementSystemContext context)
        {
            _context = context;
        }

        // GET: Diaries
        public async Task<IActionResult> Index()
        {
            ViewData["LoaiNhatKy"] = new SelectList(_context.Diaries, "DiaryId", "DiaryCategory");

            var farmManagementSystemContext = _context.Diaries.Include(d => d.Field).Include(d => d.Product).OrderByDescending(t => t.EntryDate);
            return View(await farmManagementSystemContext.ToListAsync());
        }

        // GET: Diaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Diaries == null)
            {
                return NotFound();
            }

            var diary = await _context.Diaries
                .Include(d => d.Field)
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.DiaryId == id);
            if (diary == null)
            {
                return NotFound();
            }

            return View(diary);
        }

        // GET: Diaries/Create
        public IActionResult Create()
        {
            ViewData["FieldId"] = new SelectList(_context.Fields, "FieldId", "FieldName");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
            return View();
        }

        // POST: Diaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiaryId,EntryDate,FieldId,ProductId,Description,DiarySubject,DiaryCategory")] Diary diary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FieldId"] = new SelectList(_context.Fields, "FieldId", "FieldName", diary.FieldId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", diary.ProductId);
            return View(diary);
        }

        // GET: Diaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Diaries == null)
            {
                return NotFound();
            }

            var diary = await _context.Diaries.FindAsync(id);
            if (diary == null)
            {
                return NotFound();
            }
            ViewData["FieldId"] = new SelectList(_context.Fields, "FieldId", "FieldName", diary.FieldId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", diary.ProductId);
            return View(diary);
        }

        // POST: Diaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiaryId,EntryDate,FieldId,ProductId,Description,DiarySubject,DiaryCategory")] Diary diary)
        {
            if (id != diary.DiaryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiaryExists(diary.DiaryId))
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
            ViewData["FieldId"] = new SelectList(_context.Fields, "FieldId", "FieldName", diary.FieldId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", diary.ProductId);
            return View(diary);
        }

        // GET: Diaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Diaries == null)
            {
                return NotFound();
            }

            var diary = await _context.Diaries
                .Include(d => d.Field)
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.DiaryId == id);
            if (diary == null)
            {
                return NotFound();
            }

            return View(diary);
        }

        // POST: Diaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Diaries == null)
            {
                return Problem("Entity set 'FarmManagementSystemContext.Diaries'  is null.");
            }
            var diary = await _context.Diaries.FindAsync(id);
            if (diary != null)
            {
                _context.Diaries.Remove(diary);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiaryExists(int id)
        {
          return (_context.Diaries?.Any(e => e.DiaryId == id)).GetValueOrDefault();
        }
    }
}
