using System.Collections.Generic;
using System.Threading.Tasks;
using Asani_Task0.Application.Estates;
using Asani_Task0.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Asani_Task0.Controllers
{
    [Route("api/estates")]
    [ApiController]
    public class EstateController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EstateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Estate>>> List()
        {
            return await _mediator.Send(new List.Query());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estate>> Find(int id)
        {

            return await _mediator.Send(new Details.Query { Id = id });
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            return await _mediator.Send(new Delete.Command { Id = id });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, Edit.Command command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }

    }
}