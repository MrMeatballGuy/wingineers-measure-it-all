using System;
using System.Globalization;
using System.Text.Json.Serialization;
using WingineersMeasureItAll.Converters;

namespace WingineersMeasureItAll.ApiResponse
{
	public class OrderLine
	{

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("orderName")]
        public string? OrderName { get; set; }

        [JsonPropertyName("orderPrice")]
        public double OrderPrice { get; set; }

        [JsonPropertyName("orderDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? OrderDate { get; set; }

        [JsonPropertyName("salesPersonId")]
        public int SalesPersonId { get; set; }

	}
}

