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
    }
}