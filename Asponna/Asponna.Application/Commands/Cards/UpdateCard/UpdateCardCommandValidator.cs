using Asponna.Application.Commands.Cards.Validators;
using Asponna.Application.Commands.TaskBoards.Validators;
using Asponna.Domain.Repositories;
using FluentValidation;

namespace Asponna.Application.Commands.Cards.UpdateCard
{
    public class UpdateCardCommandValidator : AbstractValidator<UpdateCardCommand>
    {
        public UpdateCardCommandValidator(ICardRepository cardRepository, ITaskBoardRepository taskBoardRepository)
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.Id)
                .MustAsync(async (cardId, cancellation) =>
                    await CardDataBaseValidator.IdExists(cardRepository, cardId))
                .WithMessage("TaskBoardId not exist");

            RuleFor(x => x.Title)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(x => x.TaskBoardId)
                .GreaterThan(0);

            RuleFor(x => x.TaskBoardId)
                .MustAsync(async (taskBoardId, cancellation) =>
                    await TaskboardDataBaseValidator.TaskBoardIdExists(taskBoardRepository, taskBoardId))
                .WithMessage("TaskBoardId not exist");
        }
    }
}