using TimeUtil.Shared;

namespace TimeUtil.Components.EventsTable;
public sealed class EventsTableData
{
    public EventsTableData(IEnumerable<Event> events)
    {
        Events = events.ToArray();
    }

    public IReadOnlyCollection<Event> Events { get; }
}
