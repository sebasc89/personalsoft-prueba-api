using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using PersonalSoft.Prueba.Common.Classes.DTO;
using PersonalSoft.Prueba.Domain.Services;
using PersonalSoft.Prueba.Infrastructure.Database.Entities;

namespace PersonalSoft.Prueba.Api.Controllers
{
    /// <summary>
    /// Controller to Poliza
    /// </summary>
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PolizaController : ControllerBase
    {
        /// <summary>
        /// IPolizaService
        /// </summary>
        protected IPolizaService _polizaService;
        private readonly IValidator<PolizaDto> _validator;

        /// <summary>
        /// Constructor of poliza controller
        /// </summary>
        /// <param name="polizaService"></param>
        public PolizaController(IPolizaService polizaService, IValidator<PolizaDto> validator)
        {
            _polizaService = polizaService;
            _validator = validator;
        }

        /// <summary>
        /// Method to return poliza list 
        /// </summary>
        /// <returns> Polizas list </returns>
        [HttpGet]
        [Route("Get")]
        public IActionResult GetAll()
        {
            var data = _polizaService.GetAll();
            return StatusCode(StatusCodes.Status200OK, data.ToArray());
        }

        /// <summary>
        /// Method to Add a Poliza 
        /// </summary>
        /// <returns> Polizas inserted </returns>
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(PolizaDto polizaDto)
        {
            var result = _validator.Validate(polizaDto);

            if (!result.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }

            var response = _polizaService.Add(polizaDto);
            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
