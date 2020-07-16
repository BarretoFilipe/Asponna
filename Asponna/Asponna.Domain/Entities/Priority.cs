using Asponna.Domain.Constants;
using Asponna.Domain.Exceptions;
using Asponna.Domain.SharedKernel;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Asponna.Domain.Entities
{
    public class Priority : BaseEntity, IBaseRepository
    {
        public Priority(string name, string color)
        {
            SetName(name);
            SetColor(color);
        }

        public string Name { get; private set; }
        public string Color { get; private set; }
        public ICollection<Card> Cards { get; private set; }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) && name.Length > 100)
                throw new DomainException("Name is empty");

            if (name.Length > 100)
                throw new DomainException("Maximum Name length is 100");
            Name = name;
        }

        public void SetColor(string color)
        {
            if (!Regex.Match(color, DomainConstants.ColorRegex).Success)
                throw new DomainException("Color is not valid");
            Color = color;
        }
    }
}