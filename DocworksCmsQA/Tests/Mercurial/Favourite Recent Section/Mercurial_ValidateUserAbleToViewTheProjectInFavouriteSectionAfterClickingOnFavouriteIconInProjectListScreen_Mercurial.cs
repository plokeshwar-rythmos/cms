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
    [TestFixture, Category("Favourite Section")]
    [Parallelizable]
    class Mercurial_ValidateUserAbleToViewTheProjectInFavouriteSectionAfterClickingOnFavouriteIconInProjectListScreen_Mercurial : BeforeTestAfterTest
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


        [Test, Description("Validate user able to view the project in favourite section after clicking on favourite icon in Project List Screen")]
        public void TC42_ValidateUserAbleToViewTheProjectInFavouriteSectionAfterClickingOnFavouriteIconInProjectListScreen()
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
                addProject.ClickFavouriteIcon();
                System.Threading.Thread.Sleep(6000);
                addProject.SuccessScreenshot("Project moved to favourite section");


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
