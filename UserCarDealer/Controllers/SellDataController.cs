using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        //api/GET/{vehicle:id}
        [HttpGet("{IdOrVin}")]
        public async Task<ActionResult> GetSellDataByVehicleIdOrVin([FromServices] IMediator _sender, string IdOrVin)
        {
            var resultGetSellDataByVehicleIdOrVin =
                await _sender.Send(new GetSellDataByVehicleIdOrVinQuery() { IdOrVin = IdOrVin });
            if (resultGetSellDataByVehicleIdOrVin != null)
            {
                return Ok(resultGetSellDataByVehicleIdOrVin);
            }
            else
            {
                return NotFound("Check input");
            }
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