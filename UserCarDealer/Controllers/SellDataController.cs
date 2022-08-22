using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserCarDealer.Handlers.SellDataHandlers.Dto;
using UserCarDealer.Queries.SellDataQueries;
using UserCarDealer.Command.SellDataCommand;

namespace UserCarDealer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellDataController : ControllerBase
    {
        //api/GET
        [HttpGet]
        public async Task<ActionResult> GetSellData([FromServices] IMediator _sender)
        {
            var resultGetSellData = await _sender.Send(new GetSellDataQuery());
            return Ok(resultGetSellData);
        }

        //api/POST
        [HttpPost]
        public async Task<ActionResult> PostSellData([FromBody] PostSellDataDto postSellDataDto,
            [FromServices] IMediator _sender)
        {
            var resultSellDataPost =
                await _sender.Send(new PostSellDataCommand() { PostSellDataDto = postSellDataDto });
            return Ok(resultSellDataPost);
        }
    }
}