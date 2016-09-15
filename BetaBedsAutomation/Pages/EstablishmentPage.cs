using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using BetaBedsAutomation;
using System.Collections.ObjectModel;
using BetaBedsAutomation.Data;
using BetaBedsAutomation.Functions;

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
                    if (Driver.FindElementWithTimeout(By.Id("establishmentpage"), 40, "Establishment page not displayed in 40 secs").Displayed)
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

        internal static void WaitForLoad()
        {
            Driver.WaitForAjax();
            Driver.FindElementWithTimeout(By.Id("establishmentpage"), 40, "Establishment page not displayed in 40 secs");
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
                        PageFunctions.WaitForLoad("agentpaymentpage","Payment page not displayed in 40 secs");
                    }
                    catch (Exception ex)
                    {
                        Guids.SearchGuid = PageFunctions.GetSearchGUID();
                        Guids.pageUrl = PageFunctions.GetUrl();
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
                            throw new Exception(string.Format("Selected Hotel room(s) are fully booked for the dates selected."));
                        if (displayedErrMsg.Text.Trim() == "No results found")
                            throw new Exception(string.Format("For Selected Hotel 'No results found' error message is displayed."));
                        if (displayedErrMsg.Text.Trim() == "Room unavailable")
                            throw new Exception(string.Format("For Room Number {0} selected room {1} is no longer available.", room.roomNumber, room.availableRoomNumber));
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
