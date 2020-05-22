using Asponna.Domain.Entities;
using Asponna.Domain.Repositories;
using Asponna.Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asponna.Persistence.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly AsponnaContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public CardRepository(AsponnaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Card>> GetAllAsync()
        {
            return await _context.Cards.ToListAsync();
        }

        public async Task<Card> GetAsync(int id)
        {
            return await _context.Cards.FindAsync(id);
        }

        public Card Insert(Card card)
        {
            if (card.IsTransient())
            {
                return _context.Cards
                    .Add(card)
                    .Entity;
            }

            return card;
        }

        public void Update(Card card)
        {
            _context.Cards.Update(card);
        }

        public void Delete(Card card)
        {
            _context.Cards.Remove(card);
        }
    }
}