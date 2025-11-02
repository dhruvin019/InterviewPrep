using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace practice1
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Log the exception (optional)
            Console.WriteLine($"Exception: {context.Exception.Message}");

            // Create a JSON response for the client
            context.Result = new JsonResult(new
            {
                Success = false,
                Message = "An unexpected error occurred. Please try again later."
            });

            // Mark the exception as handled
            context.ExceptionHandled = true;
        }
    }
}
