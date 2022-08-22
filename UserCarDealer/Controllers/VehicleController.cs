using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("{vin}")]
        public async Task<ActionResult> GetVehicleById([FromServices] IMediator _sender, string vin)
        {
            var resultGetVehicleById = await _sender.Send(new GetVehicleByIdQuery() { vin = vin });
            if (resultGetVehicleById != null)
            {
                return Ok(resultGetVehicleById);
            }
            else
            {
                return NotFound("Vehicle not found. Check vin");
            }
        }
    }
}