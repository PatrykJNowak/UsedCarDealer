using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserCarDealer.Queries.SellDataQueries;

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


    }
}