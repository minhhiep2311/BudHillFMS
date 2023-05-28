using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BudHillFMS.Areas.Identity.Data;
using BudHillFMS.Models;

namespace BudHillFMS.Controllers
{
    public class WarehouseProductsController : Controller
    {
        private readonly FarmManagementSystemContext _context;

        public WarehouseProductsController(FarmManagementSystemContext context)
        {
            _context = context;
        }

        // GET: WarehouseProducts
        public async Task<IActionResult> Index()
        {
            ViewData["DanhSachKho"] = new SelectList(_context.Warehouses, "WarehouseID", "WarehouseName");

            var farmManagementSystemContext = _context.WarehouseProducts.Include(w => w.Product).Include(w => w.Warehouse);
            return View(await farmManagementSystemContext.ToListAsync());
        }

        // GET: WarehouseProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WarehouseProducts == null)
            {
                return NotFound();
            }

            var warehouseProduct = await _context.WarehouseProducts
                .Include(w => w.Product)
                .Include(w => w.Warehouse)
                .FirstOrDefaultAsync(m => m.WarehouseId == id);
            if (warehouseProduct == null)
            {
                return NotFound();
            }

            return View(warehouseProduct);
        }

        // GET: WarehouseProducts/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "WarehouseId", "WarehouseId");
            return View();
        }

        // POST: WarehouseProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WarehouseId,ProductId,Quantity,Unit")] WarehouseProduct warehouseProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(warehouseProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", warehouseProduct.ProductId);
            ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "WarehouseId", "WarehouseId", warehouseProduct.WarehouseId);
            return View(warehouseProduct);
        }

        // GET: WarehouseProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WarehouseProducts == null)
            {
                return NotFound();
            }

            var warehouseProduct = await _context.WarehouseProducts.FindAsync(id);
            if (warehouseProduct == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", warehouseProduct.ProductId);
            ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "WarehouseId", "WarehouseId", warehouseProduct.WarehouseId);
            return View(warehouseProduct);
        }

        // POST: WarehouseProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WarehouseId,ProductId,Quantity,Unit")] WarehouseProduct warehouseProduct)
        {
            if (id != warehouseProduct.WarehouseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(warehouseProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WarehouseProductExists(warehouseProduct.WarehouseId))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", warehouseProduct.ProductId);
            ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "WarehouseId", "WarehouseId", warehouseProduct.WarehouseId);
            return View(warehouseProduct);
        }

        // GET: WarehouseProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WarehouseProducts == null)
            {
                return NotFound();
            }

            var warehouseProduct = await _context.WarehouseProducts
                .Include(w => w.Product)
                .Include(w => w.Warehouse)
                .FirstOrDefaultAsync(m => m.WarehouseId == id);
            if (warehouseProduct == null)
            {
                return NotFound();
            }

            return View(warehouseProduct);
        }

        // POST: WarehouseProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WarehouseProducts == null)
            {
                return Problem("Entity set 'FarmManagementSystemContext.WarehouseProducts'  is null.");
            }
            var warehouseProduct = await _context.WarehouseProducts.FindAsync(id);
            if (warehouseProduct != null)
            {
                _context.WarehouseProducts.Remove(warehouseProduct);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WarehouseProductExists(int id)
        {
          return (_context.WarehouseProducts?.Any(e => e.WarehouseId == id)).GetValueOrDefault();
        }
    }
}
