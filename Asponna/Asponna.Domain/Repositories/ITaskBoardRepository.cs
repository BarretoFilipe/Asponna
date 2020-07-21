using Asponna.Domain.Entities;
using Asponna.Domain.SharedKernel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asponna.Domain.Repositories
{
    public interface ITaskBoardRepository : IRepository<TaskBoard>
    {
        TaskBoard Create(TaskBoard taskBoard);

        void Update(TaskBoard taskBoard);

        void Delete(TaskBoard taskBoard);

        Task<TaskBoard> GetAsync(int id);

        Task<IEnumerable<TaskBoard>> GetAllAsync();

        Task<bool> IdExistsAsync(int id);

        Task<bool> CardsOnTaskBoard(int id);
    }
}