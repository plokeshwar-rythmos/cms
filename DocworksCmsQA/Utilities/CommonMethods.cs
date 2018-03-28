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

        public String TakeScreenshot(IWebDriver driver)
        {

            String path = GetCurrentProjectPath() + "/bin/Release/Reports/Screenshot";

            createDirectory(path);

            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");
            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
            Screenshot screenshot = ssdriver.GetScreenshot();
            screenshot.SaveAsFile(path + "/screenshot-" + TimeAndDate + ".jpeg", ScreenshotImageFormat.Jpeg);
            return "./Screenshot/screenshot-" + TimeAndDate + ".jpeg";
            
        }

        
        public static string GetCurrentProjectPath()
        {
            String path = System.AppDomain.CurrentDomain.BaseDirectory;
            path = path.Substring(0, path.IndexOf(@"\bin"));
            return path;
        }

       

        public string getImagePath()
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

        public string getInvalidImagePath()
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



        public string getCodeBlockPath()
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

public string getInvalidCodeBlockPath()
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
        public void createDirectory(String path)
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



        public String generateRandomNumbers(int length)
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
                processName = "chromedriver.exe";
            }else if (driverToUse.ToLower().Equals("firefox"))
            {
                processName = "firefox.exe";
            }
            else
            {
                processName = "InternetExplorerDriver.exe";
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
