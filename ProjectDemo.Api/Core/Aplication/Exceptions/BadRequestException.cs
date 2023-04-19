namespace ProjectDemo.Api.Core.Aplication.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
