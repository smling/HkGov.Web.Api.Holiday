using HkGov.Web.Api.Holiday.Http;
using HkGov.Web.Api.Holiday.Models;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HkGov.Web.Api.Holiday.Diagnosis.Probes
{
    public class DataSourceHealthCheckProbe : IHealthCheck
    {
        private IEnumerable<HolidaySource> targetUrls;
        public DataSourceHealthCheckProbe(IOptions<AppSettings> appSettings)
        {
            targetUrls = appSettings.Value.HolidaySources;
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                bool result = true;
                HttpRequester requester = new HttpRequester();
                foreach (HolidaySource source in targetUrls)
                {
                    string response = await requester.GetResponseAsStringAsync(source.Url);
                    if (String.IsNullOrWhiteSpace(response))
                    {
                        result = false;
                    }
                }
                if (!result)
                {
                    throw new Exception("Data source healthcheck failure.");
                }
                return HealthCheckResult.Healthy("Custom health check success.");
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy(ex.Message);
            }
        }
    }
}
