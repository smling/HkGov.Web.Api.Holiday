using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HkGov.Web.Api.Holiday.Bases
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected AppSettings _appSettings;
        public BaseApiController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
    }
}
