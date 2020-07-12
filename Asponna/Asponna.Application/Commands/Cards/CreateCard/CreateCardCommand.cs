using Asponna.Domain.Entities;
using MediatR;

namespace Asponna.Application.Commands.Cards.CreateCard
{
    public class CreateCardCommand : IRequest<Card>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TaskBoardId { get; set; }
    }
}