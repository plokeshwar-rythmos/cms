﻿using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using AventStack.ExtentReports;

namespace DocWorksQA.Tests
{
    [TestFixture, Category("Accept Draft To Live in Authoring screen")]
    [Parallelizable]
    class TC_17_ValidateUserAbleClickOnAcceptToDraftLiveButtonIfBothTheDraftsAreSame : BeforeTestAfterTest
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

        [Test, Description("Verify User Able to Click On the AcceptDraftToLive Button when two Drafts are same")]
        public void TC17_ValidateUserAbleClickOnAcceptToDraftLiveButtonIfBothTheDraftsAreSame()
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
                createDraft.ClickOnBlankDraft();
                createDraft.CreateDraft();
                project.ClickNotifications();
                String status2 = project.GetNotificationStatus();
                project.SuccessScreenshot("Blank Draft got Created Successfully");
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