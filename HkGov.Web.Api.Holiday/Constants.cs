namespace HkGov.Web.Api.Holiday
{
    /// <summary>
    /// Application constants.
    /// </summary>
    public class Constants
    {
        public const string ServiceName = "Hong Kong Public Holiday Service";
        /// <summary>
        /// API related constants, which will shown in Swagger UI.
        /// </summary>
        public class Api
        {
            /// <summary>
            /// API Name.
            /// </summary>
            public const string Title = "HKGov Public Holiday";
            /// <summary>
            /// API Version.
            /// </summary>
            public const string Version = "v1";
            /// <summary>
            /// Swagger JSON endpoint URL.
            /// </summary>
            public const string SwaggerEndpoint = "/swagger/v1/swagger.json";
        }
        /// <summary>
        /// Application Settings for load into class AppSettings.
        /// </summary>
        public class Settings {
            /// <summary>
            /// AppSetting file path.
            /// </summary>
            public const string AppSettingFilePath = "appsettings.json";
            /// <summary>
            /// AppSetting JSON section name.
            /// </summary>
            public const string AppSettingSection = "AppSettings";
        }
        /// <summary>
        /// API support language.
        /// </summary>
        public class Languages {
            /// <summary>
            /// English (EN)
            /// </summary>
            public const string English = "en";
            /// <summary>
            /// Traditional Chinese (TC)
            /// </summary>
            public const string TraditionalChinese = "tc";
            /// <summary>
            /// Simplified chinese (SC)
            /// </summary>
            public const string SimpifiedChinese = "sc";
        }
    }
}
