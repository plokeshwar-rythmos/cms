using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.IO;
using NUnit.Framework;

namespace DocWorksQA.Pages
{
    class AuthoringScreenEnhancements : SeleniumHelpers.PageControl
    {
        private IWebDriver driver;
        public By UNITYMANUAL_CLICK = By.XPath("//span[@class='ui-treenode-label ui-corner-all']");
        public By BACKDROP_CLICK = By.XPath("//div[@class='mat-drawer-backdrop mat-drawer-shown']");
        public By NEWDRAFT_BUTTON = By.XPath("//button/span/i[@class='mdi mdi-plus mdi-18px']");
        public By CLOSEDRAFT_BUTTON = By.XPath("//button[@aria-label='Close dialog']");
        public By DRAFTNAME_EDT = By.XPath("//input[@ng-reflect-placeholder='Draft Name']");
        public By BLANKDRAFT_CLICK = By.XPath("(//div[@class='mat-radio-outer-circle'])[2]");
        public By EXISTINGDRAFTDROPDOWN = By.XPath("//mat-select[@aria-label='Existing Drafts']");
        public By CODERDRAFT_CLICK = By.XPath("//mat-option/span[@class='mat-option-text'][text()=' Coder Draft ']");
        public By CREATEDRAFT_BUTTON = By.XPath("//button[@class='mat-raised-button mat-primary']");
        public By DRAFTNAMEERROR = By.XPath("//mat-error[text()='Please enter at least 5 characters.']");
        public By OPENPROJECT = By.XPath("//button[@class='mat-raised-button mat-primary']/span[text()='Open']");
        public By LEFT_DRAFTDROPDOWN = By.XPath("//div[@class='authoring-tabview left-window']//mat-select");
        public By RIGHT_DRAFTDROPDOWN = By.XPath("//div[@class='authoring-tabview right-window']//mat-select");
        //public By LEFT_DRAFTSELECT = By.XPath("(//mat-option/span)[text()='Mok123']");
        public By LEFT_GDOC_TAB = By.XPath("(//div[@class='authoring-tabview left-window']//div/span)[text()='GDoc']");
        public By LEFT_HTML_TAB = By.XPath("(//div[@class='authoring-tabview left-window']//div/span)[text()='HTML']");
        public By LEFT_MD_TAB = By.XPath("(//div[@class='authoring-tabview left-window']//div/span)[text()='.md']");
        public By LEFT_PREVIEW_TAB = By.XPath("(//div[@class='authoring-tabview left-window']//div/span)[text()='preview']");
        public By LEFT_HISTORY_TAB = By.XPath("(//div[@class='authoring-tabview left-window']//div/span)[text()='history']");
        public By RIGHT_GDOC_TAB = By.XPath("//div[@id='mat-tab-label-1-0']");
        public By RIGHT_HTML_TAB = By.XPath("//div[@id='mat-tab-label-1-1']");
        public By Right_HTML_EDT = By.XPath("//app-authoring-tabbed-view[@ng-reflect-align='right']//div[@ng-reflect-ng-class='authoring-tabview-body']/div");
        public By RIGHT_MD_TAB = By.XPath("//div[@id='mat-tab-label-1-2']");
        public By RIGHT_PREVIEW_TAB = By.XPath("//div[@id='mat-tab-label-1-3']");
        public By RIGHT_HISTORY_TAB = By.XPath("//div[@id='mat-tab-label-1-4']");
        public By EDT_LEFT_TAB = By.XPath("//div[@class='authoring-tabview left-window']/div[2]/div");
        public By EDT_RIGHT_TAB = By.XPath("//div[@class='authoring-tabview right-window']/div[2]/div");
        public By EDT_GDOC = By.XPath("(//div[@class='kix-appview-editor']//span[@class='goog-inline-block kix-lineview-text-block']/span)[1]");
        public By EDT_GDOC_HDR = By.XPath("(//div[@class='kix-appview-editor']//div[@class='kix-print-block kix-page-header'])[1]");
        public By EDT_GDOC_HDR_RT = By.XPath("(//div[@class='kix-appview-editor']//div[@class='kix-print-block kix-page-header'])[2]");
        public By INSERT = By.XPath("//button/span/i[@class='mdi mdi-menu-down mdi-18px']");
        public By SELECT_INSERT_IMAGE = By.XPath("(//button[@class='mat-menu-item']//mat-icon)[1]");
        public By SELECT_INSERT_CODEBLOCK = By.XPath("(//button[@class='mat-menu-item']//mat-icon)[2]");
        public By CLICK_UPLOADED_BY_ME = By.XPath("//mat-dialog-container//div[text()='Uploaded by me']");
        public By SELECT_IMAGE_FROM_UPLOAD = By.XPath("(//div[@class='media-image'])[last()]");
        public By SELECT_CODEBLOCK_FROM_UPLOAD = By.XPath("(//div[@class='media-image']/mat-icon)[last()]");
        public By CLICK_CODEBLOCK_TAB = By.XPath("//div[@class='mat-tab-label mat-ripple ng-star-inserted'][text()='Code Blocks']");
        public By CLICK_ACCEPTDRAFTTOLIVE = By.XPath("//button/span/i[@class='mdi mdi-checkbox-marked-circle-outline mdi-18px']");
        public By SELECT_DRAFT_FROM_CLICK_ACCEPTDRAFTTOLIVE = By.XPath("(//button[@class='mat-menu-item ng-star-inserted'])[1]");
        public By UPLOAD_BUTTON = By.XPath("(//input[@type='file'])[1]");
        public By REPLACE_BUTTON = By.XPath("(//input[@type='file'])[2]");
        public By ACCEPTDRAFTTOLIVE_DROPDOWN = By.XPath("//div[@class='mat-menu-content ng-trigger ng-trigger-fadeInItems']");
        public By SEARCH_ASSETID = By.XPath("//input[@type='Search']");
        public By SEARCH_ASSET_BAR = By.XPath("//button//span/i[@class='mdi mdi-magnify mdi-24px']");
        public By HISTORY_VALID_DRAFT1 = By.XPath("(//mat-list[@class='mat-list valid-draft ng-star-inserted']//div[@class='mat-list-item-content'])[last()]");
        public By HISTORT_VALID_DRAFT2 = By.XPath("(//mat-list[@class='mat-list valid-draft ng-star-inserted']//div[@class='mat-list-item-content'])[1]");
        public By ViewDraft_DraftName = By.XPath("//input[@ng-reflect-placeholder='Draft Name']");



        public AuthoringScreenEnhancements(IWebDriver driver) : base(driver)
        {
        }

        public void OpenProject()
        {
            Click(OPENPROJECT);
            info("Clicked on open Project");
        }

        public void ClickNode()
        {
            Click(UNITYMANUAL_CLICK);
            info("Clicked on Unity Manual Node");
        }

        public void ClickBackDrop()
        {
            Click(BACKDROP_CLICK);
             info("Clicked Backdrop");
        }

        public void LeftDraftDropDown(String str)
        {
            System.Threading.Thread.Sleep(7000);
            Click(LEFT_DRAFTDROPDOWN);
            String s = "(//mat-option/span)" + "[text()='" + str + "']";
            Click(By.XPath(s));
            info("selected Draft:  "+str+"  in left Drop Down");
        }

        public void LeftLiveDraft()
        {
            System.Threading.Thread.Sleep(7000);
            Click(LEFT_DRAFTDROPDOWN);
            Click(By.XPath("(//mat-option/span)[text()='Live Draft']"));
            info("selected a Live draft in Left Drop Down");

        }


        public void LeftCoderDraft()
        {
            Click(LEFT_DRAFTDROPDOWN);
            Click(By.XPath("(//mat-option/span)[text()='Coder Draft']"));
            info("selected a Coder draft in Left Drop Down");
        }
        public IWebElement EnterIntoLeftFrame()
        {
            IWebElement framel = WaitForElement(By.XPath("//app-authoring-tabbed-view[@ng-reflect-align='left']//div//iframe"));

            return framel;
        }

        public void ClickGdocLeft( )
        {
            Click(EDT_GDOC_HDR);
            System.Threading.Thread.Sleep(7000);
            info("Click on left Gdoc");
            

        }

        public void RightDraftDropDown(String str)
        {
            System.Threading.Thread.Sleep(7000);
            Click(RIGHT_DRAFTDROPDOWN);
            String s = "(//mat-option/span)" + "[text()='" + str + "']";
            Click(By.XPath(s));
            info("selected Draft:  " + str + "  in Right Drop Down");
        }

        public void RightLiveDraft()
        {
            Click(RIGHT_DRAFTDROPDOWN);
            Click(By.XPath("(//mat-option/span)[text()='Live Draft']"));
            info("selected a Live draft in Right Drop Down");

        }
        public Boolean IsAcceptDraftToLiveButtonEnabled()
        {
            Boolean Flag = this.IsEnabled(By.XPath("//button[@ng-reflect-disabled='true'] /span/i[@class='mdi mdi-checkbox-marked-circle-outline mdi-18px']"));

           info("AddProject Button id Enabled");


            return Flag;
        }
        public void RightCoderDraft()
        {
            Click(RIGHT_DRAFTDROPDOWN);
            Click(By.XPath("(//mat-option/span)[text()='Coder Draft']"));
            info("selected a Coder draft in Right Drop Down");

        }
        public String GetTextInRightDropDown()
        {
           String str= GetText(RIGHT_DRAFTDROPDOWN);
           info("Right Drop Down Value is " + str);
            return str;
        }
        public IWebElement EnterIntoRightFrame()
        {
            IWebElement framel = WaitForElement(By.XPath("//app-authoring-tabbed-view[@ng-reflect-align='right']//div//iframe"));

            return framel;
        }
        public void SuccessScreenshot(String path, String message)
        {
           info("<a href=\"" + path + "\">ScreenShot : " + message + "<br></a>");

        }

        public void HtmlRightTab()
        {
            Click(RIGHT_HTML_TAB);
            System.Threading.Thread.Sleep(20000);
            info("Clicked On Right HTML Tab");

        }
        public void GdocLeftTab()
        {
            Click(LEFT_GDOC_TAB);
            info("Clicked On Left GDOC Tab");
        }

        public void HtmlLeftTab()
        {
            Click(LEFT_HTML_TAB);
            System.Threading.Thread.Sleep(20000);
            info("Clicked On Left HTML Tab");

        }

        public void HistoryLeftTab()
        {
            Click(LEFT_HISTORY_TAB);
            System.Threading.Thread.Sleep(20000);
            info("Clicked On Left History Tab");

        }
        public void HistoryRightTab()
        {
            Click(RIGHT_HISTORY_TAB);
            System.Threading.Thread.Sleep(20000);
            info("Clicked On Right History Tab");
        }
        public void GdocRightTab()
        {
            Click(RIGHT_GDOC_TAB);
            System.Threading.Thread.Sleep(20000);
            info("Clicked on Right GDOC Tab");
        }
        public void MDRightTab()
        {
            Click(RIGHT_MD_TAB);
            System.Threading.Thread.Sleep(20000);
            info("Clicked on Right MD Tab");
        }
        public void MDLeftTab()
        {
            Click(LEFT_MD_TAB);
            System.Threading.Thread.Sleep(20000);
            info("Clicked On Left MD Tab");
        }
        public void PreviewRightTab()
        {
            Click(RIGHT_PREVIEW_TAB);
            System.Threading.Thread.Sleep(20000);
            info("Clicked On Right Preview Tab");
        }
        public void PreviewLeftTab()
        {
            Click(LEFT_PREVIEW_TAB);
            System.Threading.Thread.Sleep(20000);
            info("Clicked on Left Preview Tab");
        }

        public void  ClickGdocRight()
        {
            Click(EDT_GDOC_HDR);
            System.Threading.Thread.Sleep(7000);
            info("Clicked On GDOC Right");
            
        }

        public void ClickInsertImage()
        {
            Click(INSERT);
            System.Threading.Thread.Sleep(7000);
            info("Clicked On Insert Menu");
            Click(SELECT_INSERT_IMAGE);
            System.Threading.Thread.Sleep(7000);
            info("Selected Insert Image");
            Click(CLICK_UPLOADED_BY_ME);
            System.Threading.Thread.Sleep(7000);
            info("Clicked on Uploaded By Me Tab");
        }
        public void ClickInsertCodeBlock()
        {
            Click(INSERT);
            System.Threading.Thread.Sleep(7000);
            info("Clicked on Insert Menu");
            Click(SELECT_INSERT_CODEBLOCK);
            System.Threading.Thread.Sleep(7000);
            info("Selected Insert CodeBlock");
            Click(CLICK_UPLOADED_BY_ME);
            System.Threading.Thread.Sleep(7000);
            info("Clicked on Uploaded By Me Tab");
        }

        public void SearchAssetID()
        {
            System.Threading.Thread.Sleep(7000);
            EnterValue(SEARCH_ASSETID, Keys.Control + "v");
            System.Threading.Thread.Sleep(7000);
            Click(By.XPath("//button/span/i[@class='mdi mdi-magnify mdi-24px']"));
           info("Clicked the search button");
        }

        public void ReplaceTheImage(String Name)
        {

            
            String Image_Path = getImagePath();
            Console.WriteLine("********" + Image_Path);
            System.Threading.Thread.Sleep(7000);

            EnterValue(REPLACE_BUTTON, Image_Path);
            System.Threading.Thread.Sleep(7000);
            Click(By.XPath("//mat-dialog-actions/div/button/span[text()='REPLACE']"));
            System.Threading.Thread.Sleep(27000);
            info("Replaced the Image");
        }

        public void ReplaceCodeBlocks()
        {
           
            String Image_Path = getCodeBlockPath();
            Console.WriteLine("********" + Image_Path);
            System.Threading.Thread.Sleep(7000);
            EnterValue(REPLACE_BUTTON, Image_Path);
            System.Threading.Thread.Sleep(7000);
            Click(By.XPath("//mat-dialog-actions/div/button/span[text()='REPLACE']"));
            System.Threading.Thread.Sleep(27000);
            info("Replaced the codeBlocks");

        }
        public void SelectImageFromUpload(String Name)
        {
            info("Selecting image: "+Name+" from the Upload");
            System.Threading.Thread.Sleep(7000);
            Click(By.XPath("//button/span/i[@class='mdi mdi-content-copy']"));
            info("copying the clipboard content of Image");
            System.Threading.Thread.Sleep(8000);
            Click(By.XPath("//button/span/i[@class='mdi mdi-close mdi-24px']"));
            System.Threading.Thread.Sleep(7000);
            info("copied the Asset Id and Closed the dialog box");
        }

        public void SelectCodeBlockFromUpload(String Name)
        {
          
           info("Selecting CodeBlock: "+Name+" from Upload");
            System.Threading.Thread.Sleep(7000);
            Click(By.XPath("//button/span/i[@class='mdi mdi-content-copy']"));
            info("copying the clipboard content");
            System.Threading.Thread.Sleep(7000);
            Click(By.XPath("//button/span/i[@class='mdi mdi-close mdi-24px']"));
            System.Threading.Thread.Sleep(7000);
            info("copied the Asset Id and Closed the dialog box");
        }
        public void CloseUploadPage()
        {
            Click(By.XPath("//button/span/i[@class='mdi mdi-close mdi-24px']"));
            System.Threading.Thread.Sleep(7000);
            info("Closed the Uppload Image Dialog box");
        }

        public void EnterAssetID()
        {
            EnterValue(SEARCH_ASSETID, Keys.Control + "V");
            info("ENtered the Asset ID in Search Bar");
        }
        public void EnterAssetName(String Name)
        {
            EnterValue(SEARCH_ASSETID, Name);
            info("ENtered Asset Name: " + Name);
            Click(SEARCH_ASSET_BAR);
            info("Clicked On Search Bar");
            System.Threading.Thread.Sleep(5000);
        }
        public void ClickMedia()
        {
            Click(By.XPath("//a[@href='/media']"));
            System.Threading.Thread.Sleep(7000);
            info("Clicked on Media Tab");

        }
        public void ClickCodeBlocksTab()
        {
            Click(CLICK_CODEBLOCK_TAB);
            System.Threading.Thread.Sleep(5000);
            info("Clicked on CodeBlock Tab");
        }

        public void UploadCodeBlock()
        {
            Click(By.XPath("//div[@class='mat-tab-label mat-ripple ng-star-inserted'][text()='Uploaded By Me']"));
            try
            {
                String CodeBlock_Path = getCodeBlockPath();
                Console.WriteLine("********" + CodeBlock_Path);
                EnterValue(UPLOAD_BUTTON, CodeBlock_Path);
                System.Threading.Thread.Sleep(17000);
                info("Uploaded CodeBlock");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            System.Threading.Thread.Sleep(7000);
           // Click(By.XPath("//div[@class='mat-tab-label mat-ripple ng-star-inserted'][text()='Uploaded By Me']"));
            System.Threading.Thread.Sleep(7000);
        }
        public void UploadInvalidCodeBlock()
        {
            Click(By.XPath("//div[@class='mat-tab-label mat-ripple ng-star-inserted'][text()='Uploaded By Me']"));
            try
            {
                String CodeBlock_Path = getInvalidCodeBlockPath();
                var fileLength = new FileInfo(CodeBlock_Path).Length;
                fileLength = fileLength / 1000;
                Console.WriteLine("The random CodeBlock size" + fileLength);
                Console.WriteLine("********" + CodeBlock_Path);
                if (fileLength < 100)
                {
                    EnterValue(UPLOAD_BUTTON, CodeBlock_Path);
                    System.Threading.Thread.Sleep(7000);
                    Click(By.XPath("//div[@aria-controls='mat-tab-content-1-1']"));
                    System.Threading.Thread.Sleep(7000);
                    String str = GetText(By.XPath("//div/mat-error/span"));

                    Assert.AreEqual("Only .txt/.cs format allowed.", str, "Validating error message for .docx and .xml codeblocks");

                }
                else
                {
                    EnterValue(UPLOAD_BUTTON, CodeBlock_Path);
                    Click(By.XPath("//div[@aria-controls='mat-tab-content-1-1']"));
                    System.Threading.Thread.Sleep(7000);
                    String str = GetText(By.XPath("//div/mat-error/span"));

                    Assert.AreEqual("Max 100KB size allowed", str, "Validating error message for CodeBlocks size greater than 100KB");

                }
                System.Threading.Thread.Sleep(17000);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void UploadImage()
        {
            Click(By.XPath("//div[@class='mat-tab-label mat-ripple ng-star-inserted'][text()='Uploaded By Me']"));
            try
            {
                String Image_Path = getImagePath();
                Console.WriteLine("********" + Image_Path);
                EnterValue(UPLOAD_BUTTON, Image_Path);
                System.Threading.Thread.Sleep(7000);
                info("Uploaded Image");
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            System.Threading.Thread.Sleep(5000);
           // Click(By.XPath("//div[@class='mat-tab-label mat-ripple ng-star-inserted'][text()='Uploaded By Me']"));
            System.Threading.Thread.Sleep(3000);
            
        }

        public void ViewDraft()
        {
            MoveToelement(HISTORY_VALID_DRAFT1);
            System.Threading.Thread.Sleep(7000);
            MoveToelementAndClick(By.XPath("(//div[@class='draft-extend-icons']/i[@title='View Draft'])"));
            System.Threading.Thread.Sleep(7000);
            info("Clicked on View Draft");
        }

        public void ViewDraft1()
        {
            System.Threading.Thread.Sleep(7000);
            MoveToelement(HISTORT_VALID_DRAFT2);
            System.Threading.Thread.Sleep(7000);
            MoveToelementAndClick(By.XPath("(//div[@class='draft-extend-icons']/i[@title='View Draft'])"));
            System.Threading.Thread.Sleep(7000);
            info("Clicked on Uppdated View Draft");
        }

        public String CreateDraftFromSnapshot()
        {
            System.Threading.Thread.Sleep(7000);
            MoveToelement(HISTORT_VALID_DRAFT2);
            System.Threading.Thread.Sleep(7000);
            MoveToelementAndClick(By.XPath("(//div[@class='draft-extend-icons']/i[@title='Create Draft'])"));
            System.Threading.Thread.Sleep(7000);
            String str = "DraftSnapshot " + generateRandomNumbers(2);
            EnterValue(ViewDraft_DraftName, str);
            System.Threading.Thread.Sleep(7000);
            Click(By.XPath("(//button[@class='mat-raised-button mat-primary']/span)[contains(text(),'Create Draft')]"));
            System.Threading.Thread.Sleep(7000);
            info("Created Draft from SnapShot");
            return str;
        }
        public String GetViewDraft()
        {
        String str =  GetText(By.XPath("//mat-dialog-content//div[@class='view-draft-wrapper']/div"));
            info("Getting Text From View Draft");
            return str;
        }
        public void CloseViewDraft()
        {
            Click(By.XPath("//button//i[@class='mdi mdi-close mdi-24px']"));
            info("Closing View Draft");
        }
        public void UploadInvalidImages()
        {
            Click(By.XPath("//div[@class='mat-tab-label mat-ripple ng-star-inserted'][text()='Uploaded By Me']"));
            try
            {
                String Image_Path = getInvalidImagePath();
                var fileLength = new FileInfo(Image_Path).Length;
                fileLength = fileLength / 1000;
                Console.WriteLine("The random image" + fileLength);
                Console.WriteLine("********" + Image_Path);
                if (fileLength < 100)
                {
                    EnterValue(UPLOAD_BUTTON, Image_Path);
                    System.Threading.Thread.Sleep(7000);
                    Click(By.XPath("//div[@aria-controls='mat-tab-content-1-1']"));
                    System.Threading.Thread.Sleep(7000);
                    String str = GetText(By.XPath("//div/mat-error/span"));
                   
                    Assert.AreEqual("Only .jpeg/.jpg/.png/.gif format allowed.", str, "Validating error message for tif image");
                   
                }
                else
                {
                    EnterValue(UPLOAD_BUTTON, Image_Path);
                    Click(By.XPath("//div[@aria-controls='mat-tab-content-1-1']"));
                    System.Threading.Thread.Sleep(7000);
                    String str = GetText(By.XPath("//div/mat-error/span"));

                    Assert.AreEqual("Max 100KB size allowed", str, "Validating error message image size greater than 100KB");

                }
                System.Threading.Thread.Sleep(17000);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        public void ClickDashboard()
        {
            Click(By.XPath("//a[@href='/dashboard']"));
            System.Threading.Thread.Sleep(7000);
            info("Clicked on Dashboard");
        }
        public void ClickAcceptDraftToLive()
        {
            Click(CLICK_ACCEPTDRAFTTOLIVE);
            info("Clicked on Accept Draft to Live button");
        }

        public void SelectDraftFromAcceptDraftToLiveDropDown()
        {
            Click(SELECT_DRAFT_FROM_CLICK_ACCEPTDRAFTTOLIVE);
            info("Clicked on First Option in DropDown");
        }
        public String GetDropDownValues()
        {
            String str = GetText(ACCEPTDRAFTTOLIVE_DROPDOWN);
            info("When Clicked on Accept Draft to Live button the drop down consists of  "+ str);
            Click(By.XPath("//div[@class='cdk-overlay-backdrop cdk-overlay-transparent-backdrop cdk-overlay-backdrop-showing']"));
            return str;
        }
    }
}
