using Kaizen.Server.Service.Interface.Models;

namespace Kaizen.Server.Service.Interface.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsPeriodNull(PeriodModel period)
        {
            return !period.Start.HasValue && !period.End.HasValue;
        }

        public static bool IsPeriodInvalid(PeriodModel period)
        {
            if (period.Start.HasValue && period.End.HasValue)
            {
                return period.Start.Value.CompareTo(period.End.Value) > 0;
            }

            return false;
        }
    }
}