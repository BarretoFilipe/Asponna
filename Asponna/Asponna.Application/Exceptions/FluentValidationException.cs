using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Asponna.Application.Exceptions
{
    public class FluentValidationException : Exception
    {
        public FluentValidationException()
            : base("One or more validation failures have occurred.")
        {
            Failures = new Dictionary<string, string[]>();
        }

        public FluentValidationException(List<ValidationFailure> failures)
            : this()
        {
            var propertyNames = failures
                .Select(f => f.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(f => f.PropertyName == propertyName)
                    .Select(f => f.ErrorMessage)
                    .ToArray();

                Failures.Add(propertyName, propertyFailures);
            }
        }

        public IDictionary<string, string[]> Failures { get; }
    }
}