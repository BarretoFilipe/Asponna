using Asponna.Application.Queries.Cards.Get;
using Asponna.Domain.Entities;
using Asponna.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asponna.Application.Commands.Cards.CreateCard
{
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, CardViewModel>
    {
        private readonly ICardRepository _cardRepository;

        public CreateCardCommandHandler(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<CardViewModel> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            var card = new Card
                (
                    request.Title,
                    request.Description,
                    request.TaskBoardId,
                    request.PriorityId
                );

            _cardRepository.Create(card);

            await _cardRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            var viewModel = new CardViewModel
            {
                Id = card.Id,
                Title = card.Title,
                Description = card.Description,
                Completed = card.Completed,
                TaskBoardId = card.TaskBoardId,
                PriorityId = card.PriorityId
            };

            return viewModel;
        }
    }
}