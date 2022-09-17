using TimeUtil.Shared;

namespace TimeUtil.Components.Shared.DataOutput;
public sealed class EventsTableData
{
    public EventsTableData(IEnumerable<Event> events)
    {
        Events = events;
    }

    public IEnumerable<Event> Events { get; }
}
