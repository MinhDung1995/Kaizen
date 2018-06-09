using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // GET api/chinese-chess
        [HttpGet]
        [Route("online-matchs")]
        [ProducesResponseType(typeof(IEnumerable<ChineseChessOnlineMatchModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<ChineseChessOnlineMatchModel> models = await _chineseChessService.GetAll();
            return Ok(models);
        }
    }
}