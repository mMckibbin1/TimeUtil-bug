using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TimeUtil.MauiBlazor.Services
{
    public class DateOnlyConverter : JsonConverter<DateOnly>
    {
        private readonly static IFormatProvider _defaultFormatProvider = new CultureInfo("en-GB");

        private readonly IFormatProvider _serializationFormat;

        public DateOnlyConverter() : this(null)
        {
        }

        public DateOnlyConverter(IFormatProvider serializationFormat)
        {
            _serializationFormat = serializationFormat ?? _defaultFormatProvider;
        }

        public override DateOnly Read(ref Utf8JsonReader reader,
                                Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return DateOnly.Parse(value, _serializationFormat);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value,
                                            JsonSerializerOptions options)
            => writer.WriteStringValue(value.ToString(_serializationFormat));
    }
}
