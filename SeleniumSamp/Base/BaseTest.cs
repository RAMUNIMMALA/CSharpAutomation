using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Configuration;

namespace SeleniumSamp.Base
{
    [TestFixture]
    class BaseTest
    {
        private static ExtentReports extentReport= null;
        private static ExtentTest extentTest = null;
        private static IWebDriver driver = null;

        //string appDirectory = null;
        //string projectPath = null;

        public static ExtentTest ReportLog
        {
            get { return extentTest; }
        }

        public static IWebDriver getDriver
        {
            get { return driver; }
        }

        public string getProjectPath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.IndexOf("\\bin"));
            }
        }

        //triggered before every suite execution
        [OneTimeSetUp]
        public void oneTimeSetUp()
        {
            Console.WriteLine("ONE TIME SETUP Execution");
            //string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            //string projectPath = appDirectory.Substring(0, appDirectory.IndexOf("\\bin"));
            FileStream file = File.Create(getProjectPath + "\\Reports\\extent_"+DateTime.Now.ToString("ddMMyyy_hhmmss")+".html");
            extentReport = new ExtentReports(file.Name, DisplayOrder.NewestFirst);
            //load test data
            //load properities data
            //report objection creation
        }

        //triggered after every suite execution
        [OneTimeTearDown]
        public void oneTimeTearDown()
        {
            Console.WriteLine("ONE TIME TEAR DOWN Execution");
            extentReport.Flush();
            //close/flush report object
            //update testcase matrics
        }

         //triggered before every test
        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("SETUP Execution");
            extentTest = extentReport.StartTest(TestContext.CurrentContext.Test.Name);
            //driver initialization
            initializeDriver();
            //add test to report
        }

        //triggered after every test
        [TearDown]
        public void TearDown()
        {
            Console.WriteLine(TestContext.CurrentContext.Result.Outcome);
            Console.WriteLine("Test Name: "+TestContext.CurrentContext.Test.Name);
            Console.WriteLine("Test FullName: " + TestContext.CurrentContext.Test.FullName);
            Console.WriteLine("TEAR DOWN Execution");
            if(driver != null)
            {
                driver.Quit();
            }
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                extentTest.Log(LogStatus.Fail, "Test failed");
            } else if(TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                extentTest.Log(LogStatus.Pass, "Test passed");
            }
            //driver clean up
            //update test status of test in the report
        }

        private void initializeDriver()
        {
            ReportLog.Log(LogStatus.Pass, "Initializing driver");
            driver = new ChromeDriver(getProjectPath);
            ReportLog.Log(LogStatus.Pass, "Maximing driver");
            driver.Manage().Window.Maximize();
            ReportLog.Log(LogStatus.Pass, "Launching application url : " + Convert.ToString(ConfigurationManager.AppSettings["appULR"]));
            driver.Navigate().GoToUrl(Convert.ToString(ConfigurationManager.AppSettings["appULR"]));
            
        }

    }
}
