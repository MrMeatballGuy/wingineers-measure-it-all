using System;
using WingineersMeasureItAll.ApiResponse;

namespace WingineersMeasureItAll.ViewModels
{
	public class SalesPersonDetailsViewModel
	{
        private SalesPerson salesPerson;

        public int Id { get { return salesPerson.Id; } }

        public string? Name { get { return salesPerson.Name; } }

        public DateTime? HireDate { get { return salesPerson.HireDate; } }

        public string? Address { get { return salesPerson.Address; } }

        public string? City { get { return salesPerson.City; } }

        public string? ZipCode { get { return salesPerson.ZipCode; } }

        public List<OrderLine> OrderLines { get; init; }

        public SalesPersonDetailsViewModel(SalesPerson salesPerson, List<OrderLine> orderLines)
        {
            this.salesPerson = salesPerson;
            this.OrderLines = orderLines;
        }


    }
}
