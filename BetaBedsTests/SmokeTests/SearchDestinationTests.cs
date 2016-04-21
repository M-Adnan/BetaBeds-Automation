using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BetaBedsAutomation;

namespace BetaBedsTests
{
    [TestClass]
    public class SearchDestinationTests : BaseTestClass
    {
        [TestMethod]
        public void Can_Search_Destination()
        {
            HomePage.SearchDestination("Benidorm, Spain").FromCheckInDate(Calendar.PickRandomCheckInDate()).ToCheckOutDate(Calendar.PickRandomCheckOutDate())
                .ForAdults(4).WithChildren(1).OfAges(0).AddAnotherRoom().ForAdults(3).WithChildren(2).OfAges(11,17).Search();
        }
    }
}
