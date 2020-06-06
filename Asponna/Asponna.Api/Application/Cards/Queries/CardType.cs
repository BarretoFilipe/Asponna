using Asponna.Domain.Entities;
using GraphQL.Types;

namespace Asponna.Api.Application.Tickets.Queries
{
    public class CardType: ObjectGraphType<Card>
    {
        public CardType()
        {
            Name = nameof(Card);
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Card Id");
            Field(x => x.Title).Description("Card's Title ");
            Field(x => x.Description).Description("Card's Description");
            Field(x => x.Position, type: typeof(IntGraphType)).Description("Position from showing Card into Task Board");
            Field(x => x.Completed, type: typeof(BooleanGraphType)).Description("If Card is Completed");
            Field(x => x.TaskBoardId, type: typeof(IdGraphType)).Description("Task Board Id");
        }
    }
}
