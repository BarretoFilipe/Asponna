using Asponna.Domain.Entities;
using Asponna.Domain.SharedKernel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asponna.Domain.Repositories
{
    public interface IPriorityRepository : IRepository<Priority>
    {
        Task<IEnumerable<Priority>> GetAllAsync();
    }
}