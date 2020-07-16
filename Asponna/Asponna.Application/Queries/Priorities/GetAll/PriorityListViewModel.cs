using Asponna.Domain.ValueObjects;

namespace Asponna.Application.Queries.Priorities.GetAll
{
    public class PriorityListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
    }
}