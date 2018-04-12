﻿using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using AventStack.ExtentReports;

namespace DocWorksQA.Tests
{
    [TestFixture, Category("Create Draft")]
    [Parallelizable]
    class TC_13_ValidationOfCreateDraftsOfExistingAndBlankWithValidDraftNames : BeforeTestAfterTest
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
        [Test, Description("Verify User is able to create a Blank Draft")]
        public void TC13A_ValidationOfBlankDraftWithValidDraftName()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                String projectName = CreateDistribution("Mercurial", test, driver);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
                createDraft.ClickOnUnityManualNode();
                createDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                createDraft.ClickOnBlankDraft();
                addProject.SuccessScreenshot("Creating a Blank Draft");
                createDraft.CreateDraft();
                addProject.ClickNotifications();
                String status2 = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Blank Draft got Created Successfully");
                VerifyText(test,"creating a draft " + draftName + " in UnityManual is successful", status2, "Draft: " + draftName + " is Created with status:" + status2 + "", "Draft is not created with status: " + status2 + "");
                addProject.BackToProject();
                createDraft.ClickNewDraft();
                String str = "Duplicate Draft Name";
                createDraft.EnterDraftName(draftName);
                addProject.SuccessScreenshot("Error Message While Creating Duplicate Draft");
                String actual2 = addProject.GetText(addProject.INVALID_TITLE_LENGTH);
                VerifyEquals(test,str, actual2, "Duplicate Draft: " + draftName + " is Unable to Create", "Duplicate Draft " + draftName + " is created");
                createDraft.CloseDraft();

            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                throw;
            }
        }

        [Test, Description("Verify User is able to create a Existing draft")]
        public void TC13B_ValidationOfExistingDraftWithValidDraftName()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                createDraft.SelectCoderDraft();
                addProject.SuccessScreenshot("Creating Existing Draft");
                createDraft.CreateDraft();
                addProject.ClickNotifications();
                String status2 = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Draft got Created Successfully");
                VerifyText(test,"creating a draft " + draftName + " in UnityManual is successful", status2, "Draft: " + draftName + " is Created with status:" + status2 + "", "Draft is not created with status: " + status2 + "");
                addProject.BackToProject();
                createDraft.ClickNewDraft();
                String str = "Duplicate Draft Name";
                createDraft.EnterDraftName(draftName);
                addProject.SuccessScreenshot("Error Message While Creating Duplicate Draft");
                String actual2 = addProject.GetText(addProject.INVALID_TITLE_LENGTH);
               VerifyEquals(test,str, actual2, "Duplicate Draft: " + draftName + " is Unable to Create", "Duplicate Draft " + draftName + " is created");
                createDraft.CloseDraft();
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