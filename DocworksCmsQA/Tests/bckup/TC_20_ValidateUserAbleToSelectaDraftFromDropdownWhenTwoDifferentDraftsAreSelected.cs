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
    class TC_20_ValidateUserAbleToSelectaDraftFromDropdownWhenTwoDifferentDraftsAreSelected : BeforeTestAfterTest
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

        [Test, Description("Verify User is able to select a Draft from Dropdown when two different Drafts are selected for AcceptDraftToLive")]
        public void TC20A_ValidateUserAbleToSelectaDraftFromDropdownWhenClickedAcceptDraftToLiveButton()
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
                auth.ClickAcceptDraftToLive();
                project.SuccessScreenshot("DropDown Appears in Accept Draft to live When two different drafts are selected");
                auth.SelectDraftFromAcceptDraftToLiveDropDown();
                project.ClickNotifications();
                String status = project.GetNotificationStatus();
                project.SuccessScreenshot("Accept Draft To live of Draft: " + draftName + " got Created Successfully");
                VerifyText(test, "accept draft " + draftName + " to live is successful", status, "Draft: " + draftName + " is Accepted to Live with status:" + status + "", "Draft is not Accepted to Live with status: " + status + "");
                project.BackToProject();
                auth.LeftLiveDraft();
                auth.MDLeftTab();
                project.SuccessScreenshot("Content In the Live Draft");

            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                throw;
            }

        }

       [Test, Description("Verify User is Unable to create a Draft with Same Name of Existing Draft")]
        public void TC20B_ValidateUserIsUnableToCreateDuplicateDrafts()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                AddProjectPage project = new AddProjectPage(test, driver);
                createDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                createDraft.CreateDraft();
                project.ClickNotifications();
                String status2 = project.GetNotificationStatus();
                project.SuccessScreenshot("Draft: " + draftName + " got Created Successfully");
                VerifyText(test, "creating a draft " + draftName + " in UnityManual is successful", status2, "Draft: " + draftName + " is Created with status:" + status2 + "", "Draft is not created with status: " + status2 + "");
                project.BackToProject();
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test,driver);
                auth.LeftDraftDropDown(draftName);
                createDraft.ClickNewDraft();
                createDraft.EnterDraftName(draftName);
                createDraft.ClickOnBlankDraft();
                project.SuccessScreenshot("Unable To Create a Draft Named " + draftName + " with Blank Message");

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
