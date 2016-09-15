using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using BetaBedsAutomation.Data;
using BetaBedsAutomation.Functions;
using BetaBedsUITestLogger;

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
                    if (Driver.FindElementWithTimeout(By.Id("accommodationresultspage"), 40, "Accommodation result page not displayed in 40 secs").Displayed)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    Guids.SearchGuid = PageFunctions.GetSearchGUID();
                    Guids.pageUrl = PageFunctions.GetUrl();
                }
            }
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
            IWebElement hotelNameLink = hotelPanel.FindElement(By.CssSelector("h2.establishment-heading a"));
            Logger.AddClickAction(hotelNameLink.Text + " link");
            hotelNameLink.Click();
        }

        internal static void WaitForLoad()
        {
            Driver.WaitForAjax();
            Guids.SearchGuid = PageFunctions.GetSearchGUID();
            Guids.pageUrl = PageFunctions.GetUrl();
            Driver.FindElementWithTimeout(By.Id("accommodationresultspage"), 40, "Accommodation result page not displayed in 40 secs"); 
        }
    }
}
