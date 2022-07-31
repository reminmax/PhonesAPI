using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonesAPI.Helpers
{
    public static class ReleasedMonthsAgo
    {
        public static int GetMonthsAgo(this DateTime dateTime)
        {
            var currentDate = DateTime.Now;
            int monthsAgo = ((currentDate.Year - dateTime.Year) * 12) + currentDate.Month - dateTime.Month;

            return monthsAgo;
        }
    }
}
