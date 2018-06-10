namespace Kaizen.Server.Service.Interface.Excpetions
{
    public class InvalidPeriodException : KaizenApiException
    {
        public InvalidPeriodException() 
            : base("Period's start must be earlier than its end")
        {
        }
    }
}