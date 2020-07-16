using Asponna.Domain.Entities;
using Asponna.Domain.Repositories;
using Asponna.Domain.Repositories.Parameters;
using Asponna.Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asponna.Persistence.Repositories
{
    public class PriorityRepository : IPriorityRepository
    {
        private readonly AsponnaContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public PriorityRepository(AsponnaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Priority>> GetAllAsync()
        {
            return await _context.Priorities.AsQueryable().ToListAsync();
        }
    }
}