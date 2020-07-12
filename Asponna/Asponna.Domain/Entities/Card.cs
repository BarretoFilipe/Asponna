using Asponna.Domain.Exceptions;
using Asponna.Domain.SharedKernel;

namespace Asponna.Domain.Entities
{
    public class Card : BaseEntity, IBaseRepository
    {
        public Card(string title, string description, int taskBoardId)
        {
            SetTitle(title);
            SetDescription(description);
            SetTaskBoardId(taskBoardId);
            Position = 0;
            Completed = false;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool Completed { get; private set; }
        public int Position { get; private set; }
        public int TaskBoardId { get; private set; }
        public TaskBoard TaskBoard { get; private set; }

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new DomainException("Title is empty");
            Title = title;
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new DomainException("Description is empty");
            Description = description;
        }

        public void SetCompleted(bool completed)
        {
            Completed = completed;
        }

        public void SetPosition(int position)
        {
            if (position <= 0)
                throw new DomainException("Position less than or equal to 0");
            Position = position;
        }

        public void SetTaskBoardId(int taskBoardId)
        {
            if (taskBoardId <= 0)
                throw new DomainException("TaskBoardId less than or equal to 0");
            TaskBoardId = taskBoardId;
        }
    }
}