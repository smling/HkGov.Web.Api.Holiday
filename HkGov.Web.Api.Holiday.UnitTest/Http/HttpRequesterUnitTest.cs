using HkGov.Web.Api.Holiday.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HkGov.Web.Api.Holiday.UnitTest.Http
{
    public class HttpRequesterUnitTest
    {
        private HttpRequester httpRequester;

        public HttpRequesterUnitTest()
        {
            httpRequester = new HttpRequester();
        }

        [Theory(DisplayName = "Test for URL handling.")]
        [InlineData("http://www.1823.gov.hk/common/ical/en.ics", false)]
        public async Task GetHolidayDateTest(string url, bool isEmpty)
        {
            string respone = await httpRequester.GetResponseAsStringAsync(url);
            Assert.NotNull(respone);
            Assert.True(string.IsNullOrEmpty(respone)==isEmpty);
        }
    }
}
