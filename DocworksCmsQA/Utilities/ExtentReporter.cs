﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocWorksQA.Utilities
{
    public class ExtentReporter
    {
        ExtentHtmlReporter htmlReporter;
        static ExtentReports reporter;
        static ExtentTest parent;
       static ExtentTest test;

       

        public Boolean getReporter() {
            if (reporter == null)
            {
                return true;
            }
            return false;
        }

        public static ExtentHtmlReporter getHtmlReport () {

            String path = getCurrentProjectPath() + "/bin/Reports";
            new CommonMethods().createDirectory(path);

            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(path+"/Automation-"+getTimeStamp()+".html");
            htmlReporter.Configuration().Theme = Theme.Dark;
            htmlReporter.Configuration().DocumentTitle = "DocWorks Selenium Report";
            htmlReporter.Configuration().ReportName = "DocWorks Selenium Testing Report";
            return htmlReporter;
        }



        public static ExtentXReporter getXReporter() {
            
            ExtentXReporter xReporter = new ExtentXReporter(ConfigurationHelper.Get<String>("mongoDbUrl"));
            xReporter.Configuration().ServerURL = (ConfigurationHelper.Get<String>("serverUrl"));
            xReporter.Configuration().ProjectName = ("CMS");
            xReporter.Configuration().ReportName = ("DocWorks-CMS");
            return xReporter;
        }


        public static string getCurrentProjectPath() {
           String path = System.AppDomain.CurrentDomain.BaseDirectory;
            path = path.Substring(0, path.IndexOf(@"\bin"));
            return path;
        }

        public static string getTimeStamp() {
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
            String file = folderPath + "/" + reportName + getTimeStamp() + ".html";

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

            //Console.WriteLine("Creating test");
            Debug.WriteLine("Creating Test Case for Reporting. "+testCaseName);
                 test = reporter.CreateTest(testCaseName);
          
        }

        /**
         * Method creates a new instance of test with testcase name and test description.
         * @param testCaseName
         * @param description
         */
        public void CreateTest(String testCaseName, String description)
        {

            //Console.WriteLine("Creating test Case");
            Debug.WriteLine("Creating Test Case for Reporting. " + testCaseName);

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
        public void closeParentTest()
        {
            //Console.WriteLine("Closing Parent Test : " + parent);
            if (parent != null)
                parent = null;

        }

        /**
         * This method adds a pass statement to the current test instance.
         * @param description
         */
        public void pass(String description)
        {
            //Console.WriteLine("PASS : " + description);
            Debug.WriteLine(removeTags(description));
            test.Pass(description);
        }

        /**
         * This method adds a fail statement to the current test instance.
         * @param description
         */
        public void fail(String description)
        {
            //Console.WriteLine("FAIL : " + description);
            Debug.WriteLine(removeTags(description));
            test.Fail("<div style=\"color: red;\">" + description + "</div>");
        }

        /**
         * This method adds a info statement to the current test instance.
         * @param description
         */
        public void info(String description)
        {
            //Console.WriteLine("INFO : " + description);
            Debug.WriteLine(removeTags(description));
            test.Info(description);
        }

        /**
         * This method flushes report to the active extent instance.
         */
        public void reportFlusher()
        {
            //Console.WriteLine("Flushing the HTML report.");

            reporter.Flush();
        }

        public String removeTags(String data) {
            return data.Replace("<b>", " ").Replace("</b>"," ").Replace("<br>", " ");
            
        }

    }
}
