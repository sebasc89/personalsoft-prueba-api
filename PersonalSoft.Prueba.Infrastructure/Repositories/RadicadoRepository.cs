using PersonalSoft.Prueba.Infrastructure.Database.Context;
using PersonalSoft.Prueba.Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PersonalSoft.Prueba.Infrastructure.Repositories
{
    public class RadicadoRepository : IRadicadoRepository
    {
        private readonly PolizasSegurosDBContext _polizasSegurosDbContext;
        public RadicadoRepository(PolizasSegurosDBContext polizasSegurosDBContext)
        {
            _polizasSegurosDbContext = polizasSegurosDBContext;
        }

        public Radicado Add(Radicado radicado)
        {
            _polizasSegurosDbContext.Radicados.Add(radicado);
            _polizasSegurosDbContext.SaveChanges();
            return radicado;
        }

        public IEnumerable<Radicado> GetAll()
        {
            var radicados = _polizasSegurosDbContext.Radicados.ToList();
            return radicados;
        }

        public Radicado GetRadicadoInfoByFilter(string? placa, string? NroPoliza)
        {
            var radicados = _polizasSegurosDbContext.Radicados;
            var radicado = new Radicado();

            if (!string.IsNullOrEmpty(placa))
            {
                radicado = radicados.Where(u => u.Placa.Contains(placa)).FirstOrDefault();
            }

            if (!string.IsNullOrEmpty(NroPoliza))
            {
                radicado = radicados.Where(u => u.NroPoliza.Contains(NroPoliza)).FirstOrDefault();
            }

            return radicado ?? new Radicado();
        }
    }
}
