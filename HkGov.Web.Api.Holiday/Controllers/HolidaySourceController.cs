using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HkGov.Web.Api.Holiday.Bases;
using HkGov.Web.Api.Holiday.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HkGov.Web.Api.Holiday.Controllers
{
    public class HolidaySourceController : BaseApiController
    {
        public HolidaySourceController(IOptions<AppSettings> appSettings) : base(appSettings) { }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<HolidaySource>> Get()
        {
            HolidaySource[] result = _appSettings.HolidaySources.ToArray();
            return result;
        }
    }
}