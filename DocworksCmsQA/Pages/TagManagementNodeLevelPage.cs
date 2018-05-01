using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AventStack.ExtentReports;

namespace DocWorksQA.Pages
{
    class TagManagmentProjectLevelPage : SeleniumHelpers.PageControl
    {
        public By NODELEVEL_TAGGROUP_ICON = By.XPath("//i[@class='mdi mdi-tag mdi-24px']");
        public By FILTERHIERARCHY_ICON = By.XPath("//i[@class='mdi mdi-tune mdi-24px']");
        public By GET_TEXT_OF_TAGGROUP = By.XPath("(//mat-panel-title//div/span)[text()='TagGroupName']");
        public By TAGGROUP_CHECKBOX = By.XPath("(//mat-panel-title//div/span)[text()='TagGroupName']//following::mat-checkbox");
        public By NODELEVEL_CLOSEBUTTON = By.XPath("//button[@class='mat-button']//i");
        public By APPLY_BUTTON = By.XPath("(//span[@class='mat-button-wrapper'])[text()='APPLY']");
        
        private ExtentTest test;

        public TagManagmentProjectLevelPage(ExtentTest test, IWebDriver driver) : base(driver)
        {
            this.test = test;
        }


    }
}