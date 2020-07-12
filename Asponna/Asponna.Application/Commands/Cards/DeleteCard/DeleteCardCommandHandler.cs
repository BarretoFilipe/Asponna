using Asponna.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asponna.Application.Commands.Cards.DeleteCard
{
    public class DeleteCardCommandHandler : IRequestHandler<DeleteCardCommand>
    {
        private readonly ICardRepository _cardRepository;

        public DeleteCardCommandHandler(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<Unit> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            var card = await _cardRepository.GetAsync(request.Id);

            _cardRepository.Delete(card);

            await _cardRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
