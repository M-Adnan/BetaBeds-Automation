using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace BetaBedsAutomation
{
    public class WebControls
    {

        public static void TypeAndSelectDestination(string elementID, string panelID, string userInput)
        {
            IWebElement input = Driver.Instance.FindElement(By.Id(elementID));
            if (!WebControls.TypeAndSelectDestinationValue(input, panelID, userInput, false))
            {
                int count = 0;
                while (!WebControls.TypeAndSelectDestinationValue(input, panelID, userInput, true))
                {
                    if (count == 3) throw new Exception(string.Format("\"{0}\" cannot be found.", userInput));
                    count++;
                }
            }
        }


        private static bool TypeAndSelectDestinationValue(IWebElement input, string panelID, string userInput, bool useBackspace)
        {
            if (useBackspace)
            {
                input.SendKeys(Keys.Backspace);
            }
            else
            {
                input.Clear();
                input.SendKeys(userInput);
            }

            Driver.Wait(TimeSpan.FromSeconds(1));
            
            if (Driver.Instance.FindElement(By.Id(panelID)).Displayed)
            {
                IWebElement dropDown = Driver.Instance.FindElement(By.Id(panelID));
                IWebElement dropDownContainer = dropDown.FindElement(By.XPath("../ul"));
                ReadOnlyCollection<IWebElement> dropDownList = dropDownContainer.FindElements(By.XPath("li"));
                int i = 0;
                foreach (IWebElement list in dropDownList)
                {
                    try
                    {
                        if (list.Text == userInput)
                        {
                            dropDownList[i].Click();
                            return true;
                        }
                    }
                    catch
                    {
                    }
                    i++;
                }
            }
            return false;
        }

        public static void SelectDateBox(string elementId, string dropdown, string date)
        {
            SelectDateBoxYearMonth(elementId, dropdown, date);
            SelectDateBoxDay(elementId, dropdown, date);
        }

        private static void SelectDateBoxYearMonth(string elementId, string dropdown, string dt)
        {
            DateTime selectDate = DateTime.Parse("01 " + Calendar.FormatMonthYear(dt));

            //click on checkin input box
            var checkinDatePicker = Driver.Instance.FindElement(By.Id(elementId));
            checkinDatePicker.Click();

            var monthYearCal = Driver.Instance.FindElement(By.XPath(String.Format("{0}/div[2]/table/thead/tr[1]/th[2]", dropdown)));

            DateTime actualDate = DateTime.Parse("01 " + monthYearCal.Text);

            //next arrow button
            var gotoPrevMonth = Driver.Instance.FindElement(By.XPath(String.Format("{0}/div[2]/table/thead/tr[1]/th[1]", dropdown)));
            var gotoNextMonth = Driver.Instance.FindElement(By.XPath(String.Format("{0}/div[2]/table/thead/tr[1]/th[3]", dropdown)));

            if (elementId != "toDate")
            {
                do
                {
                    if (actualDate < selectDate)
                    {
                        gotoNextMonth.Click();
                    }
                    else if (actualDate > selectDate)
                    {
                        gotoPrevMonth.Click();
                    }
                    actualDate = DateTime.Parse("01 " + monthYearCal.Text);
                } while (actualDate != selectDate);
            }
        }

        private static void SelectDateBoxDay(string elementName, string dropdown, string date)
        {
            //select the date
            ReadOnlyCollection<IWebElement> calDatesTr = Driver.Instance.FindElements(By.XPath(string.Format("{0}/div[2]/table/tbody/tr", dropdown)));
            string[] splitDate = date.Split('/');
            splitDate[0] = splitDate[0].TrimStart('0');
            foreach (IWebElement dateElement in calDatesTr)
            {
                Driver.TurnOffWait();
                ReadOnlyCollection<IWebElement> calDatesTd1 = dateElement.FindElements(By.CssSelector("td[class='day'],td[class='day active']"));
                IWebElement td = calDatesTd1.FirstOrDefault(i => i.Text == splitDate[0]);
                if (td != null)
                {
                    td.Click();
                    Driver.TurnOnWait();
                    return;
                }
            }
        }

        internal static void SelectDropDown(IWebElement dropDown, string value)
        {
            var selectElement = new SelectElement(dropDown);
            selectElement.SelectByValue(value);
        }
    }
}
