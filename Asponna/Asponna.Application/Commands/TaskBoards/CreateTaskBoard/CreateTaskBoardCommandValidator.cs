using FluentValidation;

namespace Asponna.Application.Commands.TaskBoards.CreateTaskBoard
{
    public class CreateTaskBoardCommandValidator : AbstractValidator<CreateTaskBoardCommand>
    {
        public CreateTaskBoardCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Position)
                .NotEmpty();
        }
    }
}