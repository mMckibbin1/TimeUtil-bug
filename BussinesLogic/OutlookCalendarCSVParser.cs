using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using TimeUtil.Shared;

namespace TimeUtil.BussinesLogic
{
    public static class OutlookCalendarCSVParser
    {
        private static readonly CsvConfiguration configuration = new(CultureInfo.CurrentCulture)
        {
            IncludePrivateMembers = true,
        };

        public static async Task<OutlookCalendar> Parse(Stream stream)
        {
            using var reader = new StreamReader(stream);
            using var csv = new CsvReader(reader, configuration);
            csv.Context.RegisterClassMap<EventMap>();
            var eventsStream = csv.GetRecordsAsync<Event>();

            List<Event> events = new();
            await foreach (var record in eventsStream)
            {
                events.Add(record);
            }

            return new(events);
        }
    }

    internal class EventMap : ClassMap<Event>
    {
        public EventMap()
        {
            Map(m => m.EventSubject).Name("Subject");
            Map(m => m.StartTime).Name("Start Time");
            Map(m => m.EndTime).Name("End Time");
            Map(m => m.StartDate).Name("Start Date");
            Map(m => m.EndDate).Name("Start Date");
            Map(m => m.Categories).Name("Categories").TypeConverter(new CategoiresConverter());
        }
    }
}