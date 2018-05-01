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
    class TC_37_ValidateDocHistoryWithActionItems : BeforeTestAfterTest
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

        [Test, Description("Verify User is able to view history details in DocHistory module for Action items")]
        public void TC37_ValidateDocHistoryWithActionItems()
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
                Doc_HistoryPage DocHistory = new Doc_HistoryPage(test, driver);
                DocHistory.ClickDoc_History();
                DocHistory.ClickActions();
                DocHistory.ClickCheckBoxCreateDraft();
                DocHistory.ClickCheckBoxRenameDraft();
                DocHistory.ClickCheckBoxAcceptDraftToLive();
                // DocHistory.ClickEmptySpaceInNodeHistory();
                //DocHistory.ClickActivityTab();
                project.BackToProject();
               // DocHistory.ClickOnNodeHistoryCloseButton();
                DocHistory.ClickSearchButton();
                System.Threading.Thread.Sleep(10000);
                project.SuccessScreenshot("Action details loaded Successfully");

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
