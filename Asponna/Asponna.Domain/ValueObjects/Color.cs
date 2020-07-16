using Asponna.Domain.Constants;
using Asponna.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Asponna.Domain.ValueObjects
{
    public class Color
    {
        private readonly string _value;

        /*public string Value
        {
            get { return _value; }
            private set { }
        }*/

        private Color(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }

        public static implicit operator Color(string value) => Parse(value);

        private static Color Parse(string value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }
            throw new DomainException("Color is not valid");
        }

        public static bool TryParse(string value, out Color color)
        {
            if (!Regex.Match(value, DomainConstants.ColorRegex).Success)
            {
                color = default;
                return false;
            }

            color = value;
            return true;
        }
    }
}