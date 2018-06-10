using Kaizen.Server.Service.Interface.Models;

namespace Kaizen.Server.Service.Interface.Excpetions
{
    public class InvalidPageSizeException : KaizenApiException
    {
        public InvalidPageSizeException()
            : base($"Page Size must be in range 1 and 100")
        {
        }
    }
}