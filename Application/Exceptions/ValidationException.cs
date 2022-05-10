using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; } = new List<string>();

        public ValidationException() : base("One or more validations errors have occurred")
        {

        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
                Errors.Add(failure.ErrorMessage);
        }
    }
}
