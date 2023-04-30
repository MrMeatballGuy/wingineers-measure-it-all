using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using WingineersMeasureItAll.Services;
using WingineersMeasureItAll.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WingineersMeasureItAll.Controllers
{
    public class SalesPeopleController : Controller
    {
        private IWingineersApiProxy wingineersApi;
        public SalesPeopleController(IWingineersApiProxy wingineersApi)
        {
            this.wingineersApi = wingineersApi;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var salesPeople = await wingineersApi.GetSalesPeople();
            var orders = await wingineersApi.GetOrderLines();
            var orderCounts = orders.GroupBy(o => o.SalesPersonId).ToDictionary(group => group.Key, group => group.Count());

            List<SalesPersonOverviewViewModel> viewModel = new List<SalesPersonOverviewViewModel>();

            int currentOrderCount = 0;
            foreach (var salesPerson in salesPeople)
            {
                if (!orderCounts.TryGetValue(salesPerson.Id, out currentOrderCount))
                {
                    currentOrderCount = 0;
                }
                viewModel.Add(new SalesPersonOverviewViewModel(salesPerson, currentOrderCount));
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var salesPeople = await wingineersApi.GetSalesPeople();
            var salesPerson = salesPeople.Find(sp => sp.Id == id);
            var orderLines = await wingineersApi.GetOrderLines();

            var viewModel = new SalesPersonDetailsViewModel(salesPerson, orderLines.FindAll(o => o.SalesPersonId == salesPerson.Id));

            return View(viewModel);
        }
    }
}

