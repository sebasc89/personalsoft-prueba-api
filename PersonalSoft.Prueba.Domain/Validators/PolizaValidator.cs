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
    public class PolizaValidator : AbstractValidator<PolizaDto>
    {
        private readonly IPolizaRepository _polizaRepository;

        public PolizaValidator(IPolizaRepository polizaRepository)
        {
            _polizaRepository = polizaRepository;

            RuleFor(model => model.NroPoliza)
             .Custom((value, context) => ValidarPolizaExistente(value, context));
        }

        private void ValidarPolizaExistente(string nroPoliza, ValidationContext<PolizaDto> context)
        {
            var poliza = _polizaRepository.GetAll().Where(x => x.NroPoliza == nroPoliza).FirstOrDefault();

            if (poliza != null)
            {
                context.AddFailure("Ya existe una poliza con el mismo número en la base de datos.");
            }
        }
    }
}
