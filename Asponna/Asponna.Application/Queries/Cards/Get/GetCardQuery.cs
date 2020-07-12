using MediatR;

namespace Asponna.Application.Queries.Cards.Get
{
    public class GetCardQuery : IRequest<CardViewModel>
    {
        public int Id { get; set; }
    }
}