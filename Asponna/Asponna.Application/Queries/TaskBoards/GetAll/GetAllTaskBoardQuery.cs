using Asponna.Application.Queries.Cards.GetAll;
using MediatR;
using System.Collections.Generic;

namespace Asponna.Application.Queries.TaskBoards.GetAll
{
    public class GetAllTaskBoardQuery : IRequest<List<TaskBoardListViewModel>>
    { }
}