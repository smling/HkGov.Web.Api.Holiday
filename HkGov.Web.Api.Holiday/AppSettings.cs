using HkGov.Web.Api.Holiday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HkGov.Web.Api.Holiday
{
    /// <summary>
    /// Application Settings.
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Service name.
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// URL List of Holiday sources.
        /// </summary>
        public IList<HolidaySource> HolidaySources { get; set; }
    }
}
