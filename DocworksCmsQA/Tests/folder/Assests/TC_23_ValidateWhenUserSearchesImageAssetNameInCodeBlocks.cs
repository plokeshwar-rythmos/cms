using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using System.Text;
using AventStack.ExtentReports;


namespace DocWorksQA.Tests
{

    [TestFixture, Category("Upload Images")]
    [Parallelizable]
    class TC_23_ValidateWhenUserSearchesImageAssetNameInCodeBlocks : BeforeTestAfterTest
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
          [Test, Description("Verify User is not able to get the Image When searched by AssetId of Image in CodeBlocks Tab")]
        public void TC23_ValidateWhenUserSearchesImageAssetIdInCodeBlocks()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                String projectName = CreateDistribution("Mercurial", test, driver);
                AddProjectPage project = new AddProjectPage(test, driver);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test, driver);
                auth.ClickMedia();
                String ImageName = auth.UploadImage();
                project.ClickNotifications();
                String status2 = project.GetNotificationStatus();
                project.SuccessScreenshot("Image Got Uploaded Successfully");
                VerifyText(test, "upsert asset " + ImageName + " is successful", status2, "Image: " + ImageName + " is Uploaded with status:" + status2 + "", "Image is not Uploaded with status: " + status2 + "");
                project.BackToProject();
                project.ClickDashboard();
                project.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
                createDraft.ClickOnUnityManualNode();
                auth.ClickInsertImage();
                auth.EnterAssetName(ImageName);
                project.SuccessScreenshot("Verifying Uploaded Image in Search Asset");
                auth.SelectImageFromUpload(ImageName);
                auth.ClickInsertCodeBlock();
                auth.SearchAssetName();
                project.SuccessScreenshot("Verifying the image Url pasted in CodeBlocks does not show any Uploads");
                auth.CloseUploadPage();
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
