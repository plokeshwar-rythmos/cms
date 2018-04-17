﻿using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using AventStack.ExtentReports;

namespace DocWorksQA.Tests
{
    [TestFixture, Category("Create Distribution")]
    [Parallelizable]
    class TC_10_ValidateCreateDistributionForMercurialProjectWithAllFields : BeforeTestAfterTest
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

        [Test, Description("Verify User is able to add Distribution for the Mercurial Project with TOC")]
        public void TC10A_ValidateCreateDistributionForMercurialProjectWithTOC()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                String projectName = CreateMercurialProject(test, driver);
                AddProjectPage project = new AddProjectPage(test, driver);
                project.ClickDashboard();
                project.SearchForProject(projectName);
                CreateDistributionPage distribution = new CreateDistributionPage(test, driver);
                distribution.ClickDistribution();
                String expected1 = distribution.EnterDistirbutionName();
                System.Threading.Thread.Sleep(5000);
                distribution.EnterBranchForMercurial("DocworksManual3");
                distribution.EnterTocPath();
                distribution.EnterDescription("This is to create a distribution With TOC");
                distribution.ClickCreateDistribution();
                project.ClickNotifications();
                String status1 = project.GetNotificationStatus();
                project.SuccessScreenshot("Distribution got Created successfully With TOC Path");
                VerifyText(test, "creating distribution " + expected1 + " in " + projectName + " is successful", status1, "Distribution is Created For Mercurial TOC with status:" + status1 + "", "Distribution is not created For Mercurial TOC with status: " + status1 + "");
                project.ClickDashboard();
                project.SearchForProject(projectName);
                distribution.ClickDistribution();
                String actual1 = distribution.GetDistributionName();
                project.SuccessScreenshot("Created Distribution:  " + expected1 + "");
                VerifyEquals(test, expected1, actual1, "Create Distribution for Mercurial Project With TOC is successful", "Create Distribution for Mercurial Project With TOC is not successful");
                UpdateMercurialProjectProperties("Success");
                distribution.ClickCloseButton();
            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                UpdateMercurialProjectProperties("Failure");
                throw;
            }

        }

        [Test, Description("Verify User is able to add Distribution for the Mercurial Project without TOC")]
        public void TC10B_ValidateCreateDistributionForMercurialProjectWithOutTOC()
        {
            try
            {
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                Console.WriteLine("Starting Test Case : " + TestName);
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                test = StartTest(TestName, description);
                String projectName = CreateMercurialProject(test, driver);
                AddProjectPage project = new AddProjectPage(test, driver);
                project.ClickDashboard();
                project.SearchForProject(projectName);
                CreateDistributionPage distribution = new CreateDistributionPage(test, driver);
                distribution.ClickDistribution();
                String expected2 = distribution.EnterDistirbutionName();
                System.Threading.Thread.Sleep(5000);
                distribution.EnterBranchWithoutTOCForMercurial("DocworkManual2");
                distribution.EnterDescription("This is to create a distribution Without TOC");
                distribution.ClickCreateDistribution();
                project.ClickNotifications();
                String status2 = project.GetNotificationStatus();
                project.SuccessScreenshot("Distribution: " + expected2 + " got Created successfully Without TOC Path");
                VerifyText(test, "creating distribution " + expected2 + " in " + projectName + " is successful", status2, "Distribution is Created For Mercurial Without TOC with status:" + status2 + "", "Distribution is not created For Mercurial without TOC with status: " + status2 + "");
                UpdateMercurialProjectProperties("Success");
            }
            catch (Exception ex)
            {
                ReportExceptionScreenshot(test, driver, ex);
                Fail(test, ex);
                UpdateMercurialProjectProperties("Failure");
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

