using Asponna.Api.GraphQL.Commons;
using GraphQL.Types;
using System.Collections.Generic;

namespace Asponna.Api.GraphQL.Builders
{
    public class QueryBuilder : ObjectGraphType
    {
        public QueryBuilder(IEnumerable<IGraphBuilder> graphQLBuilder)
        {
            foreach (var builder in graphQLBuilder)
            {
                var objectGraphType = builder as ObjectGraphType<object>;
                foreach (var field in objectGraphType.Fields)
                {
                    AddField(field);
                }
            }
        }
    }
}