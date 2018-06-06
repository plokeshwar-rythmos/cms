﻿using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using AventStack.ExtentReports;


namespace DocWorksQA.Tests
{
    [TestFixture, Category("DocHistory")]
    [Parallelizable]
    class TC_39_ValidateDocHistoryForAcceptDraftToLive : BeforeTestAfterTest
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

        [Test, Description("Verify User is able to view history details in DocHistory module for Create,rename,delete draft")]
        public void TC39_ValidateDocHistoryForAcceptDraftToLive()
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
                /*createDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                createDraft.ClickOnBlankDraft();
                createDraft.CreateDraft();
                project.ClickNotifications();
                String status2 = project.GetNotificationStatus();
                project.SuccessScreenshot("Blank Draft got Created Successfully");
                VerifyText(test, "creating a draft " + draftName + " in UnityManual is successful", status2, "Draft: " + draftName + " is Created with status:" + status2 + "", "Draft is not created with status: " + status2 + "");
                project.BackToProject();*/
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test, driver);
                auth.LeftDraftDropDown("draft123");
                auth.RightDraftDropDown("draft123");
                auth.ClickAcceptDraftToLive();
                project.ClickNotifications();
                String status = project.GetNotificationStatus();
                project.SuccessScreenshot("Accept Draft To live of Draft got Created Successfully");
                project.BackToProject();
                Doc_HistoryPage DocHistory = new Doc_HistoryPage(test, driver);
                DocHistory.ClickDoc_History();
                System.Threading.Thread.Sleep(10000);
                project.SuccessScreenshot("Accept Draft To Live history details loaded Successfully");
                DocHistory.ClickOnNodeHistoryCloseButton();

            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                UpdateGitLabProjectProperties("Failure");
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