using BudHillFMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BudHillFMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {
           // for(int i = 1; i <= 12; i++){
              //  ViewData['Sextoy' + i] = costResponse.getQuery().Where(CostDate.Month = i.ToString() && CostDate.year = DateTime.Now.Year);
//                 var itemsInCart = from o in db.OrderLineItems
//               where o.OrderId == currentOrder.OrderId
//               select new { o.WishListItem.Price };
// var sum = itemsCard.ToList().Select(c=>c.Price).Sum();
           // }
            return View();
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