using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using BetaBedsAutomation.Navigation;
using BetaBedsAutomation.Data;
using BetaBedsAutomation.Functions;
using BetaBedsAutomation.Log;
using BetaBedsUITestLogger;

namespace BetaBedsAutomation
{
    public class HomePage
    {
        public static bool IsDisplayed
        {
            get
            {
                try
                {
                    return Driver.FindElementWithTimeout(By.Id("homepage"),40,"Home page not displayed in 40 secs").Displayed;
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

        public static void TypeDestination(string destination, bool isHotel)
        {
            Logger.AddTypeAction(destination, " in Destination field");

            WebControls.TypeAndSelectDestination("Destination", "ui-id-1", destination);
        }

        public static void SelectCheckIn(string fromDate)
        {
            Logger.AddSelectAction(fromDate, "as Checkin date");
            WebControls.SelectDateBox("fromDate", "/html/body/div[2]", fromDate);
        }

        public static void SelectCheckOut(string toDate)
        {
            Logger.AddSelectAction(toDate, "as Checkout date");
            WebControls.SelectDateBox("toDate", "/html/body/div[3]", toDate);
        }

        public static void ClickSearchButton()
        {
            Logger.AddClickAction(" Search button");
            var searchButton = Driver.Instance.FindElement(By.Id("searchFormSubmitButton"));
            searchButton.Click();
        }
   
        public static SearchCommand SearchDestination(string destination)
        {
            return new SearchCommand(destination, false);
        }

        public static SearchCommand SearchHotel(string hotel)
        {
            return new SearchCommand(hotel, true);
        }
    }


    public class SearchCommand
    {
        private class Room
        {
            public int noOfAdults { get; set; }
            public int noOfChildren { get; set; }
            public int[] childrenAges { get; set; }
        }

        private bool IsHotel;
        private string destination;
        private string fromDate;
        private string toDate;
        private int noOfAdults;
        private int noOfChildren;
        private int[] ChildrenAges;
        private List<Room> rooms;

        public SearchCommand(string destination, bool IsHotel)
        {
            this.rooms = new List<Room>();
            this.rooms.Add(new Room());
            this.destination = destination;
            this.IsHotel = IsHotel;
        }

        public SearchCommand FromCheckInDate(string fromDate)
        {
            this.fromDate = fromDate;
            return this;
        }

        public SearchCommand ToCheckOutDate(string toDate)
        {
            this.toDate = toDate;
            return this;
        }

        public SearchCommand ForAdults(int noOfAdults)
        {
            this.rooms.Last().noOfAdults = noOfAdults;
            this.noOfAdults = noOfAdults;
            return this;
        }

        public SearchCommand WithChildren(int noOfChildren)
        {
            this.rooms.Last().noOfChildren = noOfChildren;
            this.noOfChildren = noOfChildren;
            return this;
        }

        public SearchCommand OfAges(params int[] ChildrenAges)
        {
            this.rooms.Last().childrenAges = ChildrenAges;
            this.ChildrenAges = ChildrenAges;
            return this;
        }

        public SearchCommand AddAnotherRoom()
        {
            this.rooms.Add(new Room());
            return this;
        }

        public void Search()
        {

            if (destination != null) HomePage.TypeDestination(this.destination, this.IsHotel);

            if (fromDate != null) HomePage.SelectCheckIn(this.fromDate);

            if (toDate != null) HomePage.SelectCheckOut(toDate); 

            PassangerPopUpBox.Open();

            foreach (Room room in this.rooms)
            {
                if (this.rooms.IndexOf(room) > 0) PassangerPopUpBox.ClickAddAnotherRoom();
                if (room.noOfAdults != 0) PassangerPopUpBox.SelectAdults(room.noOfAdults, this.rooms.IndexOf(room));
                if (room.noOfChildren != 0) PassangerPopUpBox.SelectChildren(room.noOfChildren, room.childrenAges, this.rooms.IndexOf(room));
            }
            
            PassangerPopUpBox.SaveChanges();

            HomePage.ClickSearchButton();

            if (IsHotel)
            {
                try
                {
                    PageFunctions.WaitForLoad("establishmentpage", "Establishment page not displayed in 40 secs");
                }
                catch (Exception ex)
                {
                    ReadOnlyCollection<IWebElement> ErrMsgsDivs = Driver.Instance.FindElements(By.CssSelector("div.box-header h4.box-heading"));
                    IWebElement displayedErrMsg;
                    try
                    {
                        displayedErrMsg = ErrMsgsDivs.First(i => i.Displayed);
                    }
                    catch
                    {
                        throw ex;
                    }
                    if (displayedErrMsg.Text.Trim() == "Hotel unavailable")
                        throw new Exception(string.Format("Selected Hotel {0} is fully booked for the dates {1} to {2}.", this.destination, this.fromDate, this.toDate));
                    if (displayedErrMsg.Text.Trim() == "No results found")
                        throw new Exception(string.Format("For Selected Hotel {0} between {1} to {2} dates 'No results found' error message is displayed.", this.destination, this.fromDate, this.toDate));
                    throw ex;
                }
            }
            else
                try
                {
                    PageFunctions.WaitForLoad("accommodationresultspage", "Accommodation result page not displayed in 40 secss");
                }
                catch (Exception ex)
                {
                    ReadOnlyCollection<IWebElement> ErrMsgsDivs = Driver.Instance.FindElements(By.CssSelector("div.box-header h4.box-heading"));
                    IWebElement displayedErrMsg;
                    try
                    {
                        displayedErrMsg = ErrMsgsDivs.First(i => i.Displayed);
                    }
                    catch
                    {
                        throw ex;
                    }
                    displayedErrMsg = ErrMsgsDivs.First(i => i.Displayed);
                    if (displayedErrMsg.Text.Trim() == "No results found")
                        throw new Exception(string.Format("For Selected destination {0} between {1} to {2} dates 'No results found' error message is displayed.", this.destination, this.fromDate, this.toDate));
                    throw ex;
                }
        }
    }
}