using Asponna.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asponna.Application.Queries.Cards.Get
{
    public class GetCardQueryHandler : IRequestHandler<GetCardQuery, CardViewModel>
    {
        private readonly ICardRepository _cardRepository;

        public GetCardQueryHandler(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<CardViewModel> Handle(GetCardQuery request, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.GetAsync(request.Id);

            if (card == null)
                return new CardViewModel();

            var cardViewModel = new CardViewModel
            {
                Id = card.Id,
                Title = card.Title,
                Description = card.Description,
                Completed = card.Completed,
                TaskBoardId = card.TaskBoardId,
                PriorityId = card.PriorityId
            };

            return cardViewModel;
        }
    }
}