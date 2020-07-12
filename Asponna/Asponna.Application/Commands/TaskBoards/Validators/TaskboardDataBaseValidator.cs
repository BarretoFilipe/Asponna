using Asponna.Domain.Repositories;
using System.Threading.Tasks;

namespace Asponna.Application.Commands.TaskBoards.Validators
{
    public static class TaskboardDataBaseValidator
    {
        public static async Task<bool> TaskBoardIdExists(ITaskBoardRepository taskBoardRepository, int taskBoardId)
        {
            return await taskBoardRepository.GetAsync(taskBoardId) != null;
        }
    }
}