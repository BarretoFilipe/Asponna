using Asponna.Application.Commands.TaskBoards.DeleteTaskBoard;
using Asponna.Domain.Repositories;
using FluentValidation;

namespace Asponna.Application.Commands.Cards.DeleteCard
{
    public class DeleteCardCommandValidator : AbstractValidator<DeleteTaskBoardCommand>
    {
        public DeleteCardCommandValidator(ICardRepository cardRepository)
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Id)
                .MustAsync(async (cardId, cancellation) =>
                    await cardRepository.IdExistsAsync(cardId))
                .WithMessage("Id not exist");
        }
    }
}