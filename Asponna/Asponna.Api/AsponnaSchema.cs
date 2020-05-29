using Asponna.Application.TaskBoards.Queries;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Asponna.Api
{
    public class AsponnaSchema : Schema
    {
        public AsponnaSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<TaskBoardQuery>();
        }
    }
}