using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kaizen.Server.Service.Interface.Models;

namespace Kaizen.Server.Service.Interface.Services
{
    public interface IChineseChessService
    {
        Task<IEnumerable<ChineseChessOnlineMatchModel>> GetOnlineMatchs(PaginationModel pagination);

        Task<IEnumerable<ChineseChessOnlineMatchModel>> GetOnlineMatchsByPeriod(PeriodModel period);
    }
}
