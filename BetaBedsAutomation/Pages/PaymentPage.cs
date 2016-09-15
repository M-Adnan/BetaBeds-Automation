using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using BetaBedsAutomation.Data;
using BetaBedsAutomation.Functions;

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
                    if (Driver.FindElementWithTimeout(By.Id("agentpaymentpage"), 40, "Payment page not displayed in 40 secs").Displayed)
                    {
                        return true;
                    }

                    return false;
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
    }
}
