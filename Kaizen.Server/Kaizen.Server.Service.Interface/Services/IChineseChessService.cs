using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kaizen.Server.Service.Interface.Models;

namespace Kaizen.Server.Service.Interface.Services
{
    public interface IChineseChessService
    {
        Task<IEnumerable<ChineseChessOnlineMatchModel>> GetAll();
    }
}
