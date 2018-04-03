using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using DocworksCmsQA.CustomException;
using MongoDB.Driver;
using Newtonsoft.Json;
using NLog;
using System;
using System.Diagnostics;
using System.Text;

namespace DocWorksQA.Utilities
{
    public class ExtentReporter
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        ExtentHtmlReporter htmlReporter;
        static ExtentReports reporter;
        static ExtentTest parent;
       static ExtentTest test;

       

        public Boolean GetReporter() {
            if (reporter == null)
            {
                return true;
            }
            return false;
        }

        public static ExtentHtmlReporter GetHtmlReport () {

            String path = GetCurrentProjectPath() + "/bin/Reports";
            new CommonMethods().CreateDirectory(path);

            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(path+"/Automation-"+GetTimeStamp()+".html");
            htmlReporter.Configuration().Theme = Theme.Dark;
            htmlReporter.Configuration().DocumentTitle = "DocWorks Selenium Report";
            htmlReporter.Configuration().ReportName = "DocWorks Selenium Testing Report";
            return htmlReporter;
        }



        public static ExtentXReporter GetXReporter() {
            
            ExtentXReporter xReporter = new ExtentXReporter(ConfigurationHelper.Get<String>("mongoDbUrl"));
            xReporter.Configuration().ServerURL = (ConfigurationHelper.Get<String>("serverUrl"));
            xReporter.Configuration().ProjectName = ("CMS");
            xReporter.Configuration().ReportName = ("DocWorks-CMS");
            return xReporter;
        }


        public static string GetCurrentProjectPath() {
           String path = System.AppDomain.CurrentDomain.BaseDirectory;
            path = path.Substring(0, path.IndexOf(@"\bin"));
            return path;
        }

        public static string GetTimeStamp() {
            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");
            return TimeAndDate.ToString();
        }
        /**
        * Method creates instance of extent and creates html with reportName and in folderPath.
        * @param folderPath
        * @param reportName
        */
        public static void InitReports(String folderPath, String reportName)
        {
            System.IO.Directory.CreateDirectory(folderPath);
            String file = folderPath + "/" + reportName + GetTimeStamp() + ".html";

            //Console.WriteLine("Initializing Extent Reporting");
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(file);
            htmlReporter.Configuration().ReportName = reportName;
            htmlReporter.Configuration().DocumentTitle = reportName;
            reporter = new ExtentReports();
            reporter.AttachReporter(htmlReporter);
            //Console.WriteLine("Creating Reporting file " + file);
        }

        /**
         * Method creates instance of extent with ExtentX Server connection.
         * @param folderPath
         * @param reportName
         * @param mongoDBUrl
         * @param serverUrl
         * @param projectName
         */
        public void InitReports(String folderPath, String reportName, String mongoDBUrl, String serverUrl,
                String projectName)
        {
            ExtentXReporter xReporter = new ExtentXReporter(mongoDBUrl);
            xReporter.Configuration().ServerURL = serverUrl;
            xReporter.Configuration().ReportName = reportName;
            xReporter.Configuration().ProjectName = projectName;

            htmlReporter = new ExtentHtmlReporter(folderPath + "/" + reportName + ".html");
            htmlReporter.Configuration().ReportName = reportName;
            htmlReporter.Configuration().DocumentTitle = reportName;
            reporter = new ExtentReports();
            reporter.AttachReporter(htmlReporter, xReporter);
        }

        /**
         * Method creates a new instance of test with just testcase name.
         * @param testCaseName
         */
        public void CreateTest(String testCaseName)
        {

            Console.WriteLine("Creating Test Case for Reporting. " +testCaseName);
                 test = reporter.CreateTest(testCaseName);
          
        }

        /**
         * Method creates a new instance of test with testcase name and test description.
         * @param testCaseName
         * @param description
         */
        public void CreateTest(String testCaseName, String description)
        {

            Console.WriteLine("Creating Test Case for Reporting. " + testCaseName);

            test = reporter.CreateTest(testCaseName, description);
            
           
        }

        /**
         * This method creates a new instance of parent test with testcase name.
         * 
         * @param testCaseName
         */
        public void CreateParentTest(String testCaseName)
        {
            parent = reporter.CreateTest(testCaseName);
            //Console.WriteLine("Creating Parent Test. : " + parent);

        }

        /**
         * This method closes the current parent test instance.
         */
        public void CloseParentTest()
        {
            //Console.WriteLine("Closing Parent Test : " + parent);
            if (parent != null)
                parent = null;

        }

        /**
         * This method adds a pass statement to the current test instance.
         * @param description
         */
        public void Pass(String description)
        {
            Console.WriteLine(RemoveTags(description));
            test.Pass(description);
            ReportFlusher();
        }

        /**
         * This method adds a fail statement to the current test instance.
         * @param description
         */
        public void Fail(String description)
        {
            Console.WriteLine(RemoveTags(description));
            test.Fail("<div style=\"color: red;\">" + description + "</div>");
            ReportFlusher();
        }


        public void Fail(Exception ex)
        {
            test.CustomeFail(ex);
            ReportFlusher();

            /*string exceptionString = JsonConvert.SerializeObject(ex);

            if (ex.GetType().ToString().Contains("AssertException")) {
                Console.WriteLine(ex.GetType());
                test.Fail(new AssertException(exceptionString));
            }else {
                test.Fail(new CustomException(exceptionString));
            }
            */
        }

                
               
            
        

        /**
         * This method adds a info statement to the current test instance.
         * @param description
         */
        public void Info(String description)
        {
            Console.WriteLine(RemoveTags(description));
            test.Info(description);
            ReportFlusher();
        }

        /**
         * This method flushes report to the active extent instance.
         */
        public void ReportFlusher()
        {
            //Console.WriteLine("Flushing the HTML report.");
           
            reporter.Flush();
        }

        public String RemoveTags(String data) {
            return data.Replace("<b>", " ").Replace("</b>"," ").Replace("<br>", " ");
            
        }

    }


    public class CustomException : Exception
    {
        public override string StackTrace { get;  }
        public CustomException(string message)
        {
           // Exception ex = new Exception();
            
            this.StackTrace = message;
        }
    }
}
