using Asponna.Domain.Repositories;
using FluentValidation;

namespace Asponna.Application.Commands.TaskBoards.UpdateTaskBoard
{
    public class UpdateTaskBoardCommandValidator : AbstractValidator<UpdateTaskBoardCommand>
    {
        public UpdateTaskBoardCommandValidator(ITaskBoardRepository taskBoardRepository)
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.Id)
                .MustAsync(async (taskBoardId, cancellation) =>
                    await taskBoardRepository.IdExistsAsync(taskBoardId))
                .WithMessage("Id not exist");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Position)
                .NotEmpty();
        }
    }
}