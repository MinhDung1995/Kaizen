using Kaizen.Server.Service.Interface.Models;

namespace Kaizen.Server.Service.Interface.Excpetions
{
    public class PageNumberNotFoundException : KaizenApiException
    {
        public PageNumberNotFoundException(string pageNumber)
            : base($"Page Number {pageNumber} was not found.")
        {
        }

        public PageNumberNotFoundException(PaginationModel pagination)
            : this(pagination.PageNumber.ToString())
        {
        }
    }
}