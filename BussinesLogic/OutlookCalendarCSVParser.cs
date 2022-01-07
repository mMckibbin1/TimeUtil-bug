using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using TimeUtil.sharedClasses;

namespace TimeUtil.BussinesLogic
{
    public static class OutlookCalendarCSVParser
    {
        private static readonly CsvConfiguration configuration = new(CultureInfo.CurrentCulture)
        {
            IncludePrivateMembers = true,
        };

        public static OutlookCalendar Parse(FileStream fileStream)
        {
            using var reader = new StreamReader(fileStream);
            using var csv = new CsvReader(reader, configuration);
            csv.Context.RegisterClassMap<EventMap>();
            Event[] records = csv.GetRecords<Event>().ToArray();

            return new(records);
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
            Map(m => m.Categories).Name("Categories");
        }
    }
}