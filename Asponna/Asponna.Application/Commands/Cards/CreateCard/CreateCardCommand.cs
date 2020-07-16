using Asponna.Application.Queries.Cards.Get;
using MediatR;

namespace Asponna.Application.Commands.Cards.CreateCard
{
    public class CreateCardCommand : IRequest<CardViewModel>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TaskBoardId { get; set; }
        public int? PriorityId { get; set; }
    }
}