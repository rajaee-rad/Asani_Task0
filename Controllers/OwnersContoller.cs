using MediatR;
using Microsoft.AspNetCore.Mvc;
using Asani_Task0.Application.Owners;
using Asani_Task0.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Asani_Task0.Controllers
{
    [ApiController]
    [Route("api/owners")]
    public class OwnersContoller : ControllerBase
    {
        private readonly IMediator _mediator;
        public OwnersContoller(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Owner>>> List()
        {
            return await _mediator.Send(new List.Query());
        }

        
    }
}