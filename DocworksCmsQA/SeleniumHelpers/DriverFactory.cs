using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using DocWorksQA.Utilities;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.PhantomJS;
using System.Diagnostics;

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
        private static TraceSource _source = new TraceSource("TestLog");

        public IWebDriver Create()
        {
            IWebDriver driver;
            var driverToUse = ConfigurationHelper.Get<DriverToUse>("DriverToUse");
            var browserStackIndicator = ConfigurationHelper.Get<bool>("UseBrowserStack");
            var url = ConfigurationHelper.Get<String>("TargetUrl");

          
                switch (driverToUse)
                {
                    case DriverToUse.InternetExplorer:
                        _source.TraceEvent(TraceEventType.Information, 0, "Starting Internet Explorer Driver.");
                        driver = new InternetExplorerDriver();
                        break;
                    case DriverToUse.Firefox:
                        _source.TraceEvent(TraceEventType.Information, 0, "Starting Firefox Driver.");
                    FirefoxOptions options = new FirefoxOptions();
                   // options.AddArguments("--headless");
                    driver = new FirefoxDriver(options);
                        break;
                    case DriverToUse.Chrome:
                        _source.TraceEvent(TraceEventType.Information, 0, "Starting Chrome Driver.");
                        ChromeOptions option = new ChromeOptions();
                    option.AddArgument("--headless");
                    option.AddArguments("window-size=1200,1100");
                    option.Proxy = null;
                    option.AddArguments("disable-infobars");
                    option.AddArgument("no-sandbox");
                    option.AddArguments("--incognito");
                    driver = new ChromeDriver(option);
                        break;
                    case DriverToUse.Safari:
                        _source.TraceEvent(TraceEventType.Information, 0, "Starting Safari Driver.");
                        driver = new SafariDriver();
                        break;
                    case DriverToUse.Phantomjs:
                        driver = new PhantomJSDriver();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                
            }

            driver.Manage().Window.Maximize();
            var timeouts = driver.Manage().Timeouts();

            
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            return driver;
        }

      
        
    }
}
