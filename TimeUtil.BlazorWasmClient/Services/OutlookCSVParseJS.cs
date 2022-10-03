using Microsoft.JSInterop;
using System.Globalization;
using System.Text.Json;
using TimeUtil.Shared;
using TimeUtil.Shared.Interfaces;

namespace TimeUtil.BlazorWasmClient.Services
{
    public class OutlookCSVParseJS : IOutlookCalendarCSVParseService
    {
        private static readonly CultureInfo cultureInfo = new("en-GB");

        private static readonly JsonSerializerOptions _options = new(JsonSerializerDefaults.Web)
        {
            Converters =
            {
                new DateOnlyConverter(cultureInfo),
                new TimeOnlyConverter(cultureInfo)
            }
        };

        private readonly IJSRuntime _jSRuntime;

        public OutlookCSVParseJS(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }

        public async Task<OutlookCalendar> ParseOutlookCalendar(Stream data)
        {
            using DotNetStreamReference streamRef = new(stream: data);

            string eventsJson = await _jSRuntime.InvokeAsync<string>("parseCSV", streamRef);

            Event[] events = JsonSerializer.Deserialize<Event[]>(eventsJson, _options)!;

            return new(events);
        }

        public async Task ExportOutlookCalendar(OutlookCalendar data, string fileName)
        {
            string json = JsonSerializer.Serialize(data.Events, _options);

            await _jSRuntime.InvokeVoidAsync("exportCSV", json, fileName);
        }
    }
}
