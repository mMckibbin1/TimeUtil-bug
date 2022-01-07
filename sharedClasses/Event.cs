namespace TimeUtil.SharedClasses;

public class Event
{
    public string? EventSubject { get; private set; }
    public DateOnly StartDate { get; private set; }
    public DateOnly EndDate { get; private set; }
    public TimeOnly StartTime { get; private set; }
    public TimeOnly EndTime { get; private set; }
    public string? Categories { get; private set; }

    private TimeSpan? _Eventduration;
    public TimeSpan Eventduration
    {
        get
        {
            if (!_Eventduration.HasValue)
            {
                DateTime startDate = StartDate.ToDateTime(StartTime);
                DateTime endDate = EndDate.ToDateTime(EndTime);

                TimeSpan dif = endDate - startDate;

                _Eventduration = dif;
            }
            return _Eventduration.Value;
        }
    }
}
