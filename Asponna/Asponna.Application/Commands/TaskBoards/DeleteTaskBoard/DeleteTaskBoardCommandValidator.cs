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
                .MustAsync(async (id, cancellation) =>
                    await taskBoardRepository.NoCardOnTaskBoard(id))
                .WithMessage("Can't remove a Task Board, there are cards");
        }
    }
}