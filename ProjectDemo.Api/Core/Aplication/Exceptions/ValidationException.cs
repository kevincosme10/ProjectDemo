using FluentValidation.Results;

namespace ProjectDemo.Api.Core.Aplication.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; }

        public ValidationException() : base("Se han producido uno o mas errores de validacion")
        {
            Errors = new List<string>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
    }
    //public class ValidationException : ApplicationException
    //{
    //    public ValidationException() : base("Se presentaron uno o mas errores de validacion")
    //    {
    //        Errors = new Dictionary<string, string[]>();
    //    }

    //    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    //    {
    //        Errors = failures
    //            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
    //            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());

    //    }


    //    public IDictionary<string, string[]> Errors { get; }

    //}
}
