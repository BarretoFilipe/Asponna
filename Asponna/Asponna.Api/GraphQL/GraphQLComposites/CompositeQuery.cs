using Asponna.Application.Commons;
using GraphQL.Types;
using System.Collections.Generic;

namespace Asponna.Api.GraphQL.GraphQLComposites
{
    public class CompositeQuery : ObjectGraphType
    {
        public CompositeQuery(IEnumerable<IGraphQueryMarker> graphQueryMarkers)
        {
            foreach (var marker in graphQueryMarkers)
            {
                var q = marker as ObjectGraphType<object>;
                foreach (var f in q.Fields)
                {
                    AddField(f);
                }
            }
        }
    }
}