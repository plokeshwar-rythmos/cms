using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using DocWorksQA.SeleniumHelpers;
using DocWorksQA.TestRailApis;
using System;
using DocWorksQA.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocWorksQA.Pages;
using System.Diagnostics;

namespace DocWorksQA.Tests
{
    [TestFixture, Category("Create Project")]
    class TS_01_AddProjectModule: BeforeTestAfterTest
    {
        private static IWebDriver driver;
      
        [OneTimeSetUp]
        public void AddPProjectModule() {
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);
        }

        [Test, Description("Verifying Add Project Button Is Enabled Or Not")]
        public void TC_01_ValidateAddProjectButtonsIsEnabled()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Debug.WriteLine("Starting Test Case : "+TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                AddProjectPage addproject = new AddProjectPage(driver);

                Boolean flag = addproject.IsProjectEnable();

                String path = TakeScreenshot(driver);
                addproject.SuccessScreenshot(path, "Add Project is enabled");
                Assert.IsTrue(VerifyBoolean(true,flag,"Create Project Button is Enabled","Create Project Button is not Enabled"));
                System.Threading.Thread.Sleep(15000);
            }
            catch (Exception e)
            {
                fail(e.StackTrace);
                throw;
            }
        }

        [Test, Description("Verifying User is able to Add Project For GitLab  with all Fields")]
        public void TC_02_ValidateCreateProjectForGitLabWithAllFields()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickAddProject();
                System.Threading.Thread.Sleep(3000);
                String expected = addProject.EnterProjectTitle();
                System.Threading.Thread.Sleep(5000);
                addProject.ClickContentType();
                System.Threading.Thread.Sleep(15000);
                addProject.ClickSourceControlTypeGitLab();
                System.Threading.Thread.Sleep(15000);
                addProject.ClickRepository();
                System.Threading.Thread.Sleep(5000);
                addProject.EnterPublishedPath("Publishing path to create project");
                System.Threading.Thread.Sleep(5000);
                addProject.EnterDescription("This is to create Project");
                System.Threading.Thread.Sleep(5000);
                addProject.ClickCreateProject();
                System.Threading.Thread.Sleep(25000);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(5000);
                String status = addProject.GetNotificationStatus();
                String projectDetails = addProject.GetCreatedProject();
                String path = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path, "Project Created Title");
                Assert.IsTrue(VerifyText("Success", status, "Project is Created with status:" + status + "", "Project is not created with status: " + status + ""));
                addProject.BackToProject();
                System.Threading.Thread.Sleep(15000);
                CreateDistributionPage distmodule = new CreateDistributionPage(driver);
                System.Threading.Thread.Sleep(3000);
                distmodule.SearchForProject(expected);
                System.Threading.Thread.Sleep(3000);
                String actual = distmodule.getProjectTitle();
                String path1 = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path1, "ProjectTitle");
                Assert.IsTrue(VerifyEquals(expected, actual, "GitLab Project Got created Successfully","GitLab Project Not Created Succesfully"));
            }
            catch (Exception e)
            {
                fail(e.StackTrace);
                throw;
            }

        }

       [Test, Description("Verifying User is able to Add Project For GitHub  with all Fields")]
        public void TC_03_ValidateCreateProjectForGitHubWithAllFields()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickAddProject();
                System.Threading.Thread.Sleep(3000);
                String expected = addProject.EnterProjectTitle();
                System.Threading.Thread.Sleep(5000);
                addProject.ClickContentType();
                System.Threading.Thread.Sleep(15000);
                addProject.ClickSourceControlTypeGitHub();
                System.Threading.Thread.Sleep(15000);
                addProject.ClickRepository();
                System.Threading.Thread.Sleep(5000);
                addProject.EnterPublishedPath("Publishing path to create project");
                System.Threading.Thread.Sleep(5000);
                addProject.EnterDescription("This is to create Project");
                System.Threading.Thread.Sleep(5000);
                addProject.ClickCreateProject();
                System.Threading.Thread.Sleep(25000);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(5000);
                String status = addProject.GetNotificationStatus();
                String projectDetails = addProject.GetCreatedProject();
                String path = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path, "Project Created Title");
                Assert.IsTrue(VerifyText("Success", status, "Project is Created with status:" + status + "", "Project is not created with status: " + status + ""));
                addProject.BackToProject();
                System.Threading.Thread.Sleep(15000);
                CreateDistributionPage distmodule = new CreateDistributionPage(driver);
                System.Threading.Thread.Sleep(3000);
                distmodule.SearchForProject(expected);
                System.Threading.Thread.Sleep(3000);
                String actual = distmodule.getProjectTitle();
                String path1 = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path1, "ProjectTitle");
                Assert.IsTrue(VerifyEquals(expected, actual, "GitHub Project Got created Successfully", "GitHub Project Not Created Succesfully"));
            }
            catch (Exception e)
            {
                fail(e.StackTrace);
                throw;
            }

        }

       [Test, Description("Verifying User is able to Add Project For Mercurial with all Fields")]
        public void TC_04_ValidateCreateProjectForMercurialWithAllFields()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickAddProject();
                System.Threading.Thread.Sleep(3000);
                String expected = addProject.EnterProjectTitle();
                System.Threading.Thread.Sleep(5000);
                addProject.ClickContentType();
                System.Threading.Thread.Sleep(15000);
                addProject.ClickSourceControlTypeOno();
                System.Threading.Thread.Sleep(8000);
                addProject.EnterMercurialRepoPath();
                System.Threading.Thread.Sleep(5000);
                addProject.EnterPublishedPath("Publishing path to create project");
                System.Threading.Thread.Sleep(5000);
                addProject.EnterDescription("This is to create Project");
                System.Threading.Thread.Sleep(5000);
                addProject.ClickCreateProject();
                System.Threading.Thread.Sleep(25000);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(5000);
                String status = addProject.GetNotificationStatus();
                String projectDetails = addProject.GetCreatedProject();
                String path = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path, "Project Created Title");
                Assert.IsTrue(VerifyText("Success", status, "Project is Created with status:" + status + "", "Project is not created with status: " + status + ""));
                addProject.BackToProject();
                System.Threading.Thread.Sleep(15000);
                CreateDistributionPage distmodule = new CreateDistributionPage(driver);
                System.Threading.Thread.Sleep(3000);
                distmodule.SearchForProject(expected);
                System.Threading.Thread.Sleep(3000);
                String actual = distmodule.getProjectTitle();
                String path1 = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path1, "ProjectTitle");
                Assert.IsTrue(VerifyEquals(expected, actual, "Mercurial Project Got created Successfully", "Mercurial Project Not Created Succesfully"));
            }
            catch (Exception e)
            {
                fail(e.StackTrace);
                throw;
            }

        }
        [Test, Description("Verifying User is able to Add Project For GitLab with Mandatory Fields")]
        public void TC_05_ValidateAddingProjectForGitLabWithMandatoryFields()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickDashboard();
                System.Threading.Thread.Sleep(3000);
                addProject.ClickAddProject();
                String expected = addProject.EnterProjectTitle();
                System.Threading.Thread.Sleep(3000);
                addProject.ClickContentType();
                System.Threading.Thread.Sleep(18000);
                addProject.ClickSourceControlTypeGitLab();
                System.Threading.Thread.Sleep(13000);
                addProject.ClickRepository();
                System.Threading.Thread.Sleep(5000);
                addProject.EnterPublishedPath("Publishing path to create project");
                System.Threading.Thread.Sleep(5000);
                addProject.ClickCreateProject();
                System.Threading.Thread.Sleep(18000);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(5000);
                String status = addProject.GetNotificationStatus();
                String projectDetails = addProject.GetCreatedProject();
                String path = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path, "Project Created Title");
                Assert.IsTrue(VerifyText("Success", status, "Project is Created with status:" + status + "", "Project is not created with status: " + status + ""));
                addProject.BackToProject();
                System.Threading.Thread.Sleep(15000);
                CreateDistributionPage distmodule = new CreateDistributionPage(driver);
                System.Threading.Thread.Sleep(3000);
                distmodule.SearchForProject(expected);
                System.Threading.Thread.Sleep(3000);
                String actual = distmodule.getProjectTitle();
                String path1 = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path1, "ProjectTitle");
                Assert.IsTrue(VerifyEquals(expected, actual, "GitLab Project Got created Successfully", "GitLab Project Not Created Succesfully"));
            }
            catch (Exception e)
            {
                fail(e.StackTrace);
                throw;
            }

        }


        [Test, Description("Verify Project Title throws an error message When User gives Invalid Length")]
        public void TC_06_ValidateProjectTitleLengthWithLessThan5Characters()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(driver);
                //addProject.ClickDashboard();
                System.Threading.Thread.Sleep(3000);
                addProject.ClickAddProject();
                addProject.ProjectTitleInvalidLength();
                String expected = "Please enter at least 5 characters";
                System.Threading.Thread.Sleep(3000);
                addProject.ClickContentType();
                String actual = addProject.GetText(addProject.INVALID_TITLE_LENGTH);
                String path = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path, "Validating Length of the Title");
                System.Threading.Thread.Sleep(3000);
                Assert.IsTrue(VerifyEquals(expected, actual, "Validation Got Successful","Validation Got Failed"));
                addProject.ClickClose();
                System.Threading.Thread.Sleep(5000);
            }
            catch (Exception e)
            {
                fail(e.StackTrace);
                throw;
            }

        }

        [Test, Description("Verifying Whether User is able to send More Than 100 characters to the Project Title")]
        public void TC_07_ValidateProjectTitleLengthWithMoreThan100Characters()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickDashboard();
                System.Threading.Thread.Sleep(3000);
                addProject.ClickAddProject();
                addProject.ProjectLengthMoreThan100();
                System.Threading.Thread.Sleep(3000);
                addProject.ClickContentType();
                String path = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path, "Length of the Title exceeded its limit");
                System.Threading.Thread.Sleep(7000);
                String str = addProject.GetTitleLength();
                Assert.IsTrue(VerifyEquals("100/100" , str, "Length Of Project Title got exceeded to its limit as " + str + "", "Length Of Project Title Not got exceeded to its limit as " + str + ""));
                addProject.ClickClose();
                System.Threading.Thread.Sleep(5000);
            }
            catch (Exception e)
            {
                fail(e.StackTrace);
                throw;
            }
        }
        [Test, Description("Verifying User is able to send more than 1000 characters to Description field in Create Project")]
        public void TC_08_ValidateProjectDescriptionLengthWithMoreThan1000Characters()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickDashboard();
                System.Threading.Thread.Sleep(3000);
                addProject.ClickAddProject();
                String expected = addProject.EnterProjectTitle();
                addProject.ClickContentType();
                System.Threading.Thread.Sleep(15000);
                addProject.ClickRepository();
                addProject.EnterPublishedPath("Publishing path to create project");
                String str = addProject.ProjectDescriptionMorethan1000();
                Console.WriteLine("The Text Beyonnd 1000 is " + str);
                String path = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path, "Length of the Description exceeded its limit");
                String str1 = addProject.GetDescriptionLength();
                Assert.IsTrue(VerifyEquals("1000/1000", str1, "Length Of Project Title got exceeded to its limit as " + str1 + "", "Length Of Project Title Not got exceeded to its limit as " + str1 + ""));
                addProject.ClickCreateProject();
                System.Threading.Thread.Sleep(7000);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(5000);
                addProject.BackToProject();
                CreateDistributionPage distmodule = new CreateDistributionPage(driver);
                System.Threading.Thread.Sleep(7000);
                distmodule.SearchForProject(expected);
                System.Threading.Thread.Sleep(7000);
                String path1 = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path1, "Description Length");
                String txt = addProject.GetDescriptionText();
                Assert.IsTrue(VerifyContainsText(txt, str, "Description Text is validated successfully", "Description Text is not validated successfully"));
                System.Threading.Thread.Sleep(5000);
            }
            catch (Exception e)
            {
                fail(e.StackTrace);
                throw;
            }

        }

        [OneTimeTearDown]

        public void CloseBrowser()
        {
            driver.Quit();
        }
    }

}
