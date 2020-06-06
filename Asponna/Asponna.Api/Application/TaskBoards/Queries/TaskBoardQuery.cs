using Asponna.Api.GraphQL.Commons;
using Asponna.Domain.Repositories;
using GraphQL.Types;

namespace Asponna.Application.TaskBoards.Queries
{
    public class TaskBoardQuery : ObjectGraphType, IGraphBuilder
    {
        public TaskBoardQuery(ITaskBoardRepository taskBoardRepository)
        {
            FieldAsync<ListGraphType<TaskBoardType>>(
                 "taskboards",
                 resolve: async context =>
                 {
                     return await taskBoardRepository.GetAllAsync();
                 }
             );
        }
    }
}