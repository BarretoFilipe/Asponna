using Asponna.Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Asponna.Application.Queries.Priorities.GetAll
{
    public class GetAllPriorityQueryHandler : IRequestHandler<GetAllPriorityQuery, List<PriorityListViewModel>>
    {
        private readonly IPriorityRepository _priorityRepository;

        public GetAllPriorityQueryHandler(IPriorityRepository priorityRepository)
        {
            _priorityRepository = priorityRepository;
        }

        public async Task<List<PriorityListViewModel>> Handle(GetAllPriorityQuery request, CancellationToken cancellationToken)
        {
            var priorities = await _priorityRepository.GetAllAsync();

            var prioritiesListViewModel = priorities.Select(priority => new PriorityListViewModel
            {
                Id = priority.Id,
                Name = priority.Name,
                Color = priority.Color,
            }).ToList();

            return prioritiesListViewModel;
        }
    }
}