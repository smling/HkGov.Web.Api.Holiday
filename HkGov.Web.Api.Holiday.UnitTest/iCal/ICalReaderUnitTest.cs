using HkGov.Web.Api.Holiday.Controllers;
using HkGov.Web.Api.Holiday.iCal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace HkGov.Web.Api.Holiday.UnitTest.iCal
{
    public class ICalReaderUnitTest
    {
        private readonly ICalReader calReader;

        public ICalReaderUnitTest()
        {
            calReader = new ICalReader();
        }

        [Theory(DisplayName ="Test for calendar file handling.")]
        [InlineData("http://www.1823.gov.hk/common/ical/en.ics",1)]
        [InlineData("http://www.1823.gov.hk/common/ical/en_wrong.ics", 0)]
        public async Task GetHolidayDateTest(string url, int minRecordCount)
        {
            IEnumerable<Models.Holiday> testData=await calReader.Read(url);
            Assert.NotNull(testData);
            Assert.True(testData.ToArray().Length >= minRecordCount);
        }
    }
}
