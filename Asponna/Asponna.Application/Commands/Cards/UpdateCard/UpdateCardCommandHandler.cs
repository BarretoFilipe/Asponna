using Asponna.Application.Commands.Cards.CreateCard;
using Asponna.Application.Queries.Cards.Get;
using Asponna.Domain.Entities;
using Asponna.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asponna.Application.Commands.Cards.UpdateCard
{
    public class UpdateCardCommandHandler : IRequestHandler<UpdateCardCommand, CardViewModel>
    {
        private readonly ICardRepository _cardRepository;

        public UpdateCardCommandHandler(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<CardViewModel> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.GetAsync(request.Id);

            card.SetTitle(request.Title);
            card.SetDescription(request.Description);
            card.SetCompleted(request.Completed);
            card.SetTaskBoardId(request.TaskBoardId);
            card.SetPriorityId(request.PriorityId);

            _cardRepository.Update(card);

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