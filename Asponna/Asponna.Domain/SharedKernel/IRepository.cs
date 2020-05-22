using System;
using System.Collections.Generic;
using System.Text;

namespace Asponna.Domain.SharedKernel
{
    public interface IRepository<T> where T: IBaseRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
