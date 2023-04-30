using System;
using System.Text.Json.Serialization;
using WingineersMeasureItAll.ApiResponse;

namespace WingineersMeasureItAll.ViewModels
{
    public class SalesPersonOverviewViewModel
    {
        private SalesPerson salesPerson;

        public int Id { get { return salesPerson.Id; } }

        public string? Name { get { return salesPerson.Name; } }

        public DateTime? HireDate { get { return salesPerson.HireDate; } }

        public string? Address { get { return salesPerson.Address; } }

        public string? City { get { return salesPerson.City; } }

        public string? ZipCode { get { return salesPerson.ZipCode; } }

        public int NumberOfOrders { get; } = 0;

        public SalesPersonOverviewViewModel(SalesPerson salesPerson, int numberOfOrders)
		{
            this.salesPerson = salesPerson;
            this.NumberOfOrders = numberOfOrders;
		}
	}
}

