using MediatR;

namespace Asponna.Application.Queries.TaskBoards.Get
{
    public class GetTaskBoardQuery : IRequest<TaskBoardViewModel>
    {
        public int Id { get; set; }
    }
}