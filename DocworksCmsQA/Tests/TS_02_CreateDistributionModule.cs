using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using DocWorksQA.Utilities;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using DocWorksQA.TestRailApis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocWorksQA.Tests
{
    [TestFixture, Category("Create Distribution")]
    class TS_02_CreateDistributionModule : BeforeTestAfterTest
    {
        private static IWebDriver driver;

        [OneTimeSetUp]
        public void AddPProjectModule()
        {
            driver = new DriverFactory().Create();
            SetDriver(driver);
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);
        }

        [Test, Description("Verify User is able to add Distribution for the GitLab Project with all Fields")]
        public void TC_01_ValidateCreateDistributionForGitLabProjectWithAllFields()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickAddProject();
                String expected = addProject.EnterProjectTitle();
                addProject.ClickContentType();
                addProject.ClickSourceControlTypeGitLab();
                System.Threading.Thread.Sleep(15000);
                addProject.ClickRepository();
                addProject.EnterPublishedPath("Publishing path to create project");
                addProject.EnterDescription("This is to create Project");
                addProject.ClickCreateProject();
                addProject.ClickNotifications();
                String status = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Project Created Title");
                VerifyText("creating a project " + expected + " is successful", status, "Project Created Successfully", "Project is not created with status: " + status + "");
                addProject.ClickDashboard();
                addProject.SearchForProject(expected);
                String actual = addProject.GetProjectTitle();
                addProject.SuccessScreenshot("ProjectTitle");
                VerifyEquals(expected, actual, "Created Project Found on Dashboard.", "Created Project Not Available on Dashboard.");
                CreateDistributionPage distmodule = new CreateDistributionPage(driver);
                distmodule.ClickDistribution();
                String expected1 = distmodule.EnterDistirbutionName();
                System.Threading.Thread.Sleep(75000);
                distmodule.ClickBranchWithTOC();
                distmodule.EnterTocPath();
                distmodule.EnterDescription("This is to create a distribution");
                distmodule.ClickCreateDistribution();
                addProject.ClickNotifications();
                String status1 = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Distribution got Created successfully With TOC Path");
                VerifyText("creating distribution " + expected1 +" in " + expected + " is successful", status1, "Distribution is Created For GitLab TOC with status:" + status1 + "", "Distribution is not created For GitLab TOC with status: " + status1 + "");
                addProject.ClickDashboard();
                addProject.SearchForProject(expected);
                distmodule.ClickDistribution();
                String actual1 = distmodule.GetDistributionName();
                addProject.SuccessScreenshot("Created Distribution:  "+expected1+"");
                VerifyEquals(expected1, actual1, "Create Distribution for GitLab Project With TOC is successful", "Create Distribution for GitLab Project With TOC is not successful");
                String expected2 = distmodule.EnterDistirbutionName();
                System.Threading.Thread.Sleep(75000);
                distmodule.ClickBranchWithOutTOC();
                distmodule.EnterDescription("This is to create a distribution");
                distmodule.ClickCreateDistribution();
                addProject.ClickNotifications();
                String status2 = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Distribution: "+expected2+" got Created successfully Without TOC Path");
                VerifyText("creating distribution " + expected2 + " in " + expected + " is successful", status2, "Distribution is Created For GitLab Without TOC with status:" + status2 + "", "Distribution is not created For GitLab without TOC with status: " + status2 + "");
                addProject.ClickDashboard();
            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(driver, ex);
                Fail(ex);
                throw;
            }

        }

         [Test, Description("Verify User is able to add Distribution for the GitHub Project with all Fields")]
        public void TC_02_ValidateCreateDistributionForGitHubProjectWithAllFields()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickAddProject();
                String expected = addProject.EnterProjectTitle();
                addProject.ClickContentType();
                addProject.ClickSourceControlTypeGitHub();
                System.Threading.Thread.Sleep(15000);
                addProject.ClickRepository();
                addProject.EnterPublishedPath("Publishing path to create project");
                addProject.EnterDescription("This is to create Project");
                addProject.ClickCreateProject();
                addProject.ClickNotifications();
                String status = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Project Created Title");
                VerifyText("creating a project " + expected + " is successful", status, "Project Created Successfully", "Project is not created with status: " + status + "");
                addProject.ClickDashboard();
                addProject.SearchForProject(expected);
                String actual = addProject.GetProjectTitle();
                addProject.SuccessScreenshot("ProjectTitle");
                VerifyEquals(expected, actual, "Created Project Found on Dashboard.", "Created Project Not Available on Dashboard.");
                CreateDistributionPage distmodule = new CreateDistributionPage(driver);
                distmodule.ClickDistribution();
                String expected1 = distmodule.EnterDistirbutionName();
                System.Threading.Thread.Sleep(75000);
                distmodule.ClickBranchForGitHub();
                distmodule.EnterTocPath();
                distmodule.EnterDescription("This is to create a distribution");
                distmodule.ClickCreateDistribution();
                addProject.ClickNotifications();
                String status1 = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Distribution got Created successfully With TOC Path");
                VerifyText("creating distribution " + expected1 + " in " + expected + " is successful", status1, "Distribution is Created For GitHub TOC with status:" + status1 + "", "Distribution is not created For GitHub TOC with status: " + status1 + "");
                addProject.ClickDashboard();
                addProject.SearchForProject(expected);
                distmodule.ClickDistribution();
                String actual1 = distmodule.GetDistributionName();
                addProject.SuccessScreenshot("Created Distribution:  " + expected1 + "");
                VerifyEquals(expected1, actual1, "Create Distribution for GitHub Project With TOC is successful", "Create Distribution for GitHub Project With TOC is not successful");
                String expected2 = distmodule.EnterDistirbutionName();
                System.Threading.Thread.Sleep(75000);
                distmodule.ClickBranchWithOutTOC();
                distmodule.EnterDescription("This is to create a distribution");
                distmodule.ClickCreateDistribution();
                addProject.ClickNotifications();
                String status2 = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Distribution: " + expected2 + " got Created successfully Without TOC Path");
                VerifyText("creating distribution " + expected2 + " in " + expected + " is successful", status2, "Distribution is Created For GitHub Without TOC with status:" + status2 + "", "Distribution is not created For GitHub without TOC with status: " + status2 + "");
                addProject.ClickDashboard();
            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(driver, ex);
                Fail(ex);
                throw;
            }

        }

         [Test, Description("Verify User is able to add Distribution for the Mercurial Project with all Fields")]
        public void TC_03_ValidateCreateDistributionForMercurialProjectWithAllFields()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickAddProject();
                String expected = addProject.EnterProjectTitle();
                addProject.ClickContentType();
                System.Threading.Thread.Sleep(15000);
                addProject.ClickSourceControlTypeOno();
                addProject.EnterMercurialRepoPath();
                addProject.EnterPublishedPath("Publishing path to create project");
                addProject.EnterDescription("This is to create Project");
                addProject.ClickCreateProject();
                addProject.ClickNotifications();
                String status = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Project Created Title");
                VerifyText("creating a project " + expected + " is successful", status, "Project Created Successfully", "Project is not created with status: " + status + "");
                addProject.ClickDashboard();
                addProject.SearchForProject(expected);
                String actual = addProject.GetProjectTitle();
                addProject.SuccessScreenshot("ProjectTitle");
                VerifyEquals(expected, actual, "Created Project Found on Dashboard.", "Created Project Not Available on Dashboard.");
                CreateDistributionPage distmodule = new CreateDistributionPage(driver);
                distmodule.ClickDistribution();
                String expected1 = distmodule.EnterDistirbutionName();
                distmodule.EnterBranchForMercurial();
                distmodule.EnterTocPath();
                distmodule.EnterDescription("This is to create a distribution");
                distmodule.ClickCreateDistribution();
                addProject.ClickNotifications();
                String status1 = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Distribution got Created successfully With TOC Path");
                VerifyText("creating distribution " + expected1 + " in " + expected + " is successful", status1, "Distribution is Created For Mercurial With TOC with status:" + status1 + "", "Distribution is not created For Mercurial With TOC as status: " + status1 + "");
                addProject.ClickDashboard();
                addProject.SearchForProject(expected);
                distmodule.ClickDistribution();
                String actual1 = distmodule.GetDistributionName();
                addProject.SuccessScreenshot("Created Distribution: "+actual1+"");
                VerifyEquals(expected1, actual, "Create Distribution for Mercurial Project With TOC path is successful", "Create Distribution for Mercurial Project is not successful");
                String expected2= distmodule.EnterDistirbutionName();
                distmodule.EnterBranchWithoutTOCForMercurial();
                distmodule.EnterDescription("This is to create a distribution");
                distmodule.ClickCreateDistribution();
                addProject.ClickNotifications();
                String status2 = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Distribution: "+expected2+" got Created successfully Without TOC");
                VerifyText("creating distribution " + expected2 + " in " + expected + " is successful", status2, "Distribution is Created For mercurial Without TOC with status:" + status2 + "", "Distribution is not created with status: " + status2 + "");
                addProject.ClickDashboard();
            }

            catch (Exception ex)
            {
                ReportExceptionScreenshot(driver, ex);
                Fail(ex);
                throw;
            }

        }
        
        [Test, Description("Verify When User sends an Invalid Length to Distribution Name Then it throws an Error Message")]
        public void TC_04_ValidateDistributionNamelengthWithLessThan5Characters()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                 CreateTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickAddProject();
                String expected = addProject.EnterProjectTitle();
                addProject.ClickContentType();
                addProject.ClickSourceControlTypeGitLab();
                System.Threading.Thread.Sleep(15000);
                addProject.ClickRepository();
                addProject.EnterPublishedPath("Publishing path to create project");
                addProject.EnterDescription("This is to create Project");
                addProject.ClickCreateProject();
                addProject.ClickNotifications();
                String status = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Project Created Title");
                VerifyText("creating a project " + expected + " is successful", status, "Project Created Successfully", "Project is not created with status: " + status + "");
                addProject.ClickDashboard();
                addProject.SearchForProject(expected);
                String actual = addProject.GetProjectTitle();
                addProject.SuccessScreenshot("ProjectTitle");
                VerifyEquals(expected, actual, "Created Project Found on Dashboard.", "Created Project Not Available on Dashboard.");
                CreateDistributionPage distmodule = new CreateDistributionPage(driver);
                distmodule.ClickDistribution();
                String expected1 = "Please enter at least 5 characters.";
                distmodule.EnterInvalidnNameLength();
                distmodule.EnterDescription("Description");
                String actual1 = distmodule.GetText(distmodule.INVALID_TITLE_LENGTH);
                addProject.SuccessScreenshot("Validating Distribution Name Length");
                Assert.IsTrue(VerifyEquals(expected1, actual1, "Validation of Length Constraints for Distribution Name Field is successful", "Validation of Length Constraints for Distribution Name Field is Not successful"));
                addProject.ClickDashboard();
            }
            catch (AssertionException)
            {
                Fail("Assertion failed");
                throw;
            }
        }

        [OneTimeTearDown]

        public void CloseBrowser()
        {
            driver.Quit();
        }

    }
}
