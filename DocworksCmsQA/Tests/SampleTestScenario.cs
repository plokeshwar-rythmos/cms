using DocWorksQA.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocworksCmsQA.Tests
{
    [TestFixture]
    class SampleTestScenario : BeforeTestAfterTest
    {

        [OneTimeSetUp]
        public void Setup() {
            Console.WriteLine("Test Setup");
          Info("Test Setup");

        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Console.WriteLine("Test TearDown");
            Info("Test Teardown");
        }

        [Test, Description("")]
        public void Test1()
        {
            Console.WriteLine("Test Case");
            Info("Test Case");
            Fail(new WebDriverException("Something Went Wrong"));
        }



    }
}
