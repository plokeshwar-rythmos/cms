using System;
using System.Configuration;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using DocWorksQA.Utilities;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.PhantomJS;

namespace DocWorksQA.SeleniumHelpers
{
    public enum DriverToUse
    {
        InternetExplorer,
        Chrome,
        Safari,
        Firefox,
        Phantomjs
    }

    public class DriverFactory
    {
        

        public IWebDriver Create()
        {
            IWebDriver driver;
            var driverToUse = ConfigurationHelper.Get<DriverToUse>("DriverToUse");
            var browserStackIndicator = ConfigurationHelper.Get<bool>("UseBrowserStack");
            var url = ConfigurationHelper.Get<String>("TargetUrl");

            if (browserStackIndicator)
            {
                driver = CreateGridDriver(driverToUse);
            }
            else
            {
                switch (driverToUse)
                {
                    case DriverToUse.InternetExplorer:
                        driver = new InternetExplorerDriver();
                        break;
                    case DriverToUse.Firefox:
                        
                        driver = new FirefoxDriver();
                        break;
                    case DriverToUse.Chrome:
                        driver = new ChromeDriver();
                        break;
                    case DriverToUse.Safari:
                        driver = new SafariDriver();
                        break;
                    case DriverToUse.Phantomjs:
                        driver = new PhantomJSDriver();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            driver.Manage().Window.Maximize();
            var timeouts = driver.Manage().Timeouts();

            
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            return driver;
        }

        public static IWebDriver CreateGridDriver(DriverToUse driverToUse)
        {
            var gridUrl = ConfigurationManager.AppSettings["GridUrl"];
            var desiredCapabilities = DesiredCapabilities.InternetExplorer();
            switch (driverToUse)
            {
                case DriverToUse.Firefox:
                    desiredCapabilities = DesiredCapabilities.Firefox();
                    break;
                case DriverToUse.InternetExplorer:
                    desiredCapabilities = DesiredCapabilities.InternetExplorer();
                    break;
                case DriverToUse.Chrome:
                    desiredCapabilities = DesiredCapabilities.Chrome();
                    break;
                case DriverToUse.Safari:
                    desiredCapabilities = DesiredCapabilities.Safari();
                    break;
            }
            var browserStackUser = ConfigurationHelper.Get<String>("BrowserStackUser");
            var browserStackKey = ConfigurationHelper.Get<String>("BrowserStackKey");

            var os = ConfigurationHelper.Get<String>("OS");
            var os_version = ConfigurationHelper.Get<String>("OS_Version");
            var browserVersion = ConfigurationHelper.Get<String>("BrowserVersion");
            desiredCapabilities.SetCapability("browserstack.user", browserStackUser);
            desiredCapabilities.SetCapability("browserstack.key", browserStackKey);
            desiredCapabilities.SetCapability("browserstack.os", os);
            desiredCapabilities.SetCapability("browserstack.os_version", os_version);
            desiredCapabilities.SetCapability("browserstack.browser_version", browserVersion);
            var remoteDriver = new RemoteWebDriver(new Uri(gridUrl), desiredCapabilities);
           // var nodeHost = remoteDriver.GetNodeHost();
            //Debug.WriteLine("Running tests on host " + nodeHost);
            return remoteDriver;
        }

        
    }
}