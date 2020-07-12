using Asponna.Application.Commands.Cards.CreateCard;
using Asponna.Domain.Entities;
using Asponna.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asponna.Application.Commands.Cards.UpdateCard
{
    public class UpdateCardCommandHandler : IRequestHandler<UpdateCardCommand, Card>
    {
        private readonly ICardRepository _cardRepository;

        public UpdateCardCommandHandler(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<Card> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.GetAsync(request.Id);

            card.SetTitle(request.Title);
            card.SetDescription(request.Description);
            card.SetCompleted(request.Completed);
            card.SetTaskBoardId(request.TaskBoardId);

            _cardRepository.Update(card);

            await _cardRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return card;
        }
    }
}