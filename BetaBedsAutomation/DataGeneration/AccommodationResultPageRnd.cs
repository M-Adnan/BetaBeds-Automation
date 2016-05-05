using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetaBedsAutomation
{
    public class AccommodationResultPageRnd
    {
        public static int PickRandomHotel()
        {
            int totalHotelResults = AccommodationResultsPage.GetAccommodationResultsPanel().Count;
            int randHotel = PickRandomHotelNo(totalHotelResults);
            return randHotel;
        }

        private static int PickRandomHotelNo(int totalHotelResults)
        {
            if (totalHotelResults > 0)
            {
                int HotelNo = Driver.PickRandomNumber(1, totalHotelResults);
                return HotelNo;
            }
            else
            { 
                throw new Exception("No search results available"); 
            }
                
        }
    }
}
