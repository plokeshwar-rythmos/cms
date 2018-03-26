using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AventStack.ExtentReports;

namespace DocWorksQA.Pages
{
    class TagManagementNodeLevelPage : SeleniumHelpers.PageControl
    {
        private ExtentTest test;
        public By CREATE_DRAFT_FOR_NODE = By.XPath("");

        public TagManagementNodeLevelPage(IWebDriver driver, ExtentTest test) : base(driver)
        {
            this.test = test;
        }

    }
}
