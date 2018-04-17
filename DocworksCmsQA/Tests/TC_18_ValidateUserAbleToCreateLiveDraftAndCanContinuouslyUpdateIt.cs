using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using AventStack.ExtentReports;

namespace DocWorksQA.Tests
{
    [TestFixture, Category("Accept Draft To Live in Authoring screen")]
    [Parallelizable]
    class TC_18_ValidateUserAbleToCreateLiveDraftAndCanContinuouslyUpdateIt : BeforeTestAfterTest
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

        [Test, Description("Verify User Able to Validate Live Draft and Continuous Update Of Live Draft")]
        public void TC18A_ValidateUserAbleToCreateLiveDraftAndCanContinuouslyUpdateIt()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                String projectName = CreateDistribution("Mercurial", test, driver);
                AddProjectPage project = new AddProjectPage(test, driver);
                project.ClickDashboard();
                project.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
                createDraft.ClickOnUnityManualNode();
                createDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                createDraft.SelectCoderDraft();
                project.SuccessScreenshot("Creating an Existing Draft");
                createDraft.CreateDraft();
                project.ClickNotifications();
                String status2 = project.GetNotificationStatus();
                project.SuccessScreenshot("Draft: " + draftName + " got Created Successfully");
                VerifyText(test, "creating a draft " + draftName + " in UnityManual is successful", status2, "Draft: " + draftName + " is Created with status:" + status2 + "", "Draft is not created with status: " + status2 + "");
                project.BackToProject();
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test, driver);
                auth.LeftDraftDropDown(draftName);
                auth.RightDraftDropDown(draftName);
                auth.ClickAcceptDraftToLive();
                project.ClickNotifications();
                String status = project.GetNotificationStatus();
                project.SuccessScreenshot("Accept Draft To live of Draft: " + draftName + " got Created Successfully");
                VerifyText(test, "accept draft " + draftName + " to live is successful", status, "Draft: " + draftName + " is Accepted to Live with status:" + status + "", "Draft is not Accepted to Live with status: " + status + "");
                project.BackToProject();
                auth.LeftLiveDraft();
                auth.MDLeftTab();
                auth.RightLiveDraft();
                auth.MDRightTab();
                project.SuccessScreenshot("Validating a Live Draft in both Editor Panes with some content");
                createDraft.ClickNewDraft();
                String draftName1 = createDraft.EnterValidDraftName();
                createDraft.ClickOnBlankDraft();
                createDraft.CreateDraft();
                project.ClickNotifications();
                String status3 = project.GetNotificationStatus();
                project.SuccessScreenshot("Draft: " + draftName1 + " got Created Successfully");
                VerifyText(test, "creating a draft " + draftName1 + " in UnityManual is successful", status3, "Draft: " + draftName + " is Created with status:" + status3 + "", "Draft is not created with status: " + status3 + "");
                project.BackToProject();
                auth.LeftDraftDropDown(draftName1);
                auth.RightDraftDropDown(draftName1);
                auth.ClickAcceptDraftToLive();
                project.ClickNotifications();
                String status1 = project.GetNotificationStatus();
                project.SuccessScreenshot("Accept Draft To live of Draft: " + draftName + " got Created Successfully");
                VerifyText(test, "accept draft " + draftName + " to live is successful", status1, "Draft: " + draftName + " is Accepted to Live with status:" + status1 + "", "Draft is not Accepted to Live with status: " + status1 + "");
                project.BackToProject();
                auth.LeftLiveDraft();
                auth.MDLeftTab();
                auth.RightLiveDraft();
                auth.MDRightTab();
                project.SuccessScreenshot("Validating Updated Live Draft in both Editor Panes with blank message");
            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                throw;
            }
        }

        [Test, Description("Verify User Able To View Gdoc Content When selected Live or Coder Draft ")]
        public void TC18B_ValidateUserAbleToSeeGdocTabWithaMessageWhenSelectedLiveOrCoderDrafts()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test,driver);
                auth.LeftLiveDraft();
                auth.GdocLeftTab();
                auth.RightLiveDraft();
                auth.GdocRightTab();
                AddProjectPage project = new AddProjectPage(test, driver);
                project.SuccessScreenshot("GDoc Message when selected Live Draft");
                auth.LeftCoderDraft();
                auth.RightCoderDraft();
                project.SuccessScreenshot("GDoc Message when selected Coder Draft");
            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                throw;
            }

        }

        [Test, Description("Verify When User selects Existing Live Drafts to Live the AcceptDraftToLive Button is disabled")]
        public void TC18C_ValidateAcceptDraftToLiveButtonIsDisabledWhenUserSelectsExistingLiveDraftsToLive()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test,driver);
                auth.LeftLiveDraft();
                auth.RightLiveDraft();
                Boolean flag = auth.IsAcceptDraftToLiveButtonEnabled();
                Console.WriteLine("Flag is " + flag);
                AddProjectPage project = new AddProjectPage(test, driver);
                project.SuccessScreenshot("Verifying Accept Draft To Live Button Is Enabled or Disabled ");
                VerifyBoolean(test, false, flag, "Accept Draft to Live buttom is disabled", "Accept Draft to Live Button is enabled");
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
