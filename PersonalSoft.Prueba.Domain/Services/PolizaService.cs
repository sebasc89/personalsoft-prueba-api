using AutoMapper;
using PersonalSoft.Prueba.Common.Classes.DTO;
using PersonalSoft.Prueba.Infrastructure.Database.Entities;
using PersonalSoft.Prueba.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalSoft.Prueba.Domain.Services
{
    public interface IPolizaService
    {
        IEnumerable<PolizaDto> GetAll();
        PolizaDto Add(PolizaDto polizaDto);
    }

    public class PolizaService : IPolizaService
    {
        private readonly IPolizaRepository _polizaRepository;
        private IMapper _mapper;

        public PolizaService(IPolizaRepository polizaRepository, IMapper mapper)
        {
            _polizaRepository = polizaRepository;
            _mapper = mapper;   
        }

        public PolizaDto Add(PolizaDto polizaDto)
        {
            var poliza = _mapper.Map<Poliza>(polizaDto);
            return _mapper.Map<PolizaDto>(_polizaRepository.Add(poliza));
        }

        public IEnumerable<PolizaDto> GetAll()
        {
            return _mapper.Map<IEnumerable<PolizaDto>>(_polizaRepository.GetAll());
        }
    }
}
