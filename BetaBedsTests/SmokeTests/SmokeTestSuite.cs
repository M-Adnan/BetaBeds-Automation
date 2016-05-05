using System;
using NUnit.Framework;
using BetaBedsAutomation;


namespace BetaBedsTests
{
    [TestFixture]
    public class SearchDestinationTests : BaseTestClass
    {

        [Test]
        [Category("SmokeTest")]
        public void User_Successful_Login()
        {
            Assert.IsTrue(HomePage.IsDisplayed, "Failed to Login.");
        }

        [Test]
        [Category("SmokeTest")]
        public void Can_SearchAndBook_SingleRoom_Child_Destination_Palma_De_Mallorca_Mallorca_AdultsOnly()
        {
            HomePage.SearchDestination("Palma De Mallorca, Mallorca (Majorca), Spain")
                .FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate(1))
                .ForAdults(1).Search();

            Assert.That(AccommodationResultsPage.IsDisplayed, Is.True, "Accommodation results page wasn't available in 60 seconds");

            Assert.That(AccommodationResultsPage.AreResultsDisplayed, Is.True, "No results are available for the accommodation search");

            AccommodationResultsPage.ClickHotelNumber(AccommodationResultPageRnd.PickRandomHotel());

            Assert.That(EstablishmentPage.IsDisplayed, Is.True, "Establishment page wasn't available in 60 seconds");

            EstablishmentPage.RoomSelection().ForRoom(1).SelectRoomNumber(1).Continue();

            Assert.That(PaymentPage.IsDisplayed, Is.True, "Payment page wasn't available in 60 seconds");
        }

        [Test]
        [Category("SmokeTest")]
        public void Can_SearchAndBook_SingleRoom_Child_Destination_Albufeira_Algarve_AdultsChildrenAndInfant()
        {
            HomePage.SearchDestination("Albufeira, Algarve, Portugal")
                .FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate(7))
                .ForAdults(2).WithChildren(3).OfAges(0,11,17).Search();

            Assert.That(AccommodationResultsPage.IsDisplayed, Is.True, "Accommodation results page wasn't available in 60 seconds");

            Assert.That(AccommodationResultsPage.AreResultsDisplayed, Is.True, "No results are available for the accommodation search");

            AccommodationResultsPage.ClickHotelNumber(AccommodationResultPageRnd.PickRandomHotel());

            Assert.That(EstablishmentPage.IsDisplayed, Is.True, "Establishment page wasn't available in 60 seconds");

            EstablishmentPage.RoomSelection().ForRoom(1).SelectRoomNumber(1).Continue();

            Assert.That(PaymentPage.IsDisplayed, Is.True, "Payment page wasn't available in 60 seconds");
        }

        [Test]
        [Category("SmokeTest")]
        public void Can_SearchAndBook_SingleRoom_Parent_Destination_Algarve_AdultsChildrenAndInfant()
        {
            HomePage.SearchDestination("Algarve, Portugal")
                .FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate(3))
                .ForAdults(2).WithChildren(2).OfAges(0,2).Search();

            Assert.That(AccommodationResultsPage.IsDisplayed, Is.True, "Accommodation results page wasn't available in 60 seconds");

            Assert.That(AccommodationResultsPage.AreResultsDisplayed, Is.True, "No results are available for the accommodation search");

            AccommodationResultsPage.ClickHotelNumber(AccommodationResultPageRnd.PickRandomHotel());

            Assert.That(EstablishmentPage.IsDisplayed, Is.True, "Establishment page wasn't available in 60 seconds");

            EstablishmentPage.RoomSelection().ForRoom(1).SelectRoomNumber(1).Continue();

            Assert.That(PaymentPage.IsDisplayed, Is.True, "Payment page wasn't available in 60 seconds");
        }

        [Test]
        [Category("SmokeTest")]
        public void Can_SearchAndBook_SingleRoom_Parent_Destination_Mallorca_AdultsAndChildren()
        {
            HomePage.SearchDestination("Mallorca (Majorca), Spain")
                .FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate(5))
                .ForAdults(2).WithChildren(2).OfAges(11, 12).Search();

            Assert.That(AccommodationResultsPage.IsDisplayed, Is.True, "Accommodation results page wasn't available in 60 seconds");

            Assert.That(AccommodationResultsPage.AreResultsDisplayed, Is.True, "No results are available for the accommodation search");

            AccommodationResultsPage.ClickHotelNumber(AccommodationResultPageRnd.PickRandomHotel());

            Assert.That(EstablishmentPage.IsDisplayed, Is.True, "Establishment page wasn't available in 60 seconds");

            EstablishmentPage.RoomSelection().ForRoom(1).SelectRoomNumber(1).Continue();

            Assert.That(PaymentPage.IsDisplayed, Is.True, "Payment page wasn't available in 60 seconds");
        }

        [Test]
        [Category("SmokeTest")]
        public void Can_SearchAndBook_MultiRoom_Child_Destination_Costa_Adeje_Tenerife_AdultsChildrenAndInfant()
        {
            HomePage.SearchDestination("Costa Adeje, Tenerife, Canaries")
                .FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate(10))
                .ForAdults(2).AddAnotherRoom().ForAdults(2).WithChildren(3).OfAges(0,11,12).Search();

            Assert.That(AccommodationResultsPage.IsDisplayed, Is.True, "Accommodation results page wasn't available in 60 seconds");

            Assert.That(AccommodationResultsPage.AreResultsDisplayed, Is.True, "No results are available for the accommodation search");

            AccommodationResultsPage.ClickHotelNumber(AccommodationResultPageRnd.PickRandomHotel());

            Assert.That(EstablishmentPage.IsDisplayed, Is.True, "Establishment page wasn't available in 60 seconds");

            EstablishmentPage.RoomSelection().ForRoom(1).SelectRoomNumber(1).ForRoom(2).SelectRoomNumber(1).Continue();

            Assert.That(PaymentPage.IsDisplayed, Is.True, "Payment page wasn't available in 60 seconds");
        }

        [Test]
        [Category("SmokeTest")]
        public void Can_SearchAndBook_MultiRoom_Parent_Destination_Tenerife_AdultsChildrenAndInfant()
        {
            HomePage.SearchDestination("Tenerife, Canaries")
                .FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
                .ForAdults(2).AddAnotherRoom().ForAdults(2).WithChildren(3).OfAges(0, 11, 12).Search();

            Assert.That(AccommodationResultsPage.IsDisplayed, Is.True, "Accommodation results page wasn't available in 60 seconds");

            Assert.That(AccommodationResultsPage.AreResultsDisplayed, Is.True, "No results are available for the accommodation search");

            AccommodationResultsPage.ClickHotelNumber(AccommodationResultPageRnd.PickRandomHotel());

            Assert.That(EstablishmentPage.IsDisplayed, Is.True, "Establishment page wasn't available in 60 seconds");

            EstablishmentPage.RoomSelection().ForRoom(1).SelectRoomNumber(1).ForRoom(2).SelectRoomNumber(1).Continue();

            Assert.That(PaymentPage.IsDisplayed, Is.True, "Payment page wasn't available in 60 seconds");
        }

        [Test]
        [Category("SmokeTest")]
        public void Can_SearchAndBook_SingleRoom_Hotel_Tenerife_AdultsChildrenAndInfant()
        {
            HomePage.SearchDestination("Hotel La Estacion, Benidorm")
                .FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
                .ForAdults(2).WithChildren(3).OfAges(0, 11, 15).Search();

            Assert.That(AccommodationResultsPage.IsDisplayed, Is.True, "Accommodation results page wasn't available in 60 seconds");

            Assert.That(AccommodationResultsPage.AreResultsDisplayed, Is.True, "No results are available for the accommodation search");

            AccommodationResultsPage.ClickHotelNumber(AccommodationResultPageRnd.PickRandomHotel());

            Assert.That(EstablishmentPage.IsDisplayed, Is.True, "Establishment page wasn't available in 60 seconds");

            EstablishmentPage.RoomSelection().ForRoom(1).SelectRoomNumber(1).Continue();

            Assert.That(PaymentPage.IsDisplayed, Is.True, "Payment page wasn't available in 60 seconds");
        }

        [Test]
        [Category("SmokeTest")]
        public void Can_SearchAndBook_SingleRoom_Hotel_TropicalSol_Algarve_AdultsChildrenAndInfant()
        {
            HomePage.SearchDestination("Tropical Sol, Albufeira, Algarve")
                .FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
                .ForAdults(2).WithChildren(3).OfAges(0, 11, 15).Search();

            Assert.That(AccommodationResultsPage.IsDisplayed, Is.True, "Accommodation results page wasn't available in 60 seconds");

            Assert.That(AccommodationResultsPage.AreResultsDisplayed, Is.True, "No results are available for the accommodation search");

            AccommodationResultsPage.ClickHotelNumber(AccommodationResultPageRnd.PickRandomHotel());

            Assert.That(EstablishmentPage.IsDisplayed, Is.True, "Establishment page wasn't available in 60 seconds");

            EstablishmentPage.RoomSelection().ForRoom(1).SelectRoomNumber(1).Continue();

            Assert.That(PaymentPage.IsDisplayed, Is.True, "Payment page wasn't available in 60 seconds");
        }

        [Test]
        [Category("SmokeTest")]
        public void Can_SearchAndBook_MultiRoom_Hotel_LaEstacion_Benidorm_AdultsChildrenAndInfant()
        {
            HomePage.SearchDestination("Hotel La Estacion, Benidorm")
                .FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
                .ForAdults(2).WithChildren(2).OfAges(0, 2)
                .AddAnotherRoom().ForAdults(2).WithChildren(2).OfAges(11,17).Search();

            Assert.That(AccommodationResultsPage.IsDisplayed, Is.True, "Accommodation results page wasn't available in 60 seconds");

            Assert.That(AccommodationResultsPage.AreResultsDisplayed, Is.True, "No results are available for the accommodation search");

            AccommodationResultsPage.ClickHotelNumber(AccommodationResultPageRnd.PickRandomHotel());

            Assert.That(EstablishmentPage.IsDisplayed, Is.True, "Establishment page wasn't available in 60 seconds");

            EstablishmentPage.RoomSelection().ForRoom(1).SelectRoomNumber(1).ForRoom(2).SelectRoomNumber(1).Continue();

            Assert.That(PaymentPage.IsDisplayed, Is.True, "Payment page wasn't available in 60 seconds");
        }

        [Test]
        [Category("SmokeTest")]
        public void Can_Navigateto_ManageBookings()
        {
            PageHeader.UserMenu.ManageBookings.Select();

            Assert.That(ManageBookingsPage.IsDisplayed, Is.True, "Manage booking page wasn't available in 60 seconds");
        }

        [Test]
        [Category("SmokeTest")]
        public void Can_Navigatefrom_ManageBookings_toSearchAndBookSite()
        {
            PageHeader.UserMenu.ManageBookings.Select();

            Assert.That(ManageBookingsPage.IsDisplayed, Is.True, "Manage booking page wasn't available in 60 seconds");

            PageHeader.UserMenu.SearchAndBookSite.Select();

            Assert.IsTrue(HomePage.IsDisplayed, "Failed to return to search and book site from manage booking page");
        }
    }
}
