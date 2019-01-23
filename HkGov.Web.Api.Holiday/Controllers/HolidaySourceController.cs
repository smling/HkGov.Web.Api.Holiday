using HkGov.Web.Api.Holiday.Bases;
using HkGov.Web.Api.Holiday.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace HkGov.Web.Api.Holiday.Controllers
{
    /// <summary>
    /// Get Holiday Source.
    /// </summary>
    public class HolidaySourceController : BaseApiController
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="appSettings"></param>
        public HolidaySourceController(IOptions<AppSettings> appSettings) : base(appSettings) { }
        /// <summary>
        /// Get all holiday sources.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<HolidaySource>> Get()
        {
            HolidaySource[] result = _appSettings.HolidaySources.ToArray();
            return result;
        }
    }
}