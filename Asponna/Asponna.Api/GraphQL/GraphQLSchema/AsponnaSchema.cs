using Asponna.Application.TaskBoards.Queries;
using GraphQL;
using GraphQL.Types;

namespace Asponna.Api.GraphQL.GraphQLSchema
{
    public class AsponnaSchema : Schema
    {
        public AsponnaSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<TaskBoardQuery>();
        }
    }
}