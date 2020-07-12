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
                .LessThanOrEqualTo(0);

            RuleFor(x => x.Id)
                .MustAsync(async (cardId, cancellation) =>
                    await CardDataBaseValidator.IdExists(cardRepository, cardId))
                .WithMessage("TaskBoardId not exist");

            RuleFor(x => x.Title)
                .NotEmpty();

            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.TaskBoardId)
                .LessThanOrEqualTo(0);

            RuleFor(x => x.TaskBoardId)
                .MustAsync(async (taskBoardId, cancellation) =>
                    await TaskboardDataBaseValidator.TaskBoardIdExists(taskBoardRepository, taskBoardId))
                .WithMessage("TaskBoardId not exist");
        }
    }
}