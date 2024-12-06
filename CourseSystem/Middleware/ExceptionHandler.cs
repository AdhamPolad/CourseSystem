
using CourseSystem.Dtos.CustomDtos;
using System.Net;
using System.Text.Json;

namespace CourseSystem.Middleware
{
    public class ExceptionHandler : IMiddleware
    {
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(ILogger<ExceptionHandler> logger)
        {
            _logger = logger;
        }


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exp)
            {

                await HandleException(context, exp);
            }
            

        }

        private async Task HandleException(HttpContext context, Exception exp)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            CustomErrorDto customErrorDto = new CustomErrorDto()
            {
                Message = exp.Message,
                HttpStatusCode = System.Net.HttpStatusCode.InternalServerError
            };

            string message = JsonSerializer.Serialize(customErrorDto);
            _logger.LogError(exp, $"Exception occured: Message{exp.Message}");

            await context.Response.WriteAsync(message);

        }
    }
}
