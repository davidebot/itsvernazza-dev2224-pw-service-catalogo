using Links.OpenLending.Services.Common.Exception.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProjectWorkServiceCatalogo.BL.Interfaces;

namespace ProjectWorkServiceCatalogo.API.Controllers.v1
{
    public class CategoriaController : CommonControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriaController(ILogger<CategoriaController> logger, ICategoriaService categoriaService) : base(logger)
        {
            _categoriaService = categoriaService;
        }

        /// <summary>
        /// Inserisce una nuova categoria
        /// </summary>
        /// <param name="nome">Nome della categoria</param>
        /// <returns>L'esito dell'operazione</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request. Codes: INVALID_REQUEST</response>
        /// <response code="500">System error. Codes: SYS_ERROR</response>
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] string nome)
        {
            _logger.Log(LogLevel.Debug, "{@Method} started with request: {@Request}", MethodBase.GetCurrentMethod()?.ReflectedType?.FullName, nome);
            var result = await _categoriaService.Create(nome);
            _logger.Log(LogLevel.Debug, "{@Method} ended", MethodBase.GetCurrentMethod()?.ReflectedType?.FullName);
            return Ok(result);
        }
    }
}

