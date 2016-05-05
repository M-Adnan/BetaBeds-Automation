using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BetaBedsAutomation
{
    public class PaymentPage
    {
        public static bool IsDisplayed
        {
            get
            {
                try
                {
                    return Driver.FindElementWithTimeout(By.Id("agentpaymentpage"),60,"Payment page not displayed in 60 secs").Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        internal static void WaitForLoad()
        {
            Driver.FindElementWithTimeout(By.Id("agentpaymentpage"), 60, "Payment page not displayed in 60 secs");
        }
    }
}
