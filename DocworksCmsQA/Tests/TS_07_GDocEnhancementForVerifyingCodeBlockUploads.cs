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
    [TestFixture]
    [Parallelizable]
    class TS_07_GDocEnhancementForVerifyingCodeBlockUploads : BeforeTestAfterTest
    {
        static string result;
        private static IWebDriver driver;
        private static string uid = ConfigurationHelper.Get<String>("UserName");
        private static string pwd = ConfigurationHelper.Get<String>("password");

        [OneTimeSetUp]
        public void GDocEnhancementForVerifyingCodeBlockUploads()
        {
            driver = new DriverFactory().Create();
            try
            {
              //  String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                System.Threading.Thread.Sleep(3000);
               // CreateTest(TestName);
                LoginPage login = new LoginPage(driver);
                login.EnterUserName(uid);
                login.EnterPassword(pwd);
                System.Threading.Thread.Sleep(5000);
                login.ClickLogin();
              //  String path = TakeScreenshot(driver);
               // login.SuccessScreenshot(path, "Login Got Successful");
                System.Threading.Thread.Sleep(5000);
            }
            catch (AssertionException)
            {
                fail("Assertion failed");
                throw;
            }
        }
        [Test, Description("Verify User is able to Upload CodeBlocks in Media Screen")]
        public void TC_01_ValidationOfUploadCodeBlock()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                Console.WriteLine("Entered into testcase");
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                System.Threading.Thread.Sleep(5000);
                auth.ClickMedia();
                auth.ClickCodeBlocksTab();
                System.Threading.Thread.Sleep(5000);
                auth.UploadCodeBlock();
                System.Threading.Thread.Sleep(2000);
                String path1 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path1, "Uploaded New CodeBlock");
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(5000);
                String str = addProject.GetNotificationName();
                result = str.Split(new[] { ':' }).Skip(1).FirstOrDefault();
                Console.WriteLine("&&&&&" + result);
                String path2 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path2, "Uploaded New CodeBlock" + result + " with Notification");
                addProject.BackToProject();
                System.Threading.Thread.Sleep(2000);
                auth.ClickDashboard();
            }
            catch (AssertionException)
            {
                fail("Assertion failed");
                throw;
            }
        }
        [Test, Description("Verify User is able to make Gdoc Enhancements for Upploaded CodeBlocks")]
        public void TC_02_ValidateGdocEnhancementInUploadOfCodeBlock()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                //System.Threading.Thread.Sleep(5000);
                AddProjectPage addProject = new AddProjectPage(driver);
                //addProject.ClickAddProject();
                //System.Threading.Thread.Sleep(3000);
                //String expected = addProject.EnterProjectTitle();
                //System.Threading.Thread.Sleep(5000);
                //addProject.ClickContentType();
                //System.Threading.Thread.Sleep(15000);
                //addProject.ClickSourceControlTypeGitLab();
                //System.Threading.Thread.Sleep(25000);
                //addProject.ClickRepository();
                //System.Threading.Thread.Sleep(5000);
                //addProject.EnterPublishedPath("Publishing path to create project");
                //System.Threading.Thread.Sleep(5000);
                //addProject.EnterDescription("This is to create Project");
                //System.Threading.Thread.Sleep(5000);
                //addProject.ClickCreateProject();
                //System.Threading.Thread.Sleep(25000);
                //addProject.ClickNotifications();
                //System.Threading.Thread.Sleep(5000);
                //String status = addProject.GetNotificationStatus();
                //String projectDetails = addProject.GetCreatedProject();
                //String path = TakeScreenshot(driver);
                //addProject.SuccessScreenshot(path, "Project Created Successfully");
                //Assert.IsTrue(VerifyText("Success", status, "Project is Created with status:" + status + "", "Project is not created with status: " + status + ""));
                //addProject.BackToProject();
                //System.Threading.Thread.Sleep(15000);
                //CreateDistributionPage distmodule = new CreateDistributionPage(driver);
                //System.Threading.Thread.Sleep(3000);
                //distmodule.SearchForProject(expected);
                //System.Threading.Thread.Sleep(3000);
                //distmodule.ClickDistribution();
                //System.Threading.Thread.Sleep(8000);
                //String expected1 = distmodule.EnterDistirbutionName();
                //System.Threading.Thread.Sleep(75000);
                //distmodule.ClickBranchWithTOC();
                //System.Threading.Thread.Sleep(5000);
                //distmodule.EnterTocPath();
                //distmodule.EnterDescription("This is to create a distribution");
                //System.Threading.Thread.Sleep(5000);
                //distmodule.ClickCreateDistribution();
                //System.Threading.Thread.Sleep(40000);
                //addProject.ClickNotifications();
                //System.Threading.Thread.Sleep(15000);
                //String status1 = addProject.GetNotificationStatus();
                //String path1 = TakeScreenshot(driver);
                //addProject.SuccessScreenshot(path1, "Distribution got Created successfully");
                //Assert.IsTrue(VerifyText("Success", status1, "Distribution is Created with status:" + status1 + "", "Distribution is not created with status: " + status1 + ""));
                //addProject.BackToProject();
                CreateDistributionPage distmodule = new CreateDistributionPage(driver);
                System.Threading.Thread.Sleep(5000);
                distmodule.SearchForProject("TestQA_CK");
                CreateDraftPage createDraft = new CreateDraftPage(driver);
                System.Threading.Thread.Sleep(8000);
                createDraft.CLICKOPENPROJECT();
                System.Threading.Thread.Sleep(8000);
                createDraft.ClikOnBackdrop();
                System.Threading.Thread.Sleep(5000);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                auth.ClickInsertCodeBlock();
                System.Threading.Thread.Sleep(25000);
                Console.WriteLine("*******HERE iS RESULT" + result);
                String str = result.Split(new[] { ' ' }).Skip(2).FirstOrDefault();
                Console.WriteLine("*******HERE iS RESULT" + str);
                auth.EnterAssetName(str);
                System.Threading.Thread.Sleep(25000);
                String path1 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path1, "Verifying Uploaded CodeBlocks");
                System.Threading.Thread.Sleep(5000);
                auth.SelectCodeBlockFromUpload(result);
                CreateDraftPage createDraft1 = new CreateDraftPage(driver);
                System.Threading.Thread.Sleep(5000);
                createDraft1.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                System.Threading.Thread.Sleep(5000);
                createDraft1.ClickOnBlankDraft();
                System.Threading.Thread.Sleep(5000);
                String path2 = TakeScreenshot(driver);
                createDraft1.SuccessScreenshot(path2, "Creating Blank Draft: "+ draftName +"");
                createDraft.CreateDraft();
                System.Threading.Thread.Sleep(15000);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(5000);
                addProject.BackToProject();
                AuthoringScreenEnhancements auth1 = new AuthoringScreenEnhancements(driver);
                System.Threading.Thread.Sleep(5000);
                auth1.LeftDraftDropDown(draftName);
                System.Threading.Thread.Sleep(5000);
                IWebElement framel = auth1.EnterIntoLeftFrame();
                driver.SwitchTo().Frame(framel);
                System.Threading.Thread.Sleep(5000);
                driver.SwitchTo().ActiveElement();
                auth1.ClickGdocLeft();
                driver.SwitchTo().ActiveElement().SendKeys(Keys.Control + "v");
                System.Threading.Thread.Sleep(15000);
                String path3 = TakeScreenshot(driver);
                auth1.SuccessScreenshot(path3, "pasting the CodeBlock Url in Gdoc");
                driver.SwitchTo().DefaultContent();
                System.Threading.Thread.Sleep(5000);
                auth1.PreviewLeftTab();
                String path4 = TakeScreenshot(driver);
                auth1.SuccessScreenshot(path4, "Verifying the Code got reflected in Preview Left");
                System.Threading.Thread.Sleep(5000);
                auth.GdocLeftTab();
               // auth.ClickDashboard();
            }
            catch (AssertionException)
            {
                fail("Assertion failed");
                throw;
            }
        }
        [Test, Description("Verify User is Unable to get the codeBlock when searched with the AssetId of CodeBlock in Images Tab")]
        public void TC_03_ValidateWhenUserSearchesCodeBlockAssetIdInImages()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                /*CreateDistributionPage distmodule = new CreateDistributionPage(driver);
                System.Threading.Thread.Sleep(5000);
                distmodule.SearchForProject("Testing_Proj");
                CreateDraftPage createDraft = new CreateDraftPage(driver);
                System.Threading.Thread.Sleep(8000);
                createDraft.CLICKOPENPROJECT();
                System.Threading.Thread.Sleep(8000);
                //driver.Navigate().Refresh();
                createDraft.ClikOnBackdrop();
                System.Threading.Thread.Sleep(5000);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                auth.ClickInsertCodeBlock();
                String path1 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path1, "Verifying Uploaded CodeBlock");*/
                System.Threading.Thread.Sleep(5000);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                auth.ClickInsertCodeBlock();
                System.Threading.Thread.Sleep(25000);
                Console.WriteLine("*******HERE iS RESULT" + result);
                String str = result.Split(new[] { ' ' }).Skip(2).FirstOrDefault();
                Console.WriteLine("*******HERE iS RESULT" + str);
                auth.EnterAssetName(str);
                System.Threading.Thread.Sleep(25000);
                String path3 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path3, "Verifying the uploaded CodeBlock AssetID");
                auth.SelectCodeBlockFromUpload(result);
                auth.ClickInsertImage();
                System.Threading.Thread.Sleep(5000);
                auth.SearchAssetID();
                Console.WriteLine("Entered AssetID of CoeBlock in Images");
                System.Threading.Thread.Sleep(5000);
                String path4 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path4, "Verifying the CodeBlock  Url pasted in Images does not show any Uploads");
                auth.CloseUploadPage();
                System.Threading.Thread.Sleep(5000);
                //auth.ClickDashboard();
            }
            catch (AssertionException)
            {
                fail("Assertion failed");
                throw;
            }
        }

        [Test, Description("Verify User Is able to Replace the code blocks in media screen")]
        public void TC_04_ValidateUserIsAbleToReplaceCodeBlock()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                //CreateDistributionPage distmodule = new CreateDistributionPage(driver);
                //System.Threading.Thread.Sleep(15000);
                //distmodule.SearchForProject("Testing_Proj");
                //CreateDraftPage createDraft = new CreateDraftPage(driver);
                //System.Threading.Thread.Sleep(8000);
                //createDraft.CLICKOPENPROJECT();
                //System.Threading.Thread.Sleep(8000);
                //System.Threading.Thread.Sleep(5000);
                //createDraft.ClikOnBackdrop();
                //System.Threading.Thread.Sleep(5000);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                auth.ClickInsertCodeBlock();
                System.Threading.Thread.Sleep(15000);
                Console.WriteLine("*******HERE iS RESULT" + result);
                String str = result.Split(new[] { ' ' }).Skip(2).FirstOrDefault();
                Console.WriteLine("*******HERE iS RESULT" + str);
                auth.EnterAssetName(str);
                String path1 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path1, "Select a CodeBlock from Uploads");
                System.Threading.Thread.Sleep(25000);
                auth.SelectCodeBlockFromUpload(result);
                CreateDraftPage createDraft = new CreateDraftPage(driver);
                createDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                System.Threading.Thread.Sleep(5000);
                createDraft.ClickOnBlankDraft();
                System.Threading.Thread.Sleep(5000);
                createDraft.CreateDraft();
                System.Threading.Thread.Sleep(15000);
                System.Threading.Thread.Sleep(5000);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickNotifications();
                String path2 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path2, "Created a Draft: "+draftName+"");
                addProject.BackToProject();
                auth.LeftDraftDropDown(draftName);
                System.Threading.Thread.Sleep(5000);
                IWebElement framel = auth.EnterIntoLeftFrame();
                driver.SwitchTo().Frame(framel);
                System.Threading.Thread.Sleep(5000);
                driver.SwitchTo().ActiveElement();
                auth.ClickGdocLeft();
                driver.SwitchTo().ActiveElement().SendKeys(Keys.Control + "v");
                System.Threading.Thread.Sleep(15000);
                String path3 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path3, "pasting the CodeBlock Url in Gdoc");
                driver.SwitchTo().DefaultContent();
                System.Threading.Thread.Sleep(5000);
                auth.PreviewLeftTab();
                String path4 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path4, "Verifying the CodeBlock got reflected in Preview Left");
                auth.GdocLeftTab();
                auth.ClickInsertCodeBlock();
                System.Threading.Thread.Sleep(25000);
                Console.WriteLine("*******HERE iS RESULT" + result);
                String str1 = result.Split(new[] { ' ' }).Skip(2).FirstOrDefault();
                Console.WriteLine("*******HERE iS RESULT" + str1);
                auth.EnterAssetName(str1);
                System.Threading.Thread.Sleep(25000);
                auth.ReplaceTheImage(result);
                String path8 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path8, "Verifying the CodeBlock got replaced with new CodeBlock");
                auth.SelectCodeBlockFromUpload(result);
                System.Threading.Thread.Sleep(25000);
                auth.LeftDraftDropDown(draftName);
                String path6 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path6, "The same CodeBlock AssetId in Gdoc Which was added earlier");
                driver.SwitchTo().DefaultContent();
                auth.PreviewLeftTab();
                String path7 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path7, "Verifying the CodeBlock got replaced successfully in Preview Left");
            }
            catch (AssertionException)
            {
                fail("Assertion failed");
                throw;
            }
        }
        [Test, Description("Verify User is unable to upload Invalid Code Blocks")]
        public void TC_05_ValidateUploadOfInvalidCodeBlock()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                System.Threading.Thread.Sleep(8000);
                auth.ClickMedia();
                System.Threading.Thread.Sleep(8000);
                auth.ClickCodeBlocksTab();
                System.Threading.Thread.Sleep(8000);
                auth.UploadInvalidCodeBlock();
                System.Threading.Thread.Sleep(8000);
                String path1 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path1, "Unable to Upload CodeBlock");
                System.Threading.Thread.Sleep(5000);
                auth.ClickDashboard();
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
