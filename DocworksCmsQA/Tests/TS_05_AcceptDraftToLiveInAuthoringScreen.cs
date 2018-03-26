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
    class TS_05_AcceptDraftToLiveInAuthoringScreen : BeforeTestAfterTest
    {
        private String testcaseID = "1";
        private static IWebDriver driver;
        private static string uid = ConfigurationHelper.Get<String>("UserName");
        private static string pwd = ConfigurationHelper.Get<String>("password");

        [OneTimeSetUp]
        public void AcceptDraftToLiveInAuthoringScreen()
        {
            updateTestRun(testcaseID);
            driver = new DriverFactory().Create();
            try
            {
              //  String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                System.Threading.Thread.Sleep(5000);
               // CreateTest(TestName);
                LoginPage login = new LoginPage(driver);
                login.EnterUserName(uid);
                login.EnterPassword(pwd);
                System.Threading.Thread.Sleep(5000);
                // login.CheckCaptchaBox();
                System.Threading.Thread.Sleep(3000);
                login.ClickLogin();
                //String path = TakeScreenshot(driver);
                //login.SuccessScreenshot(path, "Login Got Successful");
                System.Threading.Thread.Sleep(5000);

            }
            catch (AssertionException)
            {
                fail("Assertion failed");
                throw;
            }
        }
        [Test, Description("Verify User Is able to View a DropDown on Clicking of AcceptDraftToLive Button When both drafts are different")]
        public void TC_01_ValidateUserAbleToSeeDropDownOnAccepttodraftliveButtonIfBothTheDraftsAreDifferent()
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
                System.Threading.Thread.Sleep(85000);
                distmodule.ClickBranchWithTOC();
                System.Threading.Thread.Sleep(5000);
                distmodule.EnterTocPath();
                distmodule.EnterDescription("This is to create a distribution");
                System.Threading.Thread.Sleep(5000);
                distmodule.ClickCreateDistribution();
                System.Threading.Thread.Sleep(50000);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(25000);
                String status1 = addProject.GetNotificationStatus();
                String path1 = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path1, "Distribution got Created successfully");
                Assert.IsTrue(VerifyText("Success", status1, "Distribution is Created with status:" + status1 + "", "Distribution is not created with status: " + status1 + ""));
                addProject.BackToProject();
                System.Threading.Thread.Sleep(5000);
                CreateDraftPage createDraft = new CreateDraftPage(driver);
                System.Threading.Thread.Sleep(8000);
                createDraft.CLICKOPENPROJECT();
                System.Threading.Thread.Sleep(10000);
                createDraft.ClikOnBackdrop();
                System.Threading.Thread.Sleep(5000);
                createDraft.ClickNewDraft();
                System.Threading.Thread.Sleep(5000);
                String Expected1 = createDraft.EnterValidDraftName();
                createDraft.CreateDraft();
                System.Threading.Thread.Sleep(15000);
                System.Threading.Thread.Sleep(5000);
                addProject.ClickNotifications();
                String path2 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path2, "Created a Draft: "+ Expected1 +"");
                addProject.BackToProject();
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                System.Threading.Thread.Sleep(5000);
                auth.LeftDraftDropDown(Expected1);
                System.Threading.Thread.Sleep(5000);
                auth.ClickAcceptDraftToLive();
                String path3 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path3, "DropDown Appears in Accept Draft to live When two different drafts are selected");
                String Actual = auth.GetDropDownValues();
                Console.WriteLine("DropDown Contains:   " + Actual);
                //auth.LeftDraftDropDown();

            }
            catch (AssertionException)
            {
                fail("Assertion failed");
                throw;
            }
        }

        [Test, Description("Verify User Able to Click On the AcceptDraftToLive Button when two Drafts are same")]
        public void TC_02_ValidateUserAbleClickOnAcceptToDraftLiveButtonIfBothTheDraftsAreSame()
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
                // createDraft.ClickOnExistingDraft();
                createDraft.CreateDraft();
                System.Threading.Thread.Sleep(15000);
                System.Threading.Thread.Sleep(5000);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(5000);
                String path1 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path1, "Created a Draft");
                addProject.BackToProject();
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                System.Threading.Thread.Sleep(5000);
                auth.LeftDraftDropDown(draftName);
                System.Threading.Thread.Sleep(5000);
                auth.RightDraftDropDown(draftName);
                System.Threading.Thread.Sleep(5000);
                auth.ClickAcceptDraftToLive();
                System.Threading.Thread.Sleep(15000);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(5000);
                String path2 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path2, "Created a Live Draft");
                AddProjectPage addProject1 = new AddProjectPage(driver);
                addProject1.BackToProject();
                System.Threading.Thread.Sleep(5000);
            }
            catch (AssertionException)
            {
                fail("Assertion failed");
                throw;
            }
        }

        [Test, Description("Verify User Able to Validate Live Draft and Continuous Update Of Live Draft")]
        public void TC_03_ValidateUserAbleToCreateLiveDraftAndCanContinuouslyUpdateIt()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                AuthoringScreenEnhancements auth1 = new AuthoringScreenEnhancements(driver);
                auth1.LeftLiveDraft();
                System.Threading.Thread.Sleep(5000);
                auth1.MDLeftTab();
                System.Threading.Thread.Sleep(5000);
                auth1.RightLiveDraft();
                System.Threading.Thread.Sleep(5000);
                auth1.MDRightTab();
                System.Threading.Thread.Sleep(5000);
                CreateDraftPage createDraft1 = new CreateDraftPage(driver);
                String path3 = TakeScreenshot(driver);
                createDraft1.SuccessScreenshot(path3, "Validating a Live Draft in both Editor Panes with some content");
                CreateDraftPage createDraft2 = new CreateDraftPage(driver);
                System.Threading.Thread.Sleep(5000);
                createDraft2.ClickNewDraft();
                System.Threading.Thread.Sleep(5000);
                String draftName1 = createDraft2.EnterValidDraftName();
                createDraft2.ClickOnBlankDraft();
                System.Threading.Thread.Sleep(5000);
                String path4 = TakeScreenshot(driver);
                createDraft2.SuccessScreenshot(path4, "Creating  a Blank Draft");
                createDraft2.CreateDraft();
                System.Threading.Thread.Sleep(15000);
                System.Threading.Thread.Sleep(5000);
                AddProjectPage addProject2 = new AddProjectPage(driver);
                addProject2.ClickNotifications();
                System.Threading.Thread.Sleep(5000);
                String path5 = TakeScreenshot(driver);
                createDraft2.SuccessScreenshot(path5, "Created a Blank Draft");
                addProject2.BackToProject();
                System.Threading.Thread.Sleep(5000);
                AuthoringScreenEnhancements auth2 = new AuthoringScreenEnhancements(driver);
                auth2.LeftDraftDropDown(draftName1);
                System.Threading.Thread.Sleep(5000);
                auth2.RightDraftDropDown(draftName1);
                System.Threading.Thread.Sleep(5000);
                auth2.ClickAcceptDraftToLive();
                System.Threading.Thread.Sleep(15000);
                System.Threading.Thread.Sleep(5000);
                addProject2.ClickNotifications();
                System.Threading.Thread.Sleep(5000);
                String path6 = TakeScreenshot(driver);
                createDraft2.SuccessScreenshot(path6, "Created a Blank Live Draft");
                addProject2.BackToProject();
                System.Threading.Thread.Sleep(5000);
                auth2.LeftLiveDraft();
                System.Threading.Thread.Sleep(5000);
                auth2.MDLeftTab();
                System.Threading.Thread.Sleep(5000);
                auth2.RightLiveDraft();
                System.Threading.Thread.Sleep(5000);
                auth2.MDRightTab();
                System.Threading.Thread.Sleep(5000);
                String path7 = TakeScreenshot(driver);
                createDraft2.SuccessScreenshot(path7, "Validating Updated Live Draft in both Editor Panes with blank message");
            }
            catch (AssertionException)
            {
                fail("Assertion failed");
                throw;
            }
        }
        [Test, Description("Verify User Able To View Gdoc Content When selected Live or Coder Draft ")]
        public void TC_04_ValidateUserAbleToSeeGdocTabWithaMessageWhenSelectedLiveOrCoderDrafts()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                System.Threading.Thread.Sleep(5000);
                auth.LeftLiveDraft();
                System.Threading.Thread.Sleep(5000);
                auth.RightLiveDraft();
                System.Threading.Thread.Sleep(5000);
                CreateDraftPage createDraft = new CreateDraftPage(driver);
                String path1 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path1, "Validating GDoc Message when selected Live Draft");
                System.Threading.Thread.Sleep(5000);
                auth.LeftCoderDraft();
                System.Threading.Thread.Sleep(5000);
                auth.RightCoderDraft();
                System.Threading.Thread.Sleep(5000);
                String path2 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path2, "Validating GDoc Message when selected Coder Draft");
            }
            catch (AssertionException)
            {
                fail("Assertion failed");
                throw;
            }

        }
        [Test, Description("Verify When User selects Existing Live Drafts to Live the AcceptDraftToLive Button is disabled")]
        public void TC_05_ValidateAcceptDraftToLiveButtonIsDisabledWhenUserSelectsExistingLiveDraftsToLive()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                System.Threading.Thread.Sleep(5000);
                auth.LeftLiveDraft();
                System.Threading.Thread.Sleep(5000);
                auth.RightLiveDraft();
                System.Threading.Thread.Sleep(5000);
                Boolean flag = auth.IsAcceptDraftToLiveButtonEnabled();
                Console.WriteLine("Flag is " + flag);
                CreateDraftPage createDraft = new CreateDraftPage(driver);
                String path1 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path1, "Verifying Accept Draft To Live Button Is Enabled or Disabled ");
                Assert.IsTrue(flag);
                System.Threading.Thread.Sleep(15000);
            }
            catch (AssertionException)
            {
               fail("Assertion failed");
                throw;
            }

        }
        [Test, Description("Verify User able to view Updated Content of Live Draft in Coder Draft and vice-versa")]
        public void TC_06_ValidateContentInLiveDraftShouldUpdateInCoderDraft()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                System.Threading.Thread.Sleep(5000);
                auth.LeftLiveDraft();
                System.Threading.Thread.Sleep(5000);
                auth.MDLeftTab();
                System.Threading.Thread.Sleep(5000);
                CreateDraftPage createDraft = new CreateDraftPage(driver);
                String path1 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path1, "Content in Live Draft Before Update");
                System.Threading.Thread.Sleep(5000);
                auth.LeftCoderDraft();
                System.Threading.Thread.Sleep(5000);
                String path2 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path2, "Content in Coder Draft Before Update");
                createDraft.ClickNewDraft();
                System.Threading.Thread.Sleep(5000);
                String draftName1 = createDraft.EnterValidDraftName();
                createDraft.ClickOnBlankDraft();
                System.Threading.Thread.Sleep(5000);
                createDraft.CreateDraft();
                System.Threading.Thread.Sleep(15000);
                System.Threading.Thread.Sleep(5000);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(5000);
                String path5 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path5, "Created a Blank Draft");
                addProject.BackToProject();
                System.Threading.Thread.Sleep(5000);
                AuthoringScreenEnhancements auth1 = new AuthoringScreenEnhancements(driver);
                auth1.LeftDraftDropDown(draftName1);
                auth1.GdocLeftTab();
                System.Threading.Thread.Sleep(5000);
                IWebElement framel = auth1.EnterIntoLeftFrame();
                driver.SwitchTo().Frame(framel);
                System.Threading.Thread.Sleep(5000);
                driver.SwitchTo().ActiveElement();
                auth1.ClickGdocLeft();
                driver.SwitchTo().ActiveElement().SendKeys("SELENIUM_TEST_123");
                System.Threading.Thread.Sleep(15000);
                driver.SwitchTo().DefaultContent();
                auth1.RightDraftDropDown(draftName1);
                System.Threading.Thread.Sleep(5000);
                auth1.ClickAcceptDraftToLive();
                System.Threading.Thread.Sleep(15000);
                System.Threading.Thread.Sleep(15000);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(5000);
                String path6 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path6, "Created a Blank Live Draft");
                addProject.BackToProject();
                System.Threading.Thread.Sleep(5000);
                auth1.LeftLiveDraft();
                System.Threading.Thread.Sleep(5000);
                auth.MDLeftTab();
                System.Threading.Thread.Sleep(5000);
                String path7 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path7, "Content in Live Draft after Update");
                System.Threading.Thread.Sleep(5000);
                auth.LeftCoderDraft();
                System.Threading.Thread.Sleep(5000);
                auth.RightCoderDraft();
                System.Threading.Thread.Sleep(5000);
                String path8 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path8, "Content in Coder Draft after Update");

            }
            catch (AssertionException)
            {
             fail("Assertion failed");
                throw;
            }

        }
        [Test, Description("Verify User is able to select a Draft from Dropdown when two different Drafts are selected for AcceptDraftToLive")]
        public void TC_07_ValidateUserAbleToSelectaDraftFromDropdownWhenClickedAcceptDraftToLiveButton()
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
                String Expected1 = createDraft.EnterValidDraftName();
                //createDraft.ClickOnExistingDraft();
                // createDraft.SelectCoderDraft();
                createDraft.CreateDraft();
                System.Threading.Thread.Sleep(15000);
                System.Threading.Thread.Sleep(5000);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickNotifications();
                // createDraft.ClikOnBackdrop();
                String path1 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path1, "Created a Draft");
                addProject.BackToProject();
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                System.Threading.Thread.Sleep(5000);
                auth.LeftDraftDropDown(Expected1);
                System.Threading.Thread.Sleep(5000);
                auth.ClickAcceptDraftToLive();
                String path2 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path2, "DropDown Appears in Accept Draft to live When two different drafts are selected");
                System.Threading.Thread.Sleep(5000);
                auth.SelectDraftFromAcceptDraftToLiveDropDown();
                System.Threading.Thread.Sleep(15000);
                System.Threading.Thread.Sleep(5000);
                addProject.ClickNotifications();
                // createDraft.ClikOnBackdrop();
                String path3 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path3, "Created a Live Draft for the scenario of two different drafts");
                addProject.BackToProject();
                System.Threading.Thread.Sleep(5000);
                auth.LeftLiveDraft();
                System.Threading.Thread.Sleep(5000);
                auth.MDLeftTab();
                String path4 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path4, "Content In the Live Draft");

            }
            catch (AssertionException)
            {
                fail("Assertion failed");
                throw;
            }
        }
        [Test, Description("Verify User is Unable to create a Draft with Same Name of Existing Draft")]
        public void TC_07_ValidateUserIsUnableToCreateDuplicateDrafts()
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
                String Expected1 = createDraft.EnterValidDraftName();
                //createDraft.ClickOnExistingDraft();
                // createDraft.SelectCoderDraft();
                createDraft.CreateDraft();
                System.Threading.Thread.Sleep(15000);
                System.Threading.Thread.Sleep(5000);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickNotifications();
                // createDraft.ClikOnBackdrop();
                String path1 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path1, "Created a Draft Named " + Expected1 + " with existing content");
                addProject.BackToProject();
                System.Threading.Thread.Sleep(5000);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                auth.LeftDraftDropDown(Expected1);
                System.Threading.Thread.Sleep(5000);
                createDraft.ClickNewDraft();
                System.Threading.Thread.Sleep(5000);
                createDraft.EnterDraftName(Expected1);
                createDraft.ClickOnBlankDraft();
                String path2 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path2, "Unable To Create a Draft Named " + Expected1 + " with Blank Message");

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
