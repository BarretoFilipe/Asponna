using MediatR;
using System.Collections.Generic;

namespace Asponna.Application.Queries.Priorities.GetAll
{
    public class GetAllPriorityQuery : IRequest<List<PriorityListViewModel>>
    { }
}