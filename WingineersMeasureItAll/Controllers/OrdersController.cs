using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WingineersMeasureItAll.Services;
using WingineersMeasureItAll.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WingineersMeasureItAll.Controllers
{
    public class OrdersController : Controller
    {
        private IWingineersApiProxy wingineersApi;
        public OrdersController(IWingineersApiProxy wingineersApi)
        {
            this.wingineersApi = wingineersApi;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var orderLines = await wingineersApi.GetOrderLines();

            var orderLineCounts = orderLines
                .GroupBy(o => new { o.OrderDate?.Year, o.OrderDate?.Month })
                .Select(x => new OrderLineOverviewViewModel
                {
                    Month = x.Key.Month ?? 0,
                    Year = x.Key.Year ?? 0,
                    OrderLineCount = x.Count()
                })
                .OrderByDescending(x => x.Year)
                .ThenBy(x => x.Month)
                .ToList();

            return View(orderLineCounts);
        }
    }
}

