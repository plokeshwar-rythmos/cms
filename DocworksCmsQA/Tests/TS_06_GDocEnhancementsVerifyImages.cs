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
   // [TestFixture]
    class TS_06_GDocEnhancementsVerifyImages : BeforeTestAfterTest
    {
        private static IWebDriver driver;
       static string result;
        private static string uid = ConfigurationHelper.Get<String>("UserName");
        private static string pwd = ConfigurationHelper.Get<String>("password");

      //  [OneTimeSetUp]
        public void GDocEnhancementsVerifyImages()
        {
            driver = new DriverFactory().Create();
            try
            {
              //  String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                System.Threading.Thread.Sleep(3000);
                //CreateTest(TestName);
                LoginPage login = new LoginPage(driver);
                login.EnterUserName(uid);
                login.EnterPassword(pwd);
                System.Threading.Thread.Sleep(5000);
                login.ClickLogin();
               // String path = TakeScreenshot(driver);
                //login.SuccessScreenshot(path, "Login Got Successful");
                System.Threading.Thread.Sleep(5000);
            }
            catch (AssertionException)
            {
              Fail("Assertion failed");
                throw;
            }
        }
       // [Test, Description("Verify User is able to Upload an Image in Media Screen")]
        public void TC_01_ValidationOfUploadImage()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                Console.WriteLine("Entered into testcase");
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                System.Threading.Thread.Sleep(8000);
                auth.ClickMedia();
                System.Threading.Thread.Sleep(8000);
                auth.UploadImage();
                System.Threading.Thread.Sleep(2000);
                String path1 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path1, "Uploaded New Image");
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickNotifications();
                System.Threading.Thread.Sleep(5000);
                String str = addProject.GetNotificationName();
                result = str.Split(new[] { ':' }).Skip(1).FirstOrDefault();
                Console.WriteLine("&&&&&"+result);
                String path2 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path2, "Uploaded New Image"+result+" with Notification");
                addProject.BackToProject();
                System.Threading.Thread.Sleep(2000);
                auth.ClickDashboard();
            }
            catch (AssertionException)
            {
                Fail("Assertion failed");
                throw;
            }
        }

       // [Test, Description("Verify user is able to do GDoc Enhancement for Uploaded Image")]
        public void TC_02_ValidateGdocEnhancementsForUploadOfImage()
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
                System.Threading.Thread.Sleep(5000);
                CreateDistributionPage distmodule = new CreateDistributionPage(driver);
                System.Threading.Thread.Sleep(3000);
                distmodule.SearchForProject("TestQA_CK");
               System.Threading.Thread.Sleep(3000);
                CreateDraftPage createDraft = new CreateDraftPage(driver);
                System.Threading.Thread.Sleep(8000);
                createDraft.CLICKOPENPROJECT();
                System.Threading.Thread.Sleep(10000);
                createDraft.ClikOnBackdrop();
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                System.Threading.Thread.Sleep(8000);
                auth.ClickInsertImage();
                System.Threading.Thread.Sleep(25000);
                Console.WriteLine("*******HERE iS RESULT"+result);
               String str = result.Split(new[] { ' ' }).Skip(2).FirstOrDefault();
                Console.WriteLine("*******HERE iS RESULT"+str);
                auth.EnterAssetName(str);
                System.Threading.Thread.Sleep(25000);
                String path2 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path2, "Verifying Uploaded Image");
                auth.SelectImageFromUpload(result);
                CreateDraftPage createDraft1 = new CreateDraftPage(driver);
                System.Threading.Thread.Sleep(5000);
                createDraft1.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                System.Threading.Thread.Sleep(5000);
                createDraft1.ClickOnBlankDraft();
                System.Threading.Thread.Sleep(5000);
                String path3 = TakeScreenshot(driver);
                createDraft1.SuccessScreenshot(path3, "Creating Blank Draft: "+draftName+"");
                createDraft.CreateDraft();
                System.Threading.Thread.Sleep(15000);
                System.Threading.Thread.Sleep(5000);
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
                System.Threading.Thread.Sleep(5000);
                String path5 = TakeScreenshot(driver);
                auth1.SuccessScreenshot(path5, "pasting the image Url in Gdoc");
                driver.SwitchTo().DefaultContent();
                System.Threading.Thread.Sleep(5000);
                auth1.PreviewLeftTab();
                String path6 = TakeScreenshot(driver);
                auth1.SuccessScreenshot(path6, "Verifying the image got reflected in Preview Left");
                System.Threading.Thread.Sleep(5000);
                auth.GdocLeftTab();
               // auth.ClickDashboard();

            }
            catch (AssertionException)
            {
                Fail("Assertion failed");
                throw;
            }
        }

      //  [Test, Description("Verify User is not able to get the Image When searched by AssetId of Image in CodeBlocks Tab")]
        public void TC_03_ValidateWhenUserSearchesImageAssetIdInCodeBlocks()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
               /* CreateDistributionPage distmodule = new CreateDistributionPage(driver);
                System.Threading.Thread.Sleep(15000);
                distmodule.SearchForProject("Testing_Proj");
                CreateDraftPage createDraft = new CreateDraftPage(driver);
                System.Threading.Thread.Sleep(8000);
                createDraft.CLICKOPENPROJECT();
                System.Threading.Thread.Sleep(8000);
                //driver.Navigate().Refresh();
                createDraft.ClikOnBackdrop();
                System.Threading.Thread.Sleep(5000);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                String path1 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path1, "Verifying Uploaded Image");*/
                System.Threading.Thread.Sleep(5000);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                auth.ClickInsertImage();
                System.Threading.Thread.Sleep(25000);
                Console.WriteLine("*******HERE iS RESULT" + result);
                String str = result.Split(new[] { ' ' }).Skip(2).FirstOrDefault();
                Console.WriteLine("*******HERE iS RESULT" + str);
                auth.EnterAssetName(str);
                System.Threading.Thread.Sleep(25000);
                String path3 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path3, "Verifying the uploaded image AssetID");
                auth.SelectImageFromUpload(result);
                auth.ClickInsertCodeBlock();
                System.Threading.Thread.Sleep(5000);
                auth.SearchAssetID();
                Console.WriteLine("Entered AssetID of Image");
                System.Threading.Thread.Sleep(5000);
                String path4 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path4, "Verifying the image Url pasted in CodeBlocks does not show any Uploads");
                auth.CloseUploadPage();
                System.Threading.Thread.Sleep(5000);
                //auth.ClickDashboard();
            }
            catch (AssertionException)
            {
               Fail("Assertion failed");
                throw;
            }
        }

     //   [Test, Description("Verify User is able to replace an Image")]
        public void TC_04_ValidateUserIsAbleToReplaceImage()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                //CreateDistributionPage distmodule = new CreateDistributionPage(driver);
                //System.Threading.Thread.Sleep(5000);
                //distmodule.SearchForProject("TestQA_CK");
                CreateDraftPage createDraft = new CreateDraftPage(driver);
                //System.Threading.Thread.Sleep(8000);
                //createDraft.CLICKOPENPROJECT();
                //System.Threading.Thread.Sleep(8000);
                //createDraft.ClikOnBackdrop();
                //System.Threading.Thread.Sleep(5000);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                auth.ClickInsertImage();
                System.Threading.Thread.Sleep(15000);
                Console.WriteLine("*******HERE iS RESULT" + result);
                String str = result.Split(new[] { ' ' }).Skip(2).FirstOrDefault();
                Console.WriteLine("*******HERE iS RESULT" + str);
                auth.EnterAssetName(str);
                String path1 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path1, "Select an Image from Uploads");
                System.Threading.Thread.Sleep(25000);
                auth.SelectImageFromUpload(result);
                System.Threading.Thread.Sleep(5000);
                createDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                System.Threading.Thread.Sleep(5000);
                createDraft.ClickOnBlankDraft();
                System.Threading.Thread.Sleep(5000);
                String path2 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path2, "Creating Blank Draft: "+draftName+"");
                createDraft.CreateDraft();
                System.Threading.Thread.Sleep(15000);
                System.Threading.Thread.Sleep(5000);
                AddProjectPage addProject = new AddProjectPage(driver);
                addProject.ClickNotifications();
                // createDraft.ClikOnBackdrop();
                String path3 = TakeScreenshot(driver);
                createDraft.SuccessScreenshot(path3, "Created a Draft");
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
                String path4 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path4, "pasting the image Asset Id in Gdoc");
                driver.SwitchTo().DefaultContent();
                System.Threading.Thread.Sleep(5000);
                auth.PreviewLeftTab();
                String path5 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path5, "Verifying the image got reflected in Preview Left");
                auth.GdocLeftTab();
                auth.ClickInsertImage();
                System.Threading.Thread.Sleep(25000);
                Console.WriteLine("*******HERE iS RESULT" + result);
                String str1 = result.Split(new[] { ' ' }).Skip(2).FirstOrDefault();
                Console.WriteLine("*******HERE iS RESULT" + str1);
                auth.EnterAssetName(str1);
                System.Threading.Thread.Sleep(25000);
                auth.ReplaceTheImage(result);
                String path8= TakeScreenshot(driver);
                auth.SuccessScreenshot(path8, "Verifying the image got replaced with new Image");
                auth.SelectImageFromUpload(result);
                 System.Threading.Thread.Sleep(25000);
                auth.LeftDraftDropDown(draftName);
                String path6 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path6, "The same image Url in Gdoc Which was added earlier");
                driver.SwitchTo().DefaultContent();
                auth.PreviewLeftTab();
                String path7 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path7, "Verifying the image got replaced Succesfully in Preview Left");
            }
            catch (AssertionException)
            {
                Fail("Assertion failed");
                throw;
            }
        }
    //    [Test, Description("Verify User is Unable to Upload Invalid Images")]
        public void TC_05_ValidateUploadOfInvalidImages()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                CreateTest(TestName, description);
                Console.WriteLine("Entered into testcase");
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(driver);
                System.Threading.Thread.Sleep(8000);
                auth.ClickMedia();
                System.Threading.Thread.Sleep(9000);
                auth.UploadInvalidImages();
                System.Threading.Thread.Sleep(8000);
                String path1 = TakeScreenshot(driver);
                auth.SuccessScreenshot(path1, "Unable to Upload Image");
                System.Threading.Thread.Sleep(5000);
                auth.ClickDashboard();
            }
            catch (AssertionException)
            {
                Fail("Assertion failed");
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
