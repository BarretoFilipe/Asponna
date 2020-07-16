namespace Asponna.Application.Queries.Cards.Get
{
    public class CardViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public int TaskBoardId { get; set; }
        public int? PriorityId { get; set; }
    }
}