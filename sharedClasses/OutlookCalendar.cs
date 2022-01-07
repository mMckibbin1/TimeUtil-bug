namespace TimeUtil.sharedClasses
{
    public class OutlookCalendar
    {
        private readonly Event[] _events;

        public OutlookCalendar(Event[] events)
        {
            _events = events;
        }

        public IEnumerable<Event> Events => _events;

        public TimeSpan Total()
        {
            return Total(_events);
        }

        public TimeSpan Total(IEnumerable<string> categories)
        {
            Event[] events = _events.Where(ev => categories.Contains(ev.Categories)).ToArray();

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
    }
}
