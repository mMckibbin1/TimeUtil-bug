using System.Text.Json;
using System.Text.Json.Serialization;

namespace TimeUtil.BlazorWasmClient.Services
{
    public class TimeOnlyConverter : JsonConverter<TimeOnly>
    {
        private readonly IFormatProvider _formatProvider;

        public TimeOnlyConverter(IFormatProvider formatProvider)
        {
            _formatProvider = formatProvider;
        }

        public override TimeOnly Read(ref Utf8JsonReader reader,
                                Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return TimeOnly.Parse(value!, _formatProvider);
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value,
                                            JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(_formatProvider));
    }
}
