using Asponna.Domain.Exceptions;
using Asponna.Domain.SharedKernel;

namespace Asponna.Domain.Entities
{
    public class Card : BaseEntity, IBaseRepository
    {
        public Card(string title, string description, int taskBoardId, int? priorityId)
        {
            SetTitle(title);
            SetDescription(description);
            SetTaskBoardId(taskBoardId);
            SetPriorityId(priorityId);
            Position = 0;
            Completed = false;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool Completed { get; private set; }
        public int Position { get; private set; }
        public int TaskBoardId { get; private set; }
        public TaskBoard TaskBoard { get; private set; }
        public int? PriorityId { get; private set; }
        public Priority Priority { get; private set; }

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title) && title.Length > 100)
                throw new DomainException("Title is empty");

            if (title.Length > 100)
                throw new DomainException("Maximum Title length is 100");
            Title = title;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetCompleted(bool completed)
        {
            Completed = completed;
        }

        public void SetPosition(int position)
        {
            if (position <= 0)
                throw new DomainException("Position must be greater than 0");
            Position = position;
        }

        public void SetTaskBoardId(int taskBoardId)
        {
            if (taskBoardId <= 0)
                throw new DomainException("TaskBoardId must be greater than 0");
            TaskBoardId = taskBoardId;
        }

        public void SetPriorityId(int? priorityId)
        {
            PriorityId = priorityId;
        }
    }
}