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

    [TestFixture, Category("Upload CodeBlock")]
    [Parallelizable]
    class GitLab_ValidateUserIsAbleToReplaceCodeBlock : BeforeTestAfterTest
    {
        private static IWebDriver driver;
        private ExtentTest test;
        String projectName;
        String distributionName;


        [OneTimeSetUp]
        public void AddPProjectModule()
        {
            projectName = new CreateProjectsApi().CreateGitHubProject();
            distributionName = new CreateDistributionsApi().CreateGitHubDistribution(projectName)["distributionName"];
            driver = new DriverFactory().Create();
            new LoginPage(driver).Login();
            System.Threading.Thread.Sleep(5000);
        }

        [Test, Description("Verify User is able to replace an Image")]
        public void ValidateUserIsAbleToReplaceCodeBlock()
        {
            try
            {

                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage project = new AddProjectPage(test, driver);
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test, driver);
                auth.ClickMedia();
                auth.ClickCodeBlocksTab();
                String CodeBlockName = auth.UploadCodeBlock();
                project.ClickNotifications();
                String status1 = project.GetNotificationStatus();
                project.SuccessScreenshot("CodeBlock Got Uploaded Successfully");
                VerifyText(test, "upsert asset " + CodeBlockName + " is successful", status1, "CodeBlock: " + CodeBlockName + " is Uploaded with status:" + status1 + "", "CodeBlock is not Uploaded with status: " + status1 + "");
                project.BackToProject();
                project.ClickDashboard();
                project.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
                createDraft.ClickOnUnityManualNode();
                auth.ClickInsertCodeBlock();
                auth.EnterAssetName(CodeBlockName);
                project.SuccessScreenshot("Verifying Uploaded CodeBlocks in search Assets");
                String ReplaceCodeBlock = auth.ReplaceTheCodeblockwithNewCodeblock(CodeBlockName);
                auth.CloseUploadPage();
                project.ClickNotifications();
                String status2 = project.GetNotificationStatus();
                project.SuccessScreenshot("Replaced Image Got uploaded Successfully");
                VerifyText(test, "upsert asset " + ReplaceCodeBlock + " is successful", status2, "CodeBlock: " + ReplaceCodeBlock + " is Uploaded with status:" + status2 + "", "CodeBlock is not Uploaded with status: " + status2 + "");
                project.BackToProject();
                auth.ClickInsertCodeBlock();
                auth.EnterAssetName(ReplaceCodeBlock);
                project.SuccessScreenshot("Verifying the Codeblock got replaced Succesfully");
                db.FindAssetAndDelete(ReplaceCodeBlock);


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
