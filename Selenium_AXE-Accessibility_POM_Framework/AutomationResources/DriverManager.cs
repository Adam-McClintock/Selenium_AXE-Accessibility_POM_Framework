using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Selenium_AXE_Accessibility_POM_Framework.AutomationResources
{
    [Binding]
    public class DriverManager
    {
        private readonly IObjectContainer container;

        public DriverManager(IObjectContainer container)
        {
            this.container = container;
        }

        #region Chrome Driver
        public ChromeOptions GetChromeOptions()
        {
            ChromeOptions options = new ChromeOptions();

            // use headless chrome
            if (Settings.Default.Headless)
            {
                options.AddArguments(new List<string>()
                    {
                        "--headless",
                        "--no-first-run",
                        "--window-size=1280,1920",
                        "--start-maximized",
                        "--incognito"
                    });
            }
            return options;
        }

        public void ClearChromeCache(IWebDriver _driver)
        {
            Console.WriteLine("Attempting to clear chrome browser cache");
            string cacheMessage = "";

            _driver.Navigate().GoToUrl("chrome://settings/clearBrowserData");
            Thread.Sleep(2000);

            if (!_driver.Title.Equals("Settings"))
            {
                cacheMessage = "Unable to clear cache using this method!";
            }
            else
            {
                //Let's try to interact with the settings page
                Actions a = new Actions(_driver);
                a.SendKeys(OpenQA.Selenium.Keys.Tab)
                    .SendKeys(OpenQA.Selenium.Keys.Tab)
                    .SendKeys(OpenQA.Selenium.Keys.Tab)
                    .SendKeys(OpenQA.Selenium.Keys.Tab)
                    .SendKeys(OpenQA.Selenium.Keys.Tab)
                    .SendKeys(OpenQA.Selenium.Keys.Tab)
                    .SendKeys(OpenQA.Selenium.Keys.Tab)
                    .SendKeys(OpenQA.Selenium.Keys.Enter)
                    .Build()
                    .Perform();

                //Driver.TakeScreenshot().SaveAsFile(Settings.Default.ScreenshotPath + "\\" + DateTime.Now.ToString("yyyymmddhhmmssfff") + ".jpg", ScreenshotImageFormat.Jpeg);

                for (int i = 0; i < Settings.Default.DelayCycles; i++)
                {
                    if (_driver.Url.Equals("chrome://settings/"))
                    {
                        cacheMessage = "Successfully cleared cache after " + (i * Settings.Default.Delays) / 1000 + " seconds!";
                        break;
                    }
                    Thread.Sleep(Settings.Default.Delays);
                }
            }
        }

        #endregion

        #region Firefox Driver
        public static FirefoxOptions GetFireFoxOptions()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.SetPreference("print.always_print_silent", true);
            options.AddArgument("--headless");
            options.AddArguments("-width=1920");
            options.AddArguments("-height=1080");
            // May need to add specific width and height here when running in headless.
            // Sometimes can run into issues where elements do not fit into viewpoint
            return options;
        }

        public static FirefoxDriverService GetFireFoxDriverService()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            return service;
        }

        public static FirefoxDriver GetFireFoxDriver()
        {
            FirefoxProfile firefoxProfile = new FirefoxProfile();
            firefoxProfile.SetPreference("print.always_print_silent", true);
            FirefoxDriver _driver = new FirefoxDriver(GetFireFoxDriverService(), GetFireFoxOptions());
            return _driver;
        }
        #endregion

        #region Edge Driver
        public static EdgeOptions GetEdgeOptions()
        {
            EdgeOptions options = new EdgeOptions();
            options.AddArgument("InPrivate");
            options.AddArgument("start-maximized");
            options.AddArgument("headless");
            options.BinaryLocation = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
            return options;
        }

        public static EdgeDriver GetEdgeDriver()
        {
            EdgeDriver _driver = new EdgeDriver(GetEdgeDriverService(), GetEdgeOptions());
            return _driver;
        }

        public static EdgeDriverService GetEdgeDriverService()
        {
            EdgeDriverService service = EdgeDriverService.CreateDefaultService();
            service.UseVerboseLogging = true;
            //service.UseSpecCompliantProtocol = true;
            return service;
        }
        #endregion

        public void DriverFactory()
        {
            IWebDriver _driver;
            string browser = Environment.GetEnvironmentVariable("browser", EnvironmentVariableTarget.Process);

            //Including the below to allow us to run a test locally as the code above is looking for
            // a browser variable from the Azure Pipeline
            if (browser == null)
            {
                browser = "chrome";
            }

            Console.WriteLine("Chosen browser is : " + browser.ToLower());
            switch (browser.ToLower())
            {
                case "chrome":
                    _driver = new ChromeDriver(GetChromeOptions());
                    {
                        Console.WriteLine("Clear cache?: " + Settings.Default.ClearCache);
                        _driver.Manage().Window.Maximize();
                        if (Settings.Default.ClearCache)
                        {
                            ClearChromeCache(_driver);
                        }
                    };
                    break;
                case "firefox":
                    _driver = GetFireFoxDriver();
                    break;
                case "edge":
                    _driver = GetEdgeDriver();
                    break;
                default:
                    _driver = new ChromeDriver(GetChromeOptions());
                    {
                        Console.WriteLine("Clear cache?: " + Settings.Default.ClearCache);
                        _driver.Manage().Window.Maximize();
                        if (Settings.Default.ClearCache)
                        {
                            ClearChromeCache(_driver);
                        }
                    };
                    break;
            }
            // Make this instance available to all other step definitions
            container.RegisterInstanceAs(_driver);
        }

        public void DestroyDriver()
        {
            IWebDriver _driver = container.Resolve<IWebDriver>();

            _driver.Close();
            _driver.Dispose();
        }
    }
}
