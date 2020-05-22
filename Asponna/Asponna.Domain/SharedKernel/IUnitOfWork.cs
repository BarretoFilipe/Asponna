using System;
using System.Threading;
using System.Threading.Tasks;

namespace Asponna.Domain.SharedKernel
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}