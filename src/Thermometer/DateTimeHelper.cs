using System;
using System.Threading.Tasks;
using Thermometer.GitHub;
using Thermometer.Netatmo;

namespace Thermometer
{

    public static class DateTimeHelper
    {
        public static DateTime TimeStampToLocalDateTime(int timeStamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timeStamp).ToLocalTime();
        }

        public static int UtcDateTimeToTimeStamp(DateTime utcDateTime)
        {
            return (int)Math.Round(utcDateTime.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
        }
    }
}
