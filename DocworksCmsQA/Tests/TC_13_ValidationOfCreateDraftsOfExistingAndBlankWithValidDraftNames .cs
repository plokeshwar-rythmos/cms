using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using AventStack.ExtentReports;

namespace DocWorksQA.Tests
{
    [TestFixture, Category("Create Draft")]
    [Parallelizable]
    class TC_13_ValidationOfCreateDraftsOfExistingAndBlankWithValidDraftNames : BeforeTestAfterTest
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
        [Test, Description("Verify User is able to create a Blank Draft")]
        public void TC_01_ValidationOfBlankDraftWithValidDraftName()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.ClickAddProject();
                String expected = addProject.EnterProjectTitle();
                addProject.SelectContentType("Manual");
                addProject.SelectSourceControlProviderType("GitLab");
                addProject.SelectRepository("Docworks");
                addProject.EnterPublishedPath("Publishing path to create project");
                addProject.EnterDescription("This is to create Project");
                addProject.ClickCreateProject();
                addProject.ClickNotifications();
                String status = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Project Created Title");
                VerifyText(test, "creating a project " + expected + " is successful", status, "Project Created Successfully", "Project is not created with status: " + status + "");
                addProject.ClickDashboard();
                addProject.SearchForProject(expected);
                String actual = addProject.GetProjectTitle();
                addProject.SuccessScreenshot("ProjectTitle");
                VerifyEquals(test, expected, actual, "Created Project Found on Dashboard.", "Created Project Not Available on Dashboard.");
                CreateDistributionPage distmodule = new CreateDistributionPage(test, driver);
                distmodule.ClickDistribution();
                String expected1 = distmodule.EnterDistirbutionName();
                System.Threading.Thread.Sleep(75000);
                distmodule.SelectBrach("DocworksManual3");
                distmodule.EnterTocPath();
                distmodule.EnterDescription("This is to create a distribution With TOC Path");
                distmodule.ClickCreateDistribution();
                addProject.ClickNotifications();
                String status1 = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Distribution got Created successfully With TOC Path");
                VerifyText(test, "creating distribution " + expected1 + " in " + expected + " is successful", status1, "Distribution is Created For GitLab TOC with status:" + status1 + "", "Distribution is not created For GitLab TOC with status: " + status1 + "");
                addProject.ClickDashboard();
                addProject.SearchForProject(expected);
                CreateDraftPage createDraft = new CreateDraftPage(test,driver);
                createDraft.CLICKOPENPROJECT();
                createDraft.ClickOnUnityManualNode();
                createDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                createDraft.ClickOnBlankDraft();
                addProject.SuccessScreenshot("Creating a Blank Draft");
                createDraft.CreateDraft();
                addProject.ClickNotifications();
                String status2 = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Blank Draft got Created Successfully");
                VerifyText(test,"creating a draft " + draftName + " in UnityManual is successful", status2, "Draft: " + draftName + " is Created with status:" + status2 + "", "Draft is not created with status: " + status2 + "");
                addProject.BackToProject();
                createDraft.ClickNewDraft();
                String str = "Duplicate Draft Name";
                createDraft.EnterDraftName(draftName);
                addProject.SuccessScreenshot("Error Message While Creating Duplicate Draft");
                String actual2 = addProject.GetText(addProject.INVALID_TITLE_LENGTH);
                VerifyEquals(test,str, actual2, "Duplicate Draft: " + draftName + " is Unable to Create", "Duplicate Draft " + draftName + " is created");
                createDraft.CLOSEDRAFT();

            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                throw;
            }
        }

        [Test, Description("Verify User is able to create a Existing draft")]
        public void TC_02_ValidationOfExistingDraftWithValidDraftName()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                createDraft.SelectCoderDraft();
                addProject.SuccessScreenshot("Creating Existing Draft");
                createDraft.CreateDraft();
                addProject.ClickNotifications();
                String status2 = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Draft got Created Successfully");
                VerifyText(test,"creating a draft " + draftName + " in UnityManual is successful", status2, "Draft: " + draftName + " is Created with status:" + status2 + "", "Draft is not created with status: " + status2 + "");
                addProject.BackToProject();
                createDraft.ClickNewDraft();
                String str = "Duplicate Draft Name";
                createDraft.EnterDraftName(draftName);
                addProject.SuccessScreenshot("Error Message While Creating Duplicate Draft");
                String actual2 = addProject.GetText(addProject.INVALID_TITLE_LENGTH);
               VerifyEquals(test,str, actual2, "Duplicate Draft: " + draftName + " is Unable to Create", "Duplicate Draft " + draftName + " is created");
                createDraft.CLOSEDRAFT();
            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
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