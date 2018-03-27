using System;
using OpenQA.Selenium;
using System.Diagnostics;

namespace DocWorksQA.Pages
{
    public class AddProjectPage : SeleniumHelpers.PageControl
    {
        public By ADDPROJECT_BUTTON = By.XPath("(//button[@class='mat-raised-button mat-primary']/span)[1]");
        public  By PROJECT_TITLE_FIELD= By.XPath("//input[@ng-reflect-placeholder='Project Title']");
        public By NOTIFICATION_NAME = By.XPath("//div[@class='mat-list-text']/p[@class='mat-line mb-5']/span");
        public By NOTIFICATION_STATUS = By.XPath("//div[@class='mat-list-text']/p[@class='mat-line mb-5']/small[@class='bg_Success']");
        public By TYPE_OF_CONTENT_DROPDOWN = By.XPath("//mat-select[@placeholder='Type of Content']");
        public By SOURCE_CONTROL_PROVIDER_DROPDOWN = By.XPath("//mat-select[@placeholder='Source Control Provider']");
        public By ENTER_SEARCH = By.XPath("//input[@aria-label='Search']");
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

        public void SuccessScreenshot(String path,String message)
        {
            info("<a href=\"" + path + "\">ScreenShot : " + message + "<br></a>");
        }


        public String GetDescriptionSize()
        {
            info("Description Size is" + this.GetSize(DESCRIPTION_FIELD));
            return this.GetSize(DESCRIPTION_FIELD);
        }

        public String GetDescriptionLength()
        {
            String str = GetText(SIZE_EXCEED_1000).ToString();
            info("Description Exceeds 1000 characters***" + str);
            return str;
        }

        public String GetDescriptionText()
        {
            String str = GetText(DESCRIPTION_MAT_CARD).ToString();
            info("The Description Text is"+str);
            return str;
        }
        public String GetTitleLength()
        {
            String str = GetText(SIZE_EXCEED_100).ToString();
            info("Title Exceeds 100 characters***" + str);
            return str;
        }
        public void ClickDashboard()
        {
            Click(By.XPath("//a[@href='/dashboard']"));
            System.Threading.Thread.Sleep(7000);
            info("Clicked On DashBoard");
        }

        public void ClickAddProject() {
            Click(ADDPROJECT_BUTTON);
            info("Clicked on AddProject Button.");
        }

        public String EnterProjectTitle() {
           String ProjectTitle = "SELENIUM" + "_" + generateRandomNumbers(2);
            EnterValue(PROJECT_TITLE_FIELD, ProjectTitle);
            info("Entered Project Title : " + ProjectTitle);
            return ProjectTitle;
        }

        public String ProjectTitleInvalidLength()
        {
            String ProjectTitle = "QA";
            EnterValue(PROJECT_TITLE_FIELD, ProjectTitle);
            info("Entered Project Title : " + ProjectTitle);
            return ProjectTitle;
        }
        
        public String ProjectLengthMoreThan100()
        {
            String ProjectTitle = "SELENIUM" + RandomValueOfLengthMorethan100();
            EnterValue(PROJECT_TITLE_FIELD, ProjectTitle);
            info("Entered Project Title : " + ProjectTitle);
            return ProjectTitle;
        }

        public String ProjectDescriptionMorethan1000()
        {
            // String Description = "<mat-menu>"+RandomValueOfLengthMorethan1000();
            String Description = "(WCM or WCMS)isa CMS designed to support the management of the content of Web pages. Most popular CMSs are also WCMSs. Web content includes text and embedded(WCM or WCMS) is a CMS designed to support the management of the content of Web pages. Most popular CMSs are also WCMSs. Web content includes text and embedded(WCM or WCMS) is a CMS designed to support the management of the content of Web pages. Most popular CMSs are also WCMSs. Web content includes text and embedded(WCM or WCMS) is a CMS designed to support the management of the content of Web pages. Most popular CMSs are also WCMSs. Web content includes text and embedded(WCM or WCMS) is a CMS designed to support the management of the content of Web pages. Most popular CMSs are also WCMSs. Web content includes text and embedded(WCM or WCMS) is a CMS designed to support the management of the content of Web pages. Most popular CMSs are also WCMSs. Web content includes text and embedded(WCM or WCMS) is a CMS designed to support the management of the content of Web pages. Most popular CMSs are also WCMSs. Web content includes text and embedded";
            EnterValue(DESCRIPTION_FIELD, Description);
            info("Entered Project Description : " + Description);
            return Description;
        }
        public String GetFooterTitle()
        {
            IWebElement element = WaitForElement(FOOTER_TEXT);
            String FooterText = this.GetText(FOOTER_TEXT);
           info("Footer Title is*************" + FooterText);
            return FooterText;
        }

        public void EnterDescription(String description) {
            EnterValue(DESCRIPTION_FIELD, description);
            info("Entered Description: " + description);
        }

        public void EnterPublishedPath(String path)
        {
            EnterValue(PUBLISHED_PATH, path);
            info("Enter Published Path:" + path);
        }

        public void ClickClose()
        {
            Click(By.XPath("//button//i[@class='mdi mdi-close mdi-24px']"));
            info("Clicked Close Button");
        }

        public void ClickBack()
        {
            Click(BACK_BUTTON);
            info("Clicked on Back Button.");

        }
        public void ClickClear()
        {
            Click(CLEAR_BUTTON);
            info("Clicked on Clear Button.");

        }
        public void ClickCreateProject()
        {
            Click(CREATE_PROJECT_BUTTON);
            info("Clicked on Create project Button.");

        }

        public void ClickNotifications()
        {
            System.Threading.Thread.Sleep(7000);
            Click(NOTIFICATION_BELL);
           info("Clicked Notification Bell");
        }

        public String GetNotificationStatus()
        {
            String text = GetText(NOTIFICATION_STATUS);
            System.Threading.Thread.Sleep(7000);
            return text;
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
            info("Status of the created Project is :   " + str);
            return str;
        }

        public void BackToProject()
        {
            this.Click(BACKDROP);
            info("Clicked On BackDrop");
        }

        public void ClickContentType()
        {

            this.Click(TYPE_OF_CONTENT_DROPDOWN);
            info("Clicked On the TypeOfContent DropDown");
            this.Click(CONTENT_VALUE);
            info("selected the content from drop down");
        }

        public void ClickSourceControlTypeGitLab()
        {
          
                this.Click(SOURCE_CONTROL_PROVIDER_DROPDOWN);
            info("Clicked On the SOURCE_CONTROL_TYPE_DROPDOWN DropDown");
            this.Click(SOURCE_CONTROL_VALUE_GITLAB);
            info("selected the SOURCE_CONTROL_VALUE as GITLAB from drop down");

        }
        public void ClickSourceControlTypeGitHub()
        {

            this.Click(SOURCE_CONTROL_PROVIDER_DROPDOWN);
            info("Clicked On the SOURCE_CONTROL_TYPE_DROPDOWN DropDown");
            this.Click(SOURCE_CONTROL_VALUE_GITHUB);
            info("selected the SOURCE_CONTROL_VALUE as GITHUB from drop down");

        }
        public void ClickSourceControlTypeOno()
        {

            this.Click(SOURCE_CONTROL_PROVIDER_DROPDOWN);
            info("Clicked On the SOURCE_CONTROL_TYPE_DROPDOWN DropDown");
            this.Click(SOURCE_CONTROL_VALUE_ONO);
            info("selected the SOURCE_CONTROL_VALUE as Ono from drop down");

        }
        public void EnterMercurialRepoPath()
        {
            String path= "https://bitbucket.org/mohittonde/docworks";
            EnterValue(MERCURIAL_REPO_PATH,path);
            info("Entered Mercurial repo Path as" + path);
        }




        public void ClickRepository()
        {
                this.Click(REPOSITORY_DROPDOWN);
            info("Clicked On the Repository DropDown");
            this.Click(REPOSITORY_VALUE);
            info("selected the Reppository_Value from drop down");


        }
          
    }
}
