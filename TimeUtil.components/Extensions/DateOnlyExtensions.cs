namespace TimeUtil.Components.Extensions;
internal static class DateOnlyExtensions
{
    public static DateOnly GetFirstDayOfMonth(this DateOnly date)
    {
        return new(date.Year, date.Month, 1);
    }
    public static DateOnly GetLastDayOfMonth(this DateOnly date)
    {
        return new(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
    }
}
