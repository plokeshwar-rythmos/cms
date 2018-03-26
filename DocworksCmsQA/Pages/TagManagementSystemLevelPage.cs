using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AventStack.ExtentReports;
namespace DocWorksQA.Pages
{
    class TagManagementSystemLevelPage : SeleniumHelpers.PageControl
    {
        public By SYSTEM_LEVEL = By.XPath("//a[@href='/system']");
        public By CREATE_TAGGROUP_BUTTON = By.XPath("//button/span[contains(text(),'CREATE TAG GROUP')]");
        public By TAG_GROUP_NAME = By.XPath("//input[@ng-reflect-placeholder='Tag Group Name']");
        public By COLOR_DROPDOWN = By.XPath("//mat-select//div[@class='mat-select-arrow-wrapper']");
        public By COLOR_VALUE = By.XPath("//mat-option/span[contains(text(),'red')]");
        public By LIMITTOONE_CHECKBOX = By.XPath("//span[@class='mat-checkbox-label'][contains(text(),'Limit to one')]");
        public By CHILDNODESINHERITS_CHECKBOX = By.XPath("//span[@class='mat-checkbox-label'][contains(text(),'Child nodes inherit')]");
        public By PUBLIC_CHECKBOX = By.XPath("//span[@class='mat-checkbox-label'][contains(text(),'Public')]");
        public By PUBLISH_CHECKBOX = By.XPath("//span[@class='mat-checkbox-label'][contains(text(),'Publish')]");
        public By DISPLAY_GROUP_NAME_CHECKBOX = By.XPath("//span[@class='mat-checkbox-label'][contains(text(),'Display group name')]");
        public By CREATE_TAGGROUP = By.XPath("//button[@class='mat-raised-button mat-primary ng-star-inserted']/span[contains(text(),'CREATE')]");
        public By GET_DETAILS_OF_TAGGROUP = By.XPath("(//mat-icon/i)[last()]");
        public By GET_GROUP_NAME = By.XPath("(//mat-list-item//div/span/span)[text()='TAGGGROUPXYZ']");
        public By EDIT_TAG_GROUP = By.XPath("//button[@class='mat-menu-item'][contains(text(),'Edit Tag Group')]");
        public By MANAGE_TAG_GROUP = By.XPath("//button[@class='mat-menu-item'][contains(text(),'Manage Tags')]");
        public By ADD_TAG = By.XPath("//button[@class='mat-raised-button secondary-btn']/span");
        public By ENTER_TAG_NAME = By.XPath("//input[@ng-reflect-placeholder='Tag Name']");
        public By CHECK_THE_TAGNAME = By.XPath("//i[@class='mdi mdi-check mdi-24px']");
        public By CROSS_TAG_NAME = By.XPath("//button[@class='mat-menu-item']//i[@class='mdi mdi-close mdi-24px']");
        public By CLOSE_MANAGE_TAGS = By.XPath("//button[@class='mat-button']//i[@class='mdi mdi-close mdi-24px']");
        public By GET_LATEST_MODIFIED_DATE = By.XPath("(//mat-list-item/div/div[3]/span)[last()]");
        public By GET_NO_OF_TAGS = By.XPath("(//mat-list-item/div/div[3]/span)[last()-1]");
        public By GET_PROJECTS_POINTED = By.XPath("(//mat-list-item/div/div[3]/span)[last()-2]");
        public By GET_PUBLIC_VALUE = By.XPath("(//mat-list-item/div/div[3]/span)[last()-3]");
        public By DELETE_TAG = By.XPath("//mat-icon/i[@class='mdi mdi-delete mdi-24px']");
        public By UPDATE_TAGGROUP = By.XPath("//button/span[contains(text(),'UPDATE')]");
        public By CLOSE_EDIT_TAGS = By.XPath("//button[@class='mat-button']//i[@class='mdi mdi-close mdi-24px']");
        public By GET_TAG_NAME = By.XPath("(//mat-dialog-container//mat-dialog-content//mat-list-item//div[@class='ng-star-inserted'])[last()]");
        public By SEARCH_TAGGROUP_COLLECTION = By.XPath("//input[@placeholder='Type to Search']");
        public By SEARCH_IN_MANAGETAGS = By.XPath("//input[@placeholder='Search Tags']");
        public By GET_SIZE_OF_NO_OF_TAGS = By.XPath("//mat-dialog-container//mat-list-item[@class='mat-list-item ng-star-inserted']/div");


        public TagManagementSystemLevelPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickSystemTab()
        {
            Click(SYSTEM_LEVEL);
            info("Clicked on System Screen");
        }

        public void ClickCreateTagGroup()
        {
            Click(CREATE_TAGGROUP_BUTTON);
            info("Clicked on Create Tag Group Button");
        }

        public String EnterTagGroupName()
        {
            String str = "GROUPTAG" + generateRandomNumbers(3);
            Clear(TAG_GROUP_NAME);
            EnterValue(TAG_GROUP_NAME, str);
            info("Entered tag Group Name as" + str);
            return str;
        }
        public void SuccessScreenshot(String path, String message)
        {
            info("<a href=\"" + path + "\">ScreenShot : " + message + "<br></a>");
        }
        public void SelectColor()
        {
            Click(COLOR_DROPDOWN);
            System.Threading.Thread.Sleep(5000);
            Click(COLOR_VALUE);
            info("Selected Tag Color");
        }

        public void ClickCheckBoxLimitToOne()
        {
            Click(LIMITTOONE_CHECKBOX);
            info("Clicked LIMITTOONE Checkbox");
        }

        public void ClickChildNodeInheritCheckBox()
        {
            Click(CHILDNODESINHERITS_CHECKBOX);
          info("Clicked oon Child Node Inherit checkbox");
        }

        public void ClickPublishCheckBox()
        {
            Click(PUBLISH_CHECKBOX);
            info("Clicked Publish Checkbox");
        }

        public void ClickPublicCheckBox()
        {
            Click(PUBLIC_CHECKBOX);
            info("Clicked Public Checkbox");
        }

        public void ClickCreateTagGroupAfterDone()
        {
            Click(CREATE_TAGGROUP);
          info("Clicked Create Tag group");
        }

        public String GetTagGroupName(String str)
        {
            String s = "//mat-list-item//div/span/span" + "[text()='"+str+"']";
            Console.WriteLine("The group name");
            String str1=  GetTextOfHiddenElement(By.XPath(s));
            Console.WriteLine("The group name is :" + str1.ToString());
          info("The Tag Group Name Created is " + str1.ToString());
            return str1.ToString();

        }
        public String GetNoOfTagsInSystemLevel(String str)
        {
            String s1 = "//mat-list-item//div/span/span" + "[text()='" + str + "']/following::span[3]";
            String str1 = GetTextOfHiddenElement(By.XPath(s1));
            Console.WriteLine("The No of Tags is :" + str1.ToString());
            info("The No of Tags is " + str1.ToString());
            return str1.ToString();
        }
        public String GetPublicValue(String str)
        {
            String s1 = "//mat-list-item//div/span/span" + "[text()='" + str + "']/following::span[1]";
            String str1 = GetTextOfHiddenElement(By.XPath(s1));
            Console.WriteLine("The public value is :" + str1.ToString());
           info("The public value  is " + str1.ToString());
            return str1.ToString();
        }
        public String GetProjctsPointed(String str)
        {
            String s1 = "//mat-list-item//div/span/span" + "[text()='" + str + "']/following::span[2]";
            String str1 = GetTextOfHiddenElement(By.XPath(s1));
            Console.WriteLine("TheProjects Pointed is :" + str1.ToString());
            info("The Projects Pointed  is " + str1.ToString());
            return str1.ToString();
        }
        public String GetLastModified(String str)
        {
            String s1 = "//mat-list-item//div/span/span" + "[text()='" +str+ "']/following::span[4]";
            String str1 = GetTextOfHiddenElement(By.XPath(s1));
            Console.WriteLine("The Get Last Modified value is :" + str1.ToString());
            info("The Get Last Modified Value value  is " + str1.ToString());
            return str1.ToString();

        }
        public void ClickTagGroupUpdate()
        {
            Click(UPDATE_TAGGROUP);
            info("Clicked On Update tag Group ");
        }
        public String GetTagName()
        {
            Console.WriteLine("The Tag name");
            String str = GetText(GET_TAG_NAME);
            Console.WriteLine("The Tag name is :" + str);
            info("The Tag Created is " + str);
            return str;
        }
        public void ClickGetDetails(String str)
        {
            String s1 = "//mat-list-item//div/span/span" + "[text()='"+str+"']/following::mat-icon[1]/i";
            System.Threading.Thread.Sleep(15000);

            ClickByJavaScriptExecutor(By.XPath(s1));
            System.Threading.Thread.Sleep(10000);
            info("Clicked On the Get Details of Tag Group");
        }
        public void ClickManageTags()
        {
            ClickByJavaScriptExecutor(MANAGE_TAG_GROUP);
            info("Clicked on Manage tags");
        }

        public void ClickEditTags()
        {
            ClickByJavaScriptExecutor(EDIT_TAG_GROUP);
            info("Clicked on Edit Tag Group");
        }
        public void ClickAddTag()
        {
            Click(ADD_TAG);
            info("Clicked on Add Tag Button");
        }

        public String EnterTagName()
        {
            String str = "TAG" + generateRandomNumbers(3);
            EnterValue(ENTER_TAG_NAME, str);
            info("Entered Tag Name as" + str);
            return str;
        }

        public void ClickAcceptTagName()
        {
            ClickByJavaScriptExecutor(CHECK_THE_TAGNAME);
           info("Clicked the Accept Button of Tags");
            System.Threading.Thread.Sleep(8000);
        }

       public String GetSizeOfTagsInManageTags()
        {
            
           String str = GetSizeOfElements(GET_SIZE_OF_NO_OF_TAGS);
                Console.WriteLine("Size of Tags" + str);
            return str;
        }

        public void ClickCloseManageTags()
        {
            Click(CLOSE_MANAGE_TAGS);
            info("Clicked on Close Manage Tags");
        }
        public void EnterSearchTagInTagGroup(String TagName)
        {
            EnterValue(SEARCH_TAGGROUP_COLLECTION, TagName);
          info("Entered Tag Name in Search Bar of Tag Group Collection");
        }
        public void EnterSearchInManageTags(String TagName)
        {
            EnterValue(SEARCH_IN_MANAGETAGS, TagName);
            info("Entered Tag Name in Search Bar of ManageTags");

        }


    }
}
