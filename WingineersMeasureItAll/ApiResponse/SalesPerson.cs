using System;
using System.Text.Json.Serialization;
using WingineersMeasureItAll.Converters;

namespace WingineersMeasureItAll.ApiResponse
{
	public class SalesPerson
	{

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("hireDate")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime? HireDate { get; set; }

        [JsonPropertyName("address")]
        public string? Address { get; set; }

        [JsonPropertyName("city")]
        public string? City { get; set; }

        [JsonPropertyName("zipCode")]
        public string? ZipCode { get; set; }

    }
}

