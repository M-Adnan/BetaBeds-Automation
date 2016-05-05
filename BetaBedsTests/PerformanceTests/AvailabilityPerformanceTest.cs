//using System;
//using NUnit.Framework;
//using BetaBedsAutomation;


//namespace BetaBedsTests.PerformanceTests
//{
//    [TestFixture]
//    [Parallelizable]
//    public class AvailabilityPerformanceTests : BaseTestClass
//    {
//        [Test]
//        public void Can_Search_Destination_Benidorm()
//        {
//            HomePage.SearchDestination("Benidorm, Spain").FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
//                .ForAdults(4).WithChildren(1).OfAges(0).AddAnotherRoom().ForAdults(3).WithChildren(2).OfAges(11, 17).Search();
//        }

//        [Test]
//        public void Can_Search_Destination_Alicante()
//        {
//            HomePage.SearchDestination("Alicante, Spain").FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
//                .ForAdults(4).WithChildren(1).OfAges(0).AddAnotherRoom().ForAdults(3).WithChildren(2).OfAges(11, 17).Search();
//        }

//        [Test]
//        public void Can_Search_Destination_Rome()
//        {
//            HomePage.SearchDestination("Rome, Italy").FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
//                .ForAdults(4).WithChildren(1).OfAges(0).AddAnotherRoom().ForAdults(3).WithChildren(2).OfAges(11, 17).Search();
//        }

//        [Test]
//        public void Can_Search_Destination_Algarve()
//        {
//            HomePage.SearchDestination("Algarve, Portugal").FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
//                .ForAdults(4).WithChildren(1).OfAges(0).AddAnotherRoom().ForAdults(3).WithChildren(2).OfAges(11, 17).Search();
//        }

//        [Test]
//        public void Can_Search_Destination_Lanzarote()
//        {
//            HomePage.SearchDestination("Lanzarote, Canaries").FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
//                .ForAdults(4).WithChildren(1).OfAges(0).AddAnotherRoom().ForAdults(3).WithChildren(2).OfAges(11, 17).Search();
//        }

//        [Test]
//        public void Can_Search_Destination_Mallorca()
//        {
//            HomePage.SearchDestination("Mallorca").FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
//                .ForAdults(4).WithChildren(1).OfAges(0).AddAnotherRoom().ForAdults(3).WithChildren(2).OfAges(11, 17).Search();
//        }

//        [Test]
//        public void Can_Search_Destination_GranCanaria()
//        {
//            HomePage.SearchDestination("Gran Canaria, Canaries").FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
//                .ForAdults(4).WithChildren(1).OfAges(0).AddAnotherRoom().ForAdults(3).WithChildren(2).OfAges(11, 17).Search();
//        }

//        [Test]
//        public void Can_Search_Destination_Ibiza()
//        {
//            HomePage.SearchDestination("Ibiza, Spain").FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
//                .ForAdults(4).WithChildren(1).OfAges(0).AddAnotherRoom().ForAdults(3).WithChildren(2).OfAges(11, 17).Search();
//        }

//        [Test]
//        public void Can_Search_Destination_CostaDorada()
//        {
//            HomePage.SearchDestination("Costa Dorada").FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
//                .ForAdults(4).WithChildren(1).OfAges(0).AddAnotherRoom().ForAdults(3).WithChildren(2).OfAges(11, 17).Search();
//        }

//        [Test]
//        public void Can_Search_Destination_Fuerteventura()
//        {
//            HomePage.SearchDestination("Fuerteventura, Canaries").FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
//                .ForAdults(4).WithChildren(1).OfAges(0).AddAnotherRoom().ForAdults(3).WithChildren(2).OfAges(11, 17).Search();
//        }

//        [Test]
//        public void Can_Search_Destination_Antalya()
//        {
//            HomePage.SearchDestination("Antalya, Turkey").FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
//                .ForAdults(4).WithChildren(1).OfAges(0).AddAnotherRoom().ForAdults(3).WithChildren(2).OfAges(11, 17).Search();
//        }

//        [Test]
//        public void Can_Search_Destination_CostaBrava()
//        {
//            HomePage.SearchDestination("Costa Brava, Spain").FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
//                .ForAdults(4).WithChildren(1).OfAges(0).AddAnotherRoom().ForAdults(3).WithChildren(2).OfAges(11, 17).Search();
//        }

//        [Test]
//        public void Can_Search_Destination_Crete()
//        {
//            HomePage.SearchDestination("Crete, Greece").FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
//                .ForAdults(4).WithChildren(1).OfAges(0).AddAnotherRoom().ForAdults(3).WithChildren(2).OfAges(11, 17).Search();
//        }

//        [Test]
//        public void Can_Search_Destination_CostaDeAlmeria()
//        {
//            HomePage.SearchDestination("Costa De Almeria, Spain").FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
//                .ForAdults(4).WithChildren(1).OfAges(0).AddAnotherRoom().ForAdults(3).WithChildren(2).OfAges(11, 17).Search();
//        }

//        [Test]
//        public void Can_Search_Destination_Bodrum()
//        {
//            HomePage.SearchDestination("Bodrum, Turkey").FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
//                .ForAdults(4).WithChildren(1).OfAges(0).AddAnotherRoom().ForAdults(3).WithChildren(2).OfAges(11, 17).Search();
//        }

//        [Test]
//        public void Can_Search_Destination_Dublin()
//        {
//            HomePage.SearchDestination("Dublin").FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
//                .ForAdults(4).WithChildren(1).OfAges(0).AddAnotherRoom().ForAdults(3).WithChildren(2).OfAges(11, 17).Search();
//        }

//        [Test]
//        public void Can_Search_Destination_Malta()
//        {
//            HomePage.SearchDestination("Malta").FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
//                .ForAdults(4).WithChildren(1).OfAges(0).AddAnotherRoom().ForAdults(3).WithChildren(2).OfAges(11, 17).Search();
//        }

//        [Test]
//        public void Can_Search_Destination_Marmaris()
//        {
//            HomePage.SearchDestination("Marmaris, Turkey").FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
//                .ForAdults(4).WithChildren(1).OfAges(0).AddAnotherRoom().ForAdults(3).WithChildren(2).OfAges(11, 17).Search();
//        }

//        [Test]
//        public void Can_Search_Destination_SharmElSheikh()
//        {
//            HomePage.SearchDestination("Sharm El Sheikh, Egypt").FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
//                .ForAdults(4).WithChildren(1).OfAges(0).AddAnotherRoom().ForAdults(3).WithChildren(2).OfAges(11, 17).Search();
//        }

//    }
//}
