using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using BetaBedsAutomation.Data;
using BetaBedsAutomation.Functions;

namespace BetaBedsAutomation
{
    public class ManageBookingsPage
    {
        public static bool IsDisplayed
        {
            get
            {
                try
                {
                    return Driver.FindElementWithTimeout(By.Id("manage-bookings"), 40, "Manage booking page not displayed in 40 secs").Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    Guids.pageUrl = PageFunctions.GetUrl();
                }

            }
        }

        public static void ClosePage()
        {
            Driver.Instance.Close();
            ReadOnlyCollection<String> browserTabs = Driver.Instance.WindowHandles; // get all window handles
            string browserWindow = browserTabs.First();
            Driver.Instance.SwitchTo().Window(browserWindow);
        }
    }
}
