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
    class TC_10_ValidateCreateDistributionForMercurialProjectWithAllFields : BeforeTestAfterTest
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

        [Test, Description("Verify User is able to add Distribution for the GitHub Project with all Fields")]
        public void TC10_ValidateCreateDistributionForMercurialProjectWithAllFields()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.ClickAddProject();
                String expected = addProject.EnterProjectTitle();
                addProject.SelectContentType("Manual");
                addProject.SelectSourceControlProviderType("Ono");
                addProject.EnterMercurialRepoPath();
                addProject.EnterPublishedPath("Publishing path to create project");
                addProject.EnterDescription("This is to create Project");
                addProject.ClickCreateProject();
                addProject.ClickNotifications();
                String status = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Project Created Title");
                VerifyText(test, "creating a project " + expected + " is successful", status, "Project Created Successfully", "Project is not created with status: " + status + "");
                addProject.ClickDashboard();
                addProject.SearchForProject(expected);
                String actual = addProject.GetProjectTitle();
                addProject.SuccessScreenshot("ProjectTitle");
                VerifyEquals(test, expected, actual, "Created Project Found on Dashboard.", "Created Project Not Available on Dashboard.");
                CreateDistributionPage distmodule = new CreateDistributionPage(test, driver);
                distmodule.ClickDistribution();
                String expected1 = distmodule.EnterDistirbutionName();
                System.Threading.Thread.Sleep(5000);
                distmodule.EnterBranchForMercurial("DocworksManual3");
                distmodule.EnterTocPath();
                distmodule.EnterDescription("This is to create a distribution With TOC");
                distmodule.ClickCreateDistribution();
                addProject.ClickNotifications();
                String status1 = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Distribution got Created successfully With TOC Path");
                VerifyText(test, "creating distribution " + expected1 + " in " + expected + " is successful", status1, "Distribution is Created For Mercurial TOC with status:" + status1 + "", "Distribution is not created For Mercurial TOC with status: " + status1 + "");
                addProject.ClickDashboard();
                addProject.SearchForProject(expected);
                distmodule.ClickDistribution();
                String actual1 = distmodule.GetDistributionName();
                addProject.SuccessScreenshot("Created Distribution:  " + expected1 + "");
                VerifyEquals(test, expected1, actual1, "Create Distribution for Mercurial Project With TOC is successful", "Create Distribution for Mercurial Project With TOC is not successful");
                String expected2 = distmodule.EnterDistirbutionName();
                System.Threading.Thread.Sleep(5000);
                distmodule.EnterBranchWithoutTOCForMercurial("DocworkManual2");
                distmodule.EnterDescription("This is to create a distribution Without TOC");
                distmodule.ClickCreateDistribution();
                addProject.ClickNotifications();
                String status2 = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Distribution: " + expected2 + " got Created successfully Without TOC Path");
                VerifyText(test, "creating distribution " + expected2 + " in " + expected + " is successful", status2, "Distribution is Created For Mercurial Without TOC with status:" + status2 + "", "Distribution is not created For Mercurial without TOC with status: " + status2 + "");
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

