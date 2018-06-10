using System;

namespace Kaizen.Server.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsEarlierDateThanOrSameDateAs(this DateTime value, DateTime? date)
        {
            return !date.HasValue || value.Date.CompareTo(date.Value.Date) >= 0;
        }

        public static bool IsLaterDateThanOrSameDateAs(this DateTime value, DateTime? date)
        {
            return !date.HasValue || value.Date.CompareTo(date.Value.Date) <= 0;
        }
    }
}