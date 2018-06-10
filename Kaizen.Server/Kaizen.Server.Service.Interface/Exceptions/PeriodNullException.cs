namespace Kaizen.Server.Service.Interface.Excpetions
{
    public class PeriodNullException : KaizenApiException
    {
        public PeriodNullException()
            : base("Period must have start or end is not null")
        {
        }
    }
}