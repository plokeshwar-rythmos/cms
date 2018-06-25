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
    class TC_29_ValidateUserIsAbleToReplaceCodeBlock : BeforeTestAfterTest
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
       [Test, Description("Verify User Is able to Replace the code blocks in media screen")]
        public void TC29_ValidateUserIsAbleToReplaceCodeBlock()
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
                createDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                createDraft.ClickOnBlankDraft();
                project.SuccessScreenshot("Creating Blank Draft: " + draftName + "");
                createDraft.CreateDraft();
                project.ClickNotifications();
                String status3 = project.GetNotificationStatus();
                project.SuccessScreenshot("Blank Draft got Created Successfully");
                VerifyText(test, "creating a draft " + draftName + " in UnityManual is successful", status3, "Draft: " + draftName + " is Created with status:" + status3 + "", "Draft is not created with status: " + status3 + "");
                project.BackToProject();
                auth.LeftDraftDropDown(draftName);
                IWebElement framel = auth.EnterIntoLeftFrame();
                driver.SwitchTo().Frame(framel);
                System.Threading.Thread.Sleep(5000);
                driver.SwitchTo().ActiveElement();
                auth.ClickGdocLeft();
                driver.SwitchTo().ActiveElement().SendKeys(Keys.Control + "v");
                project.SuccessScreenshot("pasting the CodeBlock Url in Gdoc");
                driver.SwitchTo().DefaultContent();
                auth.PreviewLeftTab();
                project.SuccessScreenshot("Verifying the CodeBlock got reflected in Preview Left");
                auth.GdocLeftTab();
                auth.ClickInsertCodeBlock();
                auth.EnterAssetName(CodeBlockName);
                auth.ReplaceCodeBlocks();
                project.SuccessScreenshot("Verifying the CodeBlock got replaced with new CodeBlock");
                auth.SelectCodeBlockFromUpload(CodeBlockName);
                auth.LeftDraftDropDown(draftName);
                project.SuccessScreenshot("The same CodeBlock AssetId in Gdoc Which was added earlier");
                driver.SwitchTo().DefaultContent();
                auth.PreviewLeftTab();
                project.SuccessScreenshot("Verifying the CodeBlock got replaced successfully in Preview Left");
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