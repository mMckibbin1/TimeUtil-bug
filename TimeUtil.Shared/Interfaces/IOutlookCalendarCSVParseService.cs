namespace TimeUtil.Shared.Interfaces
{
    public interface IOutlookCalendarCSVParseService
    {
        Task<OutlookCalendar> OutlookCalendar(Stream data);
    }
}
