using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.SeleniumHelpers;
using System;
using DocWorksQA.Pages;
using System.Diagnostics;
using AventStack.ExtentReports;

namespace DocWorksQA.Tests
{
    [TestFixture, Category("Create Project")]
    [Parallelizable]
    class TC_02_ValidateCreateProjectForGitLabWithAllFields : BeforeTestAfterTest
    {
        private IWebDriver driver;
        private ExtentTest test;


        [OneTimeSetUp]
        public void AddPProjectModule() {
            driver = new DriverFactory().Create();
            SetDriver(driver);
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);
        }

       
       [Test, Description("Verifying User is able to Add Project For GitLab  with all Fields")]
        public void TC02_ValidateCreateProjectForGitLabWithAllFields()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.ClickAddProject();
                String expected = addProject.EnterProjectTitle();
                addProject.ClickContentType();
                addProject.ClickSourceControlTypeGitLab();
                System.Threading.Thread.Sleep(15000);
                addProject.ClickRepository();
                addProject.EnterPublishedPath("Publishing path to create project");
                addProject.EnterDescription("This is to create Project");
                addProject.ClickCreateProject();
                addProject.ClickNotifications();

                String status = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Project Created Title");

                VerifyText("creating a project "+expected+ " is successful", status, "Project Created Successfully", "Project is not created with status: " + status + "");

                addProject.ClickDashboard();

                addProject.SearchForProject(expected);
                String actual = addProject.GetProjectTitle();
                addProject.SuccessScreenshot("ProjectTitle");
                VerifyEquals(expected, actual, "Created Project Found on Dashboard.", "Created Project Not Available on Dashboard.");
            }
            catch (Exception e)
            {
                ReportExceptionScreenshot(driver, e);
                Fail(test, e);
                throw;
            }

        }

       
      
        [OneTimeTearDown]
        public void CloseBrowser()
        {
            Console.WriteLine("Quiting Browser");

            CloseDriver();
         }

       
    }

}
