using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System.Threading;

namespace BetaBedsAutomation
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }
        public static bool WaitOff { get; internal set; }

        public static string BaseAddress
        {
            get
            {
                return "http://trunk.betabeds.com/";
            }
        }

        public static void Initialise()
        {
            FirefoxProfile profile = new FirefoxProfile();
            profile.SetPreference("network.proxy.type", 1);
            profile.SetPreference("network.proxy.http", "52.16.27.130");
            profile.SetPreference("network.proxy.http_port", 3128);

            Instance = new FirefoxDriver(profile);
            //Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            Instance.Manage().Window.Maximize();
        }

        public static void Close()
        {
            Instance.Close();
        }

        internal static void TurnOffWait()
        {
            if (Driver.WaitOff) return;
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));
            Driver.WaitOff = true;
        }

        internal static void TurnOnWait()
        {
            if (Driver.WaitOff)
            {
                Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                Driver.WaitOff = false;
            }
        }

        internal static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int)timeSpan.TotalSeconds*1000);
        }

        /*public static bool IsElementDisplayedBy(this IWebDriver webdriver, By by)
        {
            try
            {
                return webdriver.FindElement(by).Displayed;
            }
            catch
            {
            }

            return false;
        }*/

        /*public static void WaitForAjax(this IWebDriver value)
        {
            while (!(bool)(value as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0")) // Handle timeout somewhere
            {
                Thread.Sleep(100);
            }
        }*/
    }
}
