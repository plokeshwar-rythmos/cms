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
    // [TestFixture]
    class TS_02_CreateDistributionModule : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private static string uid = ConfigurationHelper.Get<String>("UserName");
        private static string pwd = ConfigurationHelper.Get<String>("password");

       // [OneTimeSetUp]
        public void CreateDistribution()
        {
            driver = new DriverFactory().Create();
            try
            {
                System.Threading.Thread.Sleep(5000);
                LoginPage login = new LoginPage(driver);
                login.EnterUserName(uid);
                login.EnterPassword(pwd);
                System.Threading.Thread.Sleep(3000);
                login.ClickLogin();
                System.Threading.Thread.Sleep(5000);
                Console.WriteLine(driver.Title);
                String actual = driver.Title;
           //     Assert.IsTrue(VerifyEquals("Unity DocWorks - Dashboard", actual, "Page Title is verified successfully", "Page Title is Not correct"));
            }
            catch (AssertionException ex)
            {
                Fail("Assertion failed");
                throw;
            }
        }

         //[Test, Description("Verify User is able to add Distribution for the GitLab Project with all Fields")]
        public void TC_01_ValidateCreateDistributionForGitLabProjectWithAllFields()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                System.Threading.Thread.Sleep(5000);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickAddProject();
                System.Threading.Thread.Sleep(3000);
                String expected = addProject.EnterProjectTitle();
                System.Threading.Thread.Sleep(5000);
                addProject.ClickContentType();
                System.Threading.Thread.Sleep(5000);
                addProject.ClickSourceControlTypeGitLab();
                System.Threading.Thread.Sleep(25000);
                addProject.ClickRepository();
                System.Threading.Thread.Sleep(5000);
                addProject.EnterPublishedPath("Publishing path to create project");
                System.Threading.Thread.Sleep(5000);
                addProject.EnterDescription("This is to create Project");
                System.Threading.Thread.Sleep(5000);
                addProject.ClickCreateProject();
                System.Threading.Thread.Sleep(25000);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(5000);
                String status = addProject.GetNotificationStatus();
                String projectDetails = addProject.GetCreatedProject();
                String path = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path, "Project Created Successfully");
                Assert.IsTrue(VerifyText("Success", status, "Project is Created with status:" + status + "", "Project is not created with status: " + status + ""));
                addProject.BackToProject();
                System.Threading.Thread.Sleep(15000);
                CreateDistributionPage distmodule = new CreateDistributionPage(driver);
                System.Threading.Thread.Sleep(3000);
                distmodule.SearchForProject(expected);
                System.Threading.Thread.Sleep(3000);
                distmodule.ClickDistribution();
                System.Threading.Thread.Sleep(8000);
                String expected1 = distmodule.EnterDistirbutionName();
                System.Threading.Thread.Sleep(85000);
                distmodule.ClickBranchWithTOC();
                System.Threading.Thread.Sleep(5000);
                distmodule.EnterTocPath();
                distmodule.EnterDescription("This is to create a distribution");
                System.Threading.Thread.Sleep(5000);
                distmodule.ClickCreateDistribution();
                System.Threading.Thread.Sleep(40000);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(15000);
                String status1 = addProject.GetNotificationStatus();
                String path1 = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path1, "Distribution got Created successfully With TOC Path");
                Assert.IsTrue(VerifyText("Success", status1, "Distribution is Created For GitLab TOC with status:" + status1 + "", "Distribution is not created For GitLab TOC with status: " + status1 + ""));
                addProject.BackToProject();
                System.Threading.Thread.Sleep(5000);
                distmodule.ClickDistribution();
                System.Threading.Thread.Sleep(18000);
                String actual = distmodule.GetDistributionName();
                String path2 = TakeScreenshot(driver);
                distmodule.SuccessScreenshot(path2, "Created Distribution:  "+expected1+"");
                Assert.IsTrue(VerifyEquals(expected1, actual, "Create Distribution for GitLab Project With TOC is successful", "Create Distribution for GitLab Project With TOC is not successful"));
                System.Threading.Thread.Sleep(8000);
                String expected2 = distmodule.EnterDistirbutionName();
                System.Threading.Thread.Sleep(85000);
                distmodule.ClickBranchWithOutTOC();
                System.Threading.Thread.Sleep(5000);
                distmodule.EnterDescription("This is to create a distribution");
                System.Threading.Thread.Sleep(5000);
                distmodule.ClickCreateDistribution();
                System.Threading.Thread.Sleep(40000);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(15000);
                String status2 = addProject.GetNotificationStatus();
                String path3 = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path3, "Distribution: "+expected2+" got Created successfully Without TOC Path");
                Assert.IsTrue(VerifyText("Success", status2, "Distribution is Created For GitLab Without TOC with status:" + status2 + "", "Distribution is not created For GitLab without TOC with status: " + status2 + ""));
                addProject.BackToProject();
                System.Threading.Thread.Sleep(5000);

            }
            catch (AssertionException)
            {
                Fail("Assertion failed");
                throw;
            }

        }

         //[Test, Description("Verify User is able to add Distribution for the GitHub Project with all Fields")]
        public void TC_02_ValidateCreateDistributionForGitHubProjectWithAllFields()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                System.Threading.Thread.Sleep(5000);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickAddProject();
                System.Threading.Thread.Sleep(3000);
                String expected = addProject.EnterProjectTitle();
                System.Threading.Thread.Sleep(5000);
                addProject.ClickContentType();
                System.Threading.Thread.Sleep(15000);
                addProject.ClickSourceControlTypeGitHub();
                System.Threading.Thread.Sleep(15000);
                addProject.ClickRepository();
                System.Threading.Thread.Sleep(5000);
                addProject.EnterPublishedPath("Publishing path to create project");
                System.Threading.Thread.Sleep(5000);
                addProject.EnterDescription("This is to create Project");
                System.Threading.Thread.Sleep(5000);
                addProject.ClickCreateProject();
                System.Threading.Thread.Sleep(25000);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(5000);
                String status = addProject.GetNotificationStatus();
                String projectDetails = addProject.GetCreatedProject();
                String path = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path, "GitHub Project is Created");
                Assert.IsTrue(VerifyText("Success", status, "GitHub Project is Created with status:" + status + "", "GitHub Project is not created with status: " + status + ""));
                addProject.BackToProject();
                System.Threading.Thread.Sleep(15000);
                CreateDistributionPage distmodule = new CreateDistributionPage(driver);
                System.Threading.Thread.Sleep(3000);
                distmodule.SearchForProject(expected);
                System.Threading.Thread.Sleep(3000);
                distmodule.ClickDistribution();
                System.Threading.Thread.Sleep(8000);
                String expected1 = distmodule.EnterDistirbutionName();
                System.Threading.Thread.Sleep(85000);
                distmodule.ClickBranchForGitHub();
                System.Threading.Thread.Sleep(5000);
                distmodule.EnterTocPath();
                distmodule.EnterDescription("This is to create a distribution");
                System.Threading.Thread.Sleep(5000);
                distmodule.ClickCreateDistribution();
                System.Threading.Thread.Sleep(40000);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(15000);
                String status1 = addProject.GetNotificationStatus();
                String path1 = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path1, "Distribution: "+expected1+"got Created successfully For GITHUB Project with TOC");
                Assert.IsTrue(VerifyText("Success", status1, "Distribution is Created for github With TOC Path with status:" + status1 + "", "Distribution is not created with status: " + status1 + ""));
                addProject.BackToProject();
                System.Threading.Thread.Sleep(5000);
                distmodule.ClickDistribution();
                System.Threading.Thread.Sleep(18000);
                String actual = distmodule.GetDistributionName();
                String path2 = TakeScreenshot(driver);
                distmodule.SuccessScreenshot(path1, "Created Distribution for GITHUB With TOC");
                Assert.IsTrue(VerifyEquals(expected1, actual, "Create Distribution for GitHub Project  with TOC is successful", "Create Distribution for GitHub Project is not successful"));
                System.Threading.Thread.Sleep(8000);
                String expected2 = distmodule.EnterDistirbutionName();
                System.Threading.Thread.Sleep(65000);
                distmodule.ClickBranchWithOutTOC();
                System.Threading.Thread.Sleep(5000);
                distmodule.EnterDescription("This is to create a distribution");
                System.Threading.Thread.Sleep(5000);
                distmodule.ClickCreateDistribution();
                System.Threading.Thread.Sleep(40000);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(15000);
                String status2 = addProject.GetNotificationStatus();
                String path3 = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path3, "Distribution: "+expected2+" got Created successfully Without TOC Path");
                Assert.IsTrue(VerifyText("Success", status2, "Distribution is Created For GitLab Without TOC with status:" + status2 + "", "Distribution is not created For GitLab without TOC with status: " + status2 + ""));
                addProject.BackToProject();
                System.Threading.Thread.Sleep(5000);

            }
            catch (AssertionException)
            {
                Fail("Assertion failed");
                throw;
            }

        }

         //[Test, Description("Verify User is able to add Distribution for the Mercurial Project with all Fields")]
        public void TC_03_ValidateCreateDistributionForMercurialProjectWithAllFields()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                System.Threading.Thread.Sleep(5000);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickAddProject();
                System.Threading.Thread.Sleep(3000);
                String expected = addProject.EnterProjectTitle();
                System.Threading.Thread.Sleep(5000);
                addProject.ClickContentType();
                System.Threading.Thread.Sleep(15000);
                addProject.ClickSourceControlTypeOno();
                System.Threading.Thread.Sleep(8000);
                addProject.EnterMercurialRepoPath();
                System.Threading.Thread.Sleep(5000);
                addProject.EnterPublishedPath("Publishing path to create project");
                System.Threading.Thread.Sleep(5000);
                addProject.EnterDescription("This is to create Project");
                System.Threading.Thread.Sleep(5000);
                addProject.ClickCreateProject();
                System.Threading.Thread.Sleep(25000);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(5000);
                String status = addProject.GetNotificationStatus();
                String projectDetails = addProject.GetCreatedProject();
                String path = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path, "Mercurial Project Created Successfully");
                Assert.IsTrue(VerifyText("Success", status, "Mercurial Project is Created with status:" + status + "", "Mercurial Project is not created with status: " + status + ""));
                addProject.BackToProject();
                System.Threading.Thread.Sleep(15000);
                CreateDistributionPage distmodule = new CreateDistributionPage(driver);
                System.Threading.Thread.Sleep(3000);
                distmodule.SearchForProject(expected);
                System.Threading.Thread.Sleep(3000);
                distmodule.ClickDistribution();
                System.Threading.Thread.Sleep(8000);
                String expected1 = distmodule.EnterDistirbutionName();
                System.Threading.Thread.Sleep(7000);
                distmodule.EnterBranchForMercurial();
                System.Threading.Thread.Sleep(5000);
                distmodule.EnterTocPath();
                distmodule.EnterDescription("This is to create a distribution");
                System.Threading.Thread.Sleep(5000);
                distmodule.ClickCreateDistribution();
                System.Threading.Thread.Sleep(40000);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(15000);
                String status1 = addProject.GetNotificationStatus();
                String path1 = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path1, "Distribution: "+expected1+" got Created successfully With TOC");
                Assert.IsTrue(VerifyText("Success", status1, "Distribution is Created For mercurial With TOC with status:" + status1 + "", "Distribution is not created with status: " + status1 + ""));
                addProject.BackToProject();
                System.Threading.Thread.Sleep(5000);
                distmodule.ClickDistribution();
                System.Threading.Thread.Sleep(18000);
                String actual = distmodule.GetDistributionName();
                String path2 = TakeScreenshot(driver);
                distmodule.SuccessScreenshot(path1, "Created Distribution");
                Assert.IsTrue(VerifyEquals(expected1, actual, "Create Distribution for Mercurial Project With TOC path is successful", "Create Distribution for Mercurial Project is not successful"));
                System.Threading.Thread.Sleep(8000);
                String expected2= distmodule.EnterDistirbutionName();
                System.Threading.Thread.Sleep(7000);
                distmodule.EnterBranchWithoutTOCForMercurial();
                System.Threading.Thread.Sleep(5000);
                distmodule.EnterDescription("This is to create a distribution");
                System.Threading.Thread.Sleep(5000);
                distmodule.ClickCreateDistribution();
                System.Threading.Thread.Sleep(40000);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(15000);
                String status2 = addProject.GetNotificationStatus();
                String path3 = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path3, "Distribution: "+expected2+" got Created successfully Without TOC");
                Assert.IsTrue(VerifyText("Success", status2, "Distribution is Created For mercurial Without TOC with status:" + status2 + "", "Distribution is not created with status: " + status2 + ""));
                addProject.BackToProject();
                System.Threading.Thread.Sleep(3000);

            }
            catch (AssertionException)
            {
                Fail("Assertion failed");
                throw;
            }

        }
         //[Test, Description("Verify User is able to Add Distribution to a Project of Empty TOC With Mandatory Fields")]
        public void TC_04_ValidateAddDistributionsForProjectOfEmptyTOCAndMandatoryFields()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickAddProject();
                System.Threading.Thread.Sleep(3000);
                String expected = addProject.EnterProjectTitle();
                System.Threading.Thread.Sleep(5000);
                addProject.ClickContentType();
                System.Threading.Thread.Sleep(15000);
                addProject.ClickSourceControlTypeGitLab();
                System.Threading.Thread.Sleep(5000);
                addProject.ClickRepository();
                System.Threading.Thread.Sleep(5000);
                addProject.EnterPublishedPath("Publishing path to create project");
                System.Threading.Thread.Sleep(5000);
                addProject.EnterDescription("This is to create Project");
                System.Threading.Thread.Sleep(5000);
                addProject.ClickCreateProject();
                System.Threading.Thread.Sleep(25000);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(5000);
                String status = addProject.GetNotificationStatus();
                String projectDetails = addProject.GetCreatedProject();
                String path = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path, "Project Created Successfully");
                Assert.IsTrue(VerifyText("Success", status, "Project is Created with status:" + status + "", "Project is not created with status: " + status + ""));
                addProject.BackToProject();
                System.Threading.Thread.Sleep(15000);
                CreateDistributionPage distmodule = new CreateDistributionPage(driver);
                System.Threading.Thread.Sleep(3000);
                distmodule.SearchForProject(expected);
                System.Threading.Thread.Sleep(5000);
                distmodule.ClickDistribution();
                System.Threading.Thread.Sleep(8000);
                String expected1 = distmodule.EnterDistirbutionName();
                System.Threading.Thread.Sleep(57000);
                distmodule.ClickBranchWithOutTOC();
                System.Threading.Thread.Sleep(5000);
                distmodule.ClickCreateDistribution();
                System.Threading.Thread.Sleep(35000);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(15000);
                String status1 = addProject.GetNotificationStatus();
                String path1 = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path1, "Distribution got Created successfully");
                Assert.IsTrue(VerifyText("Success", status1, "Distribution is Created with status:" + status1 + "", "Distribution is not created with status: " + status1 + ""));
                addProject.BackToProject();
                System.Threading.Thread.Sleep(5000);
                distmodule.ClickDistribution();
                System.Threading.Thread.Sleep(18000);
                String actual = distmodule.GetDistributionName();
                String path2 = TakeScreenshot(driver);
                distmodule.SuccessScreenshot(path1, "Created Distribution");
                Assert.IsTrue(VerifyEquals(expected1, actual, "Create Distribution for Project WithOut TOC is successful", "Create Distribution for Project Without TOC is not successful"));
                distmodule.ClickCloseButton();
                System.Threading.Thread.Sleep(5000);
            }
            catch (AssertionException)
            {
                Fail("Assertion failed");
                throw;
            }

        }

         //[Test, Description("Verify When User sends an Invalid Length to Distribution Name Then it throws an Error Message")]
        public void TC_05_ValidateDistributionNamelengthWithLessThan5Characters()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
               CreateTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickAddProject();
                System.Threading.Thread.Sleep(3000);
                String expected = addProject.EnterProjectTitle();
                System.Threading.Thread.Sleep(5000);
                addProject.ClickContentType();
                System.Threading.Thread.Sleep(15000);
                addProject.ClickSourceControlTypeGitLab();
                System.Threading.Thread.Sleep(5000);
                addProject.ClickRepository();
                System.Threading.Thread.Sleep(5000);
                addProject.EnterPublishedPath("Publishing path to create project");
                System.Threading.Thread.Sleep(5000);
                addProject.EnterDescription("This is to create Project");
                System.Threading.Thread.Sleep(5000);
                addProject.ClickCreateProject();
                System.Threading.Thread.Sleep(25000);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(5000);
                String status = addProject.GetNotificationStatus();
                String projectDetails = addProject.GetCreatedProject();
                String path = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path, "Project Created Successfully");
                Assert.IsTrue(VerifyText("Success", status, "Project is Created with status:" + status + "", "Project is not created with status: " + status + ""));
                addProject.BackToProject();
                System.Threading.Thread.Sleep(15000);
                CreateDistributionPage distmodule = new CreateDistributionPage(driver);
                System.Threading.Thread.Sleep(3000);
                distmodule.SearchForProject(expected);
                System.Threading.Thread.Sleep(5000);
                distmodule.ClickDistribution();
                String expected1 = "Please enter at least 5 characters.";
                distmodule.EnterInvalidnNameLength();
                System.Threading.Thread.Sleep(7000);
                distmodule.EnterDescription("Description");
                String actual = distmodule.GetText(distmodule.INVALID_TITLE_LENGTH);
                String path1 = TakeScreenshot(driver);
                distmodule.SuccessScreenshot(path1, "Validating Distribution Name Length");
                System.Threading.Thread.Sleep(7000);
                Assert.IsTrue(VerifyEquals(expected1, actual, "Validation of Length Constraints for Distribution Name Field is successful", "Validation of Length Constraints for Distribution Name Field is Not successful"));
                distmodule.ClickCloseButton();
                System.Threading.Thread.Sleep(5000);
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
