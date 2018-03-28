using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;

namespace DocWorksQA.SeleniumHelpers
{
    public class PageControl : Utilities.CommonMethods
    {
        IWebDriver driver;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        
        public PageControl(IWebDriver driver)
        {
            this.driver = driver;
            
        }

        public void Click(By by)
        {
            Logger.Debug("Clicking on " + by.ToString());
            IWebElement element = WaitForElement(by);
            elementHighlight(element);
            element.Click();
        }
       

        public void EnterValue(By by, string value)
        {
            Logger.Debug("Entering value into " + by.ToString());

            // IWebElement element = WaitForElement(by);
            // elementHighlight(element);
            // element.SendKeys(value); 

            type(by, value);

        }

        public void Clear(By by)
        {
            IWebElement element = WaitForElement(by);
            elementHighlight(element);
            element.Clear();
        }
       
        public string GetText(By by)
        {
            Logger.Debug("Getting text for " + by.ToString());

            IWebElement element = WaitForElement(by);
            elementHighlight(element);
            String t = element.Text;
            Logger.Debug("Text returned " + t);
            return t;
        }

        public String GetAttribute(By by)
        {
            IWebElement element = WaitForElement(by);
            elementHighlight(element);
            return element.GetAttribute("text");
        }
        public string GetSize(By by)    
        {
            IWebElement element = WaitForElement(by);

            elementHighlight(element);
            return element.Size.ToString();
        }

        public String GetSizeOfElements(By by)
        {


            String str= driver.FindElements(by).Count.ToString();

            return str;


        }

        public Boolean IsEnabled(By by)
        {
            Boolean Flag=false;
            IWebElement element = WaitForElement(by);
           if(element.Enabled)
            {
                Flag = true;
            }
            return Flag;
        }

        public Boolean IsDisplayed(By by)
        {
            Boolean Flag = false;
            IWebElement element = WaitForElement(by);
            if (element.Displayed)
            {
                Flag = true;
            }
            return Flag;
        }

        public string GetTitle()
        {
            System.Threading.Thread.Sleep(4000);
            string tmp = driver.Title;
            Logger.Debug("The page title is " + tmp);
            return tmp;
        }

        public void type(By by, String Value)
        {
            if (by != null)
            {
                WaitForElement(by).SendKeys(Value);
            }
            else
            {
                new Exception(by.ToString() + " : is null").ToString();
               
            }
        }

        public string GetTextOfHiddenElement(By by)
        {
            IWebElement element = WaitForElement(by);
            String script = "return arguments[0].innerHTML";
            String n = (String)((IJavaScriptExecutor)driver).ExecuteScript(script, element);
            
            return n;
        }

        public void ClickByJavaScriptExecutor(By by)
        {
            IWebElement ele = WaitForElement(by);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", ele);
        }

        public void MoveToelement(By by)
        {
            //IWebElement scrollArea = driver.FindElement(By.CssSelector("div.slimScrollBar"));
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("arguments[0].scrollTop = arguments[1];", scrollArea, 250);
           

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            const string script =
               "var timeId=setInterval(function(){window.scrollY<document.body.scrollHeight-window.screen.availHeight?window.scrollTo(0,document.body.scrollHeight):(clearInterval(timeId),window.scrollTo(0,0))},500);";

            // Start Scrolling
            js.ExecuteScript(script);
            //js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            IWebElement ele = WaitForElement(by);
            Actions act = new Actions(driver);
            act.MoveToElement(ele);
            act.Perform();
        }

        public void MoveToelementAndClick(By by)
        {
            IWebElement ele = WaitForElement(by);
            Actions builder = new Actions(driver);
    builder.MoveToElement(ele).Click().Build().Perform();
        }

        public void MoveToelementAndRightClick(By by)
        {
            IWebElement ele = WaitForElement(by);
            Actions builder = new Actions(driver);
           builder.MoveToElement(ele).ContextClick().Build().Perform();


        }
        

        public void SelectDropdown(By by, String value)
        {
            SelectElement select = new SelectElement(WaitForElement(by));

            try
            {

                Logger.Debug("Selecting by Text " + value);
                select.SelectByText(value);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Logger.Debug("Selecting by value " + value);

                select.SelectByText(value);
                //this.test.info("Element Not Found");
            }
        }

        public IWebElement WaitForElement(By by)
        {
            IWebElement el = null;
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    if (driver.FindElement(by).Displayed || driver.FindElement(by).Enabled)
                    {
                        //   Console.WriteLine("IDENTIFIED : "+by.ToString());
                        Logger.Debug("IDENTIFIED: " +by.ToString());
                        return driver.FindElement(by);
                    }
                    else {
                        //  Console.WriteLine("NOT IDENTIFIED : " + by.ToString());
                        Logger.Debug("NOT IDENTIFIED: " + by.ToString());
                     }

                }
                catch (NoSuchElementException e)
                {
                    // Console.WriteLine("Waiting for Element : " + by.ToString());
                    Logger.Debug("Waiting for Element : " + by.ToString());
                    Debug.WriteLine(e.Message);
                    //Console.WriteLine(e.StackTrace);
                    System.Threading.Thread.Sleep(200);
                }catch(Exception ex)
                {
                    fail(ex);
                    throw (ex);
                }


            }
            return el;
        }

        public void elementHighlight(IWebElement element)
        {
          IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                
                js.ExecuteScript( "arguments[0].setAttribute('style', arguments[1]);",
                        element, "color: red; border: 5px solid red;");
                        

        }

    }
}
