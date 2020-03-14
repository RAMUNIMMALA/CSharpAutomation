using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using SeleniumSamp.Pages;

namespace SeleniumSamp.Test
{
    [TestFixture]
    class UserTest : SeleniumSamp.Base.BaseTest
    {
        [Test]
        public void validateLoadPage()
        {
            ReportLog.Log(LogStatus.Pass, "Test started");
            HomePage homepage = new HomePage(getDriver);
            Assert.IsTrue(homepage.getTitle().Text == "Become A Full-Stack .Net Developer", "Title not matched");
        }
    }
}
