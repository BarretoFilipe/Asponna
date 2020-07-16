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
                .GreaterThan(0);

            RuleFor(x => x.TaskBoardId)
                .MustAsync(async (taskBoardId, cancellation) =>
                    await taskBoardRepository.IdExistsAsync(taskBoardId))
                .WithMessage("TaskBoardId not exist");
        }
    }
}