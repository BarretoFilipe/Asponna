using Asponna.Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asponna.Application.Queries.Cards.GetAll
{
    public class GetAllCardQueryHandler : IRequestHandler<GetAllCardQuery, List<CardListViewModel>>
    {
        private readonly ICardRepository _cardRepository;

        public GetAllCardQueryHandler(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<List<CardListViewModel>> Handle(GetAllCardQuery request, CancellationToken cancellationToken)
        {
            var cards = await _cardRepository.GetAllAsync(request.CardParameter);

            var cardsListViewModel = cards.Select(card => new CardListViewModel
            {
                Id = card.Id,
                Title = card.Title,
                Description = card.Description,
                Completed = card.Completed,
                Position = card.Position,
                TaskBoardId = card.TaskBoardId,
                PriorityId = card.PriorityId
            }).ToList();

            return cardsListViewModel;
        }
    }
}