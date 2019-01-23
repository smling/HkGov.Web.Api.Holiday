using System;

namespace HkGov.Web.Api.Holiday.Models
{
    /// <summary>
    /// Holiday object.
    /// </summary>
    public class Holiday
    {
        /// <summary>
        /// Date of holiday.
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Holiday description.
        /// </summary>
        public string Description { get; set; }
    }
}
