using Links.OpenLending.Services.Common.Exception.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectWorkServiceCatalogo.BL.Implementations;
using ProjectWorkServiceCatalogo.BL.Interfaces;
using ProjectWorkServiceCatalogo.BL.Models;
using System.Reflection;
using System.Threading.Tasks;

namespace ProjectWorkServiceCatalogo.API.Controllers.v1
{
    public class ProdottoController : CommonControllerBase
    {
        private readonly IProdottoService _prodottoService;
        public ProdottoController(ILogger<ProdottoController> logger, IProdottoService prodottoService) : base(logger)
        {
            _prodottoService = prodottoService;
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Create([FromBody] ProdottoDTO prodottoDTO)
        {
            _logger.Log(LogLevel.Debug, "{@Method} started with request: {@Request}", MethodBase.GetCurrentMethod()?.ReflectedType?.FullName, prodottoDTO);
            var result = await _prodottoService.Create(prodottoDTO);
            _logger.Log(LogLevel.Debug, "{@Method} ended", MethodBase.GetCurrentMethod()?.ReflectedType?.FullName);
            return Ok(result);
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [AllowAnonymous]

        public async Task<IActionResult> FindAll()
        {
            
            return Ok(await _prodottoService.FindAll());
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [AllowAnonymous]
        [Route("id/{id}")]

        public async Task<IActionResult> FindById([FromRoute]int id)
        {

            return Ok(await _prodottoService.FindById(id));
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status500InternalServerError)]
        [HttpPut]
        [AllowAnonymous]
        [Route("id/{id}")]


        public async Task<IActionResult> Update([FromRoute]int id,[FromBody] ProdottoDTO prodotto)
        {

            return Ok(await _prodottoService.Update(id,prodotto));
        }

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status500InternalServerError)]
        [HttpDelete]
        [AllowAnonymous]
        [Route("id/{id}")]


        public async Task<IActionResult> Delete([FromRoute] int id)
        {

            return Ok(await _prodottoService.Delete(id));
        }
    }
}
