using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using System.Text;
using AventStack.ExtentReports;
using DocworksCmsQA.DockworksApi;

namespace DocWorksQA.Tests
{

    [TestFixture, Category("Upload Images")]
    [Parallelizable]
    class Mercurial_ValidateUserIsAbleToReplaceImage : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;
        String projectName;
        String distributionName;


        [OneTimeSetUp]
        public void AddPProjectModule()
        {

            projectName = new CreateProjectsApi().CreateMercurialProject();
            distributionName = new CreateDistributionsApi().CreateOnoDistribution(projectName)["distributionName"];
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);
        }

        [Test, Description("Verify User is able to replace an Image")]
        public void ValidateUserIsAbleToReplaceImage()
        {
            try
            {

                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage project = new AddProjectPage(test, driver);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test, driver);
                auth.ClickMedia();
                String ImageName = auth.UploadImage();
                project.ClickNotifications();
                String status1 = project.GetNotificationStatus();
                project.SuccessScreenshot("Image Got Uploaded Successfully");
                VerifyText(test, "upsert asset " + ImageName + " is successful", status1, "Image: " + ImageName + " is Uploaded with status:" + status1 + "", "Image is not Uploaded with status: " + status1 + "");
                project.BackToProject();
                project.ClickDashboard();
                project.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
                createDraft.ClickOnUnityManualNode();
                auth.ClickInsertImage();
                auth.EnterAssetName(ImageName);
                project.SuccessScreenshot("Verifying Uploaded Image in search Assets");
                String ReplaceImage = auth.ReplaceTheImagewithNewimage(ImageName);
                auth.CloseUploadPage();
                project.ClickNotifications();
                String status2 = project.GetNotificationStatus();
                project.SuccessScreenshot("Replaced Image Got uploaded Successfully");
                VerifyText(test, "upsert asset " + ReplaceImage + " is successful", status2, "Image: " + ReplaceImage + " is Uploaded with status:" + status2 + "", "Image is not Uploaded with status: " + status2 + "");
                project.BackToProject();
                auth.ClickInsertImage();
                auth.EnterAssetName(ReplaceImage);
                project.SuccessScreenshot("Verifying the image got replaced Succesfully");
                db.FindAssetAndDelete(ReplaceImage);
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
            db.FindDistributionAndDelete(distributionName);
            db.FindProjectAndDelete(projectName);
        }
    }
}
