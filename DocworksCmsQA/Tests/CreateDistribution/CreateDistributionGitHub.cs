using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using AventStack.ExtentReports;
using DocworksCmsQA.DockworksApi;

namespace DocWorksQA.Tests
{
    [TestFixture, Category("Create Distribution")]
    [Parallelizable]
    class CreateDistributionGitHub : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;
        String projectName;


        [OneTimeSetUp]
        public void AddPProjectModule()
        {
            projectName = new CreateProjects().CreateGitHubProject();
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);
        }

       [Test, Order(1), Description("Verify User is able to add Distribution for the GitHub Project with TOC")]
        public void TC09A_ValidateCreateDistributionForGitHubProjectWithTOC()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage project = new AddProjectPage(test, driver);
               // project.ClickDashboard();
                project.SearchForProject(projectName);
                CreateDistributionPage distmodule = new CreateDistributionPage(test, driver);
                distmodule.ClickDistribution();
                String distributionName = distmodule.EnterDistirbutionName();
                distmodule.SelectBranch("DocWorksManual3");
                distmodule.EnterTocPath();
                //distmodule.EnterDescription("This is to create a distribution With TOC Path");
                distmodule.ClickCreateDistribution();
                project.ClickNotifications();
                String status1 = project.GetNotificationStatus();
                project.SuccessScreenshot(project.NOTIFICATION_MESSAGE, "Distribution got Created successfully With TOC Path");
                VerifyText(test, "creating distribution " + distributionName + " in " + projectName + " is successful", status1, "Distribution is Created For GitLab TOC with status:" + status1 + "", "Distribution is not created For GitLab TOC with status: " + status1 + "");
             }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                throw;
            }

        }


        [Test, Order(2) ,Description("Verify User is able to add Distribution for the GitHub Project without TOC")]
        public void TC09B_ValidateCreateDistributionForGitHubProjectWithOutTOC()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage project = new AddProjectPage(test, driver);
                project.ClickDashboard();
                project.SearchForProject(projectName);
                CreateDistributionPage distmodule = new CreateDistributionPage(test, driver);
                distmodule.ClickDistribution();
                String expected2 = distmodule.EnterDistirbutionName();
                //distmodule.EnterDescription("This is to create a distribution Without TOC Path");
                distmodule.SelectBranch("DocworksManual2");
                distmodule.ClickCreateDistribution();
                project.ClickNotifications();
                String status2 = project.GetNotificationStatus();
                project.SuccessScreenshot(project.NOTIFICATION_MESSAGE, "Distribution: " + expected2 + " got Created successfully Without TOC Path");
                VerifyText(test, "creating distribution " + expected2 + " in " + projectName + " is successful", status2, "Distribution is Created For GitLab Without TOC with status:" + status2 + "", "Distribution is not created For GitLab without TOC with status: " + status2 + "");
            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
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