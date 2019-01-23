using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HkGov.Web.Api.Holiday.Bases
{
    /// <summary>
    /// Abstract class to generialize Web API.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        /// <summary>
        /// DI property on AppSettings.
        /// </summary>
        protected AppSettings _appSettings;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="appSettings"></param>
        public BaseApiController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
    }
}
