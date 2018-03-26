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
    class NodesPage : SeleniumHelpers.PageControl
    {
        public By UNITYMANUAL_TREE = By.XPath("//span[@class='ui-treenode-label ui-corner-all']");
        public By UNITYMANUAL_SIDEBAR = By.XPath("//span[@class='ui-tree-toggler fa fa-fw fa-caret-right']");
        public By NEW_NODE_CLICK = By.XPath("//a[@class='ui-menuitem-link ui-corner-all ng-star-inserted']");
        public By NODE_NAME = By.XPath("//input[@ng-reflect-placeholder='Node Name']");
        public By DRAFT_NAME = By.XPath("//input[@ng-reflect-placeholder='Draft Name']");
        public By CREATE_NODE = By.XPath("(//button/span)[contains(text(),'Create Node')]");
        public By NONE_RADIO_BUTTON = By.XPath("(//mat-radio-button//div[@class='mat-radio-outer-circle'])[2]");
        public By LAST_CREATED_NODE = By.XPath("(//li/div[@class='ui-treenode-content ui-treenode-selectable'])[last()]");
        public By LAST_CREATED_NODE_SIDEBAR = By.XPath("(//li/div[@class='ui-treenode-content ui-treenode-selectable'])[last()]/span[@class='ui-tree-toggler fa fa-fw fa-caret-right']");

        public NodesPage(IWebDriver driver) : base(driver)
        {

        }

        public void RightClickOnParentTree()
        {
            System.Threading.Thread.Sleep(7000);
            MoveToelementAndRightClick(UNITYMANUAL_TREE);
            System.Threading.Thread.Sleep(7000);
            info("Right Click on Unity Manual is performed");
        }

        public void ClickOnNewNode()
        {
            MoveToelementAndClick(NEW_NODE_CLICK);
            System.Threading.Thread.Sleep(7000);
            info("Clicked on New Node");
        }

        public String EnterNodeName()
        {
            String str = "Node" + generateRandomNumbers(3);
            EnterValue(NODE_NAME, str);
            info("Entered Node Name with :" + str);
            System.Threading.Thread.Sleep(7000);
            return str;
        }

        public String EnterDulicateNodeName(String NodeName)
        {
            EnterValue(NODE_NAME, NodeName);
            info("Entered Node Name with :" + NodeName);
            System.Threading.Thread.Sleep(7000);
            return NodeName;
        }

        public void EnterDraftName()
        {
            String str = "Draft" + generateRandomNumbers(3);
            EnterValue(DRAFT_NAME, str);
            info("Entered Draft Name with : " + str);
            System.Threading.Thread.Sleep(7000);

        }


        public void ClickNoneRadioButton()
        {
            Click(NONE_RADIO_BUTTON);
            info("Clicked on None Radio Button");
            System.Threading.Thread.Sleep(7000);
        }

    
        public void ClickCreateNode()
        {
            Click(CREATE_NODE);
            info("Clicked Create Node Button");
            System.Threading.Thread.Sleep(7000);
        }
        
        public void ClickUnityManualTree()
        {
            Click(UNITYMANUAL_SIDEBAR);
            info("Clicked Unity Manual Side Bar for extensions");
            System.Threading.Thread.Sleep(7000);

        }

        public void ClickLastNodeSideBar()
        {
            Click(UNITYMANUAL_SIDEBAR);
            Click(LAST_CREATED_NODE_SIDEBAR);
           info("Clicked Side Bar of Parent Node for extensions");
            System.Threading.Thread.Sleep(7000);
        }
        public void ClickDashboard()
        {
            Click(By.XPath("//a[@href='/dashboard']"));
            System.Threading.Thread.Sleep(7000);
            info("Clicked on Dashboard");
        }

        public void RightClickOnParentNode()
        {
            System.Threading.Thread.Sleep(7000);
            MoveToelementAndRightClick(LAST_CREATED_NODE);
            System.Threading.Thread.Sleep(7000);
            info("Right Click on Parent Node is performed");
        }

    

        public String GetTextOfNode()
        {
            System.Threading.Thread.Sleep(7000);
           String str = GetText(By.XPath("(//li/div[@class='ui-treenode-content ui-treenode-selectable'])[last()]"));
            info("The Text of Node Created is" + str);
            return str;
        }

        public void ClickOnNode(String NodeName)
        {
            String str = "(//li/div[@class='ui-treenode-content ui-treenode-selectable']//span)"+ "[text()='"+NodeName+"']";
            Click(By.XPath(str));
            info("Clicked On Node" + NodeName);
        }
       

        
    }
}
