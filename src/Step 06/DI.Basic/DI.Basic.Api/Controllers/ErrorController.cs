using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DI.Basic.Api.Controllers;

public class ErrorController : ApiControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        //var (statusCode, title) = exception switch
        //{
        //    DuplicateCompanyException e => (StatusCodes.Status409Conflict, e.Message),
        //    _ => (StatusCodes.Status500InternalServerError, "Something happened.")
        //};
        //return Problem(title: title, statusCode: statusCode);
        return Problem();
    }
}
