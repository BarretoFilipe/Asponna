using Asponna.Domain.Repositories;
using FluentValidation;

namespace Asponna.Application.Commands.TaskBoards.DeleteTaskBoard
{
    public class DeleteTaskBoardCommandValidator : AbstractValidator<DeleteTaskBoardCommand>
    {
        public DeleteTaskBoardCommandValidator(ITaskBoardRepository taskBoardRepository)
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Id)
                .MustAsync(async (taskBoardId, cancellation) =>
                    await taskBoardRepository.IdExistsAsync(taskBoardId))
                .WithMessage("Id not exist");

            RuleFor(x => x.Id)
                .MustAsync(async (taskBoardId, cancellation) =>
                {
                    return ! await taskBoardRepository.CardsOnTaskBoard(taskBoardId);
                })
                .WithMessage("Can't remove a Task Board, there are cards");
        }
    }
}