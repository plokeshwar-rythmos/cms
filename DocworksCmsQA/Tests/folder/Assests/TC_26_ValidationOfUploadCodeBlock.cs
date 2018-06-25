using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using System.Text;
using AventStack.ExtentReports;


namespace DocWorksQA.Tests
{

    [TestFixture, Category("Upload CodeBlocks")]
    [Parallelizable]
    class TC_26_ValidationOfUploadCodeBlock : BeforeTestAfterTest
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
       [Test, Description("Verify User is able to Upload CodeBlocks in Media Screen")]
        public void TC26_ValidationOfUploadCodeBlock()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                Console.WriteLine("Entered into testcase");
                AuthoringScreenEnhancements auth = new AuthoringScreenEnhancements(test, driver);
                auth.ClickMedia();
                auth.ClickCodeBlocksTab();
               String CodeBlockName = auth.UploadCodeBlock();
                AddProjectPage project = new AddProjectPage(test, driver);
                project.ClickNotifications();
                String status2 = project.GetNotificationStatus();
                project.SuccessScreenshot("CodeBlock Got Uploaded Successfully");
                VerifyText(test, "upsert asset " + CodeBlockName + " is successful", status2, "CodeBlock: " + CodeBlockName + " is Uploaded with status:" + status2 + "", "CodeBlock is not Uploaded with status: " + status2 + "");
                project.BackToProject();
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
