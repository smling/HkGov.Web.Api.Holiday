using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HkGov.Web.Api.Holiday.Bases;
using HkGov.Web.Api.Holiday.Http;
using HkGov.Web.Api.Holiday.iCal;
using HkGov.Web.Api.Holiday.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HkGov.Web.Api.Holiday.Controllers
{
    public class HolidayController : BaseApiController
    {
        public HolidayController(IOptions<AppSettings> appSettings) : base(appSettings) { }
        /// <summary>
        /// Get General holiday from Government.
        /// </summary>
        /// <param name="language">EN (Englist), TC (Tradition Chinese) and SC (Simplication Chinese)</param>
        /// <returns></returns>
        [HttpGet("{language}", Name = "Get")]
        public async Task<IEnumerable<Models.Holiday>> Get(string language)
        {
            ICalReader icalReader = new ICalReader();
            HolidaySource targetUrl = _appSettings.HolidaySources.FirstOrDefault(o=>o.Language.Trim().ToUpper()==language.Trim().ToUpper());
            if (targetUrl == null)
                throw new ArgumentException("Incorrect language detected, only en / tc / sc allow.");

            IEnumerable<Models.Holiday> result = await icalReader.Read(targetUrl.Url);
            return result;
        }
    }
}
