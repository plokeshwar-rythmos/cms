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

        public PageControl(IWebDriver driver)
        {
            this.driver = driver;

        }



        public void Click(By by)
        {
            Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "Clicking on " + by.ToString());
            try
            {
                WaitForElement(by).Click();
                System.Threading.Thread.Sleep(5000);
            }
            catch (StaleElementReferenceException se)
            {
                Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "ERROR : " + se.Message);
                Console.WriteLine("Retrying Click Operation");
                WaitForElement(by).Click();

            }
            catch (WebDriverException wbe)
            {
                Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "ERROR : " + wbe.Message);
                Console.WriteLine("Retrying Click Operation");
                WaitForElement(by).Click();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public void EnterValue(By by, string value)
        {
            Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "Entering value into " + by.ToString());
            try
            {

                Type(by, value);

            }
            catch (Exception e)
            {
                throw e;
            }


        }

        public void Clear(By by)
        {
            try
            {
                WaitForElement(by).Clear();
            }
            catch (StaleElementReferenceException se)
            {
                Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "ERROR : " + se.Message);
                Console.WriteLine("Retrying Clear Operation");
                WaitForElement(by).Clear();

            }
            catch (WebDriverException wbe)
            {
                Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "ERROR : " + wbe.Message);
                Console.WriteLine("Retrying Clear Operation");
                WaitForElement(by).Clear();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string GetText(By by)
        {
            Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "Getting text for " + by.ToString());

            try
            {
                return WaitForElement(by).Text;
            }
            catch (StaleElementReferenceException se)
            {
                Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "ERROR : " + se.Message);
                Console.WriteLine("Retrying Get Text Operation");
                return WaitForElement(by).Text;

            }
            catch (WebDriverException wbe)
            {
                Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "ERROR : " + wbe.Message);
                Console.WriteLine("Retrying Get Text Operation");
                return WaitForElement(by).Text;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public String GetAttribute(By by)
        {
            try
            {
                return WaitForElement(by).GetAttribute("text");
            }
            catch (StaleElementReferenceException se)
            {
                Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "ERROR : " + se.Message);
                Console.WriteLine("Retrying Get Attribute Operation");
                return WaitForElement(by).GetAttribute("text");

            }
            catch (WebDriverException wbe)
            {
                Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "ERROR : " + wbe.Message);
                Console.WriteLine("Retrying Get Attribute Operation");
                return WaitForElement(by).GetAttribute("text");
            }
            catch (Exception e)
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
            String str = driver.FindElements(by).Count.ToString();
            return str;
        }

        public Boolean IsEnabled(By by)
        {
            try
            {
                return WaitForElement(by).Enabled;
            }
            catch (Exception e)
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
            catch (StaleElementReferenceException se)
            {
                Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "ERROR : " + se.Message);
                Console.WriteLine("Retrying Type Operation");
                WaitForElement(by).SendKeys(Value);

            }
            catch (WebDriverException wbe)
            {
                Console.WriteLine("DRIVER ID : " + driver.GetHashCode() + ", " + "ERROR : " + wbe.Message);
                Console.WriteLine("Retrying Type Operation");
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

        public void MoveToElement(By by)
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



        public void MoveToElement(IWebElement element)
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
            SelectElement select = null;

            try
            {
                select = new SelectElement(WaitForElement(by));

                Console.WriteLine("Selecting by Text " + value);
                select.SelectByText(value);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Console.WriteLine("Selecting by value " + value);

                select.SelectByText(value);
            }
        }

        public IWebElement WaitForElement(By by)
        {
            IWebElement el = null;
            for (int i = 0; i <= 30; i++)
            {
                try
                {
                    if (driver.FindElement(by).Displayed || driver.FindElement(by).Enabled)
                    {
                        Console.WriteLine("DRIVER ID : "+driver.GetHashCode()+", IDENTIFIED: " + by.ToString());
                        return driver.FindElement(by);
                    }
                }
                catch (NoSuchElementException e)
                {
                    if (i == 30)
                    {
                        throw e;
                    }
                    else
                    {

                        Console.WriteLine("DRIVER ID : " + driver +", "+ e.Message + " Retrying after 1 second.");
                        System.Threading.Thread.Sleep(2000);
                    }

                }
                catch (StaleElementReferenceException se)
                {
                    Console.WriteLine("DRIVER ID : " + driver + ", " + se.Message + " Retrying after 1 second.");
                    System.Threading.Thread.Sleep(2000);

                }
                catch (Exception ex)
                {

                    throw ex;
                }


            }
            return el;
        }


        public void ElementHighlight(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);",
                    element, "color: red; border: 5px solid red;");


        }

    }
}
