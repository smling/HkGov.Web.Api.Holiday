using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HkGov.Web.Api.Holiday
{
    public class Constants
    {
        public class Api
        {
            public const string Title = "HKGov Public Holiday";
            public const string Version = "v1";
            public const string SwaggerEndpoint = "/swagger/v1/swagger.json";
        }
        public class Settings {
            public const string AppSettingFilePath = "appsettings.json";
            public const string AppSettingSection = "AppSettings";
        }
    }
}
