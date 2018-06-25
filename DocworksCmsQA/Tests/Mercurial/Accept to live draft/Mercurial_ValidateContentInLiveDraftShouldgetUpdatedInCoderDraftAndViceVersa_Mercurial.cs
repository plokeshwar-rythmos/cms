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
    class Mercurial_ValidateContentInLiveDraftShouldgetUpdatedInCoderDraftAndViceVersa_Mercurial : BeforeTestAfterTest
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

        [Test, Description("Verify User able to view Updated Content of Live Draft in Coder Draft and vice-versa")]

        public void ValidateContentInLiveDraftShouldUpdateInCoderDraft()
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
                project.SuccessScreenshot("Content in Live Draft Before Update");
                auth.LeftCoderDraft();
                auth.MDLeftTab();
                project.SuccessScreenshot("Content in Coder Draft Before Update");
                createDraft.ClickNewDraft();
                String draftName1 = createDraft.EnterValidDraftName();
               // createDraft.ClickOnBlankDraft();
                createDraft.CreateDraft();
                project.ClickNotifications();
                String status1 = project.GetNotificationStatus();
                project.SuccessScreenshot("Draft: " + draftName1 + " got Created Successfully");
                VerifyText(test, "creating a draft " + draftName1 + " in UnityManual is successful", status1, "Draft: " + draftName1 + " is Created with status:" + status1 + "", "Draft is not created with status: " + status1 + "");
                project.BackToProject();
                auth.LeftDraftDropDown(draftName1);
                auth.GdocLeftTab();
                IWebElement framel = auth.EnterIntoLeftFrame();
                driver.SwitchTo().Frame(framel);
                System.Threading.Thread.Sleep(5000);
                driver.SwitchTo().ActiveElement();
                auth.ClickGdocLeft();
                driver.SwitchTo().ActiveElement().SendKeys("SELENIUM_TEST_123");
                driver.SwitchTo().DefaultContent();
                auth.RightDraftDropDown(draftName1);
                auth.ClickAcceptDraftToLive();
                project.ClickNotifications();
                String status3 = project.GetNotificationStatus();
                project.SuccessScreenshot("Accept Draft To live of Draft: " + draftName1 + " got Created Successfully");
                VerifyText(test, "accept draft " + draftName1 + " to live is successful", status3, "Draft: " + draftName1 + " is Accepted to Live with status:" + status3 + "", "Draft is not Accepted to Live with status: " + status3 + "");
                project.BackToProject();
                auth.LeftLiveDraft();
                auth.MDLeftTab();
                project.SuccessScreenshot("Content in Live Draft after Update");
                auth.LeftCoderDraft();
                project.SuccessScreenshot("Content in Coder Draft after Update");

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
