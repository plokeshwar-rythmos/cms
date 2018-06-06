using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using AventStack.ExtentReports;


namespace DocWorksQA.Tests
{
    [TestFixture, Category("DocHistory")]
    [Parallelizable]
    class ValidateSystemLevel : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;
        
        [OneTimeSetUp]
        public void AddPProjectModule()
        {
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);


        }

        [Test, Description("Verify User is able to create taggroup at system level")]
        public void TC42_ValidateSystemLevel()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                String projectName = CreateDistribution("Mercurial", test, driver);
                AddProjectPage project = new AddProjectPage(test, driver);
                project.ClickDashboard();
                TagManagementSystemLevelPage SystemLevel = new TagManagementSystemLevelPage(test, driver);
                SystemLevel.ClickSystemTab();
                SystemLevel.ClickCreateTagGroup();
                SystemLevel.ClickColorPicker();

                Console.WriteLine();
                project.SuccessScreenshot("Action details loaded Successfully by draft name");

            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                UpdateGitLabProjectProperties("Failure");
                throw;
            }

        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            Console.WriteLine("Quiting Browser");
            CloseDriver(driver);
        }

    }
}