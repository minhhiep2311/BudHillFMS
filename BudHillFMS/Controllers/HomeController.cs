using BudHillFMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BudHillFMS.Areas.Identity.Data;
using BudHillFMS.Views.Home;
using Microsoft.EntityFrameworkCore;

namespace BudHillFMS.Controllers
{
    public class HomeController : Controller
    {
           
        private readonly FarmManagementSystemContext _context;

        public HomeController(FarmManagementSystemContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var outcome = _context.Costs.Sum(c => c.CostAmount) ?? 0;
            var farmsNumber = _context.Farms.Count();
            var seedsNumber = _context.Tasks.Count(t => t.TaskCheck == false);
            var employeeNumber = _context.Employees.Count();
            var productCheck = _context.Products.Include(p => p.Field)
                .ThenInclude(f => f.Farm)
                .Where(p => p.ProductStatus == true) 
                .Take(3)
                .ToList();

            var currentYear = DateTime.Now.Year;
            var cost = _context.Costs
               .Select(c => new
                {
                    c.CostAmount,
                    c.CategoryId,
                    CategoryName = c.Category != null ? c.Category.CategoryName : "",
                    Month = c.CostDate != null ? c.CostDate.Value.Month : 0,
                    Year = c.CostDate != null ? c.CostDate.Value.Year : 0,
                })
               .Where(c => !string.IsNullOrEmpty(c.CategoryName) && c.Year == currentYear)
               .GroupBy(c => new { c.CategoryId, c.Month, c.Year })
               .Select(c => new
                {
                    c.First().Month,
                    c.First().CategoryId,
                    c.First().CategoryName,
                    Total = c.Sum(i => i.CostAmount) ?? 0
                })
               .ToList();

            var colors = new[] { "rgb(0, 128, 255)", "rgb(102, 178, 255)", "rgb(204, 224, 255)" };
            var outcomeList = new List<Tuple<int?, string, decimal[], string>>();

            foreach (var c in cost)
            {
                var index = outcomeList.FindIndex(x => x.Item1 == c.CategoryId);
                if (index == -1)
                {
                    var colorIndex = outcomeList.Count % 3;
                    outcomeList.Add(
                        Tuple.Create(c.CategoryId, c.CategoryName, Enumerable.Repeat(0m, 12).ToArray(), colors[colorIndex]));
                    index = outcomeList.Count - 1;
                }

                outcomeList[index].Item3[c.Month - 1] = c.Total;
            }

            var model = new HomePageModel
            {
                FarmsNumber = farmsNumber,
                SeedsNumber = seedsNumber,
                EmployeeNumber = employeeNumber,
                Outcome = outcome,
                OutcomeList = outcomeList,
                ListProduct = productCheck
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}