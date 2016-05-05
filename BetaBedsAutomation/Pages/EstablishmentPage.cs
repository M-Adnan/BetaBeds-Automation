using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using BetaBedsAutomation;
using System.Collections.ObjectModel;

namespace BetaBedsAutomation
{
    public class EstablishmentPage
    {
        public static bool IsDisplayed
        {
            get
            {
                try
                {
                    return Driver.FindElementWithTimeout(By.Id("establishmentpage"), 60, "Establishment page not displayed in 60 secs").Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static RoomSelectionProcess RoomSelection()
        {
            return new RoomSelectionProcess();
        }

        internal static void SelectRoomTab(int roomNumber)
        {
            var selectedRoom = Driver.Instance.FindElement(By.Id(string.Format("estab0-room-tab{0}", roomNumber)));
            selectedRoom.Click();
            Driver.WaitForAjax();
        }

        internal static void SelectRoomByNumber(int availableRoom)
        {
            IWebElement availableRoomButton = GetAvailableRoomButton(availableRoom);
            availableRoomButton.Click();
        }

        private static IWebElement GetAvailableRoomButton(int availableRoom)
        {
            IWebElement roomPanel = GetAvailableRoomPanel(availableRoom);
            IWebElement roomButton = roomPanel.FindElement(By.CssSelector("[class='select-room-wrapper']"));
            //IWebElement roomButton = roomButtonDiv
            return roomButton;
        }

        private static IWebElement GetAvailableRoomPanel(int availableRoom)
        {
            IWebElement roomsPanel = GetHotelRoomPanel();
            Driver.Wait(TimeSpan.FromSeconds(1));
            ReadOnlyCollection<IWebElement> roomsList = Driver.FindElementsWithTimeout(By.CssSelector("ul.list.rooms-list.card"),30);
            IWebElement displayedRoomPanel = roomsList.First(i => i.Displayed);
            ReadOnlyCollection<IWebElement> rooms = displayedRoomPanel.FindElements(By.CssSelector("li.list-item.room-item"));
            if (rooms.Count < availableRoom) throw new Exception(string.Format("Available room {0} not available.", availableRoom));
            IWebElement roomPanel = rooms[(availableRoom - 1)];
            return roomPanel;
        }

        private static IWebElement GetHotelRoomPanel()
        {
            Driver.Instance.FindElement(By.CssSelector("[class='rooms-wrapper']")) ;
            var roomsPanel = Driver.Instance.FindElement(By.CssSelector("[class='rooms-wrapper']"));
            return roomsPanel;
        }
    }


    public class RoomSelectionProcess
    {
        internal class Room
        {
            internal Room(int roomNumber)
            {
                this.roomNumber = roomNumber;
            }

            public int roomNumber { get; set; }
            public int availableRoomNumber { get; set; }
            public string roomType { get; set; }
            public string MyProperty { get; set; }
        }

        private List<Room> rooms { get; set; }

        public RoomSelectionProcess()
        {
            this.rooms = new List<Room>();
            //this.rooms.Add(new Room());
        }

        public RoomSelectionProcess SelectRoomNumber(int availableRoomNumber)
        {
            this.rooms.Last().availableRoomNumber = availableRoomNumber;
            return this;
        }

        public RoomSelectionProcess SelectRoomType(string roomType)
        {
            this.rooms.Last().roomType = roomType;
            return this;
        }

        public RoomSelectionProcess WithBoardType(string boardType)
        {
            this.rooms.Last().roomType = boardType;
            return this;
        }

        public RoomSelectionProcess ForRoom(int roomNumber)
        {
            this.rooms.Add(new Room(roomNumber));
            return this;
        }

        public void Continue()
        {
            foreach (Room room in this.rooms)
            {
                if (this.rooms.IndexOf(room) > 0)
                {
                    EstablishmentPage.SelectRoomTab(room.roomNumber);
                    if (room.availableRoomNumber != 0) EstablishmentPage.SelectRoomByNumber(room.availableRoomNumber);
                    Driver.WaitForAjax();
                    Driver.Wait(TimeSpan.FromSeconds(1));
                    var continueButton = Driver.Instance.FindElement(By.Id("continue-0"));
                    continueButton.Click();
                    try
                    {
                        PaymentPage.WaitForLoad();
                    }
                    catch (Exception ex)
                    {
                        if (Driver.IsElementDisplayed(By.CssSelector("div.box-header h4[class='box-heading']")))
                            throw new Exception(string.Format("Room Number {0} selected room is no longer available.", room.roomNumber));
                        if (Driver.IsElementDisplayed(By.CssSelector("div.box-header h4[class='alert alert-warning hidden']")))
                            throw new Exception("Selected Hotel is fully booked for the dates selected.");
                        throw ex;      
                    }
                    
                }
                else
                {
                    if (room.availableRoomNumber != 0) EstablishmentPage.SelectRoomByNumber(room.availableRoomNumber);  
                }
            }
        }
    }
}
