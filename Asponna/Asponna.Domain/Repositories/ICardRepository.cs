using Asponna.Domain.Entities;
using Asponna.Domain.Repositories.Parameters;
using Asponna.Domain.SharedKernel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asponna.Domain.Repositories
{
    public interface ICardRepository : IRepository<Card>
    {
        Card Create(Card card);

        void Update(Card card);

        void Delete(Card card);

        Task<Card> GetAsync(int id);

        Task<IEnumerable<Card>> GetAllAsync(CardParameter cardParameter);
    }
}