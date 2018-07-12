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
    class GitLab_ValidateUserIsAbleToReplaceImage : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;
        String projectName;
        String distributionName;


        [OneTimeSetUp]
        public void AddPProjectModule()
        {
            projectName = new CreateProjectsApi().CreateGitLabProject();
            distributionName = new CreateDistributionsApi().CreateGitLabDistribution(projectName)["distributionName"];
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);
        }
       //[Test, Description("Verify User is able to replace an Image")]
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
                project.SuccessScreenshot("Select an Image from Uploads");
                auth.SelectImageFromUpload(ImageName);
                createDraft.ClickNewDraft();
                String draftName = createDraft.EnterValidDraftName();
                createDraft.ClickOnBlankDraft();
                createDraft.CreateDraft();
                project.ClickNotifications();
                String status3 = project.GetNotificationStatus();
                project.SuccessScreenshot("Blank Draft got Created Successfully");
                VerifyText(test, "creating a draft " + draftName + " in UnityManual is successful", status3, "Draft: " + draftName + " is Created with status:" + status3 + "", "Draft is not created with status: " + status3 + "");
                project.BackToProject();
                auth.LeftDraftDropDown(draftName);
                IWebElement framel = auth.EnterIntoLeftFrame();
                driver.SwitchTo().Frame(framel);
                System.Threading.Thread.Sleep(5000);
                driver.SwitchTo().ActiveElement();
                auth.ClickGdocLeft();
                driver.SwitchTo().ActiveElement().SendKeys(Keys.Control + "v");
                project.SuccessScreenshot("pasting the image Asset Id in Gdoc");
                driver.SwitchTo().DefaultContent();
                auth.PreviewLeftTab();
                project.SuccessScreenshot("Verifying the image got reflected in Preview Left");
                auth.GdocLeftTab();
                auth.ClickInsertImage();
                auth.EnterAssetName(ImageName);
                auth.ReplaceTheImage();
                project.SuccessScreenshot("Verifying the image got replaced with new Image");
                auth.SelectImageFromUpload(ImageName);
                auth.LeftDraftDropDown(draftName);
                project.SuccessScreenshot("The same image Url in Gdoc Which was added earlier");
                driver.SwitchTo().DefaultContent();
                auth.PreviewLeftTab();
                project.SuccessScreenshot("Verifying the image got replaced Succesfully in Preview Left");
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
