using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using DocWorksQA.Utilities;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using DocWorksQA.TestRailApis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocWorksQA.Tests
{
   //  //[TestFixture]
    class TS_03_CreateDraftModule : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private static string uid = ConfigurationHelper.Get<String>("UserName");
        private static string pwd = ConfigurationHelper.Get<String>("password");


        //[OneTimeSetUp]
        public void CreateDraftModule()
        {
            driver = new DriverFactory().Create();
            try
            {
                //String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                System.Threading.Thread.Sleep(5000);
                //CreateTest(TestName);
                LoginPage login = new LoginPage(driver);
                login.EnterUserName(uid);
                login.EnterPassword(pwd);
                System.Threading.Thread.Sleep(3000);
                login.ClickLogin();
                //String path = TakeScreenshot(driver);
                //login.SuccessScreenshot(path, "Login Got Successful");

            }
            catch (AssertionException)
            {
               fail("Assertion failed");
                throw;
            }
        }

         //[Test, Description("Verify New Draft Button is enabled or not")]
        public void TC_01_ValidateNewDraftButtonDialogBoxIsAppearedOrNot()
        {
            
                try
                {
                    String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                    String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                    CreateTest(TestName, description);
                    System.Threading.Thread.Sleep(5000);
                    AddProjectPage addProject = new AddProjectPage(driver);
                    addProject.ClickAddProject();
                    System.Threading.Thread.Sleep(3000);
                    String expected = addProject.EnterProjectTitle();
                    System.Threading.Thread.Sleep(5000);
                    addProject.ClickContentType();
                    System.Threading.Thread.Sleep(15000);
                    addProject.ClickSourceControlTypeGitLab();
                    System.Threading.Thread.Sleep(5000);
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
                    addProject.SuccessScreenshot(path, "Project Created Successfully");
                    Assert.IsTrue(VerifyText("Success", status, "Project is Created with status:" + status + "", "Project is not created with status: " + status + ""));
                    addProject.BackToProject();
                    System.Threading.Thread.Sleep(15000);
                    CreateDistributionPage distmodule = new CreateDistributionPage(driver);
                    System.Threading.Thread.Sleep(3000);
                    distmodule.SearchForProject(expected);
                    System.Threading.Thread.Sleep(3000);
                    distmodule.ClickDistribution();
                    System.Threading.Thread.Sleep(8000);
                    String expected1 = distmodule.EnterDistirbutionName();
                    System.Threading.Thread.Sleep(75000);
                    distmodule.ClickBranchWithTOC();
                    System.Threading.Thread.Sleep(5000);
                    distmodule.EnterTocPath();
                    distmodule.EnterDescription("This is to create a distribution");
                    System.Threading.Thread.Sleep(5000);
                    distmodule.ClickCreateDistribution();
                    System.Threading.Thread.Sleep(40000);
                    addProject.ClickNotifications();
                    System.Threading.Thread.Sleep(15000);
                    String status1 = addProject.GetNotificationStatus();
                    String path1 = TakeScreenshot(driver);
                    addProject.SuccessScreenshot(path1, "Distribution got Created successfully");
                    Assert.IsTrue(VerifyText("Success", status1, "Distribution is Created with status:" + status1 + "", "Distribution is not created with status: " + status1 + ""));
                    addProject.BackToProject();
                    System.Threading.Thread.Sleep(5000);
                    CreateDraftPage createDraft = new CreateDraftPage(driver);
                    System.Threading.Thread.Sleep(8000);
                    createDraft.CLICKOPENPROJECT();
                    System.Threading.Thread.Sleep(8000);
                    createDraft.ClikOnBackdrop();
                    System.Threading.Thread.Sleep(5000);
                    createDraft.ClickNewDraft();
                    System.Threading.Thread.Sleep(5000);
                    Boolean flag = createDraft.isDraftPopUpEnabled();
                    System.Threading.Thread.Sleep(5000);
                    String path2 = TakeScreenshot(driver);
                 createDraft.SuccessScreenshot(path2, "Draft Dialog Box Is appeared on screen");
                Assert.IsTrue(VerifyBoolean(true, flag, "Draft Dialog Box got Opened Successfully", "Draft Dialog Box is not Opened Successfully"));
                    createDraft.CLOSEDRAFT();
            }
            catch (AssertionException)
            {
                fail("Assertion failed");
                throw;
            }

        }
         //[Test, Description("Verify When User Enters Invalid Draft Name Then an error message is apeared")]
        public void TC_02_ValidateErrorMsgForInvalidDraftName()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                CreateDraftPage createDraft = new CreateDraftPage(driver);
                System.Threading.Thread.Sleep(5000);
                createDraft.ClickNewDraft();
                System.Threading.Thread.Sleep(5000);
                String expected = "Please enter at least 5 characters.";
                createDraft.EnterInvalidnNameLength();
                String actual = createDraft.GetErrorText(createDraft.DRAFTNAMEERROR);
                String path1 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path1, "Validating Draft Name Length");
                System.Threading.Thread.Sleep(15000);
                Assert.IsTrue(VerifyEquals(expected, actual, "Validation Of Length Constraints for Draft Name Field is successful","Validation of Length Constraints for Draft Name Field is not successful"));
                //distmodule.ClickCloseButton();
                System.Threading.Thread.Sleep(5000);
                createDraft.CLOSEDRAFT();
                System.Threading.Thread.Sleep(5000);
            }
            catch (AssertionException)
            {
                fail("Assertion failed");
                throw;
            }

        }
         //[Test, Description("Verify User is able to create an existing Draft")]
        public void TC_03_ValidationOfCreateExistingDraftWithValidDraftName()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                CreateDraftPage createDraft = new CreateDraftPage(driver);
                System.Threading.Thread.Sleep(5000);
                createDraft.ClickNewDraft();
                System.Threading.Thread.Sleep(5000);
                String draftName = createDraft.EnterValidDraftName();
                //createDraft.ClickOnExistingDraft();
                createDraft.SelectCoderDraft();
                String path1 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path1, "Creating Existing Draft");
                createDraft.CreateDraft();
                System.Threading.Thread.Sleep(25000);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(8000);
                String status = addProject.GetNotificationStatus();
                String path = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path, "Draft got Created Successfully");
                Assert.IsTrue(VerifyText("Success", status, "Draft: "+ draftName + " is Created with status:" + status + "", "Draft is not created with status: " + status + ""));
                addProject.BackToProject();
                //creating duplicate draft
                System.Threading.Thread.Sleep(15000);
                createDraft.ClickNewDraft();
                System.Threading.Thread.Sleep(5000);
                String str = "Duplicate Draft Name";
                createDraft.EnterDraftName(draftName);
                String path2 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path2, "Error Message While Creating Duplicate Draft");
               String actual =  addProject.GetText(addProject.INVALID_TITLE_LENGTH);
                Assert.IsTrue(VerifyEquals(str, actual, "Duplicate Draft: " + draftName + " is Unable to Create", "Duplicate Draft "+draftName+" is created"));
                createDraft.CLOSEDRAFT();
            }
            catch (AssertionException)
            {
                fail("Assertion failed");
                throw;
            }

        }
         //[Test, Description("Verify User is able to create a blank draft")]
        public void TC_04_ValidationOfCreateBlankDraftWithValidDraftName()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                CreateDraftPage createDraft = new CreateDraftPage(driver);
                System.Threading.Thread.Sleep(5000);
                createDraft.ClickNewDraft();
               String draftName = createDraft.EnterValidDraftName();
                System.Threading.Thread.Sleep(5000);
                createDraft.ClickOnBlankDraft();
                System.Threading.Thread.Sleep(5000);
                String path1 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path1, "Creating Blank Draft");
                createDraft.CreateDraft();
                System.Threading.Thread.Sleep(25000);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(8000);
                String status = addProject.GetNotificationStatus();
                String path3 = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path3, "Draft got Created Successfully");
                Assert.IsTrue(VerifyText("Success", status, "Draft: " + draftName + " is Created with status:" + status + "", "Draft is not created with status: " + status + ""));
                addProject.BackToProject();
            }
            catch (AssertionException)
            {
                fail("Assertion failed");
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
