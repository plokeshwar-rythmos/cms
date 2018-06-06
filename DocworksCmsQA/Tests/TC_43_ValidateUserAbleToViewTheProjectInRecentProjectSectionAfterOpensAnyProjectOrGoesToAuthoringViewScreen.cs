using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.SeleniumHelpers;
using System;
using DocWorksQA.Pages;
using System.Diagnostics;
using AventStack.ExtentReports;
using System.Collections.Generic;

namespace DocWorksQA.Tests
{
    [TestFixture, Category("Recent Projects Section")]
    [Parallelizable]
    class TC_43_ValidateUserAbleToViewTheProjectInRecentProjectSectionAfterOpensAnyProjectOrGoesToAuthoringViewScreen : BeforeTestAfterTest
    {
        private IWebDriver driver;
        private ExtentTest test;
        
        [OneTimeSetUp]
        public void AddPProjectModule()
        {
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);
        }


        [Test, Description("Validate user able to view the project in recent project section after opens any project or goes to authoring view screen")]
        public void TC43_ValidateUserAbleToViewTheProjectInRecentProjectSectionAfterOpensAnyProjectOrGoesToAuthoringViewScreen()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.ClickAddProject();
                String projectName = addProject.EnterProjectTitle();
                addProject.SelectContentType("Manual");
                addProject.SelectSourceControlProviderType("Ono");
                addProject.EnterMercurialRepoPath();
                addProject.EnterPublishedPath("Publishing path to create project");
                addProject.EnterDescription("This is to create Project");
                addProject.ClickCreateProject();
                addProject.ClickNotifications();
                String status = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Project Created Title");
                VerifyText(test, "creating a project " + projectName + " is successful", status, "Project Created Successfully", "Project is not created with status: " + status + "");
                addProject.BackToProject();
                addProject.ClickDashboard();
                addProject.SearchForProject(projectName);
                CreateDistributionPage distribution = new CreateDistributionPage(test, driver);
                distribution.ClickDistribution();
                String expected1 = distribution.EnterDistirbutionName();
                System.Threading.Thread.Sleep(5000);
                distribution.EnterBranchForMercurial("DocworksManual3");
                distribution.EnterTocPath();
                distribution.EnterDescription("This is to create a distribution With TOC");
                distribution.ClickCreateDistribution();
                addProject.ClickNotifications();
                String status1 = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Distribution got Created successfully With TOC Path");
                VerifyText(test, "creating distribution " + expected1 + " in " + projectName + " is successful", status1, "Distribution is Created For Mercurial TOC with status:" + status1 + "", "Distribution is not created For Mercurial TOC with status: " + status1 + "");
                addProject.ClickDashboard();
                addProject.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
                createDraft.ClickOnUnityManualNode();
                addProject.ClickOnAuthoring();
                System.Threading.Thread.Sleep(25000);
                addProject.SuccessScreenshot("Project moved to Recent Projects Section");

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
