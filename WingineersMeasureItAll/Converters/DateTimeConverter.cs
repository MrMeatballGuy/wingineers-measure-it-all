using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WingineersMeasureItAll.Converters
{
	public class DateTimeConverter : JsonConverter<DateTime>
    {
		public DateTimeConverter()
		{
		}

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string input = reader.GetString();

            DateTime output;

            bool hasParsed = DateTime.TryParseExact(input, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out output);
            if (!hasParsed) hasParsed = DateTime.TryParseExact(input, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out output);
            if (!hasParsed) hasParsed = DateTime.TryParseExact(input, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out output);

            if (!hasParsed)
            {
                throw new Exception("DateTime format invalid");
            }
            return output;

        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}

