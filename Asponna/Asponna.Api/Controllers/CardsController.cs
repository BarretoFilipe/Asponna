using Asponna.Application.Commands.Cards.CreateCard;
using Asponna.Application.Commands.Cards.DeleteCard;
using Asponna.Application.Commands.Cards.UpdateCard;
using Asponna.Application.Queries.Cards.Get;
using Asponna.Application.Queries.Cards.GetAll;
using Asponna.Domain.Repositories.Parameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asponna.Api.Controllers
{
    public class CardsController : BaseController
    {
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CardListViewModel>>> GetAll([FromQuery] CardParameter cardParameter)
        {
            return Ok(await Mediator.Send(new GetAllCardQuery(cardParameter)));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CardViewModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetCardQuery { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateCardCommand cardCommand)
        {
            var card = await Mediator.Send(cardCommand);

            return Ok(card);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Update([FromBody] UpdateCardCommand cardCommand)
        {
            var card = await Mediator.Send(cardCommand);

            return Ok(card);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCardCommand { Id = id });

            return NoContent();
        }
    }
}