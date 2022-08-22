using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserCarDealer.Command.VehicleCommand;
using UserCarDealer.Handlers.VehicleHandlers.Dto;
using UserCarDealer.Queries.VehicleQueries;

namespace UserCarDealer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        //api/GET
        [HttpGet]
        public async Task<ActionResult> GetVehicle([FromServices] IMediator _sender)
        {
            var resultGetVehicle = await _sender.Send(new GetVehicleQuery());
            return Ok(resultGetVehicle);
        }

        //api/GET/{vin}
        [HttpGet("{vinOrId}")]
        public async Task<ActionResult> GetVehicleById([FromServices] IMediator _sender, string vinOrId)
        {
            var resultGetVehicleById = await _sender.Send(new GetVehicleByIdQuery() { vinOrId = vinOrId });
            if (resultGetVehicleById != null)
            {
                return Ok(resultGetVehicleById);
            }
            else
            {
                return NotFound("Vehicle not found. Check vin");
            }
        }

        //api/POST
        [HttpPost]
        public async Task<ActionResult> PostVehicle([FromBody] PostVehicleDto postVehicleDto,
            [FromServices] IMediator _sender)
        {
            var resultPostVehicle = await _sender.Send(new PostVehicleCommand() { PostVehicleDto = postVehicleDto });
            if (resultPostVehicle != 0)
            {
                return Ok("Vehicle added witch Id = " + resultPostVehicle);
            }
            else
            {
                return NotFound("Vehicle with same vin is already exist");
            }
        }
    }
}