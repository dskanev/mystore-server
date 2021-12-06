using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsOlderThanNumberOfDays(this long ticks, int numberOfDays)
        {
            if (ticks == default)
            {
                return true;
            }

            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            var dbDate = dtDateTime.AddMilliseconds(ticks).ToLocalTime();
            return dbDate.AddDays(numberOfDays) < DateTime.Now;
        }
    }
}
