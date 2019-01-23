using Ical.Net.CalendarComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HkGov.Web.Api.Holiday.Models.Builders
{
    public class HolidayBuilder
    {
        public static Holiday Create(CalendarEvent calendarEvent) {
            Holiday result = new Holiday() {
                Date = calendarEvent.Start.Date,
                Description=calendarEvent.Summary
            };
            return result;
        }
    }
}
