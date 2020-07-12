using Asponna.Domain.Entities;
using Asponna.Domain.Repositories;
using Asponna.Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asponna.Persistence.Repositories
{
    public class TaskBoardRepository : ITaskBoardRepository
    {
        private readonly AsponnaContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public TaskBoardRepository(AsponnaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskBoard>> GetAllAsync()
        {
            return await _context.TaskBoards.ToListAsync();
        }

        public async Task<TaskBoard> GetAsync(int id)
        {
            return await _context.TaskBoards.FindAsync(id);
        }

        public TaskBoard Create(TaskBoard taskBoard)
        {
            if (taskBoard.IsTransient())
            {
                return _context.TaskBoards
                    .Add(taskBoard)
                    .Entity;
            }

            return taskBoard;
        }

        public void Update(TaskBoard taskBoard)
        {
            _context.TaskBoards.Update(taskBoard);
        }

        public void Delete(TaskBoard taskBoard)
        {
            _context.TaskBoards.Remove(taskBoard);
        }
    }
}