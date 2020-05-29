using Asponna.Application.Commons;
using GraphQL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asponna.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskBoardController : ControllerBase
    {
        private readonly AsponnaSchema _asponnaSchema;

        public TaskBoardController(AsponnaSchema asponnaSchema)
        {
            _asponnaSchema = asponnaSchema;
        }

        [HttpPost]
        public async Task<IActionResult> GetAll([FromBody]GraphQLQuery query)
        {
           var inputs = query.Variables.ToInputs();

            var result = await new DocumentExecuter().ExecuteAsync(exec =>
            {
                exec.Schema = _asponnaSchema;
                exec.Query = query.Query;
                exec.OperationName = query.OperationName;
                exec.Inputs = inputs;
            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}