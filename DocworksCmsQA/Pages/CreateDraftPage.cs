using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AventStack.ExtentReports;

namespace DocWorksQA.Pages
{
    public class CreateDraftPage : SeleniumHelpers.PageControl
    {
        public By UNITYMANUAL_CLICK = By.XPath("//span[@class='ui-treenode-label ui-corner-all']");
        public By BACKDROP_CLICK = By.XPath("//div[@class='mat-drawer-backdrop mat-drawer-shown']");
        public By NEWDRAFT_BUTTON = By.XPath("//button/span/i[@class='mdi mdi-plus mdi-18px']");
        public By CLOSEDRAFT_BUTTON = By.XPath("//button[@aria-label='Close dialog']");
        public By DRAFTNAME_EDT = By.XPath("//input[@placeholder='Draft Name']");
        public By EXISTINGDRAFT_CLICK = By.XPath("(//div[@class='mat-radio-outer-circle'])[1]");
        public By BLANKDRAFT_CLICK = By.XPath("(//div[@class='mat-radio-outer-circle'])[2]");
        public By EXISTINGDRAFTDROPDOWN = By.XPath("//mat-select[@aria-label='Existing Drafts']");
        public By CODERDRAFT_CLICK = By.XPath("(//mat-option[@class='mat-option ng-star-inserted mat-selected mat-active']//span)[contains(text(),' Source Control Draft ')]");
        public By CREATEDRAFT_BUTTON = By.XPath("(//button[@class='mat-raised-button mat-primary']/span)[contains(text(),'Create Draft')]");
        public By DRAFTNAMEERROR = By.XPath("//mat-error[text()='Please enter at least 5 characters.']");
        public By OPENPROJECT = By.XPath("(//button[@class='mat-raised-button mat-primary']/span)[contains(text(),'Open')]");
        public By LATEST_DRAFT_IN_DROPDOWN = By.XPath("(//mat-option[@class='mat-option ng-star-inserted']//span)[last()]");

        private ExtentTest test;
        /**
        * Constructor: CreateDraftPage()
        * Description: This constructor is used to initialize the webdriver
        */
        public CreateDraftPage(ExtentTest test,IWebDriver driver) : base(driver)
        {
            this.test = test;
        }

        

        /**
        * MethodName: ClickNewDraft()
        * Description: This method is used to click on New Draft button
        */
        public void ClickNewDraft()
        {
            Click(NEWDRAFT_BUTTON);
            Info(test,"Clicked on New Draft Button.");
        }

        /**
        * MethodName: SuccessScreenshot()
        * Description: This method is used to capture screenshots
        */
        public void SuccessScreenshot(String path, String message)
        {
            Info("<a href=\"" + path + "\">ScreenShot : " + message + "<br></a>");

        }

        /**
        * MethodName: GetErrorText()
        * Description: This method is used to Get Error Text
        */
        public string GetErrorText(By by)
        {
            EnterValue(DRAFTNAME_EDT, Keys.Tab);
            String text = GetText(by);
            Info(test,"Error for Invalid Draft is: "+text+" ");
            Click(DRAFTNAME_EDT);
            return text;
        }

        /**
        * MethodName: SelectCoderDraft()
        * Description: This method is used to select Coder Draft from Existing Drafts
        */
        public void SelectCoderDraft()
        {
            Click(EXISTINGDRAFTDROPDOWN);
            Click(CODERDRAFT_CLICK);
            Info(test,"Coder Draft Selected.");
        }

        public void SelectExistingDraft()
        {
            Click(EXISTINGDRAFTDROPDOWN);
            System.Threading.Thread.Sleep(5000);
            Click(LATEST_DRAFT_IN_DROPDOWN);
            Info(test,"Selected latest Draft");

        }

        /**
        * MethodName: ClikOnBackdrop()
        * Description: This method is used to click on Backdrop
        */
        public void ClickOnUnityManualNode()
        {
            Click(UNITYMANUAL_CLICK);
            System.Threading.Thread.Sleep(15000);
            Info(test,"Clicked on Unity Manual Node");

        }

        /**
        * MethodName: isDraftPopUpEnabled()
        * Description: This method is used to verify if the draft pop up is enabled after clicking on new draft button
        */
        public Boolean IsDraftPopUpEnabled()
        {
            Boolean flag = this.IsEnabled(CLOSEDRAFT_BUTTON);
            Info(test,"Draft Dialog Box Is Enabled");
            return flag;
        }

        /**
        * MethodName: EnterInvalidnNameLength()
        * Description: This method is used to enter invalid draft name
        */
        public String EnterInvalidnNameLength()
        {
            String DraftName = "QA";
            EnterValue(DRAFTNAME_EDT, DraftName);
            Info(test,"Entered Draft Name : " + DraftName + " ");
            return DraftName;

        }

        /**
        * MethodName: EnterDraftName()
        * Description: This method is used to enter draft name
        */
        public void EnterDraftName(String draftName)
        {
            EnterValue(DRAFTNAME_EDT, draftName);
            Info(test,"Entered Draft Name:" + draftName + " ");

        }

        /**
        * MethodName: EnterValidDraftName()
        * Description: This method is used to enter valis draft name
        */
        public String EnterValidDraftName()
        {
            String DraftName = "Draft" + "_" + GenerateRandomNumbers(2);
            Click(DRAFTNAME_EDT);
            EnterValue(DRAFTNAME_EDT, DraftName);
            Info(test,"Draft Name is" + DraftName + " ");
            return DraftName;
        }

        /**
        * MethodName: CreateDraft()
        * Description: This method is used to click on  create draft button
        */
        public void CreateDraft()
        {
            Click(CREATEDRAFT_BUTTON);
            Info(test,"Clicked on Create Draft button");
        }

        /**
        * MethodName: ClickOnBlankDraft()
        * Description: This method is used to click on Blank Draft for draft creation
        */
        public void ClickOnBlankDraft()
        {
            Click(BLANKDRAFT_CLICK);
            Info(test,"Selected Blank Draft.");
        } 

        /**
        * MethodName: ClickOnExistingDraft()
        * Description: This method is used to click on Existing Draft for draft creation
        */
        public void ClickOnExistingDraft()
        {
            Click(EXISTINGDRAFT_CLICK);
            Info(test,"Selected Existing Draft.");
        }

        /**
        * MethodName: CLOSEDRAFT()
        * Description: This method is used to close draft
        */
        public void CloseDraft()
        {
            Click(CLOSEDRAFT_BUTTON);
            Info(test,"Clicked on Close Draft Button.");
        }

        /**
        * MethodName: CLICKOPENPROJECT()
        * Description: This method is used to open the project
        */
        public void ClickOpenProject()
        {
            Click(OPENPROJECT);
            System.Threading.Thread.Sleep(25000);
            Info(test,"Clicked on Open Project Button");
        }

    }
}
