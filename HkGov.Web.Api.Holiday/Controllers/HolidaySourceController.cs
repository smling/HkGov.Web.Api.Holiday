using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HkGov.Web.Api.Holiday.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HkGov.Web.Api.Holiday.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidaySourceController : ControllerBase
    {
        protected AppSettings _appSettings;
        public HolidaySourceController(IOptions<AppSettings> appSettings) {
            _appSettings = appSettings.Value;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<HolidaySource>> Get()
        {
            HolidaySource[] result = _appSettings.HolidaySources.ToArray();
            return result;
        }
    }
}