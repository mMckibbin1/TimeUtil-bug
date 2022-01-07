using TimeUtil.BussinesLogic;
using TimeUtil.sharedClasses;

string path = @"C:\Users\Matt\OneDrive - SERC\workign from home\HR\calendare exports\calendar exports\Calendar export May-July 21.CSV";


using FileStream fs = new FileStream(path, FileMode.Open);

OutlookCalendar cal = OutlookCalendarCSVParser.Parse(fs);


Event[]? events = cal.Events.Where(x => x.Categories == "Business Services Delivery" || x.Categories == "CDP").ToArray();



foreach (var ev in cal.Events)
{
    Console.WriteLine(ev.EventSubject);
    Console.WriteLine(ev.Eventduration);
}

Console.WriteLine($"\nTotal hours: {cal.Events.Sum(x => x.Eventduration.TotalHours)}");

Console.WriteLine($"\nTotal hours new: {cal.Total().TotalHours}");

Console.WriteLine($"\nTotal hours control: {events.Sum(x=> x.Eventduration.TotalHours)}");

Console.WriteLine($"\nTotal hours new: {cal.Total(new string[] { "Business Services Delivery", "CDP" }).TotalHours}");