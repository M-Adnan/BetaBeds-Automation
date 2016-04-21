using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BetaBedsAutomation.Navigation
{
    public static class PassangerPopUpBox
    {
        public static void Open()
        {
            var passengersPopUpBox = Driver.Instance.FindElement(By.Id("passengers"));
            passengersPopUpBox.Click();
        }

        public static void SaveChanges()
        {
            IWebElement passangerButtonSet = Driver.Instance.FindElement(By.CssSelector("div.ui-dialog-buttonset button.btn"));
            IWebElement saveChangesButton = Driver.Instance.FindElement(By.XPath("//div/button[2]"));
            saveChangesButton.Click();
        }

        internal static void ClickAddAnotherRoom()
        {
            var addAnotherRoomButton = Driver.Instance.FindElement(By.CssSelector("div.section a.ctx-add.btn.tertiary"));
            addAnotherRoomButton.Click();
        }

        internal static void SelectAdults(int noOfAdults, int roomIndex)
        {
            if (noOfAdults < 1 || noOfAdults > 6) throw new ArgumentOutOfRangeException("adults", noOfAdults, "The number of adults must be between 1 and 6.");
            AddRemovePassangers(noOfAdults, roomIndex, 1);    
        }

        internal static void SelectChildren(int noOfChildren, int[] childrenAges, int roomIndex)
        {
            if (noOfChildren < 0 || noOfChildren > 4) throw new ArgumentOutOfRangeException("children", noOfChildren, "The number of children must be between 0 and 4.");
            if (childrenAges == null) throw new ArgumentNullException("childrenAges");
            if (noOfChildren != childrenAges.Length) throw new ArgumentException("children ages must have the same number of elements as number of children.");
            if (childrenAges.Any(i => i < 0 || i > 17)) throw new ArgumentOutOfRangeException("Children age must be between 0 and 12.");

            IWebElement roomPanel = AddRemovePassangers(noOfChildren, roomIndex, 2);

            for (int i = 0; i < (childrenAges.Length); i++)
            {
                IWebElement childageDropDown = roomPanel.FindElement(By.XPath(string.Format("//div[{0}]/div[2]/div/div/ul/li[{1}]/div/select", (roomIndex + 1), (i+1))));
                WebControls.SelectDropDown(childageDropDown, childrenAges[i].ToString());
            }
        }

        private static IWebElement AddRemovePassangers(int noOfAdultsOrChildren, int roomIndex, int AdultorChildren)
        {
            IWebElement roomPanel = findRoomPanel(roomIndex);
            IWebElement AdultsChildrenSpinButton = roomPanel.FindElement(By.XPath(string.Format("//div[{0}]/div[2]/ul/li[{1}]/div/div/input", (roomIndex + 1), AdultorChildren)));
            int actualNoOfAdultsOrChildren = int.Parse(AdultsChildrenSpinButton.GetAttribute("aria-valuenow"));
            IWebElement removeAdultsChildren = roomPanel.FindElement(By.XPath(string.Format("//div[{0}]/div[2]/ul/li[{1}]/div/div/a[2]", (roomIndex + 1), AdultorChildren)));
            IWebElement addAdultsChildren = roomPanel.FindElement(By.XPath(string.Format("//div[{0}]/div[2]/ul/li[{1}]/div/div/a[1]", (roomIndex + 1), AdultorChildren)));
            do
            {
                if (actualNoOfAdultsOrChildren < noOfAdultsOrChildren)
                {
                    addAdultsChildren.Click();
                }
                else if (actualNoOfAdultsOrChildren > noOfAdultsOrChildren)
                {
                    removeAdultsChildren.Click();
                }
                actualNoOfAdultsOrChildren = int.Parse(AdultsChildrenSpinButton.GetAttribute("aria-valuenow"));
            } while (actualNoOfAdultsOrChildren != noOfAdultsOrChildren);

            return roomPanel;
        }

        private static IWebElement findRoomPanel(int roomIndex)
        {
            if (roomIndex == 0)
            {
                return Driver.Instance.FindElement(By.XPath("/html/body/div[5]/div[2]/div/div/div[1]"));
            }
            else
            {
                var element = Driver.Instance.FindElement(By.XPath(string.Format("/html/body/div[5]/div[2]/div/div/div[1]/div[2]/div[{0}]", (roomIndex+1))));
                return element;
            }
        }
    }
}
