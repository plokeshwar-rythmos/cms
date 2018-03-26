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
    class TS_04_AuthoringScreenEnhancements : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private static string uid = ConfigurationHelper.Get<String>("UserName");
        private static string pwd = ConfigurationHelper.Get<String>("password");

      //  [OneTimeSetUp]
        public void AuthoringScreenEnhancements()
        {
            driver = new DriverFactory().Create();
            try
            {
               // String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                System.Threading.Thread.Sleep(5000);
                //CreateTest(TestName);
                LoginPage login = new LoginPage(driver);
                login.EnterUserName(uid);
                login.EnterPassword(pwd);
                System.Threading.Thread.Sleep(5000);
                // login.CheckCaptchaBox();
                System.Threading.Thread.Sleep(3000);
                login.ClickLogin();
             //   String path = TakeScreenshot(driver);
               // login.SuccessScreenshot(path, "Login Got Successful");
                System.Threading.Thread.Sleep(5000);
               
            }
            catch (AssertionException)
            {
                fail("Assertion failed");
                throw;
            }
        }
         //[Test, Description("Verify User is able to edit the existing draft content in Left side GDOC")]
        public void TC_01_ValidateScreenEnhancementsWhenUserEditsExistingContentInLeftGdoc()
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
                System.Threading.Thread.Sleep(10000);
                createDraft.ClikOnBackdrop();
                System.Threading.Thread.Sleep(5000);
                createDraft.ClickNewDraft();
                System.Threading.Thread.Sleep(5000);
                String draftName = createDraft.EnterValidDraftName();
                createDraft.SelectCoderDraft();
                System.Threading.Thread.Sleep(5000);
                createDraft.CreateDraft();
                System.Threading.Thread.Sleep(15000);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(8000);
                String status2 = addProject.GetNotificationStatus();
                String path2 = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path2, "Draft got Created Successfully");
                Assert.IsTrue(VerifyText("Success", status2, "Draft: " + draftName + " is Created with status:" + status2 + "", "Draft is not created with status: " + status2 + ""));
                addProject.BackToProject();
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                System.Threading.Thread.Sleep(8000);
                auth.LeftDraftDropDown(draftName);
                System.Threading.Thread.Sleep(5000);
                IWebElement framel = auth.EnterIntoLeftFrame();
                driver.SwitchTo().Frame(framel);
                System.Threading.Thread.Sleep(5000);
                driver.SwitchTo().ActiveElement();
                auth.ClickGdocLeft();
                driver.SwitchTo().ActiveElement().SendKeys("SELENIUM_TEST_123");
                System.Threading.Thread.Sleep(15000);
                String path3 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path3, "Editing Existing Draft in GDOC Left");
                driver.SwitchTo().DefaultContent();
                auth.RightDraftDropDown(draftName);
                System.Threading.Thread.Sleep(5000);
            }
            catch (AssertionException)
            {
                fail("Assertion failed");
                throw;
            }
        }
         //[Test, Description("Verify User is Able to view changes made of Existing Draft in Left GDOC are reflected in Right Side Tabs")]
        public void TC_02_ValidationWhenEditedExistingDraftInLeftGDocGetsReflectedInRightSideTabs()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                String expected = "SELENIUM_TEST_123";
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                String path3 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path3, "Verifying Edited Draft Contains String: " + expected + " in GDOC Right");
                auth.HtmlRightTab();
                String path4 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path4, "Verifying Edited Draft Contains String: " + expected + " in HTML Right");
                auth.MDRightTab();
                String path5 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path5, "Verifying Edited Draft Contains String: " + expected + " in MD Right");
                auth.PreviewRightTab();
                String path6 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path6, "Verifying Edited Draft  Contains String: " + expected + "in Preview Right");
                auth.GdocRightTab();
            }
            catch (AssertionException)
            {
                fail("Assertion failed");
                throw;
            }
        }
         //[Test, Description("Verify User is able to edit the existing draft content in Right side GDOC")]
        public void TC_03_ValidationOfScreenEnhancementsUserEditsExistingContentInRightGdoc()
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
                createDraft.SelectCoderDraft();
                System.Threading.Thread.Sleep(5000);
                createDraft.CreateDraft();
                System.Threading.Thread.Sleep(15000);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(8000);
                String status2 = addProject.GetNotificationStatus();
                String path2 = TakeScreenshot(driver);
                addProject.SuccessScreenshot(path2, "Draft got Created Successfully");
                Assert.IsTrue(VerifyText("Success", status2, "Draft: " + draftName + " is Created with status:" + status2 + "", "Draft is not created with status: " + status2 + ""));
                addProject.BackToProject();
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                System.Threading.Thread.Sleep(8000);
                auth.RightDraftDropDown(draftName);
                System.Threading.Thread.Sleep(8000);
                IWebElement framel = auth.EnterIntoRightFrame();
                driver.SwitchTo().Frame(framel);
                System.Threading.Thread.Sleep(5000);
                driver.SwitchTo().ActiveElement();
                auth.ClickGdocRight();
                driver.SwitchTo().ActiveElement().SendKeys("SELENIUM_TEST_123");
                System.Threading.Thread.Sleep(15000);
                String path3 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path3, "Editing Existing Draft in GDOC Right");
                driver.SwitchTo().DefaultContent();
                auth.LeftDraftDropDown(draftName);
                System.Threading.Thread.Sleep(5000);
            }
            catch (AssertionException)
            {
                fail("Assertion failed");
                throw;
            }
        }
         //[Test, Description("Verify User is Able to view changes made of Existing Draft in Right GDOC are reflected in Left Side Tabs")]
        public void TC_04_ValidationWhenUserEditedRightGDocGetsReflectedInLeftSideTabs()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                String expected = "SELENIUM_TEST_123";
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                String path1 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path1, "Verifying Edited Draft Contains String: " + expected + " in GDOC Left");
                auth.HtmlLeftTab();
                String path2 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path2, "Verifying Edited Draft Contains String: " + expected + " in HTML Left");
                auth.MDLeftTab();
                String path3 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path3, "Verifying Edited Draft Contains String: " + expected + " in MD Left");
                auth.PreviewLeftTab();
                String path4 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path4, "Verifying Edited Draft  Contains String: " + expected + "in Preview Left");
                auth.GdocLeftTab();
            }
            catch (AssertionException)
            {
                fail("Assertion failed");
                throw;
            }
        }
         //[Test, Description("Verify User is able to Edit the content in Blank Draft in Left GDOC")]
        public void TC_05_ValidationOfScreenEnhancementWhenUserEditsBlankDraftContentInLeftGdoc()
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
                System.Threading.Thread.Sleep(15000);
                System.Threading.Thread.Sleep(5000);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickNotifications();
                // createDraft.ClikOnBackdrop();
                String path2 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path2, "Created a Draft");
                addProject.BackToProject();
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                System.Threading.Thread.Sleep(8000);
                auth.LeftDraftDropDown(draftName);
                System.Threading.Thread.Sleep(5000);
                IWebElement framel = auth.EnterIntoLeftFrame();
                driver.SwitchTo().Frame(framel);
                System.Threading.Thread.Sleep(5000);
                driver.SwitchTo().ActiveElement();
                auth.ClickGdocLeft();
                driver.SwitchTo().ActiveElement().SendKeys("SELENIUM_TEST_123");
                System.Threading.Thread.Sleep(15000);
                String path3 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path3, "Editing Existing Draft in GDOC Left");
                driver.SwitchTo().DefaultContent();
                auth.RightDraftDropDown(draftName);
                System.Threading.Thread.Sleep(5000);
            }
            catch (AssertionException)
            {
               fail("Assertion failed");
                throw;
            }
        }
         //[Test, Description("Verify User is able to view changes made for blank draft in Left are reflected in Rightside tabs ")]
        public void TC_06_ValidationWhenUserEditedBlankDraftInLeftGDocGetsReflectedInRightSideTabs()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                String expected = "SELENIUM_TEST_123";
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                String path1 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path1, "Verifying Edited Blank Draft Contains String: " + expected + " in GDOC Right");
                auth.HtmlRightTab();
                String path2 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path2, "Verifying Edited Blank Draft Contains String: " + expected + " in HTML Right");
                auth.MDRightTab();
                String path3 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path3, "Verifying Edited Blank Draft Contains String: " + expected + " in MD Right");
                auth.PreviewRightTab();
                String path4 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path4, "Verifying Edited Blank Draft  Contains String: " + expected + "in Preview Right");
                auth.GdocRightTab();
            }
            catch (AssertionException)
            {
                fail("Assertion failed");
                throw;
            }
        }
         //[Test, Description("Verify User is able to Edit Content for Blank Draft in Right Side GDOC")]
        public void TC_07_ValidationOfScreenEnhancementsWhenUserEditsBlankDraftContentInRightGdoc()
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
                System.Threading.Thread.Sleep(15000);
                System.Threading.Thread.Sleep(5000);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickNotifications();
                // createDraft.ClikOnBackdrop();
                String path2 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path2, "Created a Draft");
                addProject.BackToProject();
                System.Threading.Thread.Sleep(8000);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                auth.RightDraftDropDown(draftName);
                System.Threading.Thread.Sleep(5000);
                IWebElement framel = auth.EnterIntoRightFrame();
                driver.SwitchTo().Frame(framel);
                System.Threading.Thread.Sleep(5000);
                driver.SwitchTo().ActiveElement();
                auth.ClickGdocRight();
                driver.SwitchTo().ActiveElement().SendKeys("SELENIUM_TEST_123");
                System.Threading.Thread.Sleep(15000);
                String path3 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path3, "Editing Existing Draft in GDOC Left");
                driver.SwitchTo().DefaultContent();
                auth.LeftDraftDropDown(draftName);
                System.Threading.Thread.Sleep(5000);

            }
            catch (AssertionException)
            {
                fail("Assertion failed");
                throw;
            }
        }

         //[Test, Description("Verify User is able to view changes made for blank draft in Right are reflected in Left side tabs")]
        public void TC_08_ValidationWhenUserEditedBlankDraftInRightGDocGetsReflectedInLeftSideTabs()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
               CreateTest(TestName, description);
                String expected = "SELENIUM_TEST_123";
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                String path1 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path1, "Verifying Edited Blank Draft Contains String: " + expected + " in GDOC Left");
                auth.HtmlLeftTab();
                String path2 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path2, "Verifying Edited Blank Draft Contains String: " + expected + " in HTML Left");
                auth.MDLeftTab();
                String path3 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path3, "Verifying Edited Blank Draft Contains String: " + expected + " in MD Left");
                auth.PreviewLeftTab();
                String path4 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path4, "Verifying Edited Blank Draft  Contains String: " + expected + "in Preview Left");
                auth.GdocLeftTab();
            }
            catch (AssertionException)
            {
                fail("Assertion failed");
                throw;
            }
        }

         //[Test, Description("Verify User is able to view the same content after a new draft is created with existing draft")]
        public void TC_09_ValidationOfContentAftercreationOfNewDraftWithExistingContent()
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
                createDraft.CreateDraft();
                System.Threading.Thread.Sleep(15000);
                System.Threading.Thread.Sleep(8000);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickNotifications();
                // createDraft.ClikOnBackdrop();
                String path1 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path1, "Creating Blank Draft Named ** " + draftName + "");
                addProject.BackToProject();
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                System.Threading.Thread.Sleep(5000);
                auth.LeftDraftDropDown(draftName);
                System.Threading.Thread.Sleep(5000);
                IWebElement framel = auth.EnterIntoLeftFrame();
                driver.SwitchTo().Frame(framel);
                System.Threading.Thread.Sleep(5000);
                driver.SwitchTo().ActiveElement();
                auth.ClickGdocLeft();
                driver.SwitchTo().ActiveElement().SendKeys("SELENIUM_TEST_123" + Keys.Enter + "<br></br><a></a>" + Keys.Enter + "<dw-image>5a719f8b1d0d3a3450aee4bf</dw-image>");
                System.Threading.Thread.Sleep(15000);
                driver.SwitchTo().DefaultContent();
                auth.RightDraftDropDown(draftName);
                System.Threading.Thread.Sleep(5000);
                String path2 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path2, "Edited Blank Draft in GDOC Left");
                System.Threading.Thread.Sleep(5000);
                createDraft.ClickNewDraft();
                System.Threading.Thread.Sleep(5000);
                String draftName1 = createDraft.EnterValidDraftName();
                createDraft.SelectExistingDraft();
                System.Threading.Thread.Sleep(5000);
                createDraft.CreateDraft();
                System.Threading.Thread.Sleep(15000);
                System.Threading.Thread.Sleep(18000);
                addProject.ClickNotifications();
                // createDraft.ClikOnBackdrop();
                String path3 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path3, "Creating a Existing Draft Named:   " + draftName1 + "");
                addProject.BackToProject();
                System.Threading.Thread.Sleep(5000);
                auth.LeftDraftDropDown(draftName1);
                System.Threading.Thread.Sleep(5000);
                auth.RightDraftDropDown(draftName1);
                System.Threading.Thread.Sleep(5000);
                String path4 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path4, "Content of the exisiting Draft:  " + draftName1 + " in Gdoc Left Based on Draft: " + draftName + " ");
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
