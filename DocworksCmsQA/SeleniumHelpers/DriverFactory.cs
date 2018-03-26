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
        private static readonly FirefoxProfile FirefoxProfile = CreateFirefoxProfile();

        private static FirefoxProfile CreateFirefoxProfile()
        {
            var firefoxProfile = new FirefoxProfile();
            firefoxProfile.SetPreference("general.useragent.override", "UA-STRING");
            firefoxProfile.SetPreference("extensions.modify_headers.currentVersion", "0.7.1.1-signed");
            firefoxProfile.SetPreference("modifyheaders.headers.count", 1);
            firefoxProfile.SetPreference("modifyheaders.headers.action0", "Add");
            firefoxProfile.SetPreference("modifyheaders.headers.name0", "SampleHeader");
            firefoxProfile.SetPreference("modifyheaders.headers.value0", "test1234");
            firefoxProfile.SetPreference("modifyheaders.headers.enabled0", true);
            firefoxProfile.SetPreference("modifyheaders.config.active", true);
            firefoxProfile.SetPreference("modifyheaders.config.alwaysOn", true);
            firefoxProfile.SetPreference("modifyheaders.config.start", true);
            firefoxProfile.SetPreference("network.automatic-ntlm-auth.trusted-uris", "http://localhost");
            return firefoxProfile;
        }

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
                        driver = new InternetExplorerDriver(AppDomain.CurrentDomain.BaseDirectory, new InternetExplorerOptions(), TimeSpan.FromMinutes(5));
                        break;
                    case DriverToUse.Firefox:
                        
                        FirefoxOptions option = new FirefoxOptions();
                        option.Profile = DriverFactory.FirefoxProfile;
                        driver = new FirefoxDriver(option);
                        break;
                    case DriverToUse.Chrome:
                        ChromeOptions options = new ChromeOptions();
                       // options.AddArguments("--incognito");
                        //options.AddArguments("--enable-notifications");
                        options.AddUserProfilePreference("profile.managed_default_content_settings.notifications", 1);
                        
                       // options.AddAdditionalCapability("excludeSwitches", "disable-default-apps");
                        //options.AddAdditionalCapability("profile.default_content_setting_values.notifications", "2");
                       // options.AddArgument("--headless");
                        driver = new ChromeDriver(options);
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

            
            // Suppress the onbeforeunload event first. This prevents the application hanging on a dialog box that does not close.
            ((IJavaScriptExecutor)driver).ExecuteScript("window.onbeforeunload = function(e){};");
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