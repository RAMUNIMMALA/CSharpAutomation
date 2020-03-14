using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumSamp.Base
{
    public class BasePage
    {
        public IWebDriver driver = null;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
