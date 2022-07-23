using TimeUtil.Shared;
using TimeUtil.Shared.Interfaces;
using TimeUtil.BussinesLogic;

namespace TimeUtil.BlazorWasmClient.Services
{
    internal class OutlookCSVParseService : IOutlookCalendarCSVParseService
    {
        public Task<OutlookCalendar> ParseOutlookCalendar(Stream data)
        {
            return OutlookCalendarCSVParser.Parse(data);
        }
    }
}
