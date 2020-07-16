using Asponna.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asponna.Application.Commands.TaskBoards.DeleteTaskBoard
{
    public class DeleteTaskBoardCommandHandler : IRequestHandler<DeleteTaskBoardCommand>
    {
        private readonly ITaskBoardRepository _taskBoardRepository;

        public DeleteTaskBoardCommandHandler(ITaskBoardRepository taskBoardRepository)
        {
            _taskBoardRepository = taskBoardRepository;
        }

        public async Task<Unit> Handle(DeleteTaskBoardCommand request, CancellationToken cancellationToken)
        {
            var taskBoard = await _taskBoardRepository.GetAsync(request.Id);

            _taskBoardRepository.Delete(taskBoard);

            await _taskBoardRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}