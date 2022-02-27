using System;

namespace HkGov.Web.Api.Holiday.Diagnosis
{
    /// <summary>
    /// Health check probe.
    /// </summary>
    public class HealthCheckProbe
    {
        /// <summary>
        /// Health check component name.
        /// </summary>
        public string Component { get; set; }
        /// <summary>
        /// Health check component description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Health check component status.
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Time used on the health check.
        /// </summary>
        public TimeSpan Duration { get; set; }
        /// <summary>
        /// Captured expection name if unhealthy detected.
        /// </summary>
        public string Exception { get; set; }
        /// <summary>
        /// Unhealthy diagnosis message.
        /// </summary>
        public string Message { get; set; }
    }
}
