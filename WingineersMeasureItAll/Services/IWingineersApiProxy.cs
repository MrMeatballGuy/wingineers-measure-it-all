using System;
using WingineersMeasureItAll.ApiResponse;
using System.Collections.Generic;

namespace WingineersMeasureItAll.Services
{
	public interface IWingineersApiProxy
	{
        public Task<List<SalesPerson>> GetSalesPeople();
        public Task<List<OrderLine>> GetOrderLines();
    }
}

