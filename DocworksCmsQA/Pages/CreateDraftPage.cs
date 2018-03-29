using System;
using OpenQA.Selenium;

namespace DocWorksQA.Pages
{
    public class CreateDraftPage : SeleniumHelpers.PageControl
    {
        public By UNITYMANUAL_CLICK = By.XPath("//span[@class='ui-treenode-label ui-corner-all']");
        public By BACKDROP_CLICK = By.XPath("//div[@class='mat-drawer-backdrop mat-drawer-shown']");
        public By NEWDRAFT_BUTTON = By.XPath("//button/span/i[@class='mdi mdi-plus mdi-18px']");
        public By CLOSEDRAFT_BUTTON = By.XPath("//button[@aria-label='Close dialog']");
        public By DRAFTNAME_EDT = By.XPath("//input[@ng-reflect-placeholder='Draft Name']");
        public By EXISTINGDRAFT_CLICK = By.XPath("(//div[@class='mat-radio-outer-circle'])[1]");
        public By BLANKDRAFT_CLICK = By.XPath("(//div[@class='mat-radio-outer-circle'])[2]");
        public By EXISTINGDRAFTDROPDOWN = By.XPath("//mat-select[@aria-label='Existing Drafts']");
        public By CODERDRAFT_CLICK = By.XPath("(//mat-option[@class='mat-option ng-star-inserted mat-selected mat-active']//span)[contains(text(),'Coder Draft')]");
        public By CREATEDRAFT_BUTTON = By.XPath("(//button[@class='mat-raised-button mat-primary']/span)[contains(text(),'Create Draft')]");
        public By DRAFTNAMEERROR = By.XPath("//mat-error[text()='Please enter at least 5 characters.']");
        public By OPENPROJECT = By.XPath("(//button[@class='mat-raised-button mat-primary']/span)[contains(text(),'Open')]");
        public By LATEST_DRAFT_IN_DROPDOWN = By.XPath("(//mat-option[@class='mat-option ng-star-inserted']//span)[last()]");

        
        /**
        * Constructor: CreateDraftPage()
        * Description: This constructor is used to initialize the webdriver
        */
        public CreateDraftPage(IWebDriver driver) : base(driver)
        {

        }

        

        /**
        * MethodName: ClickNewDraft()
        * Description: This method is used to click on New Draft button
        */
        public void ClickNewDraft()
        {
            Click(NEWDRAFT_BUTTON);
            Info("Clicked on New Draft Button.");
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
            Info("Error for Invalid Draft is: "+text);
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
            Info("Coder Draft Selected.");
        }

        public void SelectExistingDraft()
        {
            Click(EXISTINGDRAFTDROPDOWN);
            System.Threading.Thread.Sleep(5000);
            Click(LATEST_DRAFT_IN_DROPDOWN);
            Info("Selected latest Draft");

        }

        /**
        * MethodName: ClikOnBackdrop()
        * Description: This method is used to click on Backdrop
        */
        public void ClikOnBackdrop()
        {
            Click(UNITYMANUAL_CLICK);
            Info("Clicked on Backdrop.");

        }

        /**
        * MethodName: isDraftPopUpEnabled()
        * Description: This method is used to verify if the draft pop up is enabled after clicking on new draft button
        */
        public Boolean IsDraftPopUpEnabled()
        {
            Boolean flag = this.IsEnabled(CLOSEDRAFT_BUTTON);
            Info("Draft Dialog Box Is Enabled");
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
            Info("Entered Draft Name : " + DraftName);
            return DraftName;

        }

        /**
        * MethodName: EnterDraftName()
        * Description: This method is used to enter draft name
        */
        public void EnterDraftName(String draftName)
        {
            EnterValue(DRAFTNAME_EDT, draftName);
            Info("Entered Draft Name:" + draftName);

        }

        /**
        * MethodName: EnterValidDraftName()
        * Description: This method is used to enter valis draft name
        */
        public String EnterValidDraftName()
        {
            String DraftName = "Draft" + "_" + GenerateRandomNumbers(2);
            EnterValue(DRAFTNAME_EDT, DraftName);
            Info("Draft Name is" + DraftName);
            return DraftName;
        }

        /**
        * MethodName: CreateDraft()
        * Description: This method is used to click on  create draft button
        */
        public void CreateDraft()
        {
            Click(CREATEDRAFT_BUTTON);
            Info("Draft Created Successfully.");
        }

        /**
        * MethodName: ClickOnBlankDraft()
        * Description: This method is used to click on Blank Draft for draft creation
        */
        public void ClickOnBlankDraft()
        {
            Click(BLANKDRAFT_CLICK);
            Info("Selected Blank Draft.");
        }

        /**
        * MethodName: ClickOnExistingDraft()
        * Description: This method is used to click on Existing Draft for draft creation
        */
        public void ClickOnExistingDraft()
        {
            Click(EXISTINGDRAFT_CLICK);
            Info("Selected Existing Draft.");
        }

        /**
        * MethodName: CLOSEDRAFT()
        * Description: This method is used to close draft
        */
        public void CLOSEDRAFT()
        {
            Click(CLOSEDRAFT_BUTTON);
            Info("Clicked on Close Draft Button.");
        }

        /**
        * MethodName: CLICKOPENPROJECT()
        * Description: This method is used to open the project
        */
        public void CLICKOPENPROJECT()
        {
            Click(OPENPROJECT);
            Info("Clicked on Open Project Button.");
        }

    }
}
