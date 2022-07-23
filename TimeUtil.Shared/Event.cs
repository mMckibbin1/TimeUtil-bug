using System.Text.Json.Serialization;

namespace TimeUtil.Shared;

public class Event
{
    [JsonInclude]
    public string? EventSubject { get; private set; }

    [JsonInclude]
    public DateOnly StartDate { get; private set; }

    [JsonInclude]
    public DateOnly EndDate { get; private set; }

    [JsonInclude]
    public TimeOnly StartTime { get; private set; }

    [JsonInclude]
    public TimeOnly EndTime { get; private set; }

    [JsonInclude]
    public IEnumerable<string> Categories { get; private set; } = Enumerable.Empty<string>();

    private TimeSpan? _Eventduration;
    public TimeSpan Eventduration
    {
        get
        {
            if (!_Eventduration.HasValue)
            {
                TimeSpan dif = FullEndDateTime - FullStartDateTime;

                _Eventduration = dif;
            }
            return _Eventduration.Value;
        }
    }
    private DateTime? _fullStartDateTime;
    private DateTime? _fullEndDateTime;
    public DateTime FullStartDateTime => _fullStartDateTime ??= StartDate.ToDateTime(StartTime);
    public DateTime FullEndDateTime => _fullEndDateTime ??= EndDate.ToDateTime(EndTime);
}
