namespace WebApi.UseCases.V1.CustomError
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     CustomError
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#controller">
    ///         Controller Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class CustomErrorController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult CustomError()
        {
            var model = new CustomErrorResponse
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View("~/UseCases/V1/CustomError/CustomError.cshtml", model);
        }
    }
}
