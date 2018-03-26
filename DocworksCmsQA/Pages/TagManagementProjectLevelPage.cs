using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AventStack.ExtentReports;

namespace DocWorksQA.Pages
{
    class TagManagementProjectLevelPage : SeleniumHelpers.PageControl
    {
        public By DASHBOARD = By.XPath("//a[@href='/dashboard']");
        public By SEARCH_IN_DASHBOARD = By.XPath("//input[@type='Search']");
        public By SETTINGS = By.XPath("(//mat-card/mat-card-title/div[2]//i[1])[last()-1]");
        public By CLICK_MANAGE_TAG_GROUPS = By.XPath("//button[@class='mat-menu-item'][contains(text(),'Manage Tag Groups')]");
        public By SEARCH_TAGS_AT_PROJECTLEVEL = By.XPath("//input[@placeholder='Search Tag Groups']");
        public By AVAILABLE_TAG_PLUS_CIRCLE = By.XPath("//mat-expansion-panel//i[@class='mdi mdi-plus-circle mdi-18px']");
        public By ASSIGNED_TAG_CLOSE_CIRCLE = By.XPath("//mat-expansion-panel//i[@class='mdi mdi-close-circle mdi-18px']");
        public By GET_TAG_NAME_AT_PROJECTLEVEL = By.XPath("//mat-chip/span");
        public By CLOSE_MANAGE_TAG_GROUPS = By.XPath("//button/span/i[@class='mdi mdi-close mdi-24px']");

        public TagManagementProjectLevelPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickDashBoard()
        {
            Click(DASHBOARD);
            info("Clicked Onn DashBoard");
        }
        public String GetTagNameAtProjectLevel()
        {
            String str = GetText(GET_TAG_NAME_AT_PROJECTLEVEL);
            Console.WriteLine("####" + str);
            info("The Tag Name at Project Level is" + str);
            return str;
        }
        public void EnterSearchForProject(String ProjectName)
        {
            Clear(SEARCH_IN_DASHBOARD);
            EnterValue(SEARCH_IN_DASHBOARD, ProjectName);
            info("ProjectName is" + ProjectName);
        }

        public void ClickSettings()
        {
            Click(SETTINGS);
            info("Clicked on Settings");
        }

        public void ClickOnManageTagGroups()
        {
            Click(CLICK_MANAGE_TAG_GROUPS);
            info("Clicked on Manage Tag Groups");
        }

        public void SearchTagsAtProjectLevel(String TagName)
        {
            Clear(SEARCH_TAGS_AT_PROJECTLEVEL);
            EnterValue(SEARCH_TAGS_AT_PROJECTLEVEL, TagName);
            info("Searched Tags At Project Level");
        }
        public void ClickPlusCircle()
        {
            Click(AVAILABLE_TAG_PLUS_CIRCLE);
            info("Clicked On Plus circle of Available Tag to Move into Assigned Tags");
        }
       public  void ClickCloseCircle()
        {
            Click(ASSIGNED_TAG_CLOSE_CIRCLE);
            info("Clicked on Close circle to remove the tag from Assigned Tags");
        }
        public void ClickCloseManageTagGroups()
        {
            Click(CLOSE_MANAGE_TAG_GROUPS);
            info("Clicked Close Manage Tag Groups");
        }
        public void SuccessScreenshot(String path, String message)
        {
            info("<a href=\"" + path + "\">ScreenShot : " + message + "<br></a>");
        }
    }
}
