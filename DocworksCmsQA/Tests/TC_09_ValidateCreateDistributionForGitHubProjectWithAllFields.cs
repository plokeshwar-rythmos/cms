using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using AventStack.ExtentReports;

namespace DocWorksQA.Tests
{
    [TestFixture, Category("Create Distribution")]
    [Parallelizable]
    class TC_09_ValidateCreateDistributionForGitHubProjectWithAllFields : BeforeTestAfterTest
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

        [Test, Description("Verify User is able to add Distribution for the GitHub Project with TOC")]
        public void TC09A_ValidateCreateDistributionForGitHubProjectWithTOC()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                String projectName = CreateGitHubProject(test, driver);
                AddProjectPage project = new AddProjectPage(test, driver);
                project.ClickDashboard();
                project.SearchForProject(projectName);
                CreateDistributionPage distmodule = new CreateDistributionPage(test, driver);
                distmodule.ClickDistribution();
                String distributionName = distmodule.EnterDistirbutionName();
                System.Threading.Thread.Sleep(75000);
                distmodule.SelectBranch("DocWorksManual3");
                distmodule.EnterTocPath();
                distmodule.EnterDescription("This is to create a distribution With TOC Path");
                distmodule.ClickCreateDistribution();
                project.ClickNotifications();
                String status1 = project.GetNotificationStatus();
                SuccessScreenshot(driver, "Distribution got Created successfully With TOC Path", test);
                VerifyText(test, "creating distribution " + distributionName + " in " + projectName + " is successful", status1, "Distribution is Created For GitLab TOC with status:" + status1 + "", "Distribution is not created For GitLab TOC with status: " + status1 + "");
                project.ClickDashboard();
                project.SearchForProject(projectName);
                distmodule.ClickDistribution();
                String actual1 = distmodule.GetDistributionName();
                SuccessScreenshot(driver, "Created Distribution:  " + distributionName + "", test);
                VerifyEquals(test, distributionName, actual1, "Create Distribution for GitLab Project With TOC is successful", "Create Distribution for GitLab Project With TOC is not successful");
                UpdateGitHubProjectProperties("Success");
                distmodule.ClickCloseButton();
            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                UpdateGitHubProjectProperties("Failure");
                throw;
            }

        }


       // [Test, Description("Verify User is able to add Distribution for the GitHub Project without TOC")]
        public void TC09B_ValidateCreateDistributionForGitHubProjectWithOutTOC()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                String projectName = CreateGitHubProject(test, driver);
                AddProjectPage project = new AddProjectPage(test, driver);
                project.ClickDashboard();
                project.SearchForProject(projectName);
                CreateDistributionPage distmodule = new CreateDistributionPage(test, driver);
                distmodule.ClickDistribution();
                String expected2 = distmodule.EnterDistirbutionName();
                System.Threading.Thread.Sleep(75000);
                distmodule.SelectBranch("DocworksManual2");
                distmodule.EnterDescription("This is to create a distribution Without TOC Path");
                distmodule.ClickCreateDistribution();
                project.ClickNotifications();
                String status2 = project.GetNotificationStatus();
                SuccessScreenshot(driver, "Distribution: " + expected2 + " got Created successfully Without TOC Path", test);
                VerifyText(test, "creating distribution " + expected2 + " in " + projectName + " is successful", status2, "Distribution is Created For GitLab Without TOC with status:" + status2 + "", "Distribution is not created For GitLab without TOC with status: " + status2 + "");
                UpdateGitHubProjectProperties("Success");
            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                UpdateGitHubProjectProperties("Failure");
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