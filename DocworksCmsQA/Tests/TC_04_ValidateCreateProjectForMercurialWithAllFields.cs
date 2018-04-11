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
    [TestFixture, Category("Create Project")]
    [Parallelizable]
    class TC_04_ValidateCreateProjectForMercurialWithAllFields : BeforeTestAfterTest
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



        [Test, Description("Verifying User is able to Add Project For Mercurial with all Fields")]
        public void TC04_ValidateCreateProjectForMercurialWithAllFields()
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

                addProject.ClickDashboard();

                addProject.SearchForProject(projectName);
                String actual = addProject.GetProjectTitle();
                addProject.SuccessScreenshot("ProjectTitle");
                VerifyEquals(test, projectName, actual, "Created Project Found on Dashboard.", "Created Project Not Available on Dashboard.");

                var map = new Dictionary<string, string>();
                map.Add("projectName", projectName);
                map.Add("projectStatus", "Success");
                map.Add("distributionStatus", "");
                CreateFile(GetCurrentProjectPath() + "//bin/onoProject.properties", map);

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
