using Asponna.Application.TaskBoards.Queries.Types;
using Asponna.Domain.Repositories;
using GraphQL.Types;

namespace Asponna.Application.TaskBoards.Queries
{
    public class TaskBoardQuery : ObjectGraphType<object>
    {
        public TaskBoardQuery(ITaskBoardRepository taskBoardRepository)
        {
            Field<ListGraphType<TaskBoardType>>("taskboard",
                resolve: context =>
                {
                    return taskBoardRepository.GetAllAsync();
                });
        }
    }
}