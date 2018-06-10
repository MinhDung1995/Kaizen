using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kaizen.Server.Entity;
using Kaizen.Server.Repository.Interface;
using Kaizen.Server.Service.Interface.Models;
using Kaizen.Server.Service.Interface.Services;

namespace Kaizen.Server.Service
{
    public class ChineseChessService : IChineseChessService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChineseChessService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<ChineseChessOnlineMatchModel>> GetAll()
        {
            return await _unitOfWork.Repository<ChineseChessOnlineMatch>().Get()
                .Select(m => new ChineseChessOnlineMatchModel()).ToListAsync();
        }
    }
}
