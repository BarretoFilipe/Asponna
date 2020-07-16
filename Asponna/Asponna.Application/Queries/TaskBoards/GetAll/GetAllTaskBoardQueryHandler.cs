using Asponna.Application.Queries.Cards.GetAll;
using Asponna.Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asponna.Application.Queries.TaskBoards.GetAll
{
    public class GetAllTaskBoardQueryHandler : IRequestHandler<GetAllTaskBoardQuery, List<TaskBoardListViewModel>>
    {
        private readonly ITaskBoardRepository _taskBoardRepository;

        public GetAllTaskBoardQueryHandler(ITaskBoardRepository taskBoardRepository)
        {
            _taskBoardRepository = taskBoardRepository;
        }

        public async Task<List<TaskBoardListViewModel>> Handle(GetAllTaskBoardQuery request, CancellationToken cancellationToken)
        {
            var taskBoards = await _taskBoardRepository.GetAllAsync();

            var taskBoardsListViewModel = taskBoards.Select(taskBoard => new TaskBoardListViewModel
            {
                Id = taskBoard.Id,
                Name = taskBoard.Name,
                Position = taskBoard.Position
            }).ToList();

            return taskBoardsListViewModel;
        }
    }
}