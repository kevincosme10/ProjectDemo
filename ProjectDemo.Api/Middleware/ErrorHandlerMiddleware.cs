using ProjectDemo.Api.Core.Aplication.Wrappers;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using ProjectDemo.Api.Core.Aplication.Exceptions;
using System.Text.Json;

namespace ProjectDemo.Api.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                var responseModel = new Response<string>() { Succeeded = false, Message = error?.Message };
                switch (error)
                {
                    case ApiException e: //here handle erros like  400, 500
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case ValidationException e:
                        //Custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Errors;

                        break;

                    case KeyNotFoundException e: //Not Found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
