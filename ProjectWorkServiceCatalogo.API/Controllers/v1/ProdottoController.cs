using Links.OpenLending.Services.Common.Exception.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectWorkServiceCatalogo.BL.Implementations;
using ProjectWorkServiceCatalogo.BL.Interfaces;
using ProjectWorkServiceCatalogo.BL.Models;
using System.Collections.Generic;
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
        
        /// <summary>
        /// Inserisce un nuovo prodotto
        /// </summary>
        /// <param name="prodottoDTO">Dati del prodotto</param>
        /// <returns>L'esito dell'operazione</returns>
        /// <response code="201">Created</response>
        /// <response code="400">Bad request. Codes: INVALID_REQUEST</response>
        /// <response code="500">System error. Codes: SYS_ERROR</response>
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] ProdottoUpsertDTO prodottoDTO)
        {
            _logger.Log(LogLevel.Debug, "{@Method} started with request: {@Request}", MethodBase.GetCurrentMethod()?.ReflectedType?.FullName, prodottoDTO);
            var result = await _prodottoService.Create(prodottoDTO);
            _logger.Log(LogLevel.Debug, "{@Method} ended", MethodBase.GetCurrentMethod()?.ReflectedType?.FullName);
            return Ok(result);
        }

        /// <summary>
        /// Restituisce i prodotti filtrati
        /// </summary> 
        /// <param name="idCategoria">Filtro per categoria</param>
        /// <returns>L'elenco dei prodotti</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request. Codes: INVALID_REQUEST</response>
        /// <response code="500">System error. Codes: SYS_ERROR</response>
        [ProducesResponseType(typeof(List<ProdottoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> FindAll([FromQuery] long idCategoria)
        {
            return Ok(await _prodottoService.FindAll(idCategoria));
        }

        /// <summary>
        /// Restituisce il dettaglio del prodotto
        /// </summary> 
        /// <returns>Il dettaglio del prodotto</returns>
        /// <param name="id">Id del prodotto</param>
        /// <response code="200">OK</response>
        /// <response code="400">Not Found. Codes: NOT_FOUND</response>
        /// <response code="500">System error. Codes: SYS_ERROR</response>
        [ProducesResponseType(typeof(ProdottoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [AllowAnonymous]
        [Route("{id}")]
        public async Task<IActionResult> FindById([FromRoute] int id)
        {
            return Ok(await _prodottoService.FindById(id));
        }

        /// <summary>
        /// Aggiorna il prodotto
        /// </summary> 
        /// <returns>L'esito dell'operazione</returns>
        /// <param name="id">Id del prodotto</param>
        /// <param name="prodotto">Dati da aggiornare</param>
        /// <response code="200">OK</response>
        /// <response code="400">Not Found. Codes: NOT_FOUND</response>
        /// <response code="500">System error. Codes: SYS_ERROR</response>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status500InternalServerError)]
        [HttpPut]
        [AllowAnonymous]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProdottoUpsertDTO prodotto)
        {
            return Ok(await _prodottoService.Update(id, prodotto));
        }

        /// <summary>
        /// Elimina il prodotto
        /// </summary> 
        /// <returns>L'esito dell'operazione</returns>
        /// <param name="id">Id del prodotto</param>
        /// <response code="200">OK</response>
        /// <response code="400">Not Found. Codes: NOT_FOUND</response>
        /// <response code="500">System error. Codes: SYS_ERROR</response>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status500InternalServerError)]
        [HttpDelete]
        [AllowAnonymous]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _prodottoService.Delete(id));
        }
    }
}
