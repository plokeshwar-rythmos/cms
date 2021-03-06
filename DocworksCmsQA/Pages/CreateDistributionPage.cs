﻿using System;
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
            Info("ProjectName is" + projectName);
        }

        /**
       * MethodName: getProjectTitle()
       * Description: This method is used to get the project Title
       */
        public String GetProjectTitle()
        {
            Info("ProjectTitle is" + this.GetText(GET_TITLE));
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
            Info("Clicked on Distributions");

        }

        /**
        * MethodName: SuccessScreenshot()
        * Description: This method is used to take the success screenshots
        */
        public void SuccessScreenshot(String path, String message)
        {
         Info("<a href=\"" + path + "\">ScreenShot : " + message + "<br></a>");

        }

        /**
        * MethodName: EnterDistirbutionName()
        * Description: This method is used to enter the distribution name
        */
        public String EnterDistirbutionName()
        {
            String DistName = "SELENIUM_DIST" + "_" + GenerateRandomNumbers(2);
            EnterValue(DISTRIBUTION_NAME, DistName);
            Info("Distribution Name is" + DistName);
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
            Info("Entered Distribution Title : " + DistributionTitle);
            return DistributionTitle;

        }

        /**
      * MethodName: EnterDescription()
      * Description: This method is used to enter the Description
      */
        public void EnterDescription(String Description)
        {
            EnterValue(DESCRIPTION, Description);
            Info("Distribution Description is" + Description);
        }

        public void EnterTocPath()
        {
            EnterValue(TOC_PATH, "Tocfolder");
            Info("Entered TOC Path");
        }
        /**
             * MethodName: ClickBranch()
            * Description: This method is used to click the branch
        */
        public void ClickBranchWithTOC()
        {
            WaitForElement(SELECT_BRANCH);
                this.Click(SELECT_BRANCH);
            Info("Cicked on Branch dropdown");
            System.Threading.Thread.Sleep(5000);
                    this.Click(BRANCH_OPTIONS_WITHTOC);
            Info("Selected the branch");
        }

        public void ClickBranchWithOutTOC()
        {
            
            WaitForElement(SELECT_BRANCH);
            this.Click(SELECT_BRANCH);
            Info("Cicked on Branch dropdown");
            System.Threading.Thread.Sleep(5000);
            this.Click(BRANCH_OPTIONS_WITHOUT_TOC);
            Info("Selected the branch");
        }
        public void ClickBranchForGitHub()
        {
            WaitForElement(SELECT_BRANCH);
            this.Click(SELECT_BRANCH);
            Info("Cicked on Branch dropdown");
            System.Threading.Thread.Sleep(5000);
            this.Click(BRANCH_OPTIONS_GITHUB);
            Info("Selected the branch");
        }

        public void EnterBranchForMercurial()
        {
            String str = "DocworksManual3";
            EnterValue(BRANCH,str);
            Info("Entered Branch value");
        }
        public void EnterBranchWithoutTOCForMercurial()
        {
            String str = "DocworkManual2";
            EnterValue(BRANCH, str);
            Info("Entered Branch value");
        }
        /**
            * MethodName: ClickCreateDistribution()
            * Description: This method is used to click the Create Distribution
       */
        public void ClickCreateDistribution()
        {
            Click(CREATE_DISTRIBUTION);
            Info("Click on Create distribution");
        }

        /**
           * MethodName: ClickClearButton()
           * Description: This method is used to click the Clear Button
        */
        public void ClickClearButton()
        {
            Click(CLEAR_BUTTON);
            Info("Click Clear Button");

        }

        /**
           * MethodName: ClickCloseButton()
           * Description: This method is used to click the close Button
        */
        public void ClickCloseButton()
        {
            Click(CLOSE_BUTTON);
            Info("Click Close Button");
            

        }

        /**
          * MethodName: getDistributionName()
          * Description: This method is used to get the distribution name
       */
        public String GetDistributionName()
        {
            Info("Available Distribution Name is" + this.GetText(AVAIL_DISTRIBUTION_NAME));
            return this.GetText(AVAIL_DISTRIBUTION_NAME);
        }

        /**
         * MethodName: ClickAvailDistributionDeletd()
         * Description: This method is used to click on the available distribution
        */
       
    }
}
