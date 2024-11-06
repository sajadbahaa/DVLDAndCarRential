using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLCPresentation.Global_Classes
{
    public class clsCalculation
    {

        static public int GetDayFromMonth(int Day, DateTime dt)
        {
            //get last day for month by adding -1 to addDays(-1)
            DateTime firstDayNextMonth = new DateTime(dt.Year, dt.Month, 1).AddMonths(1);

            // Get the last day of the current month by subtracting one day from the first day of next month
            DateTime LastDayForMonth = firstDayNextMonth.AddDays(-1);

            // Get the last day of the month as an integer
            int LastDay = LastDayForMonth.Day;

            // Return the remaining days in the month
            return LastDay - Day;
        }
        static public int GetActualDay(DateTime d1 , DateTime d2)
        {
            if (d1.Month < d2.Month)
            {
                return GetDayFromMonth(d1.Day, d1)+d2.Day;
            }
            return  d2.Day - d1.Day;
        }
         
       static public bool IsDayFarDate(int DayAcutual,int DayEnd)
        {
            return DayAcutual > DayEnd ? true : DayAcutual == DayEnd ? false : DayAcutual < DayEnd ? false : false;
        }
        
    }
}
