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
    class ValidateDocHistoryBySelectingDate_GitLab : BeforeTestAfterTest
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

        [Test, Description("Verify User is able to view history details in DocHistory module")]
        public void ValidateDocHistoryBySelectingDate()
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
                System.Threading.Thread.Sleep(6000);
                DocHistory.ChooseDate();
                DocHistory.ClickSearchButton();
                System.Threading.Thread.Sleep(20000);
                project.SuccessScreenshot("Action details loaded Successfully for selected date");
                project.BackToProject();

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

