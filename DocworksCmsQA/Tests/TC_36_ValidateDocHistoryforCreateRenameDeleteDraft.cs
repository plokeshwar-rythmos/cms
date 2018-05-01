using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using AventStack.ExtentReports;


namespace DocWorksQA.Tests
{
    [TestFixture, Category("DocHistory")]
    [Parallelizable]
    class TC_36_ValidateDocHistoryforCreateRenameDeleteDraft : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;
        private bool projectStatus;

        [OneTimeSetUp]
        public void AddPProjectModule()
        {
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);

        }

        [Test, Description("Verify User is able to view history details in DocHistory module for Create draft")]
        public void TC36A_ValidateDocHistoryforCreateDraft()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                String projectName = CreateDistribution("Mercurial", test, driver);
                AddProjectPage project = new AddProjectPage(test, driver);
                project.ClickDashboard();
                project.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
                createDraft.ClickOnUnityManualNode();
                CreateDraftPage CreateDraft = new CreateDraftPage(test, driver);

                //Creating draft

                CreateDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                CreateDraft.ClickOnBlankDraft();
                CreateDraft.CreateDraft();
                project.ClickNotifications();
                String status2 = project.GetNotificationStatus();
                project.SuccessScreenshot("Blank Draft got Created Successfully");
                VerifyText(test, "creating a draft " + draftName + " in UnityManual is successful", status2, "Draft: " + draftName + " is Created with status:" + status2 + "", "Draft is not created with status: " + status2 + "");
                project.BackToProject();
                Doc_HistoryPage DocHistory = new Doc_HistoryPage(test, driver);
                DocHistory.ClickDoc_History();
                driver.Navigate().Refresh();
                DocHistory.ClickDoc_History();
                project.SuccessScreenshot("Created draft history details loaded Successfully");
                project.BackToProject();

                //Renaming Draft
                DocHistory.ClickLeftCursor();
                DocHistory.ClickAllDrafts();
                DocHistory.RenameDraft(draftName, "draft123");
                DocHistory.ClickOnRightMarkToRename();
                project.ClickNotifications();
                String status3 = project.GetNotificationStatus();
                project.SuccessScreenshot("Draft Renamed Successfully");
                project.BackToProject();
                DocHistory.ClickDoc_History();
                System.Threading.Thread.Sleep(10000);
                project.SuccessScreenshot("Rename draft history details loaded Successfully");
                DocHistory.ClickOnNodeHistoryCloseButton();

                //Deleting Draft

                DocHistory.ClickLeftCursor();
                DocHistory.ClickAllDrafts();
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

        /* [Test, Description("Verify User is able to view history details in DocHistory module for rename draft")]
         public void TC36B_ValidateDocHistoryforRenameDraft()
         {
             try
             {
                 String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                 Console.WriteLine("Starting Test Case : " + TestName);
                 String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                 test = StartTest(TestName, description);
                 String projectName = CreateDistribution("Mercurial", test, driver);
                 AddProjectPage project = new AddProjectPage(test, driver);
                 project.ClickDashboard();
                 project.SearchForProject(projectName);
                 CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                 createDraft.ClickOpenProject();
                 createDraft.ClickOnUnityManualNode();
                 CreateDraftPage CreateDraft = new CreateDraftPage(test, driver);


                 

             }
             catch (Exception ex)
             {
                 ReportExceptionScreenshot(test, driver, ex);
                 Fail(test, ex);
                 UpdateGitLabProjectProperties("Failure");
                 throw;
             }

         }

         [Test, Description("Verify User is able to view history details in DocHistory module for delete draft")]
         public void TC36C_ValidateDocHistoryforCreateRenameDeleteDraft()
         {
             try
             {
                 String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                 Console.WriteLine("Starting Test Case : " + TestName);
                 String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                 test = StartTest(TestName, description);
                 String projectName = CreateDistribution("Mercurial", test, driver);
                 AddProjectPage project = new AddProjectPage(test, driver);
                 project.ClickDashboard();
                 project.SearchForProject(projectName);
                 CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                 createDraft.ClickOpenProject();
                 createDraft.ClickOnUnityManualNode();
                 CreateDraftPage CreateDraft = new CreateDraftPage(test, driver);



                 //Deleting Draft

                 DocHistory.ClickLeftCursor();
                 DocHistory.ClickAllDrafts();


             }
             catch (Exception ex)
             {
                 ReportExceptionScreenshot(test, driver, ex);
                 Fail(test, ex);
                 UpdateGitLabProjectProperties("Failure");
                 throw;
             }

         }
         */
        [OneTimeTearDown]
        public void CloseBrowser()
        {
            Console.WriteLine("Quiting Browser");
            CloseDriver(driver);
        }

    }
}