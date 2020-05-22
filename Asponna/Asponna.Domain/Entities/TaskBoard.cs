using Asponna.Domain.Exceptions;
using Asponna.Domain.SharedKernel;
using System.Collections.Generic;

namespace Asponna.Domain.Entities
{
    public class TaskBoard : BaseEntity, IBaseRepository
    {
        public TaskBoard(string name, byte position)
        {
            SetName(name);
            SetPosition(position);
            Cards = new HashSet<Card>();
        }

        public string Name { get; private set; }
        public byte Position { get; private set; }
        public ICollection<Card> Cards { get; private set; }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Name is empty");

            Name = name;
        }

        public void SetPosition(byte position)
        {
            if (position <= 0)
                throw new DomainException("Position less than or equal to 0");

            Position = position;
        }
    }
}