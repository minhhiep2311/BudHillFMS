using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BudHillFMS.Areas.Identity.Data;
using BudHillFMS.Models;

namespace BudHillFMS.Controllers;

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
        ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");
        ViewData["WarehouseId"] = new SelectList(_context.Warehouses, "WarehouseId", "WarehouseName");
        return View();
    }

    // POST: WarehouseProducts/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("WarehouseId,ProductId,Quantity,Unit")] WarehouseProduct warehouseProduct)
    {
        try
        {
            if (ModelState.IsValid)
            {
                // Check if a record with the same combination of WarehouseId and ProductId already exists
                var existingWarehouseProduct =
                    await _context.WarehouseProducts.FindAsync(warehouseProduct.WarehouseId,
                        warehouseProduct.ProductId);
                if (existingWarehouseProduct != null)
                {
                    ModelState.AddModelError("", "Đã tồn tại một kho hàng có cùng kho hàng và sản phẩm.");
                    ViewData["ProductId"] = new SelectList(_context.Products,
                        "ProductId",
                        "ProductName",
                        warehouseProduct.ProductId);
                    ViewData["WarehouseId"] = new SelectList(_context.Warehouses,
                        "WarehouseId",
                        "WarehouseName",
                        warehouseProduct.WarehouseId);
                    return View(warehouseProduct);
                }

                _context.Add(warehouseProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }
        catch (DbUpdateException ex)
        {
            // Log the exception or handle it as needed
            ModelState.AddModelError("", "Đã xảy ra lỗi khi lưu các thay đổi của thực thể.");
        }

        ViewData["ProductId"] =
            new SelectList(_context.Products, "ProductId", "ProductName", warehouseProduct.ProductId);
        ViewData["WarehouseId"] = new SelectList(_context.Warehouses,
            "WarehouseId",
            "WarehouseName",
            warehouseProduct.WarehouseId);
        return View(warehouseProduct);
    }

    // GET: WarehouseProducts/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var warehouseProduct =
            await _context.WarehouseProducts.FirstOrDefaultAsync(wp => wp.WarehouseId == id || wp.ProductId == id);
        if (warehouseProduct == null)
        {
            return NotFound();
        }

        ViewData["ProductId"] =
            new SelectList(_context.Products, "ProductId", "ProductName", warehouseProduct.ProductId);
        ViewData["WarehouseId"] = new SelectList(_context.Warehouses,
            "WarehouseId",
            "WarehouseName",
            warehouseProduct.WarehouseId);
        return View(warehouseProduct);
    }

    // POST: WarehouseProducts/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,
        [Bind("WarehouseId,ProductId,Quantity,Unit")]
        WarehouseProduct warehouseProduct)
    {
        if (id != warehouseProduct.WarehouseId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                var newWarehouseProduct = _context.WarehouseProducts.FirstOrDefault(wp =>
                    wp.WarehouseId == warehouseProduct.WarehouseId &&
                    wp.ProductId == warehouseProduct.ProductId);

                if (newWarehouseProduct != null)
                {
                    newWarehouseProduct.WarehouseId = warehouseProduct.WarehouseId;
                    newWarehouseProduct.ProductId = warehouseProduct.ProductId;
                    newWarehouseProduct.Quantity = warehouseProduct.Quantity;
                    newWarehouseProduct.Unit = warehouseProduct.Unit;
                }

                _context.WarehouseProducts.Update(newWarehouseProduct);
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

        ViewData["ProductId"] =
            new SelectList(_context.Products, "ProductId", "ProductName", warehouseProduct.ProductId);
        ViewData["WarehouseId"] = new SelectList(_context.Warehouses,
            "WarehouseId",
            "WarehouseName",
            warehouseProduct.WarehouseId);
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