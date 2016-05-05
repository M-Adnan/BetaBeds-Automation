using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace BetaBedsAutomation
{
    public class AccommodationResultsPage
    {
        public static bool IsDisplayed
        {
            get
            {
                try
                {
                    return Driver.FindElementWithTimeout(By.Id("accommodationresultspage"), 60, "Accommodation result page not displayed in 60 secs").Displayed;
                }
                catch (Exception)
                {
                    
                    return false;
                }
            }
        }

        private static string SaveSearchGUID()
        {
            string url = Driver.Instance.Url;
            string searchID = url.Split(new char[] { '=', '&' })[1];
            return searchID;
        }

        public static bool AreResultsDisplayed
        {
            get
            {
                try
                {
                    return (GetAccommodationResultsPanel().Count > 0);
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        internal static ReadOnlyCollection<IWebElement> GetAccommodationResultsPanel()
        {
            var allSearchResults = Driver.Instance.FindElement(By.Id("establishmentResults"));
            return allSearchResults.FindElements(By.CssSelector("ul.list.results li.list-item.card"));
        }

        private static IWebElement GetHotelPanel(int hotelNumber)
        {
            return GetAccommodationResultsPanel()[hotelNumber - 1];
        }


        public static void ClickHotelNumber(int hotelNumber)
        {
            var hotelPanel = GetHotelPanel(hotelNumber);
            var hotelNameLink = hotelPanel.FindElement(By.CssSelector("h2.establishment-heading a"));
            hotelNameLink.Click();
        }
    }
}
