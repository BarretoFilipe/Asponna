using Asponna.Api.GraphQL.Builders;
using GraphQL;
using GraphQL.Types;

namespace Asponna.Api.GraphQL
{
    public class AsponnaSchema : Schema
    {
        public AsponnaSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<QueryBuilder>();
        }
    }
}