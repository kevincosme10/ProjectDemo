using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectDemo.Api.Core.Aplication.Features.Commands.Clients.CreateClient;
using ProjectDemo.Api.Core.Aplication.Features.Commands.Clients.DeleteClient;
using ProjectDemo.Api.Core.Aplication.Features.Commands.Clients.Update;
using ProjectDemo.Api.Core.Aplication.Features.Queries.Clients.GetAllClients;
using ProjectDemo.Api.Core.Aplication.Features.Queries.Clients.GetClientsByCountry;
using ProjectDemo.Api.Core.Aplication.Features.Queries.Clients.GetClientsByCountry.DTOs;
using System.Data;
using System.Net;

namespace ProjectDemo.Api.Controllers.v1
{
  
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly IMediator _mediator;

        public ClientsController(ILogger<ClientsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateClient")]
        [ProducesResponseType((int)StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientCommand command)
        {
            var response = await _mediator.Send(command);
          

            return Created("CreateClient", response);
        }

        [HttpDelete("{id}", Name = "DeleteClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteClient(int id)
        {
            var command = new DeleteClientCommand
            {
                Id = id
            };

            var response= await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut("{id}",Name = "UpdateClient")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateClient(int id,[FromBody] UpdateClientCommand command)
        {
            command.SetId(id);
           
            return Ok(await _mediator.Send(command));
         
        }

        [HttpGet("{country}", Name = "GetClientsByCountry")]
        [ProducesResponseType(typeof(List<ClientDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<ClientDto>>> GetClientsByCountry(string country)
        {
            var query = new GetClientsByCountryQuery(country);
            var clients = await _mediator.Send(query);
            return Ok(clients);
        }

        [HttpGet( Name = "GetAllClients")]
        [ProducesResponseType(typeof(List<ClientDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<ClientDto>>> GetAllClients()
        {
            var query = new GetAllClientsQuery();
            var clients = await _mediator.Send(query);
            return Ok(clients);
        }







    }

}
