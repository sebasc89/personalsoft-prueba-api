using AutoMapper;
using PersonalSoft.Prueba.Common.Classes.DTO;
using PersonalSoft.Prueba.Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalSoft.Prueba.Common.Dependencies
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Poliza, PolizaDto>().ReverseMap();
            CreateMap<Radicado, RadicadoDto>().ReverseMap();
        } 
    }
}
