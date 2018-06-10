using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaizen.Server.Service.Interface.Excpetions;
using Kaizen.Server.Service.Interface.Models;
using Kaizen.Server.Service.Interface.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kaizen.Server.WebApi.Controllers
{
    [Route("api/v1/chinese-chess")]
    [ApiController]
    public class ChineseChessController : ControllerBase
    {
        private readonly IChineseChessService _chineseChessService;

        public ChineseChessController(IChineseChessService chineseChessService)
        {
            _chineseChessService = chineseChessService;
        }

        #region OnlineMatch

        // GET api/chinese-chess
        [HttpGet]
        [Route("online-matchs")]
        [ProducesResponseType(typeof(IEnumerable<ChineseChessOnlineMatchModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOnlineMatchs([FromQuery] PaginationModel pagination)
        {
            try
            {
                IEnumerable<ChineseChessOnlineMatchModel> models = await _chineseChessService.GetOnlineMatchs(pagination);
                return Ok(models);
            }
            catch (PageNumberNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidPageSizeException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/chinese-chess
        [HttpGet]
        [Route("online-matchs")]
        [ProducesResponseType(typeof(IEnumerable<ChineseChessOnlineMatchModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOnlineMatchsByPeriod([FromQuery] PeriodModel period)
        {
            try
            {
                IEnumerable<ChineseChessOnlineMatchModel> models = await _chineseChessService.GetOnlineMatchsByPeriod(period);
                return Ok(models);
            }
            catch (PeriodNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidPeriodException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        #endregion;
        
    }
}