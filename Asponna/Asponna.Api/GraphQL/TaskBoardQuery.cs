using Asponna.Domain.Repositories;
using GraphQL.Types;

namespace Asponna.Application.TaskBoards.Queries
{
    public class TaskBoardQuery : ObjectGraphType
    {
        public TaskBoardQuery(ITaskBoardRepository taskBoardRepository)
        {
            Field<ListGraphType<TaskBoardType>>(
                 "taskboard",
                 resolve: context =>
                 {
                     return taskBoardRepository.GetAllAsync();
                 }
             );
        }
    }
}