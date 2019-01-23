using Ical.Net.CalendarComponents;

namespace HkGov.Web.Api.Holiday.Models.Builders
{
    /// <summary>
    /// Builder for creating Holiday class.
    /// </summary>
    public class HolidayBuilder
    {
        /// <summary>
        /// Create Hoilday class by calendar event.
        /// </summary>
        /// <param name="calendarEvent"></param>
        /// <returns></returns>
        public static Holiday Create(CalendarEvent calendarEvent)
        {
            Holiday result = new Holiday()
            {
                Date = calendarEvent.Start.Date,
                Description = calendarEvent.Summary
            };
            return result;
        }
    }
}
