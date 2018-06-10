using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kaizen.Server.Entity;
using Kaizen.Server.Common.Extensions;
using Kaizen.Server.Repository.Interface;
using Kaizen.Server.Service.Interface.Models;
using Kaizen.Server.Service.Interface.Services;
using Kaizen.Server.Service.Interface.Excpetions;
using Kaizen.Server.Service.Interface.Helpers;

namespace Kaizen.Server.Service
{
    public class ChineseChessService : IChineseChessService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChineseChessService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<ChineseChessOnlineMatchModel>> GetOnlineMatchs(PaginationModel pagination)
        {
            if (pagination.PageSize < 1)
            {
                throw new InvalidPageSizeException();
            }

            long totalCount = _unitOfWork.Repository<ChineseChessOnlineMatch>().Get().Count();
            long totalPages = totalCount / pagination.PageSize + (totalCount % pagination.PageSize);
            if (pagination.PageNumber < 1 || pagination.PageNumber > totalPages)
            {
                throw new PageNumberNotFoundException(pagination);
            }

            return await _unitOfWork.Repository<ChineseChessOnlineMatch>()
                .Get()
                .OrderByDescending(m => m.Date)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Select(m => new ChineseChessOnlineMatchModel())
                .ToListAsync();
        }

        public async Task<IEnumerable<ChineseChessOnlineMatchModel>> GetOnlineMatchsByPeriod(PeriodModel period)
        {
            if (ValidationHelper.IsPeriodNull(period))
            {
                throw new PeriodNullException();
            }

            if (ValidationHelper.IsPeriodInvalid(period))
            {
                throw new InvalidPeriodException();
            }

            return await _unitOfWork.Repository<ChineseChessOnlineMatch>()
                .Get(m => m.Date.IsEarlierDateThanOrSameDateAs(period.Start)
                        && m.Date.IsLaterDateThanOrSameDateAs(period.End))
                .Select(m => new ChineseChessOnlineMatchModel())
                .ToListAsync();
        }
    }
}
