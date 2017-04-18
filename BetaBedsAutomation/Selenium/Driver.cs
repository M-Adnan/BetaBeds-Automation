using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;


namespace BetaBedsAutomation
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }
        public static bool WaitOff { get; internal set; }
        public static int DefaultImplicitWait { get; internal set; }
        internal static Random Random = new Random();

        public static string BaseAddress
        {
            get
            {
                return "http://trunk.betabeds.com/";
            }
        }

        public static void Initialise(string TestingEnviorment, bool SeleniumExecuteLocally, string SeleniumBrowser, string SeleniumRemoteServerURL, bool ProxyEnabled, string httpProxy, int httpPort)
        {

            if (SeleniumExecuteLocally)
            {
                switch (SeleniumBrowser.Trim().ToLower())
                { 
                    case "firefox":
                        FirefoxProfile firefoxProfile = new FirefoxProfile();
                        if (ProxyEnabled)
                        {
                            firefoxProfile.SetPreference("network.proxy.type", 1);
                            firefoxProfile.SetPreference("network.proxy.http", httpProxy);
                            firefoxProfile.SetPreference("network.proxy.http_port", httpPort);
                        }
                        Instance = new FirefoxDriver(firefoxProfile);
                        SetDefaultImplicitWait(5);
                        
                        Instance.Manage().Window.Maximize();
                        break;

                    case "chrome":
                        ChromeOptions chromeProfile = new ChromeOptions();
                        Proxy proxy = new Proxy();
                        if (ProxyEnabled)
                        {
                            proxy.HttpProxy = string.Format("{0}:{1}", httpProxy, httpPort);
                            chromeProfile.Proxy = proxy;
                        }
                        chromeProfile.AddArgument("ignore-certificate-errors");
                        Instance = new ChromeDriver("\\Drivers\\", chromeProfile);
                        SetDefaultImplicitWait(5);
                        //Driver.Wait(TimeSpan())
                        Instance.Manage().Window.Maximize();
                        break;
                    default:
                        throw new Exception(string.Format("Browser {0} unknown", SeleniumBrowser));
                }
            }
            else
            {
                //string randomBrowser = PickRandomBrowser();
                //string randomPlatform = PickRandomPlatform();

                switch (SeleniumBrowser.Trim().ToLower())
                {
                    case "firefox":
                        Proxy firefoxProxy = new Proxy();
                        if (ProxyEnabled)
                        {
                            firefoxProxy.HttpProxy = string.Format("{0}:{1}", httpProxy, httpPort);
                        }
                        DesiredCapabilities firefoxCapability = DesiredCapabilities.Firefox();
                        firefoxCapability.SetCapability("browserName", "firefox");
                        //firefoxCapability.SetCapability("platform", "WIN8_1");
                        firefoxCapability.SetCapability(CapabilityType.Proxy, firefoxProxy);
                        Instance = new RemoteWebDriver(new Uri(SeleniumRemoteServerURL), firefoxCapability);
                        Driver.Wait(TimeSpan.FromSeconds(1));
                        Instance.Manage().Window.Maximize();
                        SetDefaultImplicitWait(5);
                        break;
                    case "chrome":
                        Proxy chromeProxy = new Proxy();
                        if (ProxyEnabled)
                        {
                            chromeProxy.HttpProxy = string.Format("{0}:{1}", httpProxy, httpPort);
                        }
                        DesiredCapabilities chromeCapability = DesiredCapabilities.Chrome();
                        chromeCapability.SetCapability("browserName", "chrome");
                        //chromeCapability.SetCapability("platform", "WIN10");
                        chromeCapability.SetCapability(CapabilityType.Proxy, chromeProxy);
                        Instance = new RemoteWebDriver(new Uri(SeleniumRemoteServerURL), chromeCapability);
                        Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                        Instance.Manage().Window.Maximize();
                        break;
                    case "ie":
                        Proxy ieProxy = new Proxy();
                        if (ProxyEnabled)
                        {
                            ieProxy.HttpProxy = string.Format("{0}:{1}", httpProxy, httpPort);
                        }
                        DesiredCapabilities ieCapability = DesiredCapabilities.InternetExplorer();
                        ieCapability.SetCapability("browserName", "internet explorer");
                        //ieCapability.SetCapability("platform", "WIN8_1");
                        ieCapability.SetCapability(CapabilityType.Proxy, ieProxy);
                        Instance = new RemoteWebDriver(new Uri(SeleniumRemoteServerURL), ieCapability);
                        SetDefaultImplicitWait(5);
                        Instance.Manage().Window.Maximize();
                        break;
                }
            }
        }

        public static void Close()
        {
            Driver.Instance.Close();
            Driver.Instance.Quit();
        }

        internal static void SetDefaultImplicitWait()
        {
            if (DefaultImplicitWait == 0)
            {
                Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            }
            else
            {
                Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(DefaultImplicitWait));
            }

        }

        internal static void SetDefaultImplicitWait(int seconds)
        {
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(seconds));
        }

        internal static void TurnOffWait()
        {
            if (Driver.WaitOff) return;
            Driver.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));
            Driver.WaitOff = true;
        }

        internal static void TurnOnWait()
        {
            if (Driver.WaitOff)
            {
                if (DefaultImplicitWait == 0)
                {
                    Driver.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                }
                else
                {
                    Driver.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(DefaultImplicitWait));
                }
                Driver.WaitOff = false;
            }
        }

        public static IWebElement FindElementWithTimeout(By by, int timeoutInSeconds, string errMsg)
        {
            Driver.TurnOffWait();
            var wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(timeoutInSeconds));
            try
            {
                var webelement = wait.Until(drv => drv.FindElement(by));
                Driver.TurnOnWait();
                return webelement;
            }
            catch
            {
                throw new Exception(errMsg);
            }
        }

        public static ReadOnlyCollection<IWebElement> FindElementsWithTimeout(By by, int timeoutInSeconds)
        {
            Driver.TurnOffWait();
            var wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(timeoutInSeconds));
            ReadOnlyCollection<IWebElement> webelements = wait.Until(drv => drv.FindElements(by));
            Driver.TurnOnWait();
            return webelements;
        }

        public static void WaitForAjax()
        {
            while (!(bool)(Driver.Instance as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0")) // Handle timeout somewhere
            {
                Thread.Sleep(100);
            }
        }

        public static bool IsElementDisplayed(By by)
        {
            Driver.WaitForAjax();
            try
            {
                return Instance.FindElement(by).Displayed;
            }
            catch
            {
            }
            return false;
        }

        public static void NoWait(Action action)
        {
            TurnOffWait();
            action();
            TurnOnWait();
        }


        internal static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int)timeSpan.TotalSeconds * 1000);
        }

        public static string PickRandomBrowser()
        {
            List<String> BrowserList = new List<string>
            {
                "firefox","chrome"
            };

            int index = Random.Next(BrowserList.Count);
            string RandomBrowser = BrowserList[index];
            return RandomBrowser;
        }

        public static string PickRandomPlatform()
        {
            List<String> PlatformList = new List<string>
            {
                "WIN10","WIN8_1"
            };

            int index = Random.Next(PlatformList.Count);
            string RandomPlatform = PlatformList[index];
            return RandomPlatform;
        }

        public static int PickRandomNumber(int minValue, int maxValue)
        {
            return Random.Next(minValue, maxValue);
        }
    }
}
