using NUnit.Framework;
using DocWorksQA.Utilities;
using System;

namespace DocWorksQA.Tests
{
    public class BeforeTestAfterTest : CommonMethods
    {
        
        [OneTimeSetUp]
        public void SetupReporting()
        {
            String path = GetCurrentProjectPath() + "/bin/Release/Reports";


            if (GetReporter()) { 
                InitReports(path, "CMS-Selenium");
            }


        }
       

        [OneTimeTearDown]
        public void GenerateReport()
        {
            Console.WriteLine("Running OneTimeTearDown in BeforeAfter Script");
            KillProcess();
            ReportFlusher();
        }

    }
}
