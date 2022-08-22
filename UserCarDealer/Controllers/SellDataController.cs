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

        //api/GET/{vehicle:IdOrVin}
        [HttpGet("IdOrVin/{IdOrVin}")]
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

        //api/GET/{customer:id}
        [HttpGet("Id/{Id}")]
        public async Task<ActionResult> GetSellDataByCustomerId([FromServices] IMediator _sender, int Id)
        {
            var resultGetSellDataByCustomerId =
                await _sender.Send(new GetSellDataByCustomerIdQuery() { Id = Id });
            if (resultGetSellDataByCustomerId.Count() != 0)
            {
                return Ok(resultGetSellDataByCustomerId);
            }
            else
            {
                return NotFound("Check customer id");
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

        //api/PUT
        [HttpPut]
        public async Task<ActionResult> PutSellData([FromBody] PutSellDataDto putSellDataDto,
            [FromServices] IMediator _sender)
        {
            var resultPutSellData = await _sender.Send(new PutSellDataCommand() { PutSellDataDto = putSellDataDto });
            if (resultPutSellData != 0)
            {
                return Ok("Done");
            }
            else
            {
                return NotFound("Vehicle not found. Check vin");
            }
        }


        //api/DELETE
        [HttpDelete("DelId/{Id}")]
        public async Task<ActionResult> DelSellData([FromServices] IMediator _sender, int Id)
        {
            var resultDelSellData = await _sender.Send(new DelSellDataCommand() { Id = Id });
            if (resultDelSellData == 1)
            {
                return Ok("Done");
            }
            else
            {
                return NotFound("Check id");
            }
        }
    }
}