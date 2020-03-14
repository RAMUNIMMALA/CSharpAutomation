using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SeleniumSamp.Base;
using System.Configuration;

namespace SeleniumSamp
{
    [TestFixture]
    class SampleTest : BaseTest
    {
        [OneTimeSetUp]
        public void oneTimeSetUp()
        {
            Console.WriteLine("ONE TIME SETUP Execution in TEST");
        }

        [OneTimeTearDown]
        public void oneTimeTearDown()
        {
            Console.WriteLine("ONE TIME TEAR DOWN Execution in TEST");
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine("ENVIRONMENT: " + ConfigurationManager.AppSettings["env"]);
            Console.WriteLine("Executing test - 1");
        }

        [Test]
        public void Test2()
        {
            Console.WriteLine("Executing test - 2");
        }
    }
}
