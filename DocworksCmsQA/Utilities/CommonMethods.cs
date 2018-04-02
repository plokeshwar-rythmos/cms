using OpenQA.Selenium;
using DocWorksQA.TestRailApis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DocWorksQA.Utilities
{
    public class CommonMethods : TestRailMethods
    {

        private IWebDriver Driver;

        public void SetDriver(IWebDriver Driver) {
            this.Driver = Driver;
        }

        public IWebDriver GetCurrentDriver() {
            return this.Driver;
        }
        
        public void CloseDriver() {
            String driverToUse = ConfigurationHelper.Get<String>("DriverToUse");
            if (driverToUse.ToLower().Equals("firefox"))
            {
                Driver.Navigate().GoToUrl("about:config");
                Driver.Navigate().GoToUrl("about:blank");
                Driver.Close();
            }

            if (Driver != null){
                Driver.Quit();
            }
        }

        public String TakeScreenshot(IWebDriver driver)
        {

            String path = GetCurrentProjectPath() + "/bin/Release/Reports/Screenshot";

            CreateDirectory(path);

            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");
            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
            Screenshot screenshot = ssdriver.GetScreenshot();
            screenshot.SaveAsFile(path + "/screenshot-" + TimeAndDate + ".jpeg", ScreenshotImageFormat.Jpeg);
            return "./Screenshot/screenshot-" + TimeAndDate + ".jpeg";
            
        }


        public void ReportExceptionScreenshot(IWebDriver driver, Exception ex) {
            String path = TakeScreenshot(driver);
            ExceptionScreenshot(path, ex.Message);

        }

        public void ExceptionScreenshot(String path, String message)
        {
            Info("<a style=\"font - size: 20px; color: red;\" href=\"" + path + "\">Exception Occurred : "+message+"<br></a>");
        }

        public string GetImagePath()
        {
            String path = GetCurrentProjectPath();
            String savedpath = path + @"\MediaFiles\Images\";
            Console.WriteLine("Original Path" + savedpath);
            string file = null;
            if (!string.IsNullOrEmpty(savedpath))
            {
                var extensions = new string[] { ".png", ".jpg", ".gif" };
                try
                {
                    var di = new DirectoryInfo(savedpath);
                    var rgFiles = di.GetFiles("*.*").Where(f => extensions.Contains(f.Extension.ToLower()));
                    Random R = new Random();
                    file = rgFiles.ElementAt(R.Next(0, rgFiles.Count())).FullName;
                }
                // probably should only catch specific exceptions
                // throwable by the above methods.
                catch { }
            }
            Console.WriteLine("The random image" + file);
            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");
            String savedpath1 = file;
            FileInfo finfo = new FileInfo(savedpath1);
            Console.WriteLine("saved Path" + savedpath1);
            String Updatedpath = path + @"\MediaFiles\Images\" + TimeAndDate + ".jpg";
            Console.WriteLine("updated Path" + Updatedpath);
            finfo.CopyTo(Updatedpath);
            Console.WriteLine("Original Path" + Updatedpath);
            return Updatedpath;
        }

        public string GetInvalidImagePath()
        {
            String path = GetCurrentProjectPath();

            String savedpath = path + @"\MediaFiles\Images\";
            Console.WriteLine("Original Path" + savedpath);
            string file = null;
            if (!string.IsNullOrEmpty(savedpath))
            {
                var extensions = new string[] { ".tif" };
                try
                {
                    var di = new DirectoryInfo(savedpath);
                    var rgFiles = di.GetFiles("*.*").Where(f => extensions.Contains(f.Extension.ToLower()));
                    Random R = new Random();
                    file = rgFiles.ElementAt(R.Next(0, rgFiles.Count())).FullName;
                }
                // probably should only catch specific exceptions
                // throwable by the above methods.
                catch { }
            }

            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");
            String savedpath1 = file;
            FileInfo finfo = new FileInfo(savedpath1);
            Console.WriteLine("saved Path" + savedpath1);
            String Updatedpath = path + @"\MediaFiles\Images\" + TimeAndDate + ".tif";
            Console.WriteLine("updated Path" + Updatedpath);
            finfo.CopyTo(Updatedpath);
            Console.WriteLine("Original Path" + Updatedpath);
            return Updatedpath;
        }



        public string GetCodeBlockPath()
        {
            String path = GetCurrentProjectPath();
            String savedpath = path + @"\MediaFiles\CodeBlocks\";
            Console.WriteLine("Original Path" + savedpath);
            string file = null;
            if (!string.IsNullOrEmpty(savedpath))
            {
                var extensions = new string[] { ".txt", ".cs" };
                try
                {
                    var di = new DirectoryInfo(savedpath);
                    var rgFiles = di.GetFiles("*.*").Where(f => extensions.Contains(f.Extension.ToLower()));
                    Random R = new Random();
                    file = rgFiles.ElementAt(R.Next(0, rgFiles.Count())).FullName;
                }
                // probably should only catch specific exceptions
                // throwable by the above methods.
                catch { }
            }
            Console.WriteLine("The random image" + file);
            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");
            String savedpath1 = file;
            FileInfo finfo = new FileInfo(savedpath1);
            Console.WriteLine("saved Path" + savedpath1);
            String Updatedpath = path + @"\MediaFiles\CodeBlocks\" + TimeAndDate + ".txt";
            Console.WriteLine("updated Path" + Updatedpath);
            finfo.CopyTo(Updatedpath);
            Console.WriteLine("Original Path" + Updatedpath);
            return Updatedpath;
        }

public string GetInvalidCodeBlockPath()
        {
            String path = GetCurrentProjectPath();
            String savedpath = path + @"\MediaFiles\CodeBlocks\";
            Console.WriteLine("Original Path" + savedpath);
            string file = null;
            if (!string.IsNullOrEmpty(savedpath))
            {
                var extensions = new string[] { ".docx", ".xml" };
                try
                {
                    var di = new DirectoryInfo(savedpath);
                    var rgFiles = di.GetFiles("*.*").Where(f => extensions.Contains(f.Extension.ToLower()));
                    Random R = new Random();
                    file = rgFiles.ElementAt(R.Next(0, rgFiles.Count())).FullName;
                }
                // probably should only catch specific exceptions
                // throwable by the above methods.
                catch { }
            }
            Console.WriteLine("The random image" + file);
            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");
            String savedpath1 = file;
            FileInfo finfo = new FileInfo(savedpath1);
            Console.WriteLine("saved Path" + savedpath1);
            String Updatedpath = path + @"\MediaFiles\CodeBlocks\" + TimeAndDate + ".xml";
            Console.WriteLine("updated Path" + Updatedpath);
            finfo.CopyTo(Updatedpath);
            Console.WriteLine("Original Path" + Updatedpath);
            return Updatedpath;
        }
        public void CreateDirectory(String path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }


        public String RandomValueOfLengthMorethan100()
        {
            char data = ' ';
            String dat = "";
            Random ran = new Random();
            for (int i = 0; i <= 250; i++)
            {
                data = (char)(ran.Next(25) + 97);
                dat = data + dat;
            }
            return dat;

        }


        public String RandomValueOfLengthMorethan1000()
        {

            char data = ' ';
            String dat = "";
            Random ran = new Random();
            for (int i = 0; i <= 1000; i++)
            {
                data = (char)(ran.Next(25) + 97);
                dat = data + dat;
            }

            return dat;
        }



        public String GenerateRandomNumbers(int length)
        {
            String characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rng = new Random();
            char[] text = new char[length];
            for (int i = 0; i < length; i++)
            {
                text[i] = characters.ElementAt(rng.Next(characters.Length));
                    
            }
            return new String(text);
        }


        public void KillProcess()
        {
            String processName = "";

            String driverToUse = ConfigurationHelper.Get<String>("DriverToUse");
            if (driverToUse.ToLower().Equals("chrome"))
            {
                processName = "chromedriver";
            }else if (driverToUse.ToLower().Equals("firefox"))
            {
                processName = "firefox";
            }
            else
            {
                processName = "InternetExplorerDriver";
            }


                try
            {
                foreach (Process process in Process.GetProcessesByName(processName))
                {
                    //kill the process 
                    Console.WriteLine("Killing process "+process);
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                //show the exceptions if any here
                Console.WriteLine(ex.ToString());
            };

        }


      


    }
}
