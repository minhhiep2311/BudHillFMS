using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudHillFMS.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BudHillFMS.Models;
using MyTask = BudHillFMS.Models.Task;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace BudHillFMS.Controllers
{
    public class TasksController : Controller
    {
        private readonly FarmManagementSystemContext _context;
        public INotyfService _notyfService;

        public TasksController(FarmManagementSystemContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            var farmManagementSystemContext = _context.Tasks
                .Include(t => t.Farm)
                .Include(t => t.Field)
                .Include(t => t.Subtasks)
                .OrderBy(t => t.TaskCheck)
                .ThenByDescending(t => t.TaskDate); 
            return View(await farmManagementSystemContext.ToListAsync());
        }

        // Get Field in Farm
        [HttpGet]
        public IActionResult GetFieldsByFarmId(int farmId)
        {
            var fields = _context.Fields.Where(f => f.FarmId == farmId).Select(f => new { fieldId = f.FieldId, fieldName = f.FieldName }).ToList();
            return Json(fields);
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .Include(t => t.Farm)
                .Include(t => t.Field)
                 .Include(t => t.Subtasks)
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {

            ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmName");
            ViewData["FieldId"] = new SelectList(Enumerable.Empty<Field>(), "FieldId", "FieldName"); // Khởi tạo dropdown list rỗng
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskId,TaskName,TaskDescription,FarmId,FieldId,TaskDate,DuaDate,TaskStatus,TaskCheck")] MyTask task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
                _notyfService.Success("Tạo mới thành công!");
                return RedirectToAction(nameof(Index));
            }

            var fields = _context.Fields.Where(f => f.FarmId == task.FarmId);
            ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmName", task.FarmId);
            ViewData["FieldId"] = new SelectList(fields, "FieldId", "FieldName", task.FieldId); // Sử dụng danh sách fields đã lấy

            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
           
            ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmName", task.FarmId);
            ViewData["FieldId"] = new SelectList(_context.Fields, "FieldId", "FieldName", task.FieldId);
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskId,TaskName,TaskDescription,FarmId,FieldId,TaskDate,DuaDate,TaskStatus,TaskCheck")] MyTask task)
        {
            if (id != task.TaskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Cập nhật thành công!");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.TaskId))
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
            
            ViewData["FarmId"] = new SelectList(_context.Farms, "FarmId", "FarmName", task.FarmId);
            ViewData["FieldId"] = new SelectList(_context.Fields, "FieldId", "FieldName", task.FieldId);
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .Include(t => t.Farm)
                .Include(t => t.Field)
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tasks == null)
            {
                return Problem("Entity set 'FarmManagementSystemContext.Tasks'  is null.");
            }
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
            }
            
            await _context.SaveChangesAsync();
            _notyfService.Success("Xóa thành công!");
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(int id)
        {
          return (_context.Tasks?.Any(e => e.TaskId == id)).GetValueOrDefault();
        }
    }
}
