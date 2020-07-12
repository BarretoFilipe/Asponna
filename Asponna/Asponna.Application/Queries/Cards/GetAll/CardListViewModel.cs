namespace Asponna.Application.Queries.Cards.GetAll
{
    public class CardListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public int Position { get; set; }
        public int TaskBoardId { get; set; }
    }
}