using Asponna.Api.GraphQL.Commons;
using Asponna.Domain.Repositories;
using GraphQL.Types;

namespace Asponna.Api.Application.Tickets.Queries
{
    public class CardQuery : ObjectGraphType, IGraphBuilder
    {
        public CardQuery(ICardRepository cardRepository)
        {
            FieldAsync<ListGraphType<CardType>>(
                "cards",
                resolve: async context =>
                {
                    return await cardRepository.GetAllAsync();
                }
            );

            FieldAsync<CardType>(
                "card",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: async context =>
                {
                    var id = context.GetArgument<int>("id");
                    return await cardRepository.GetAsync(id);
                }
            );
        }
    }
}