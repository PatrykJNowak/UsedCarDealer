using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserCarDealer.Command.CustomerCommand;
using UserCarDealer.Handlers.CustomerHandlers.Dto;
using UserCarDealer.Queries;
using UserCarDealer.Queries.CustomerQueries;

namespace UserCarDealer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //api/GET
        [HttpGet]
        public async Task<ActionResult> GetCustomer([FromServices] IMediator _sender)
        {
            var resultsGetCustomer = await _sender.Send(new GetCustomerQuery());
            return Ok(resultsGetCustomer);
        }

        //api/GET/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCustomerById([FromServices] IMediator _sender, int id)
        {
            var resultGetCustomerById = await _sender.Send(new GetCustomerByIdQuery() { Id = id });
            if (resultGetCustomerById != null)
            {
                return Ok(resultGetCustomerById);
            }
            else
            {
                return NotFound("Custumer not found. Check customer Id");
            }
        }

        //api/POST
        [HttpPost]
        public async Task<ActionResult> PostCustomer([FromBody] PostCustomerDto postCustomerDto,
            [FromServices] IMediator _sender)
        {
            var restulPostCustomer =
                await _sender.Send(new PostCustomerCommand() { PostCustomerDto = postCustomerDto });
            if (restulPostCustomer != 0)
            {
                return Ok("User added. Id = " + restulPostCustomer);
            }
            else
            {
                return NotFound("User witch same PersonalId is in database.");
            }
        }

        //api/PUT
        [HttpPut]
        public async Task<ActionResult> PutCustomer([FromBody] PutCustomerDto putCustomerDto,
            [FromServices] IMediator _sender)
        {
            var resultPutCustomer = await _sender.Send(new PutCustomerCommand() { PutCustomerDto = putCustomerDto });
            if (resultPutCustomer == 1)
            {
                return Ok("Customer updated");
            }
            else
            {
                return NotFound("User not found. Check PersonalId");
            }
        }

        //api/DELETE/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DelCustomer([FromServices] IMediator _sender, int id)
        {
            var resultDelCustomer = await _sender.Send(new DelCustomerCommand());
            return Ok("Done");
        }
    }
}