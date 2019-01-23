using Ical.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HkGov.Web.Api.Holiday.Models;
using HkGov.Web.Api.Holiday.Http;
using System.IO;
using Ical.Net.CalendarComponents;
using HkGov.Web.Api.Holiday.Models.Builders;

namespace HkGov.Web.Api.Holiday.iCal
{
    public class ICalReader
    {
        public async Task<IEnumerable<Holiday.Models.Holiday>> Read(string filePath)
        {
            IList<Holiday.Models.Holiday> result = new List<Holiday.Models.Holiday>();
            HttpRequester requester = new HttpRequester();
            string icalString = await requester.GetAsync(filePath);
            Calendar calendar = Calendar.Load(icalString);
            Console.WriteLine("calendiar loaded." + calendar.Events.Count);
            calendar.Events.ToList().ForEach(delegate (CalendarEvent calendarEvent) {
                Holiday.Models.Holiday holiday = HolidayBuilder.Create(calendarEvent);
                result.Add(holiday);
            });
            return result;
        }
    }
}
