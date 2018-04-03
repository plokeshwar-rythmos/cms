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
        protected IWebDriver driver;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        
        public PageControl(IWebDriver driver)
        {
            this.driver = driver;
            
        }



        public void Click(By by)
        {
            Console.WriteLine("Clicking on " + by.ToString());
            try
            {
                WaitForElement(by).Click();
                System.Threading.Thread.Sleep(5000);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
       

        public void EnterValue(By by, string value)
        {
            Console.WriteLine("Entering value into " + by.ToString());
            try {

                Type(by, value);

            } catch (Exception e) {
                throw e;
                }
            

        }

        public void Clear(By by)
        {
            try
            {
                WaitForElement(by).Clear();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
       
        public string GetText(By by)
        {
            Console.WriteLine("Getting text for " + by.ToString());

            try
            {
                return WaitForElement(by).Text;
            }catch(Exception e)
            {
                throw e;
            }
        }

        public String GetAttribute(By by)
        {
            try
            {
                return WaitForElement(by).GetAttribute("text");
            }catch(Exception e)
            {
                throw e;
            }
       }

        public string GetSize(By by)    
        {
            IWebElement element = WaitForElement(by);

            ElementHighlight(element);
            return element.Size.ToString();
        }

        public String GetSizeOfElements(By by)
        {


            String str= driver.FindElements(by).Count.ToString();

            return str;


        }

        public Boolean IsEnabled(By by)
        {
            try
            {
                return WaitForElement(by).Enabled;
            }catch(Exception e)
            {
                throw e;
            }

        }

        public Boolean IsDisplayed(By by)
        {
            try
            {
                return WaitForElement(by).Displayed;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GetTitle()
        {
            System.Threading.Thread.Sleep(4000);
            string tmp = driver.Title;
            Console.WriteLine("The page title is " + tmp);
            return tmp;
        }

        public void Type(By by, String Value)
        {
            try
            {
                WaitForElement(by).SendKeys(Value);
            }
            catch (Exception e)
            {
                throw e;
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
            

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            const string script =
               "var timeId=setInterval(function(){window.scrollY<document.body.scrollHeight-window.screen.availHeight?window.scrollTo(0,document.body.scrollHeight):(clearInterval(timeId),window.scrollTo(0,0))},500);";

            js.ExecuteScript(script);

            IWebElement ele = WaitForElement(by);
            Actions act = new Actions(driver);
            act.MoveToElement(ele);
            act.Perform();
        }

        public void MoveToelement(IWebElement element)
        {


            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            const string script =
               "var timeId=setInterval(function(){window.scrollY<document.body.scrollHeight-window.screen.availHeight?window.scrollTo(0,document.body.scrollHeight):(clearInterval(timeId),window.scrollTo(0,0))},500);";

            js.ExecuteScript(script);

            Actions act = new Actions(driver);
            act.MoveToElement(element);
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

                Console.WriteLine("Selecting by Text " + value);
                select.SelectByText(value);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Console.WriteLine("Selecting by value " + value);

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
                        Console.WriteLine("IDENTIFIED: " +by.ToString());
                      //  MoveToelement(driver.FindElement(by));
                        return driver.FindElement(by);
                    }
                }
                catch (NoSuchElementException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Waiting for Element : " + by.ToString());
                    Console.WriteLine("Waiting for Element : " + by.ToString());
                    System.Threading.Thread.Sleep(500);
                }catch(Exception ex)
                {

                    throw ex;
                }


            }
            return el;
        }


        public void ElementHighlight(IWebElement element)
        {
          IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                
                js.ExecuteScript( "arguments[0].setAttribute('style', arguments[1]);",
                        element, "color: red; border: 5px solid red;");
                        

        }

    }
}
