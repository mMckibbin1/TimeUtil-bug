using Microsoft.JSInterop;
using System.Text.Json;
using TimeUtil.Shared;
using TimeUtil.Shared.Interfaces;

namespace TimeUtil.MauiBlazor.Services
{
    public class OutlookCSVParseJS : IOutlookCalendarCSVParseService
    {
        private static readonly JsonSerializerOptions _options = new(JsonSerializerDefaults.Web)
        {
            Converters =
            {
                new DateOnlyConverter(),
                new TimeOnlyConverter()
            }
        };

        private readonly IJSRuntime _jSRuntime;

        public OutlookCSVParseJS(IJSRuntime jSRuntime)
        {
            _jSRuntime = jSRuntime;
        }

        public Task ExportOutlookCalendar(OutlookCalendar data, string fileName)
        {
            throw new NotImplementedException();
        }

        public async Task<OutlookCalendar> ParseOutlookCalendar(Stream data)
        {
            using DotNetStreamReference streamRef = new(stream: data);

            string eventsJson = await _jSRuntime.InvokeAsync<string>("parseCSV", streamRef);

            Event[] events = JsonSerializer.Deserialize<Event[]>(eventsJson, _options)!;

            return new(events);
        }
    }
}
