using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using AventStack.ExtentReports;

namespace DocWorksQA.Tests
{
    [TestFixture, Category("Authoring Screen Enhancements")]
    [Parallelizable]
    class TC_15_ValidateScreenEnhancementsWhenUserEditsBlankDraftContent : BeforeTestAfterTest
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
        [Test, Description("Verify User is able to edit the Blank draft content in Left side GDOC")]
        public void TC_01_ValidateScreenEnhancementsWhenUserEditsBlankContentInLeftGdoc()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                System.Threading.Thread.Sleep(5000);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                //addProject.ClickAddProject();
                //String expected = addProject.EnterProjectTitle();
                //addProject.SelectContentType("Manual");
                //addProject.SelectSourceControlProviderType("GitLab");
                //addProject.SelectRepository("Docworks");
                //addProject.EnterPublishedPath("Publishing path to create project");
                //addProject.EnterDescription("This is to create Project");
                //addProject.ClickCreateProject();
                //addProject.ClickNotifications();
                //String status = addProject.GetNotificationStatus();
                //addProject.SuccessScreenshot("Project Created Title");
                //VerifyText(test, "creating a project " + expected + " is successful", status, "Project Created Successfully", "Project is not created with status: " + status + "");
                //addProject.ClickDashboard();
                //addProject.SearchForProject(expected);
                //String actual = addProject.GetProjectTitle();
                //addProject.SuccessScreenshot("ProjectTitle");
                //VerifyEquals(test, expected, actual, "Created Project Found on Dashboard.", "Created Project Not Available on Dashboard.");
                //CreateDistributionPage distmodule = new CreateDistributionPage(test, driver);
                //distmodule.ClickDistribution();
                //String expected1 = distmodule.EnterDistirbutionName();
                //System.Threading.Thread.Sleep(75000);
                //distmodule.SelectBrach("DocworksManual3");
                //distmodule.EnterTocPath();
                //distmodule.EnterDescription("This is to create a distribution With TOC Path");
                //distmodule.ClickCreateDistribution();
                //addProject.ClickNotifications();
                //String status1 = addProject.GetNotificationStatus();
                //addProject.SuccessScreenshot("Distribution got Created successfully With TOC Path");
                //VerifyText(test, "creating distribution " + expected1 + " in " + expected + " is successful", status1, "Distribution is Created For GitLab TOC with status:" + status1 + "", "Distribution is not created For GitLab TOC with status: " + status1 + "");
                //addProject.ClickDashboard();
                addProject.SearchForProject("SELENIUM_B7");
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
                createDraft.ClickOnUnityManualNode();
                createDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                createDraft.ClickOnBlankDraft();
                createDraft.CreateDraft();
                addProject.ClickNotifications();
                String status2 = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Blank Draft got Created Successfully");
                VerifyText(test, "creating a draft " + draftName + " in UnityManual is successful", status2, "Draft: " + draftName + " is Created with status:" + status2 + "", "Draft is not created with status: " + status2 + "");
                addProject.BackToProject();
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test, driver);
                auth.LeftDraftDropDown(draftName);
                IWebElement framel = auth.EnterIntoLeftFrame();
                driver.SwitchTo().Frame(framel);
                driver.SwitchTo().ActiveElement();
                auth.ClickGdocLeft();
                driver.SwitchTo().ActiveElement().SendKeys("SELENIUM_TEST_123");
                System.Threading.Thread.Sleep(15000);
                addProject.SuccessScreenshot("Editing Existing Draft in GDOC Left");
                driver.SwitchTo().DefaultContent();
                auth.RightDraftDropDown(draftName);
                System.Threading.Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                throw;
            }
        }
        [Test, Description("Verify User is Able to view changes made of Blank Draft in Left GDOC are reflected in Right Side Tabs")]
        public void TC_02_ValidationWhenEditedBlankDraftInLeftGDocGetsReflectedInRightSideTabs()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                String expected = "SELENIUM_TEST_123";
                AddProjectPage addProject = new AddProjectPage(test, driver);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test, driver);
                addProject.SuccessScreenshot("Verifying Edited Draft Contains String: " + expected + " in GDOC Right");
                auth.HtmlRightTab();
                addProject.SuccessScreenshot("Verifying Edited Draft Contains String: " + expected + " in HTML Right");
                auth.MDRightTab();
                addProject.SuccessScreenshot("Verifying Edited Draft Contains String: " + expected + " in MD Right");
                auth.PreviewRightTab();
                addProject.SuccessScreenshot("Verifying Edited Draft  Contains String: " + expected + "in Preview Right");
                auth.GdocRightTab();
            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                throw;
            }
        }
        [Test, Description("Verify User is able to edit the Blank draft content in Right side GDOC")]
        public void TC_03_ValidationOfScreenEnhancementsUserEditsBlankContentInRightGdoc()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                createDraft.ClickOnBlankDraft();
                createDraft.CreateDraft();
                AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.ClickNotifications();
                String status2 = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Blank Draft got Created Successfully");
                VerifyText(test, "creating a draft " + draftName + " in UnityManual is successful", status2, "Draft: " + draftName + " is Created with status:" + status2 + "", "Draft is not created with status: " + status2 + "");
                addProject.BackToProject();
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test, driver);
                auth.RightDraftDropDown(draftName);
                IWebElement framel = auth.EnterIntoRightFrame();
                driver.SwitchTo().Frame(framel);
                System.Threading.Thread.Sleep(5000);
                driver.SwitchTo().ActiveElement();
                auth.ClickGdocRight();
                driver.SwitchTo().ActiveElement().SendKeys("SELENIUM_TEST_123");
                System.Threading.Thread.Sleep(15000);
                addProject.SuccessScreenshot("Editing Existing Draft in GDOC Right");
                driver.SwitchTo().DefaultContent();
                auth.LeftDraftDropDown(draftName);
                System.Threading.Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                throw;
            }
        }
        [Test, Description("Verify User is Able to view changes made of Blank Draft in Right GDOC are reflected in Left Side Tabs")]
        public void TC_04_ValidationWhenUserEditedRightGDocGetsReflectedInLeftSideTabs()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                String expected = "SELENIUM_TEST_123";
                AddProjectPage addProject = new AddProjectPage(test, driver);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test, driver);
                addProject.SuccessScreenshot("Verifying Edited Draft Contains String: " + expected + " in GDOC Left");
                auth.HtmlLeftTab();
                addProject.SuccessScreenshot("Verifying Edited Draft Contains String: " + expected + " in HTML Left");
                auth.MDLeftTab();
                addProject.SuccessScreenshot("Verifying Edited Draft Contains String: " + expected + " in MD Left");
                auth.PreviewLeftTab();
                addProject.SuccessScreenshot("Verifying Edited Draft  Contains String: " + expected + "in Preview Left");
                auth.GdocLeftTab();
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