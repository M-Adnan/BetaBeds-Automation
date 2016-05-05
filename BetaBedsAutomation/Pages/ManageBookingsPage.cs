using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

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
                    return Driver.FindElementWithTimeout(By.Id("manage-bookings"), 60, "Manage booking page not displayed in 60 secs").Displayed;
                }
                catch (Exception)
                {
                    return false;
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
