using Asponna.Domain.Entities;
using Asponna.Domain.SharedKernel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asponna.Domain.Repositories
{
    public interface ITaskBoardRepository : IRepository<TaskBoard>
    {
        TaskBoard Insert(TaskBoard taskBoard);

        void Update(TaskBoard taskBoard);

        void Delete(TaskBoard taskBoard);

        Task<IEnumerable<TaskBoard>> GetAllAsync();
    }
}