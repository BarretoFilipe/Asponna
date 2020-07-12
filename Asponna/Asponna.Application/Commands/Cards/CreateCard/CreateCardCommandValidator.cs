using Asponna.Application.Commands.TaskBoards.Validators;
using Asponna.Domain.Repositories;
using FluentValidation;

namespace Asponna.Application.Commands.Cards.CreateCard
{
    public class CreateCardCommandValidator : AbstractValidator<CreateCardCommand>
    {
        public CreateCardCommandValidator(ITaskBoardRepository taskBoardRepository)
        {
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