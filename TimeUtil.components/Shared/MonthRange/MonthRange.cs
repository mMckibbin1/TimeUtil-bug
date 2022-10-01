using TimeUtil.Components.Extensions;

namespace TimeUtil.Components.Shared;
public class MonthRange
{
    public MonthRange(DateOnly? startMonth, DateOnly? endMonth)
    {
        StartMonth = startMonth.HasValue ? startMonth.Value.GetFirstDayOfMonth() : null;
        EndMonth = endMonth.HasValue ? endMonth.Value.GetLastDayOfMonth() : null;
    }

    public DateOnly? StartMonth { get; }
    public DateOnly? EndMonth { get; }
}
