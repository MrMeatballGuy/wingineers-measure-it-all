using System;
using WingineersMeasureItAll.ApiResponse;

namespace WingineersMeasureItAll.Services
{
	public class WingineersApiProxy : IWingineersApiProxy
	{
		private HttpClient httpClient;
		
		public WingineersApiProxy(IHttpClientFactory httpClientFactory)
		{
			this.httpClient = httpClientFactory.CreateClient("Wingineers");
		}

		// should ideally support query params or maybe even be rewritten to support all HTTP methods
		private async Task<TResult> makeRequest<TResult>(string endpoint)
		{
			// proper error handling should be implemented
			return await httpClient.GetFromJsonAsync<TResult>(endpoint);
		}

		public async Task<List<SalesPerson>> GetSalesPeople()
		{
			return await this.makeRequest<List<SalesPerson>>("SalesPersons");
		}

        public async Task<List<OrderLine>> GetOrderLines()
        {
            return await this.makeRequest<List<OrderLine>>("Orderlines");
        }
    }
}

