using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using PersonalSoft.Prueba.Common.Classes.DTO;
using PersonalSoft.Prueba.Domain.Services;
using PersonalSoft.Prueba.Infrastructure.Database.Entities;

namespace PersonalSoft.Prueba.Api.Controllers
{
    /// <summary>
    /// Controller to Radicado
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RadicadoController : ControllerBase
    {
        /// <summary>
        /// IRadicadoService
        /// </summary>
        protected IRadicadoService _radicadoService;
        private readonly IValidator<RadicadoDto> _validator;

        /// <summary>
        /// Constructor of radicado controller
        /// </summary>
        /// <param name="radicadoService"></param>
        public RadicadoController(IRadicadoService radicadoService, IValidator<RadicadoDto> validator)
        {
            _radicadoService = radicadoService;
            _validator = validator; 
        }


        /// <summary>
        /// Method to return radicados list 
        /// </summary>
        /// <returns> Radicados list </returns>
        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            var data = _radicadoService.GetAll();
            return StatusCode(StatusCodes.Status200OK, data.ToArray());
        }

        /// <summary>
        /// Method to return a radicado by nroPoliza or Placa 
        /// </summary>
        /// <returns> Radicado filtered </returns>
        [HttpGet]
        [Route("GetByFilter")]
        public IActionResult GetByFilter(string? placa, string? nroPoliza)
        {
            var radicado = _radicadoService.GetRadicadoInfoByFilter(placa, nroPoliza);

            return StatusCode(StatusCodes.Status200OK, radicado);
        }

        /// <summary>
        /// Method to Add a Radicado 
        /// </summary>
        /// <returns> Radicado inserted </returns>
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(RadicadoDto radicadoDto)
        {
            var result = _validator.Validate(radicadoDto);

            if (!result.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            var response = _radicadoService.Add(radicadoDto);
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
