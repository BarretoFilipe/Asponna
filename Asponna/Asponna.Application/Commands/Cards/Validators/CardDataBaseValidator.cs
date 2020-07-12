using Asponna.Domain.Repositories;
using System.Threading.Tasks;

namespace Asponna.Application.Commands.Cards.Validators
{
    public static class CardDataBaseValidator
    {
        public static async Task<bool> IdExists(ICardRepository cardRepository, int id)
        {
            return await cardRepository.GetAsync(id) != null;
        }
    }
}