using Asponna.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asponna.Application.Queries.TaskBoards.Get
{
    public class GetTaskBoardQueryHandler : IRequestHandler<GetTaskBoardQuery, TaskBoardViewModel>
    {
        private readonly ITaskBoardRepository _taskBoardRepository;

        public GetTaskBoardQueryHandler(ITaskBoardRepository taskBoardRepository)
        {
            _taskBoardRepository = taskBoardRepository;
        }

        public async Task<TaskBoardViewModel> Handle(GetTaskBoardQuery request, CancellationToken cancellationToken)
        {
            var taskBoard = await _taskBoardRepository.GetAsync(request.Id);

            if (taskBoard == null)
                return new TaskBoardViewModel();

            var taskBoardViewModel = new TaskBoardViewModel
            {
                Id = taskBoard.Id,
                Name = taskBoard.Name
            };

            return taskBoardViewModel;
        }
    }
}