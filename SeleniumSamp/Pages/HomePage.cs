using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumSamp.Base;
using RelevantCodes.ExtentReports;

namespace SeleniumSamp.Pages
{
    public class HomePage : Base.BasePage
    {

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        By byTitle = By.XPath("//div[@class='header-type']//dnd");

        public IWebElement getTitle()
        {
            BaseTest.ReportLog.Log(LogStatus.Pass, "Getting page title");
            IWebElement element = driver.FindElement(byTitle);
            BaseTest.ReportLog.Log(LogStatus.Pass, "Page title is: " + element.Text);
            return element;
        }
    }
}
