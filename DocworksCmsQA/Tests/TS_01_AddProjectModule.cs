using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.SeleniumHelpers;
using System;
using DocWorksQA.Pages;
using System.Diagnostics;

namespace DocWorksQA.Tests
{
    [TestFixture, Category("Create Project")]
    class TS_01_AddProjectModule : BeforeTestAfterTest
    {
        private IWebDriver driver;


        [OneTimeSetUp]
        public void AddPProjectModule() {
            driver = new DriverFactory().Create();
            SetDriver(driver);
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);
        }

        [Test, Description("Verifying Add Project Button Is Enabled Or Not")]
        public void TC_01_ValidateAddProjectButtonsIsEnabled()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                AddProjectPage addproject = new AddProjectPage(driver);
                Boolean flag = addproject.IsProjectEnable();
                addproject.SuccessScreenshot("Add Project is enabled");
                Assert.IsTrue(VerifyTrue(flag, "Create Project Button is Enabled", "Create Project Button is not Enabled"));
            }
            catch (Exception ex) {
                ReportExceptionScreenshot(driver, ex);
                Fail(ex);
                throw;
            }
        }

       [Test, Description("Verifying User is able to Add Project For GitLab  with all Fields")]
        public void TC_02_ValidateCreateProjectForGitLabWithAllFields()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(driver);
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
                Fail(e);
                throw;
            }

        }

       [Test, Description("Verifying User is able to Add Project For GitHub  with all Fields")]
        public void TC_03_ValidateCreateProjectForGitHubWithAllFields()
        {
            try
            {

                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);

                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickAddProject();
                String expected = addProject.EnterProjectTitle();
                addProject.ClickContentType();
                addProject.ClickSourceControlTypeGitHub();
                System.Threading.Thread.Sleep(15000);
                addProject.ClickRepository();
                addProject.EnterPublishedPath("Publishing path to create project");
                addProject.EnterDescription("This is to create Project");
                addProject.ClickCreateProject();

                addProject.ClickNotifications();



                String status = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Project Created Title");

                VerifyText("creating a project " + expected + " is successful", status, "Project Created Successfully", "Project is not created with status: " + status + "");

                addProject.ClickDashboard();

                addProject.SearchForProject(expected);
                String actual = addProject.GetProjectTitle();
                addProject.SuccessScreenshot("ProjectTitle");
                VerifyEquals(expected, actual, "Created Project Found on Dashboard.", "Created Project Not Available on Dashboard.");
            }
            catch (Exception e)
            {
                ReportExceptionScreenshot(driver, e);
                Fail(e);
                throw;
            }

        }

      [Test, Description("Verifying User is able to Add Project For Mercurial with all Fields")]
        public void TC_04_ValidateCreateProjectForMercurialWithAllFields()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);

                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickAddProject();
                String expected = addProject.EnterProjectTitle();
                addProject.ClickContentType();
                addProject.ClickSourceControlTypeOno();
                System.Threading.Thread.Sleep(8000);
                addProject.EnterMercurialRepoPath();
                addProject.EnterPublishedPath("Publishing path to create project");
                addProject.EnterDescription("This is to create Project");
                addProject.ClickCreateProject();

                addProject.ClickNotifications();

                String status = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Project Created Title");

                VerifyText("creating a project " + expected + " is successful", status, "Project Created Successfully", "Project is not created with status: " + status + "");

                addProject.ClickDashboard();

                addProject.SearchForProject(expected);
                String actual = addProject.GetProjectTitle();
                addProject.SuccessScreenshot("ProjectTitle");
                VerifyEquals(expected, actual, "Created Project Found on Dashboard.", "Created Project Not Available on Dashboard.");
            }
            catch (Exception e)
            {
                ReportExceptionScreenshot(driver, e);
                Fail(e);
                throw;
            }

        }

      [Test, Description("Verifying User is able to Add Project For GitLab with Mandatory Fields")]
        public void TC_05_ValidateAddingProjectForGitLabWithMandatoryFields()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);

                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickAddProject();
                String expected = addProject.EnterProjectTitle();
                addProject.ClickContentType();
                addProject.ClickSourceControlTypeGitLab();
                System.Threading.Thread.Sleep(13000);
                addProject.ClickRepository();
                addProject.EnterPublishedPath("Publishing path to create project");
                addProject.ClickCreateProject();
                addProject.ClickNotifications();

                String status = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Project Created Title");

                VerifyText("creating a project " + expected + " is successful", status, "Project Created Successfully", "Project is not created with status: " + status + "");

                addProject.ClickDashboard();

                addProject.SearchForProject(expected);
                String actual = addProject.GetProjectTitle();
                addProject.SuccessScreenshot("ProjectTitle");
                VerifyEquals(expected, actual, "Created Project Found on Dashboard.", "Created Project Not Available on Dashboard.");
            }
            catch (Exception e)
            {
                ReportExceptionScreenshot(driver, e);
                Fail(e);
                throw;
            }

        }


      [Test, Description("Verify Project Title throws an error message When User gives Invalid Length")]
        public void TC_06_ValidateProjectTitleLengthWithLessThan5Characters()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);

                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                Trace.TraceInformation("");
                CreateTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickDashboard();
                System.Threading.Thread.Sleep(3000);
                addProject.ClickAddProject();
                addProject.ProjectTitleInvalidLength();
                String expected = "Please enter at least 5 characters";
                addProject.ClickContentType();
                String actual = addProject.GetText(addProject.INVALID_TITLE_LENGTH);

                addProject.SuccessScreenshot("Validating Length of the Title");
                VerifyEquals(expected, actual, "Validation Got Successful", "Validation Got Failed");
            }
            catch (Exception e)
            {
                ReportExceptionScreenshot(driver, e);
                Fail(e);
                throw;
            }

        }

        [Test, Description("Verifying Whether User is able to send More Than 100 characters to the Project Title")]
        public void TC_07_ValidateProjectTitleLengthWithMoreThan100Characters()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);

                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickDashboard();
                System.Threading.Thread.Sleep(3000);
                addProject.ClickAddProject();
                addProject.ProjectLengthMoreThan100();
                addProject.ClickContentType();

                addProject.SuccessScreenshot("Length of the Title exceeded its limit");

                String str = addProject.GetTitleLength();
                VerifyEquals("100/100", str, "Length Of Project Title got exceeded to its limit as " + str + "", "Length Of Project Title Not got exceeded to its limit as " + str + "");
                
            }
            catch (Exception e)
            {
                ReportExceptionScreenshot(driver, e);
                Fail(e);
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
