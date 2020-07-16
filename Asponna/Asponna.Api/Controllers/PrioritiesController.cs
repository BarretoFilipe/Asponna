using Asponna.Application.Queries.Priorities.GetAll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asponna.Api.Controllers
{
    public class PrioritiesController : BaseController
    {
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PriorityListViewModel>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllPriorityQuery()));
        }
    }
}