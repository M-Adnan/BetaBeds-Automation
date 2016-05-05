using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using BetaBedsAutomation.Navigation;


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
                    return Driver.FindElementWithTimeout(By.Id("homepage"),60,"Home page not displayed in 60 secs").Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static SearchCommand SearchDestination(string destination)
        {
            return new SearchCommand(destination);
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

        private string destination;
        private string fromDate;
        private string toDate;
        private int noOfAdults;
        private int noOfChildren;
        private int[] ChildrenAges;
        private List<Room> rooms;

        public SearchCommand(string destination)
        {
            this.rooms = new List<Room>();
            this.rooms.Add(new Room());
            this.destination = destination;
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

            if (destination != null) WebControls.TypeAndSelectDestination("Destination", "ui-id-1", destination);

            if (fromDate != null) WebControls.SelectDateBox("fromDate", "/html/body/div[2]", fromDate);

            if (toDate != null) WebControls.SelectDateBox("toDate", "/html/body/div[3]", toDate); ;

            PassangerPopUpBox.Open();

            foreach (Room room in this.rooms)
            {
                if (this.rooms.IndexOf(room) > 0) PassangerPopUpBox.ClickAddAnotherRoom();
                if (room.noOfAdults != 0) PassangerPopUpBox.SelectAdults(room.noOfAdults, this.rooms.IndexOf(room));
                if (room.noOfChildren != 0) PassangerPopUpBox.SelectChildren(room.noOfChildren, room.childrenAges, this.rooms.IndexOf(room));
            }
            PassangerPopUpBox.SaveChanges();

            var searchButton = Driver.Instance.FindElement(By.Id("searchFormSubmitButton"));
            searchButton.Click();
        }

        internal void searchProcess()
        {
 
        }
    }
}