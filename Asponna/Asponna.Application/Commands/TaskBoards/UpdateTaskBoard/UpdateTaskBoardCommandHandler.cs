using Asponna.Application.Queries.TaskBoards.Get;
using Asponna.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asponna.Application.Commands.TaskBoards.UpdateTaskBoard
{
    public class UpdateTaskBoardCommandHandler : IRequestHandler<UpdateTaskBoardCommand, TaskBoardViewModel>
    {
        private readonly ITaskBoardRepository _taskBoardRepository;

        public UpdateTaskBoardCommandHandler(ITaskBoardRepository taskBoardRepository)
        {
            _taskBoardRepository = taskBoardRepository;
        }

        public async Task<TaskBoardViewModel> Handle(UpdateTaskBoardCommand request, CancellationToken cancellationToken)
        {
            var taskBoard = await _taskBoardRepository.GetAsync(request.Id);

            taskBoard.SetName(request.Name);
            taskBoard.SetPosition(request.Position);

            _taskBoardRepository.Update(taskBoard);

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