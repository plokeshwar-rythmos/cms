using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using AventStack.ExtentReports;

namespace DocWorksQA.Tests
{
    [TestFixture, Category("Create Draft")]
    [Parallelizable]
    class TC_12_ValidateNewDraftDialogBoxAndErrorMsgForInvalidDrafts : BeforeTestAfterTest
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

        [Test, Description("Verify New Draft Button is enabled or not")]

        public void TC_01_ValidateNewDraftDialogBoxIsAppearedOrNot()
        {

            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.ClickAddProject();
                String expected = addProject.EnterProjectTitle();
                addProject.SelectContentType("Manual");
                addProject.SelectSourceControlProviderType("GitLab");
                addProject.SelectRepository("Docworks");
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
                System.Threading.Thread.Sleep(75000);
                distmodule.SelectBrach("DocworksManual3");
                distmodule.EnterTocPath();
                distmodule.EnterDescription("This is to create a distribution With TOC Path");
                distmodule.ClickCreateDistribution();
                addProject.ClickNotifications();
                String status1 = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Distribution got Created successfully With TOC Path");
                VerifyText(test, "creating distribution " + expected1 + " in " + expected + " is successful", status1, "Distribution is Created For GitLab TOC with status:" + status1 + "", "Distribution is not created For GitLab TOC with status: " + status1 + "");
                addProject.ClickDashboard();
                addProject.SearchForProject("SELENIUM_QI");
                CreateDraftPage createDraft = new CreateDraftPage(test,driver);
                createDraft.CLICKOPENPROJECT();
                createDraft.ClickOnUnityManualNode();
                createDraft.ClickNewDraft();
                Boolean flag = createDraft.IsDraftPopUpEnabled();
                addProject.SuccessScreenshot("Draft Dialog Box Is appeared on screen");
                VerifyBoolean(test,true, flag, "Draft Dialog Box got Opened Successfully", "Draft Dialog Box is not Opened Successfully");
                createDraft.CLOSEDRAFT();
            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                throw;
            }
        }
        [Test, Description("Verify When User Enters Invalid Draft Name Then an error message is apeared")]
        public void TC_02_ValidateErrorMesgForInvalidDraftName()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickNewDraft();
                String expected2 = "Please enter at least 5 characters.";
                createDraft.EnterInvalidnNameLength();
                String actual2 = createDraft.GetErrorText(createDraft.DRAFTNAMEERROR);
                addProject.SuccessScreenshot("Validating Draft Name Length");
                VerifyEquals(test,expected2, actual2, "Validation Of Length Constraints for Draft Name Field is successful", "Validation of Length Constraints for Draft Name Field is not successful");
                createDraft.CLOSEDRAFT();
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
