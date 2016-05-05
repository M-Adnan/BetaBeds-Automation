using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace BetaBedsAutomation
{
    public class PageHeader
    {
        public class UserMenu
        {
            public class ManageBookings
            {
                public static void Select()
                {
                    PageHeader.ClickUserMenu();
                    if (UserMenu.IsUserMenuDropdownOpen())
                    {
                        ReadOnlyCollection<IWebElement> userMenuOptions = PageHeader.GetUserMenuList();
                        IWebElement ManageBookingLink = userMenuOptions[0].FindElement(By.LinkText("Manage Bookings"));
                        ManageBookingLink.Click();
                        PageHeader.SwitchTab();
                    }
                    else
                        throw new Exception("User menu dropdown isn't open");
                }
            }

            public class Logout
            {
                public static void Select()
                {
                    PageHeader.ClickUserMenu();
                    if (UserMenu.IsUserMenuDropdownOpen())
                    {
                        ReadOnlyCollection<IWebElement> userMenuOptions = PageHeader.GetUserMenuList();
                        userMenuOptions[1].Click();
                    }
                    else
                        throw new Exception("User menu dropdown isn't open");
                }
            }

            public class SearchAndBookSite
            {
                public static void Select()
                {
                    PageHeader.ClickUserMenu();
                    if (UserMenu.IsUserMenuDropdownOpen())
                    {
                        ReadOnlyCollection<IWebElement> userMenuOptions = PageHeader.GetUserMenuList();
                        IWebElement searchAndBookLink = userMenuOptions[0].FindElement(By.LinkText("Search and Book site"));
                        searchAndBookLink.Click();
                        PageHeader.ClosePreviousAndSwitchTab();
                    }
                    else
                        throw new Exception("User menu dropdown isn't open");
                }
            }

            internal static bool IsUserMenuDropdownOpen()
            {
                return Driver.IsElementDisplayed(By.CssSelector("div.site-header-user-wrapper.open"));
            }
        }


        internal static void ClickUserMenu()
        {
            var userMenuLink = Driver.Instance.FindElement(By.Id("userMenuToggle"));
            userMenuLink.Click();
        }

        internal static ReadOnlyCollection<IWebElement> GetUserMenuList()
        {
            var userMenuDivs = Driver.Instance.FindElement(By.CssSelector("div.site-header-user-wrapper.open"));
            ReadOnlyCollection<IWebElement> userMenuList = userMenuDivs.FindElements(By.CssSelector("li"));
            return userMenuList;
        }

        internal static void SwitchTab()
        {
            //Driver.Wait(TimeSpan.FromSeconds(1));
            Driver.WaitForAjax();
            ReadOnlyCollection<String> browserTabs = Driver.Instance.WindowHandles; // get all window handles
            String newTab = browserTabs[(browserTabs.Count() - 1)];
            Driver.Instance.SwitchTo().Window(newTab);
        }

        internal static void ClosePreviousAndSwitchTab()
        {
            Driver.WaitForAjax();
            ReadOnlyCollection<String> browserTabs = Driver.Instance.WindowHandles; // get all window handles
            foreach (string tab in browserTabs)
            {
                if (tab == browserTabs.Last())
                {
                    Driver.Instance.SwitchTo().Window(tab);
                }
                else
                {
                    Driver.Instance.SwitchTo().Window(tab);
                    Driver.Instance.Close();
                }
            }           
        }
    }
}
