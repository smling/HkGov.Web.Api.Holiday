using HkGov.Web.Api.Holiday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HkGov.Web.Api.Holiday
{
    public class AppSettings
    {
        public IList<HolidaySource> HolidaySources { get; set; }
    }
}
