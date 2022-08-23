using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
        public async Task<ActionResult> GetCustomer([FromServices] IMediator sender)
        {
            var resultsGetCustomer = await sender.Send(new GetCustomerQuery());
            return Ok(resultsGetCustomer);
        }

        //api/GET/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCustomerById([FromServices] IMediator sender, int id)
        {
            var resultGetCustomerById = await sender.Send(new GetCustomerByIdQuery() { Id = id });
            if (resultGetCustomerById != null)
            {
                return Ok(resultGetCustomerById);
            }
            else
            {
                return NotFound("Customer not found. Check customer Id");
            }
        }

        //api/POST
        [HttpPost]
        public async Task<ActionResult> PostCustomer([FromBody] PostCustomerDto postCustomerDto,
            [FromServices] IMediator sender)
        {
            var restulPostCustomer =
                await sender.Send(new PostCustomerCommand() { PostCustomerDto = postCustomerDto });
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
            [FromServices] IMediator sender)
        {
            var resultPutCustomer = await sender.Send(new PutCustomerCommand() { PutCustomerDto = putCustomerDto });
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
        [HttpDelete("{personalId}")]
        public async Task<ActionResult<int>> DelCustomer([FromServices] IMediator sender, string personalId)
        {
            var resultDelCustomer = await sender.Send(new DelCustomerCommand() { PersonalId = personalId });
            if (resultDelCustomer)
            {
                return Ok("Done");
            }
            else
            {
                return NotFound("Check input");
            }
        }
    }
}