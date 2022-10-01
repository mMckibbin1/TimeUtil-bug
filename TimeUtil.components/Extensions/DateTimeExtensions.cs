namespace TimeUtil.Components.Extensions;
internal static class DateTimeExtensions
{
    public static DateTime GetFirstDayOfMonth(this DateTime date)
    {
        return new(date.Year, date.Month, 1);
    }
    public static DateTime GetLastDayOfMonth(this DateTime date)
    {
        return new(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
    }
}
