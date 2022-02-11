
namespace TimeUtil.Shared
{
    public class OutlookCalendar
    {
        private readonly Event[] _events;

        public OutlookCalendar(IEnumerable<Event> events)
        {
            _events = events.ToArray();
        }

        public IEnumerable<Event> Events => _events;

        private IEnumerable<string>? _categories;
        public IEnumerable<string> Categories => _categories ??= _events.SelectMany(e => e.Categories).Distinct();

        public TimeSpan Total()
        {
            return Total(_events);
        }

        public TimeSpan Total(IEnumerable<string> categories)
        {
            Event[] events = _events.Where(ev => categories.Any(c => ev.Categories.Contains(c))).ToArray();

            return Total(events);
        }

        private static TimeSpan Total(Event[] events)
        {
            TimeSpan total = TimeSpan.Zero;

            for (int i = 0; i < events.Length; i++)
            {
                total += events[i].Eventduration;
            }

            return total;
        }

        public double TimeUtilisationPercentage(double targetHours, IEnumerable<string> categories)
        {
            double totalHours = Total(categories).TotalHours;
            double timeUtilPercentage = totalHours / targetHours * 100;
            return timeUtilPercentage;
        }
    }
}
