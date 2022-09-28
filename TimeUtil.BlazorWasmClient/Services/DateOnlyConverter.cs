using System.Text.Json;
using System.Text.Json.Serialization;

namespace TimeUtil.BlazorWasmClient.Services
{
    public class DateOnlyConverter : JsonConverter<DateOnly>
    {
        private readonly IFormatProvider _formatProvider;

        public DateOnlyConverter(IFormatProvider formatProvider)
        {
            _formatProvider = formatProvider;
        }

        public override DateOnly Read(ref Utf8JsonReader reader,
                                Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return DateOnly.Parse(value!, _formatProvider);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value,
                                            JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(_formatProvider));
    }
}
