using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BetaBedsAutomation.Functions
{
    public class PageFunctions
    {
        public static void WaitForLoad(string pageID, string errMsg)
        {
            Driver.WaitForAjax();
            Driver.FindElementWithTimeout(By.Id(pageID), 40, errMsg);
        }

        public static string GetUrl()
        {
            string url = Driver.Instance.Url;
            return url;
        }
        
        public static string GetSearchGUID()
        {
            string url = GetUrl();
            string searchID = url.Split(new char[] { '=', '&' })[1];
            return searchID;
        }
    }
}
