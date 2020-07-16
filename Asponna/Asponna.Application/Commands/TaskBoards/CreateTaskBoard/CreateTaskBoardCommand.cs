using Asponna.Application.Queries.TaskBoards.Get;
using MediatR;

namespace Asponna.Application.Commands.TaskBoards.CreateTaskBoard
{
    public class CreateTaskBoardCommand : IRequest<TaskBoardViewModel>
    {
        public string Name { get; set; }
        public byte Position { get; set; }
    }
}