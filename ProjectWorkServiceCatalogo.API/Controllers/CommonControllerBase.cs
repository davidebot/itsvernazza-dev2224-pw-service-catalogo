using Links.OpenLending.Services.Common.Exception.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace ProjectWorkServiceCatalogo.API.Controllers
{
    /// <summary>
    /// A base class for an API MVC controller with model state validation and base configurations
    /// </summary>
    [ApiController]
    [ApiVersion("1")]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ModelStateValidationFilterAttribute]
    [ServiceFilter(typeof(IExceptionFilter))]
    public abstract class CommonControllerBase : ControllerBase
    {
        /// <summary>
        /// Logger utility
        /// </summary>
        protected readonly ILogger<CommonControllerBase> _logger;

        /// <summary>
        /// Common class controller constructor
        /// </summary>
        /// <param name="logger"></param>
        protected CommonControllerBase(ILogger<CommonControllerBase> logger)
        {
            _logger = logger;
        }
    }
}