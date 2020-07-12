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
    public class CardRepository : ICardRepository
    {
        private readonly AsponnaContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public CardRepository(AsponnaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Card>> GetAllAsync(CardParameter cardParameter)
        {
            var cards = _context.Cards.AsQueryable();

            if (cardParameter.TaskBoardId != default)
                cards = cards.Where(x => x.TaskBoardId == cardParameter.TaskBoardId);

            if (cardParameter.Completed != default)
                cards = cards.Where(x => x.Completed == cardParameter.Completed);

            return await cards
                .Take(cardParameter.Take)
                .Skip(cardParameter.Skip)
                .ToListAsync();
        }

        public async Task<Card> GetAsync(int id)
        {
            return await _context.Cards.FindAsync(id);
        }

        public Card Create(Card card)
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