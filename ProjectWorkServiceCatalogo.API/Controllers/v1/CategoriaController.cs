﻿using Links.OpenLending.Services.Common.Exception.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProjectWorkServiceCatalogo.BL.Interfaces;
using System.Runtime.CompilerServices;
using ProjectWorkServiceCatalogo.BL.Models;
using System.Collections.Generic;

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
        /// <summary>
        /// Modifica una categoria tramite id
        /// </summary>
        /// <param name="id">id della categoria da modificare</param>
        /// <param name="nome">nome della categoria da modificare</param>
        /// <returns>L'esito dell'operazione</returns>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found. Codes: NOT_FOUND</response>
        /// <response code="500">System error. Codes: SYS_ERROR</response>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status500InternalServerError)]
        [HttpPut]
        [AllowAnonymous]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] string nome)
        {
            _logger.Log(LogLevel.Debug, "{@Method} started with id: {@Id} and name {@Name}", MethodBase.GetCurrentMethod()?.ReflectedType?.FullName, id, nome);
            var result = await _categoriaService.Update(id, nome);
            _logger.Log(LogLevel.Debug, "{@Method} ended", MethodBase.GetCurrentMethod()?.ReflectedType?.FullName);
            return Ok(result);
        }

        /// <summary>
        /// Cancella una categoria tramite id
        /// </summary>
        /// <param name="id">id della categoria da cancellare</param>
        /// <returns>L'esito dell'operazione</returns>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found. Codes: NOT_FOUND</response>
        /// <response code="500">System error. Codes: SYS_ERROR</response>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status500InternalServerError)]
        [HttpDelete]
        [AllowAnonymous]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            _logger.Log(LogLevel.Debug, "{@Method} started with request: {@Request}", MethodBase.GetCurrentMethod()?.ReflectedType?.FullName, id);
            var result = await _categoriaService.Delete(id);
            _logger.Log(LogLevel.Debug, "{@Method} ended", MethodBase.GetCurrentMethod()?.ReflectedType?.FullName);
            return Ok(result);
        }

        /// <summary>
        /// Visualizza tutte le categorie
        /// </summary>
        /// <returns>L'esito dell'operazione</returns>
        /// <response code="200">OK</response>
        /// <response code="400">Bad request. Codes: INVALID_REQUEST</response>
        /// <response code="500">System error. Codes: SYS_ERROR</response>
        [ProducesResponseType(typeof(List<CategoriaDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            _logger.Log(LogLevel.Debug, "{@Method} started with request: {@Request}", MethodBase.GetCurrentMethod()?.ReflectedType?.FullName);
            var result = await _categoriaService.GetAll();
            _logger.Log(LogLevel.Debug, "{@Method} ended", MethodBase.GetCurrentMethod()?.ReflectedType?.FullName);
            return Ok(result);
        }

        /// <summary>
        /// Visualizza una categoria tramite id
        /// </summary>
        /// <param name="id">id della categoria da visualizzare</param>
        /// <returns>L'esito dell'operazione</returns>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found. Codes: NOT_FOUND</response>
        /// <response code="500">System error. Codes: SYS_ERROR</response>
        [ProducesResponseType(typeof(CategoriaDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [AllowAnonymous]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            _logger.Log(LogLevel.Debug, "{@Method} started with request: {@Request}", MethodBase.GetCurrentMethod()?.ReflectedType?.FullName, id);
            var result = await _categoriaService.GetById(id);
            _logger.Log(LogLevel.Debug, "{@Method} ended", MethodBase.GetCurrentMethod()?.ReflectedType?.FullName);
            return Ok(result);
        }
    }
}

