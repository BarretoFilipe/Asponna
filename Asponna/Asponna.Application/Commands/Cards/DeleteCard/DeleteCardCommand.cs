using MediatR;

namespace Asponna.Application.Commands.Cards.DeleteCard
{
    public class DeleteCardCommand : IRequest
    {
        public int Id { get; set; }
    }
}