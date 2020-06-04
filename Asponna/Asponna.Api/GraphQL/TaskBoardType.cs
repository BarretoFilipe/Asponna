using Asponna.Domain.Entities;
using GraphQL.Types;

namespace Asponna.Application.TaskBoards.Queries
{
    public class TaskBoardType : ObjectGraphType<TaskBoard>
    {
        public TaskBoardType()
        {
            Name = nameof(TaskBoard);
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Task Board Id");
            Field(x => x.Name).Description("Task Board Name");
            Field(x => x.Position, type: typeof(IntGraphType)).Description("Position from showing Task Board");
        }
    }
}