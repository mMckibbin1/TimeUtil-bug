namespace TimeUtil.Components.Shared;
public class MonthRange
{
    public MonthRange(DateOnly? startMonth, DateOnly? endMonth)
    {
        StartMonth = startMonth.HasValue ? new DateOnly(startMonth.Value.Year, startMonth.Value.Month, 1) : null;
        EndMonth = endMonth.HasValue ? new DateOnly(endMonth.Value.Year, endMonth.Value.Month, DateTime.DaysInMonth(endMonth.Value.Year, endMonth.Value.Month)) : null;
    }

    public DateOnly? StartMonth { get; }
    public DateOnly? EndMonth { get; }
}
