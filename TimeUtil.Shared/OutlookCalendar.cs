
namespace TimeUtil.Shared
{
    public class OutlookCalendar
    {
        private readonly Event[] _events;
        private readonly Dictionary<string, IEnumerable<Event>> _eventLookup;
        private string[]? _categories; 
        

        public OutlookCalendar(IEnumerable<Event> events)
        {
            _events = events.ToArray();

            _eventLookup = PopulateEventLookup();
        }

        public IEnumerable<Event> Events => _events;
        public string[] Categories => _categories ??= _events.SelectMany(e => e.Categories).Distinct().ToArray();

        private Dictionary<string, IEnumerable<Event>> PopulateEventLookup()
        {
            Dictionary<string, IEnumerable<Event>> eventLookup = new();

            foreach (var category in Categories)
            {
                eventLookup.Add(category, _events.Where(ev => ev.Categories.Contains(category)));
            }

            return eventLookup;
        }

        public TimeSpan TotalEventTimeSpan()
        {
            return TotalEventTimeSpan(_events);
        }

        public TimeSpan TotalEventTimeSpan(IEnumerable<string> categories)
        {
            return TotalEventTimeSpan(FilterEvents(categories).ToArray());
        }

        public static TimeSpan TotalEventTimeSpan(IList<Event> events)
        {
            TimeSpan total = TimeSpan.Zero;

            for (int i = 0; i < events.Count; i++)
            {
                total += events[i].Eventduration;
            }

            return total;
        }

        public static double TimeUtilisationPercentage(double targetHours, IEnumerable<Event> events)
        {
            double totalHours = TotalEventTimeSpan(events.ToArray()).TotalHours;
            double timeUtilPercentage = totalHours / targetHours * 100;
            return timeUtilPercentage;
        }

        public IEnumerable<Event> FilterEvents(IEnumerable<string> categories)
        {
            return FilterEvents(categories, null, null);
        }

        public IEnumerable<Event> FilterEvents(DateOnly? startDate = null, DateOnly? endDate = null)
        {
            return FilterEvents(null, startDate, endDate);
        }

        public IEnumerable<Event> FilterEvents(IEnumerable<string>? categories = null, DateOnly? startDate = null, DateOnly? endDate = null)
        {
            IEnumerable<Event> local = categories is null ? _events : FilterEventsByCategories(categories);

            if (startDate is not null)
            {
                local = local.Where(e => e.StartDate >= startDate);
            }

            if (endDate is not null)
            {
                local = local.Where(e => e.EndDate <= endDate);
            }

            return local;
        }

        private IEnumerable<Event> FilterEventsByCategories(IEnumerable<string> categories)
        {
            List<Event> events = new();

            foreach (var category in categories)
            {
                if (_eventLookup.TryGetValue(category, out var value))
                {
                    events.AddRange(value);
                }
            }

            return events.Distinct();
        }
    }
}
