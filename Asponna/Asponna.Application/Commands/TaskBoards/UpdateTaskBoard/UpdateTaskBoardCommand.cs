using Asponna.Application.Queries.TaskBoards.Get;
using MediatR;

namespace Asponna.Application.Commands.TaskBoards.UpdateTaskBoard
{
    public class UpdateTaskBoardCommand : IRequest<TaskBoardViewModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Position { get; set; }
    }
}