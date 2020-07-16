using MediatR;

namespace Asponna.Application.Commands.TaskBoards.DeleteTaskBoard
{
    public class DeleteTaskBoardCommand : IRequest
    {
        public int Id { get; set; }
    }
}