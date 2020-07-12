using Asponna.Domain.Entities;
using Asponna.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asponna.Application.Commands.Cards.CreateCard
{
    public class CreateCardCommandHandler : IRequestHandler<CreateCardCommand, Card>
    {
        private readonly ICardRepository _cardRepository;

        public CreateCardCommandHandler(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<Card> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            var card = new Card
                (
                    request.Title,
                    request.Description,
                    request.TaskBoardId
                );

            _cardRepository.Create(card);

            await _cardRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return card;
        }
    }
}