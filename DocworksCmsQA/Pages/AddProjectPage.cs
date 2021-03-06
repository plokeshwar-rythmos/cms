﻿using System;
using OpenQA.Selenium;
using System.Diagnostics;

namespace DocWorksQA.Pages
{
    public class AddProjectPage : SeleniumHelpers.PageControl
    {
        public By GET_TITLE = By.XPath("//mat-card/mat-card-title/div");
        public By ADDPROJECT_BUTTON = By.XPath("(//button[@class='mat-raised-button mat-primary']/span)[1]");
        public  By PROJECT_TITLE_FIELD= By.XPath("//input[@ng-reflect-placeholder='Project Title']");
        public By BELL_NOTIFICATION = By.XPath("//mat-chip[@class='mat-chip notification cursor-pointer mat-warn mat-chip-selected ng-star-inserted']");
        public By NOTIFICATION_MESSAGE = By.XPath("//div[@class='mat-line operation-status-wrapper']//small");
        public By NOTIFICATION_PROGRESS = By.XPath("//mat-progress-spinner[@class='mat-progress-spinner mat-primary mat-progress-spinner-indeterminate-animation']");
        public By NOTIFICATION_NAME = By.XPath("//div[@class='mat-list-text']/p[@class='mat-line mb-5']/span");
        public By NOTIFICATION_STATUS = By.XPath("//div[@class='mat-list-text']/p[@class='mat-line mb-5']/small[@class='bg_Success']");
        public By ENTER_SEARCH = By.XPath("//input[@type='Search']");
        public By TYPE_OF_CONTENT_DROPDOWN = By.XPath("//mat-select[@placeholder='Type of Content']");
        public By SOURCE_CONTROL_PROVIDER_DROPDOWN = By.XPath("//mat-select[@placeholder='Source Control Provider']");
        public By REPOSITORY_DROPDOWN = By.XPath("//mat-select[@placeholder='Repository']");
        public By REPOSITORY_VALUE = By.XPath("//mat-option//span[contains(@class,'mat-option-text')][contains(text(),'Docworks')]");
        public  By CONTENT_VALUE = By.XPath("//mat-option//span[contains(@class,'mat-option-text')][contains(text(),'Manual')]");
        public By SOURCE_CONTROL_VALUE_GITLAB = By.XPath("//mat-option//span[contains(@class,'mat-option-text')][contains(text(),'GitLab')]");
        public By SOURCE_CONTROL_VALUE_GITHUB = By.XPath("//mat-option//span[contains(@class,'mat-option-text')][contains(text(),'GitHub')]");
        public By SOURCE_CONTROL_VALUE_ONO = By.XPath("//mat-option//span[contains(@class,'mat-option-text')][contains(text(),'Ono')]");
        public By MERCURIAL_REPO_PATH = By.XPath("//input[@placeholder='Mercurial Repo Path']");
        public By SIZE_EXCEED_100 = By.XPath("(//mat-dialog-content//div/small)[1]");
        public By SIZE_EXCEED_1000 = By.XPath("(//mat-dialog-content//div/small)[4]");
        public By DESCRIPTION_FIELD = By.XPath("//textarea[@ng-reflect-placeholder='Description']");
        public By PUBLISHED_PATH = By.XPath("//input[@placeholder='Published Path']");
        public By BACK_BUTTON = By.XPath("//button[@class='mat-raised-button']/span");
        public By CLEAR_BUTTON = By.XPath("//button[@class='mat-raised-button mat-warn']/span");
        public By CREATE_PROJECT_BUTTON = By.XPath("(//button/span[contains(@class,'mat-button-wrapper')][contains(text(),'Create Project')])[2]");
        public By INVALID_TITLE_LENGTH = By.XPath("//mat-error[@class='mat-error ng-star-inserted']");
        public By FOOTER_TEXT = By.XPath("//*/snack-bar-container/app-custom-snack-bar-component");
        public By NOTIFICATION_BELL = By.XPath("//i[@class='mdi mdi-bell mdi-24px']");
        public By GET_CREATEDPROJECT = By.XPath("//div/mat-list-item/div/div[2]");
        public By BACKDROP = By.XPath("//div[@class='mat-drawer-backdrop mat-drawer-shown']");
        public By DESCRIPTION_MAT_CARD = By.XPath("//mat-card-content/p");
        public object DriverWaitUtil { get; private set; }



        public AddProjectPage(IWebDriver driver) : base(driver)
        {
        }



        public Boolean IsProjectEnable()
        {
            Boolean Flag =
            this.IsEnabled(ADDPROJECT_BUTTON);
            Debug.WriteLine("Is Add Project Button Enabled " + Flag);

            return Flag;
        }

        public void SearchForProject(String projectName)
        {
            Clear(ENTER_SEARCH);
            EnterValue(ENTER_SEARCH, projectName);
            
        }

        public void SuccessScreenshot(String path,String message)
        {
            Info("<a href=\"" + path + "\">ScreenShot : " + message + "<br></a>");
        }

        public void SuccessScreenshot(String message)
        {
            String path = TakeScreenshot(driver);
            SuccessScreenshot(path, message);
        }



        


        public String GetDescriptionSize()
        {
            Info("Description Size is" + this.GetSize(DESCRIPTION_FIELD));
            return this.GetSize(DESCRIPTION_FIELD);
        }

        public String GetDescriptionLength()
        {
            String str = GetText(SIZE_EXCEED_1000).ToString();
            Info("Description Exceeds 1000 characters***" + str);
            return str;
        }

        public String GetDescriptionText()
        {
            String str = GetText(DESCRIPTION_MAT_CARD).ToString();
            Info("The Description Text is"+str);
            return str;
        }
        public String GetTitleLength()
        {
            String str = GetText(SIZE_EXCEED_100).ToString();
            Info("Title Exceeds 100 characters***" + str);
            return str;
        }
        public void ClickDashboard()
        {
            String url = driver.Url;
            url = url.Substring(0, url.LastIndexOf("/"));
            driver.Navigate().GoToUrl(url + "/dashboard");
            //Click(By.XPath("//a[@href='/dashboard']"));
            System.Threading.Thread.Sleep(7000);
            Info("Clicked On DashBoard");
        }

        public void ClickAddProject() {
            ClickDashboard();
            Click(ADDPROJECT_BUTTON);
            WaitForElement(CREATE_PROJECT_BUTTON);
            Info("Clicked on AddProject Button.");
        }

        public String EnterProjectTitle() {
           String ProjectTitle = "SELENIUM" + "_" + GenerateRandomNumbers(2);
            EnterValue(PROJECT_TITLE_FIELD, ProjectTitle);
            Info("Entered Project Title : " + ProjectTitle);
            return ProjectTitle;
        }

        public String ProjectTitleInvalidLength()
        {
            String ProjectTitle = "QA";
            EnterValue(PROJECT_TITLE_FIELD, ProjectTitle);
            Info("Entered Project Title : " + ProjectTitle);
            return ProjectTitle;
        }
        
        public String ProjectLengthMoreThan100()
        {
            String ProjectTitle = "SELENIUM" + RandomValueOfLengthMorethan100();
            EnterValue(PROJECT_TITLE_FIELD, ProjectTitle);
            Info("Entered Project Title : " + ProjectTitle);
            return ProjectTitle;
        }

        public String GetProjectTitle()
        {
            Info("ProjectTitle is" + this.GetText(GET_TITLE));
            return this.GetText(GET_TITLE);
        }

        public String ProjectDescriptionMorethan1000()
        {
            // String Description = "<mat-menu>"+RandomValueOfLengthMorethan1000();
            try
            {
                String Description = "(WCM or WCMS)isa CMS designed to support the management of the content of Web pages. Most popular CMSs are also WCMSs. Web content includes text and embedded(WCM or WCMS) is a CMS designed to support the management of the content of Web pages. Most popular CMSs are also WCMSs. Web content includes text and embedded(WCM or WCMS) is a CMS designed to support the management of the content of Web pages. Most popular CMSs are also WCMSs. Web content includes text and embedded(WCM or WCMS) is a CMS designed to support the management of the content of Web pages. Most popular CMSs are also WCMSs. Web content includes text and embedded(WCM or WCMS) is a CMS designed to support the management of the content of Web pages. Most popular CMSs are also WCMSs. Web content includes text and embedded(WCM or WCMS) is a CMS designed to support the management of the content of Web pages. Most popular CMSs are also WCMSs. Web content includes text and embedded(WCM or WCMS) is a CMS designed to support the management of the content of Web pages. Most popular CMSs are also WCMSs. Web content includes text and embedded";
                EnterDescription(Description);
                Info("Entered Project Description : " + Description);
                return Description;
            }catch(Exception e)
            {
                throw e;
            }
        }
        public String GetFooterTitle()
        {
            IWebElement element = WaitForElement(FOOTER_TEXT);
            String FooterText = this.GetText(FOOTER_TEXT);
           Info("Footer Title is*************" + FooterText);
            return FooterText;
        }

        public void EnterDescription(String description) {
            EnterValue(DESCRIPTION_FIELD, description);
            Info("Entered Description: " + description);
        }

        public void EnterPublishedPath(String path)
        {
            EnterValue(PUBLISHED_PATH, path);
            Info("Enter Published Path:" + path);
        }

        public void EscapePopUp()
        {
            WaitForElement(CREATE_PROJECT_BUTTON).SendKeys(Keys.Escape);
        }

        public void ClickClose()
        {
            
            Click(By.XPath("//button//i[@class='mdi mdi-close mdi-24px']"));
            Info("Clicked Close Button");
        }

        public void ClickBack()
        {
            Click(BACK_BUTTON);
            Info("Clicked on Back Button.");

        }
        public void ClickClear()
        {
            Click(CLEAR_BUTTON);
            Info("Clicked on Clear Button.");

        }
        public void ClickCreateProject()
        {
            Click(CREATE_PROJECT_BUTTON);
            Info("Clicked on Create project Button.");
            WaitForElement(BELL_NOTIFICATION);

        }

        public void ClickNotifications()
        {
            System.Threading.Thread.Sleep(7000);
            Click(NOTIFICATION_BELL);
           Info("Clicked Notification Bell");
        }

        public void WaitForProcessCompletion() {
            for(int i = 0; i < 200; i++)
            {
                String tmp = WaitForElement(NOTIFICATION_MESSAGE).Text;

                if (tmp.Contains("successful"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine(tmp);
                    //Console.WriteLine("Notification is still in progress.");
                    System.Threading.Thread.Sleep(1000);
                }

            }
        }

        public String GetNotificationStatus()
        {

            WaitForProcessCompletion();
            return GetText(NOTIFICATION_MESSAGE);
            
        }

        public String GetNotificationName()
        {
            String text = GetText(NOTIFICATION_NAME);
            System.Threading.Thread.Sleep(7000);
            //Console.WriteLine("%%%%%" + text);
            return text;
        }
        public String GetCreatedProject()
        {
            for (int i=1;i<=5;i++)
            {
                String text = GetText(NOTIFICATION_STATUS);
                if (text.ToString() == "Pending")
                {
                    System.Threading.Thread.Sleep(5000);
                }
                else
                {
                    break;
                }
            }
            
            String str =this.GetText(GET_CREATEDPROJECT);
            Info("Status of the created Project is :   " + str);
            return str;
        }

        public void BackToProject()
        {
            this.Click(BACKDROP);
            Info("Clicked On BackDrop");
        }

        public void ClickContentType()
        {

            this.Click(TYPE_OF_CONTENT_DROPDOWN);
            Info("Clicked On the TypeOfContent DropDown");
            this.Click(CONTENT_VALUE);
            Info("selected the content from drop down");
        }

        public void ClickSourceControlTypeGitLab()
        {
          
                this.Click(SOURCE_CONTROL_PROVIDER_DROPDOWN);
            Info("Clicked On the SOURCE_CONTROL_TYPE_DROPDOWN DropDown");
            this.Click(SOURCE_CONTROL_VALUE_GITLAB);
            Info("selected the SOURCE_CONTROL_VALUE as GITLAB from drop down");

        }
        public void ClickSourceControlTypeGitHub()
        {

            this.Click(SOURCE_CONTROL_PROVIDER_DROPDOWN);
            Info("Clicked On the SOURCE_CONTROL_TYPE_DROPDOWN DropDown");
            this.Click(SOURCE_CONTROL_VALUE_GITHUB);
            Info("selected the SOURCE_CONTROL_VALUE as GITHUB from drop down");

        }
        public void ClickSourceControlTypeOno()
        {

            this.Click(SOURCE_CONTROL_PROVIDER_DROPDOWN);
            Info("Clicked On the SOURCE_CONTROL_TYPE_DROPDOWN DropDown");
            this.Click(SOURCE_CONTROL_VALUE_ONO);
            Info("selected the SOURCE_CONTROL_VALUE as Ono from drop down");

        }
        public void EnterMercurialRepoPath()
        {
            String path= "https://bitbucket.org/mohittonde/docworks";
            EnterValue(MERCURIAL_REPO_PATH,path);
            Info("Entered Mercurial repo Path as" + path);
        }




        public void ClickRepository()
        {
            this.Click(REPOSITORY_DROPDOWN);
            Info("Clicked On the Repository DropDown");
            this.Click(REPOSITORY_VALUE);
            Info("selected the Reppository_Value from drop down");


        }
          
    }
}
