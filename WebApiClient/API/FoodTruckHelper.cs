using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiClient.API
{
	public static class FoodTruckHelper
	{
		public static int StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
		{
			return (7 + (dt.DayOfWeek - startOfWeek)) % 7;
		}

        public static bool UnixTimeStampToDateTime(string unixTimeStamp, out DateTime utcDate)
        {
            if (double.TryParse(unixTimeStamp, out double timeStamp))
            {
                // Unix timestamp is seconds
                DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                utcDate = dtDateTime.AddSeconds(timeStamp);
                return true;
            }

            utcDate = DateTime.UtcNow;
            return false;
        }
    }
}
