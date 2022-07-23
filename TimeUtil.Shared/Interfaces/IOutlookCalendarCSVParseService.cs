namespace TimeUtil.Shared.Interfaces
{
    public interface IOutlookCalendarCSVParseService
    {
        Task<OutlookCalendar> ParseOutlookCalendar(Stream data);
    }
}
