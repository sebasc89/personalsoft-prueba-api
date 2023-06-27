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
    public interface IRadicadoService
    {
        IEnumerable<RadicadoDto> GetAll();
        RadicadoDto GetRadicadoInfoByFilter(string? placa, string? NroPoliza);
        RadicadoDto Add(RadicadoDto radicadoDto);
    }

    public class RadicadoService : IRadicadoService
    {
        private readonly IRadicadoRepository _radicadoRepository;
        private IMapper _mapper;

        public RadicadoService(IRadicadoRepository radicadoRepository, IMapper mapper)
        {
            _radicadoRepository = radicadoRepository;
            _mapper = mapper;   
        }

        public RadicadoDto Add(RadicadoDto radicadoDto)
        {
            var radicado = _mapper.Map<Radicado>(radicadoDto);
            return _mapper.Map<RadicadoDto>(_radicadoRepository.Add(radicado));
        }

        public IEnumerable<RadicadoDto> GetAll()
        {
            return _mapper.Map<IEnumerable<RadicadoDto>>(_radicadoRepository.GetAll());
        }

        public RadicadoDto GetRadicadoInfoByFilter(string? placa, string? NroPoliza)
        {
            return _mapper.Map<RadicadoDto>(_radicadoRepository.GetRadicadoInfoByFilter(placa, NroPoliza));
        }
    }
}
