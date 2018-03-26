using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AventStack.ExtentReports;
namespace DocWorksQA.Pages
{
    class CreateDistributionPage : SeleniumHelpers.PageControl
    {

        private ExtentTest test;

        public By ENTER_SEARCH = By.XPath("//input[@type='Search']");
        public By GET_TITLE = By.XPath("//mat-card/mat-card-title/div");
        public By SETTINGS = By.XPath("//mat-card/mat-card-title/div[2]//i[1]");
        public By DISTRIBUTIONS = By.XPath("(//button[@class='mat-menu-item ng-star-inserted'])[contains(text(),'Distributions')]");
            //By.XPath("(//button[@class='mat-menu-item'])[2]");
        public By DISTRIBUTION_NAME = By.XPath("//input[@ng-reflect-placeholder='Distribution Name']");
        public By DESCRIPTION = By.XPath("//input[@ng-reflect-placeholder='Description']");
        public By SELECT_BRANCH = By.XPath("//mat-select[@ng-reflect-placeholder='Select Branch']");
        public By BRANCH = By.XPath("//input[@placeholder='Branch']");
        public By BRANCH_OPTIONS_WITHTOC = By.XPath("(//mat-option//span[contains(@class,'mat-option-text')])[text()='DocworksManual3']");
        public By BRANCH_OPTIONS_WITHOUT_TOC = By.XPath("(//mat-option//span[contains(@class,'mat-option-text')])[text()='DocworksManual2']");
        public By BRANCH_OPTIONS_GITHUB = By.XPath("(//mat-option//span[contains(@class,'mat-option-text')])[text()='DocWorksManual3']");
        public By CLEAR_BUTTON = By.XPath("(//button[@class='mat-raised-button']/span)[1]");
        public By CLOSE_BUTTON = By.XPath("//button/span/i[@class='mdi mdi-close mdi-24px']");
        public By CREATE_DISTRIBUTION = By.XPath("(//button[@class='mat-raised-button mat-primary']/span)[3]");
        public By AVAIL_DISTRIBUTION_NAME = By.XPath("(//mat-chip/div/strong)");
        public By AVAIL_DISTRIBUTION_EDIT = By.XPath("//mat-chip/div/mat-icon/i");
        //public By AVAIL_DISTRIBUTION_CREATED_DT = By.XPath("//mat-chip/small/strong");
        public By INVALID_TITLE_LENGTH = By.XPath("//mat-error[@class='mat-error ng-star-inserted']");
        public By TOC_PATH = By.XPath("//input[@placeholder='TOC Path']");

        /**
        * Constructor: CreateDistributionPage()
        * Description: This constructor is used to initialize the webdriver
        */
        public CreateDistributionPage(IWebDriver driver) : base(driver)
        {
           
        }

        /**
        * MethodName: SearchForProject()
        * Description: This method is used to search for the projectName
        */
        public void SearchForProject(String projectName)
        {
            Clear(ENTER_SEARCH);
            EnterValue(ENTER_SEARCH, projectName);
            info("ProjectName is" + projectName);
        }

        /**
       * MethodName: getProjectTitle()
       * Description: This method is used to get the project Title
       */
        public String getProjectTitle()
        {
            info("ProjectTitle is" + this.GetText(GET_TITLE));
            return this.GetText(GET_TITLE);
        }

        /**
         * MethodName: ClickDistribution()
        * Description: This method is used to click the distribution
         */
        public void ClickDistribution()
        {
            Click(SETTINGS);
            Click(DISTRIBUTIONS);
            info("Clicked on Distributions");

        }

        /**
        * MethodName: SuccessScreenshot()
        * Description: This method is used to take the success screenshots
        */
        public void SuccessScreenshot(String path, String message)
        {
         info("<a href=\"" + path + "\">ScreenShot : " + message + "<br></a>");

        }

        /**
        * MethodName: EnterDistirbutionName()
        * Description: This method is used to enter the distribution name
        */
        public String EnterDistirbutionName()
        {
            String DistName = "SELENIUM_DIST" + "_" + generateRandomNumbers(2);
            EnterValue(DISTRIBUTION_NAME, DistName);
            info("Distribution Name is" + DistName);
            return DistName;
        }

        /**
       * MethodName: EnterInvalidnNameLength()
       * Description: This method is used to enter the invalid name length
       */
        public String EnterInvalidnNameLength()
        {
            String DistributionTitle = "QA";
            EnterValue(DISTRIBUTION_NAME, DistributionTitle);
            info("Entered Distribution Title : " + DistributionTitle);
            return DistributionTitle;

        }

        /**
      * MethodName: EnterDescription()
      * Description: This method is used to enter the Description
      */
        public void EnterDescription(String Description)
        {
            EnterValue(DESCRIPTION, Description);
            info("Distribution Description is" + Description);
        }

        public void EnterTocPath()
        {
            EnterValue(TOC_PATH, "Tocfolder");
            info("Entered TOC Path");
        }
        /**
             * MethodName: ClickBranch()
            * Description: This method is used to click the branch
        */
        public void ClickBranchWithTOC()
        {
            Boolean flag = false;
           
                WaitForElement(SELECT_BRANCH);
                this.Click(SELECT_BRANCH);
            info("Cicked on Branch dropdown");
            System.Threading.Thread.Sleep(5000);
                    this.Click(BRANCH_OPTIONS_WITHTOC);
            info("Selected the branch");
        }
        public void ClickBranchWithOutTOC()
        {
            Boolean flag = false;

            WaitForElement(SELECT_BRANCH);
            this.Click(SELECT_BRANCH);
            info("Cicked on Branch dropdown");
            System.Threading.Thread.Sleep(5000);
            this.Click(BRANCH_OPTIONS_WITHOUT_TOC);
            info("Selected the branch");
        }
        public void ClickBranchForGitHub()
        {
            Boolean flag = false;

            WaitForElement(SELECT_BRANCH);
            this.Click(SELECT_BRANCH);
            info("Cicked on Branch dropdown");
            System.Threading.Thread.Sleep(5000);
            this.Click(BRANCH_OPTIONS_GITHUB);
            info("Selected the branch");
        }

        public void EnterBranchForMercurial()
        {
            String str = "DocworksManual3";
            EnterValue(BRANCH,str);
            info("Entered Branch value");
        }
        public void EnterBranchWithoutTOCForMercurial()
        {
            String str = "DocworkManual2";
            EnterValue(BRANCH, str);
            info("Entered Branch value");
        }
        /**
            * MethodName: ClickCreateDistribution()
            * Description: This method is used to click the Create Distribution
       */
        public void ClickCreateDistribution()
        {
            Click(CREATE_DISTRIBUTION);
            info("Click on Create distribution");
        }

        /**
           * MethodName: ClickClearButton()
           * Description: This method is used to click the Clear Button
        */
        public void ClickClearButton()
        {
            Click(CLEAR_BUTTON);
            info("Click Clear Button");

        }

        /**
           * MethodName: ClickCloseButton()
           * Description: This method is used to click the close Button
        */
        public void ClickCloseButton()
        {
            Click(CLOSE_BUTTON);
            info("Click Close Button");
            

        }

        /**
          * MethodName: getDistributionName()
          * Description: This method is used to get the distribution name
       */
        public String getDistributionName()
        {
            info("Available Distribution Name is" + this.GetText(AVAIL_DISTRIBUTION_NAME));
            return this.GetText(AVAIL_DISTRIBUTION_NAME);
        }

        /**
         * MethodName: ClickAvailDistributionDeletd()
         * Description: This method is used to click on the available distribution
        */
       
    }
}
