﻿using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using System.Text;
using AventStack.ExtentReports;


namespace DocWorksQA.Tests
{

    [TestFixture, Category("Upload CodeBlocks")]
    [Parallelizable]
    class TC_28_ValidateWhenUserSearchesCodeBlockAssetIdInImages : BeforeTestAfterTest
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
       [Test, Description("Verify User is Unable to get the codeBlock when searched with the AssetId of CodeBlock in Images Tab")]
        public void TC_03_ValidateWhenUserSearchesCodeBlockAssetIdInImages()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                String projectName = CreateDistribution("Mercurial", test, driver);
                AddProjectPage project = new AddProjectPage(test, driver);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test, driver);
                auth.ClickMedia();
                auth.ClickCodeBlocksTab();
                String CodeBlockName = auth.UploadCodeBlock();
                project.ClickNotifications();
                String status2 = project.GetNotificationStatus();
                project.SuccessScreenshot("CodeBlock Got Uploaded Successfully");
                VerifyText(test, "upsert asset " + CodeBlockName + " is successful", status2, "CodeBlock: " + CodeBlockName + " is Uploaded with status:" + status2 + "", "CodeBlock is not Uploaded with status: " + status2 + "");
                project.BackToProject();
                project.ClickDashboard();
                project.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
                createDraft.ClickOnUnityManualNode();
                auth.ClickInsertCodeBlock();
                auth.EnterAssetName(CodeBlockName);
                project.SuccessScreenshot("Verifying Uploaded CodeBlocks in search Assets");
                auth.SelectCodeBlockFromUpload(CodeBlockName); 
                auth.ClickInsertImage();
                System.Threading.Thread.Sleep(5000);
                auth.SearchAssetName();
                project.SuccessScreenshot("Verifying the CodeBlock  Url pasted in Images does not show any Uploads");
                auth.CloseUploadPage();
            }
            catch (Exception e)
            {
                ReportExceptionScreenshot(test, driver, e);
                Fail(test, e);
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
