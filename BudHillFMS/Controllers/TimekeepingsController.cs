using BudHillFMS.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BudHillFMS.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using OfficeOpenXml;

namespace BudHillFMS.Controllers;

public class TimekeepingsController : Controller
{
    private readonly FarmManagementSystemContext _context;
    private readonly INotyfService _notyfService;

    public TimekeepingsController(FarmManagementSystemContext context, INotyfService notyfService)
    {
        _context = context;
        _notyfService = notyfService;
    }

    // GET: Timekeepings
    public async Task<IActionResult> Index()
    {
        var farmManagementSystemContext = _context.Timekeepings.Include(t => t.Employee)
           .OrderByDescending(t => t.TimekeepingDate)
           .ThenBy(t => t.Employee.EmployeeName);
        return View(await farmManagementSystemContext.ToListAsync());
    }

    // GET: Timekeepings/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
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
    public async Task<IActionResult> Create(
        [Bind("TimekeepingId,EmployeeId,CheckIn,CheckOut,TimekeepingDate")] Timekeeping timekeeping)
    {
        if (ModelState.IsValid)
        {
            _context.Add(timekeeping);
            await _context.SaveChangesAsync();
            _notyfService.Success("Tạo mới thành công!");
            return RedirectToAction(nameof(Index));
        }

        ViewData["EmployeeId"] =
            new SelectList(_context.Employees, "EmployeeId", "EmployeeName", timekeeping.EmployeeId);
        return View(timekeeping);
    }

    // GET: Timekeepings/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var timekeeping = await _context.Timekeepings.FindAsync(id);
        if (timekeeping == null)
        {
            return NotFound();
        }

        ViewData["EmployeeId"] =
            new SelectList(_context.Employees, "EmployeeId", "EmployeeName", timekeeping.EmployeeId);
        return View(timekeeping);
    }

    // POST: Timekeepings/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,
        [Bind("TimekeepingId,EmployeeId,CheckIn,CheckOut,TimekeepingDate")] Timekeeping timekeeping)
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
                _notyfService.Success("Cập nhật thành công!");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimekeepingExists(timekeeping.TimekeepingId))
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

        ViewData["EmployeeId"] =
            new SelectList(_context.Employees, "EmployeeId", "EmployeeName", timekeeping.EmployeeId);
        return View(timekeeping);
    }

    // GET: Timekeepings/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
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
        var timekeeping = await _context.Timekeepings.FindAsync(id);
        if (timekeeping != null)
        {
            _context.Timekeepings.Remove(timekeeping);
        }

        await _context.SaveChangesAsync();
        _notyfService.Success("Xóa thành công!");
        return RedirectToAction(nameof(Index));
    }

    private bool TimekeepingExists(int id)
    {
        return _context.Timekeepings.Any(e => e.TimekeepingId == id);
    }

    //Export excel 

    public IActionResult ExportToExcel(DateTime? startDate, DateTime? endDate)
    {
        var timekeepings = _context.Timekeepings
           .Include(t => t.Employee)
           .Where(t => t.TimekeepingDate >= startDate && t.TimekeepingDate <= endDate)
           .OrderByDescending(t => t.TimekeepingDate)
           .ThenBy(t => t.Employee.EmployeeName)
           .ToList();

        // Tạo file Excel từ dữ liệu timekeepings
        var excelData = GenerateExcelData(timekeepings);

        // Đặt tên file và loại nội dung
        var startDateString = startDate?.ToString("yyyy-MM-dd");
        var endDateString = endDate?.ToString("yyyy-MM-dd");

        var fileName = $"chamcong_{startDateString}_{endDateString}.xlsx";
        const string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        // Trả về file Excel để tải xuống
        return File(excelData, contentType, fileName);
    }

    public byte[] GenerateExcelData(IEnumerable<Timekeeping> timekeepings)
    {
        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Chấm công");

        // Thiết lập header cho các cột
        worksheet.Cells[1, 1].Value = "STT";
        worksheet.Cells[1, 2].Value = "Nhân viên";
        worksheet.Cells[1, 3].Value = "Checkin";
        worksheet.Cells[1, 4].Value = "Checkout";
        worksheet.Cells[1, 5].Value = "Ngày";

        // Định dạng header: bôi đậm và canh giữa
        var headerRange = worksheet.Cells["A1:E1"];
        headerRange.Style.Font.Bold = true;
        headerRange.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;


        // Ghi dữ liệu vào worksheet
        var rowIndex = 2;
        var count = 1;
        foreach (var timekeeping in timekeepings)
        {
            worksheet.Cells[rowIndex, 1].Value = count;
            worksheet.Cells[rowIndex, 2].Value = timekeeping.Employee?.EmployeeName;
            worksheet.Cells[rowIndex, 3].Value = timekeeping.CheckIn?.ToString("hh:mm:ss tt");
            worksheet.Cells[rowIndex, 4].Value = timekeeping.CheckOut?.ToString("hh:mm:ss tt");
            worksheet.Cells[rowIndex, 5].Value = timekeeping.TimekeepingDate?.ToString("dd/MM/yyyy");

            rowIndex++;
            count++;
        }

        // Thiết lập kiểu dữ liệu ngày tháng cho cột TimekeepingDate
        var timekeepingDateColumn = worksheet.Cells[$"E2:E{rowIndex - 1}"];
        timekeepingDateColumn.Style.Numberformat.Format = "dd/MM/yyyy";

        // Tự động điều chỉnh kích thước các cột cho phù hợp với nội dung
        worksheet.Cells.AutoFitColumns();

        // Tạo stream để ghi dữ liệu ra file
        using var stream = new MemoryStream();
        package.SaveAs(stream);
        stream.Position = 0;

        // Chuyển stream thành mảng byte
        return stream.ToArray();
    }
}