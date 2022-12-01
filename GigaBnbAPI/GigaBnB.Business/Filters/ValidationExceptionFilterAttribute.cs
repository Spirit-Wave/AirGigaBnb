using GigaBnB.Business.Filters.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GigaBnB.Business.Filters;

public class ValidationExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is not ValidationException exception) return;
        context.Result = new ObjectResult(new {error = exception.Messages})
        {
            StatusCode = 400
        };
        context.ExceptionHandled = true;
    }
}