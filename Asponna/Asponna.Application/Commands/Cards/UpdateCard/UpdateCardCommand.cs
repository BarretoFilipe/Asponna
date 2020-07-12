using Asponna.Domain.Entities;
using MediatR;

namespace Asponna.Application.Commands.Cards.UpdateCard
{
    public class UpdateCardCommand : IRequest<Card>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public int TaskBoardId { get; set; }
    }
}