using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using AventStack.ExtentReports;

namespace DocWorksQA.Tests
{
    [TestFixture, Category("Create Distribution")]
    [Parallelizable]
    class TC_11_ValidateDistributionNameLengthWithLessThan5Characters : BeforeTestAfterTest
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
        [Test, Description("Verify When User sends an Invalid Length to Distribution Name Then it throws an Error Message")]
        public void TC11_ValidateDistributionNamelengthWithLessThan5Characters()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.ClickAddProject();
                String expected = addProject.EnterProjectTitle();
                addProject.SelectContentType("Manual");
                addProject.SelectSourceControlProviderType("Ono");
                addProject.EnterMercurialRepoPath();
                addProject.EnterPublishedPath("Publishing path to create project");
                addProject.EnterDescription("This is to create Project");
                addProject.ClickCreateProject();
                addProject.ClickNotifications();
                String status = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Project Created Title");
                VerifyText(test, "creating a project " + expected + " is successful", status, "Project Created Successfully", "Project is not created with status: " + status + "");
                addProject.ClickDashboard();
                addProject.SearchForProject(expected);
                String actual = addProject.GetProjectTitle();
                addProject.SuccessScreenshot("ProjectTitle");
                VerifyEquals(test, expected, actual, "Created Project Found on Dashboard.", "Created Project Not Available on Dashboard.");
                CreateDistributionPage distmodule = new CreateDistributionPage(test, driver);
                distmodule.ClickDistribution();
                String expected1 = "Please enter at least 5 characters.";
                distmodule.EnterInvalidnNameLength();
                distmodule.EnterDescription("Description");
                String actual1 = distmodule.GetText(distmodule.INVALID_TITLE_LENGTH);
                addProject.SuccessScreenshot("Validating Distribution Name Length");
                VerifyEquals(test, expected1, actual1, "Validation of Length Constraints for Distribution Name Field is successful", "Validation of Length Constraints for Distribution Name Field is Not successful");
            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                throw;
            }
        }

    }
}
