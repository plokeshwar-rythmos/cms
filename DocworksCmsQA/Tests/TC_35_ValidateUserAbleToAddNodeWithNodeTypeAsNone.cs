using NUnit.Framework;
using OpenQA.Selenium;
using DocWorksQA.Pages;
using DocWorksQA.SeleniumHelpers;
using System;
using System.Text;
using AventStack.ExtentReports;


namespace DocWorksQA.Tests
{

    [TestFixture, Category("AddNodeModule")]
    [Parallelizable]
    class TC_35_ValidateUserAbleToAddNodeWithNodeTypeAsNone : BeforeTestAfterTest
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


        [Test, Description("Verify User is able to add a Node with Node Type as None")]
        public void TC35_VerifyUserAbleToAddNodeWithNodeTypeAsNone()
        {
            try
            {
                String description = TestContext.CurrentContext.Test.Properties.Get("Description").ToString();
                String TestName = (TestContext.CurrentContext.Test.Name.ToString());
                test = StartTest(TestName, description);
                String projectName = CreateDistribution("Mercurial", test, driver);
                AddProjectPage addProject = new AddProjectPage(test, driver);
                addProject.ClickDashboard();
                addProject.SearchForProject(projectName);
                CreateDraftPage createDraft = new CreateDraftPage(test, driver);
                createDraft.ClickOpenProject();
                NodesPage node = new NodesPage(test, driver);
                node.RightClickOnParentTree();
                node.ClickOnNewNode();
                String NodeTitle = node.EnterNodeTitle();
                String NodeSubTitle = node.EnterNodeSubTitle();
                node.ClickNoneRadioButton();
                node.ClickCreateNode();
                addProject.ClickNotifications();
                String status2 = addProject.GetNotificationStatus();
                addProject.SuccessScreenshot("Node: " + NodeTitle + " Created Successfully");
                VerifyText(test, "adding a node " + NodeTitle + " is successful", status2, "Node: " + NodeTitle + " is Created with status:" + status2 + "", "Node is not created with status: " + status2 + "");
                addProject.BackToProject();
                node.ClickUnityManualTree();
                addProject.SuccessScreenshot("Created NodeSubTitle:  " + NodeSubTitle + "");
                String Actual = node.GetTextOfNode(NodeSubTitle);
                VerifyEquals(test, NodeSubTitle, Actual, "Validation of the Node Created Under Tree is successful", "Validation of Node creation is unsuccessful");
                node.ClickDashboard();
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