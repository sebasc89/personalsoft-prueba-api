using FluentValidation;
using PersonalSoft.Prueba.Common.Classes.DTO;
using PersonalSoft.Prueba.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalSoft.Prueba.Domain.Validators
{
    public class RadicadoValidator : AbstractValidator<RadicadoDto>
    {
        private readonly IPolizaRepository _polizaRepository; 

        public RadicadoValidator(IPolizaRepository polizaRepository)
        {
            _polizaRepository = polizaRepository;

            RuleFor(model => model.FechaPoliza)
             .Custom((value, context) => ValidarPolizarVigente(value, context, context.InstanceToValidate.NroPoliza));
        }

        private void ValidarPolizarVigente(DateTime fechaPoliza, ValidationContext<RadicadoDto> context, string nroPoliza)
        {
            var poliza = _polizaRepository.GetAll().Where(x => x.NroPoliza == nroPoliza && fechaPoliza <= x.FechaVigencia).FirstOrDefault();

            if (poliza == null)
            {
                context.AddFailure("La poliza que está intentado crear no se encuentra vigente.");
            }
        }
    }
}
