namespace Asponna.Domain.Repositories.Parameters
{
    public class CardParameter
    {
        public int Take { get; set; } = 20;
        public int Skip { get; set; } = 0;
        public bool? Completed { get; set; }
        public int? TaskBoardId { get; set; }
    }
}