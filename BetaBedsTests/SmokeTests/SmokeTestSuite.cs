using System;
using NUnit.Framework;
using BetaBedsAutomation;



namespace BetaBedsTests
{
    [TestFixture]
    public class SearchDestinationTests : BaseTestClass 
    {
        [Test]
        public void NUnitFileLoggingAddin_IsDiscoverable()
        {
            /*var addin = new NUnitFileLoggerAddin();

            addin.Should().BeAssignableTo<IAddin>();
            addin.GetType().Should().BeDecoratedWith<NUnitAddinAttribute>(
                a => a.Type == ExtensionType.Core);*/
            
        }

        [Test]
        [Category("SmokeTest")]
        public void User_Successful_Login()
        {
            Assert.IsTrue(LoginPage.IsDisplayed, "Login page wasn't displayed in 40 seconds");

            LoginPage.LoginAs("venkatay").WithPassword("password").Login();

            Assert.IsTrue(HomePage.IsDisplayed, "Failed to Login.");

        }

        [Test]
        [Category("SmokeTest")]
        public void Can_SearchAndBook_SingleRoom_Child_Destination_Palma_De_Mallorca_Mallorca_AdultsOnly()
        {
            Assert.IsTrue(LoginPage.IsDisplayed, "Login page wasn't displayed in 40 seconds");

            LoginPage.LoginAs("venkatay").WithPassword("password").Login();
            
            Assert.IsTrue(HomePage.IsDisplayed, "Failed to Login.");

            HomePage.SearchDestination("Palma De Mallorca, Mallorca (Majorca), Spain")
                .FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate(1))
                .ForAdults(1).Search();

            Assert.That(AccommodationResultsPage.IsDisplayed, Is.True, "Accommodation results page wasn't available in 40 seconds");

            Assert.That(AccommodationResultsPage.AreResultsDisplayed, Is.True, "No results are available for the accommodation search");

            AccommodationResultsPage.ClickHotelNumber(AccommodationResultPageRnd.PickRandomHotel());

            Assert.That(EstablishmentPage.IsDisplayed, Is.True, "Establishment page wasn't available in 40 seconds");

            EstablishmentPage.RoomSelection().ForRoom(1).SelectRoomNumber(1).Continue();

            Assert.That(PaymentPage.IsDisplayed, Is.True, "Payment page wasn't available in 40 seconds");
        }

        [Test]
        [Category("SmokeTest")]
        public void Can_SearchAndBook_SingleRoom_Child_Destination_Albufeira_Algarve_AdultsChildrenAndInfant()
        {
            Assert.IsTrue(LoginPage.IsDisplayed, "Login page wasn't displayed in 40 seconds");

            LoginPage.LoginAs("venkatay").WithPassword("password").Login();

            Assert.IsTrue(HomePage.IsDisplayed, "Failed to Login.");

            HomePage.SearchDestination("Albufeira, Algarve, Portugal")
                .FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate(7))
                .ForAdults(2).WithChildren(3).OfAges(0,11,17).Search();

            Assert.That(AccommodationResultsPage.IsDisplayed, Is.True, "Accommodation results page wasn't available in 40 seconds");

            Assert.That(AccommodationResultsPage.AreResultsDisplayed, Is.True, "No results are available for the accommodation search");

            AccommodationResultsPage.ClickHotelNumber(AccommodationResultPageRnd.PickRandomHotel());

            Assert.That(EstablishmentPage.IsDisplayed, Is.True, "Establishment page wasn't available in 40 seconds");

            EstablishmentPage.RoomSelection().ForRoom(1).SelectRoomNumber(1).Continue();

            Assert.That(PaymentPage.IsDisplayed, Is.True, "Payment page wasn't available in 40 seconds");
        }

        [Test]
        [Category("SmokeTest")]
        public void Can_SearchAndBook_SingleRoom_Parent_Destination_Algarve_AdultsChildrenAndInfant()
        {
            Assert.IsTrue(LoginPage.IsDisplayed, "Login page wasn't displayed in 40 seconds");

            LoginPage.LoginAs("venkatay").WithPassword("password").Login();

            Assert.IsTrue(HomePage.IsDisplayed, "Failed to Login.");

            HomePage.SearchDestination("Algarve, Portugal")
                .FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate(3))
                .ForAdults(2).WithChildren(2).OfAges(0,2).Search();

            Assert.That(AccommodationResultsPage.IsDisplayed, Is.True, "Accommodation results page wasn't available in 40 seconds");

            Assert.That(AccommodationResultsPage.AreResultsDisplayed, Is.True, "No results are available for the accommodation search");

            AccommodationResultsPage.ClickHotelNumber(AccommodationResultPageRnd.PickRandomHotel());

            Assert.That(EstablishmentPage.IsDisplayed, Is.True, "Establishment page wasn't available in 40 seconds");

            EstablishmentPage.RoomSelection().ForRoom(1).SelectRoomNumber(1).Continue();

            Assert.That(PaymentPage.IsDisplayed, Is.True, "Payment page wasn't available in 40 seconds");
        }

        [Test]
        [Category("SmokeTest")]
        public void Can_SearchAndBook_SingleRoom_Parent_Destination_Mallorca_AdultsAndChildren()
        {
            Assert.IsTrue(LoginPage.IsDisplayed, "Login page wasn't displayed in 40 seconds");

            LoginPage.LoginAs("venkatay").WithPassword("password").Login();

            Assert.IsTrue(HomePage.IsDisplayed, "Failed to Login.");

            HomePage.SearchDestination("Mallorca (Majorca), Spain")
                .FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate(5))
                .ForAdults(2).WithChildren(2).OfAges(11, 12).Search();

            Assert.That(AccommodationResultsPage.IsDisplayed, Is.True, "Accommodation results page wasn't available in 40 seconds");

            Assert.That(AccommodationResultsPage.AreResultsDisplayed, Is.True, "No results are available for the accommodation search");

            AccommodationResultsPage.ClickHotelNumber(AccommodationResultPageRnd.PickRandomHotel());

            Assert.That(EstablishmentPage.IsDisplayed, Is.True, "Establishment page wasn't available in 40 seconds");

            EstablishmentPage.RoomSelection().ForRoom(1).SelectRoomNumber(1).Continue();

            Assert.That(PaymentPage.IsDisplayed, Is.True, "Payment page wasn't available in 40 seconds");

        }

        [Test]
        [Category("SmokeTest")]
        public void Can_SearchAndBook_MultiRoom_Child_Destination_Costa_Adeje_Tenerife_AdultsChildrenAndInfant()
        {
            Assert.IsTrue(LoginPage.IsDisplayed, "Login page wasn't displayed in 40 seconds");

            LoginPage.LoginAs("venkatay").WithPassword("password").Login();

            Assert.IsTrue(HomePage.IsDisplayed, "Failed to Login.");

            HomePage.SearchDestination("Costa Adeje, Tenerife, Canaries")
                .FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate(10))
                .ForAdults(2).AddAnotherRoom().ForAdults(2).WithChildren(3).OfAges(0,11,12).Search();

            Assert.That(AccommodationResultsPage.IsDisplayed, Is.True, "Accommodation results page wasn't available in 40 seconds");

            Assert.That(AccommodationResultsPage.AreResultsDisplayed, Is.True, "No results are available for the accommodation search");

            AccommodationResultsPage.ClickHotelNumber(AccommodationResultPageRnd.PickRandomHotel());

            Assert.That(EstablishmentPage.IsDisplayed, Is.True, "Establishment page wasn't available in 40 seconds");

            EstablishmentPage.RoomSelection().ForRoom(1).SelectRoomNumber(1).ForRoom(2).SelectRoomNumber(1).Continue();

            Assert.That(PaymentPage.IsDisplayed, Is.True, "Payment page wasn't available in 40 seconds");
        }

        [Test]
        [Category("SmokeTest")]
        public void Can_SearchAndBook_MultiRoom_Parent_Destination_Tenerife_AdultsChildrenAndInfant()
        {
            Assert.IsTrue(LoginPage.IsDisplayed, "Login page wasn't displayed in 40 seconds");

            LoginPage.LoginAs("venkatay").WithPassword("password").Login();

            Assert.IsTrue(HomePage.IsDisplayed, "Failed to Login.");

            HomePage.SearchDestination("Tenerife, Canaries")
                .FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
                .ForAdults(2).AddAnotherRoom().ForAdults(2).WithChildren(3).OfAges(0, 11, 12).Search();

            Assert.That(AccommodationResultsPage.IsDisplayed, Is.True, "Accommodation results page wasn't available in 40 seconds");

            Assert.That(AccommodationResultsPage.AreResultsDisplayed, Is.True, "No results are available for the accommodation search");

            AccommodationResultsPage.ClickHotelNumber(AccommodationResultPageRnd.PickRandomHotel());

            Assert.That(EstablishmentPage.IsDisplayed, Is.True, "Establishment page wasn't available in 40 seconds");

            EstablishmentPage.RoomSelection().ForRoom(1).SelectRoomNumber(1).ForRoom(2).SelectRoomNumber(1).Continue();

            Assert.That(PaymentPage.IsDisplayed, Is.True, "Payment page wasn't available in 40 seconds");
        }

        [Test]
        [Category("SmokeTest")]
        public void Can_SearchAndBook_SingleRoom_Hotel_Hotel_Medano_Tenerife_AdultsChildrenAndInfant()
        {
            Assert.IsTrue(LoginPage.IsDisplayed, "Login page wasn't displayed in 40 seconds");

            LoginPage.LoginAs("venkatay").WithPassword("password").Login();

            Assert.IsTrue(HomePage.IsDisplayed, "Failed to Login.");

            HomePage.SearchHotel("Hotel Medano, El Medano, Tenerife")
                .FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
                .ForAdults(2).WithChildren(3).OfAges(0, 11, 15).Search();

            Assert.That(EstablishmentPage.IsDisplayed, Is.True, "Establishment page wasn't available in 40 seconds");

            EstablishmentPage.RoomSelection().ForRoom(1).SelectRoomNumber(1).Continue();

            Assert.That(PaymentPage.IsDisplayed, Is.True, "Payment page wasn't available in 40 seconds");
        }

        [Test]
        [Category("SmokeTest")]
        public void Can_SearchAndBook_SingleRoom_Hotel_Eden_Resort_Algarve_AdultsChildrenAndInfant()
        {
            Assert.IsTrue(LoginPage.IsDisplayed, "Login page wasn't displayed in 40 seconds");

            LoginPage.LoginAs("venkatay").WithPassword("password").Login();

            Assert.IsTrue(HomePage.IsDisplayed, "Failed to Login.");

            HomePage.SearchHotel("Eden Resort, Albufeira, Algarve")
                .FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
                .ForAdults(2).WithChildren(3).OfAges(0, 11, 15).Search();

            Assert.That(EstablishmentPage.IsDisplayed, Is.True, "Establishment page wasn't available in 40 seconds");

            EstablishmentPage.RoomSelection().ForRoom(1).SelectRoomNumber(1).Continue();

            Assert.That(PaymentPage.IsDisplayed, Is.True, "Payment page wasn't available in 40 seconds");
        }

        [Test]
        [Category("SmokeTest")]
        public void Can_SearchAndBook_MultiRoom_Hotel_LaEstacion_Benidorm_AdultsChildrenAndInfant()
        {
            Assert.IsTrue(LoginPage.IsDisplayed, "Login page wasn't displayed in 40 seconds");

            LoginPage.LoginAs("venkatay").WithPassword("password").Login();

            Assert.IsTrue(HomePage.IsDisplayed, "Failed to Login.");

            HomePage.SearchHotel("Hotel La Estacion, Benidorm")
                .FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
                .ForAdults(2).WithChildren(2).OfAges(0, 2)
                .AddAnotherRoom().ForAdults(2).WithChildren(2).OfAges(11,17).Search();         

            Assert.That(EstablishmentPage.IsDisplayed, Is.True, "Establishment page wasn't available in 40 seconds");

            EstablishmentPage.RoomSelection().ForRoom(1).SelectRoomNumber(1).ForRoom(2).SelectRoomNumber(1).Continue();

            Assert.That(PaymentPage.IsDisplayed, Is.True, "Payment page wasn't available in 40 seconds");
        }

        [Test]
        [Category("SmokeTest")]
        public void Can_Navigateto_ManageBookings()
        {
            Assert.IsTrue(LoginPage.IsDisplayed, "Login page wasn't displayed in 40 seconds");

            LoginPage.LoginAs("venkatay").WithPassword("password").Login();

            Assert.IsTrue(HomePage.IsDisplayed, "Failed to Login.");

            PageHeader.UserMenu.ManageBookings.Select();

            Assert.That(ManageBookingsPage.IsDisplayed, Is.True, "Manage booking page wasn't available in 40 seconds");
        }

        [Test]
        [Category("SmokeTest")]
        public void Can_Navigatefrom_ManageBookings_toSearchAndBookSite()
        {
            Assert.IsTrue(LoginPage.IsDisplayed, "Login page wasn't displayed in 40 seconds");

            LoginPage.LoginAs("venkatay").WithPassword("password").Login();

            Assert.IsTrue(HomePage.IsDisplayed, "Failed to Login.");

            PageHeader.UserMenu.ManageBookings.Select();

            Assert.That(ManageBookingsPage.IsDisplayed, Is.True, "Manage booking page wasn't available in 40 seconds");

            PageHeader.UserMenu.SearchAndBookSite.Select();

            Assert.IsTrue(HomePage.IsDisplayed, "Failed to return to search and book site from manage booking page");
        }
    }
}
