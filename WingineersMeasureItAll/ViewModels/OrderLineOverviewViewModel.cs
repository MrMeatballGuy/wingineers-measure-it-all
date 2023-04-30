using System;
using System.Globalization;

namespace WingineersMeasureItAll.ViewModels
{
	public class OrderLineOverviewViewModel
	{
		public OrderLineOverviewViewModel()
		{
		}

		public int Month { get; set; }
		public int Year { get; set; }
		public string MonthName {
			get
			{
				return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Month);
            }
		}
		public int OrderLineCount { get; set; }
    }
}

