using System;
using System.Collections.Generic;

namespace HkGov.Web.Api.Holiday.Diagnosis
{
    /// <summary>
    /// Health check response.
    /// </summary>
    public class HealthCheckResponse
    {
        /// <summary>
        /// Overall status.
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Detail status for each health check probes.
        /// </summary>
        public IEnumerable<HealthCheckProbe> HealthCheckProbes { get; set; }
        /// <summary>
        /// Health check time used.
        /// </summary>
        public TimeSpan Duration { get; set; }
    }
}
