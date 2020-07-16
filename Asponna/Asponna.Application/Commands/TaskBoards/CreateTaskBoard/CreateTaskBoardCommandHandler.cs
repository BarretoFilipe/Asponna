using Asponna.Application.Queries.TaskBoards.Get;
using Asponna.Domain.Entities;
using Asponna.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asponna.Application.Commands.TaskBoards.CreateTaskBoard
{
    public class CreateTaskBoardCommandHandler : IRequestHandler<CreateTaskBoardCommand, TaskBoardViewModel>
    {
        private readonly ITaskBoardRepository _taskBoardRepository;

        public CreateTaskBoardCommandHandler(ITaskBoardRepository taskBoardRepository)
        {
            _taskBoardRepository = taskBoardRepository;
        }

        public async Task<TaskBoardViewModel> Handle(CreateTaskBoardCommand request, CancellationToken cancellationToken)
        {
            var taskBoard = new TaskBoard
                (
                    request.Name,
                    request.Position
                );

            _taskBoardRepository.Create(taskBoard);

            await _taskBoardRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            var viewModel = new TaskBoardViewModel
            {
                Id = taskBoard.Id,
                Name = taskBoard.Name
            };

            return viewModel;
        }
    }
}