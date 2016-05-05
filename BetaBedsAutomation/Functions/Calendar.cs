using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetaBedsAutomation
{
    public class Calendar
    {
        private static string lastCheckInDate;
        internal static Random random = new Random();

        internal static string FormatMonthYear(string date)
        {
            return DateTime.Parse(date).ToString("MMMM yyyy");
        }

        internal static string FormatDate(string date)
        {
            return DateTime.Parse(date).ToString("dd MMM yyyy");
        } 

        public static string PickRandomCheckInDate()
        {
            DateTime StartDate = DateTime.Now.AddMonths(4);
            DateTime EndDate = DateTime.Now.AddMonths(7);
            int range = (EndDate - StartDate).Days;
            DateTime rDate = StartDate.AddDays(random.Next(range));
            lastCheckInDate = rDate.ToShortDateString();
            return lastCheckInDate;
        }

        public static string PickRandomCheckOutDate(int upperlimit=0)
        {
            DateTime StartDate = Convert.ToDateTime(lastCheckInDate);//.AddDays(1);
            if (upperlimit != 0)
            {
                DateTime EndDate = StartDate.AddDays(upperlimit);
                return EndDate.ToShortDateString();
            }
            else
            {
                DateTime EndDate = StartDate.AddDays(random.Next(5, 9));
                return EndDate.ToShortDateString();
            }
        }
    }
}
