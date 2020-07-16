using Asponna.Application.Commands.TaskBoards.CreateTaskBoard;
using Asponna.Application.Commands.TaskBoards.DeleteTaskBoard;
using Asponna.Application.Commands.TaskBoards.UpdateTaskBoard;
using Asponna.Application.Queries.Cards.GetAll;
using Asponna.Application.Queries.TaskBoards.Get;
using Asponna.Application.Queries.TaskBoards.GetAll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asponna.Api.Controllers
{
    public class TaskBoardsController : BaseController
    {
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TaskBoardListViewModel>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllTaskBoardQuery()));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TaskBoardViewModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetTaskBoardQuery { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateTaskBoardCommand taskBoardCommand)
        {
            var taskBoard = await Mediator.Send(taskBoardCommand);

            return Ok(taskBoard);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Update([FromBody] UpdateTaskBoardCommand taskBoardCommand)
        {
            var taskBoard = await Mediator.Send(taskBoardCommand);

            return Ok(taskBoard);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTaskBoardCommand { Id = id });

            return NoContent();
        }
    }
}