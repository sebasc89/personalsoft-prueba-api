using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PersonalSoft.Prueba.Infrastructure.Database;
using PersonalSoft.Prueba.Infrastructure.Database.Context;
using PersonalSoft.Prueba.Infrastructure.Database.Entities;

namespace PersonalSoft.Prueba.Infrastructure.Repositories
{
    public class PolizaRepository : IPolizaRepository
    {
        private readonly PolizasSegurosDBContext _polizasSegurosDbContext;
        public PolizaRepository(PolizasSegurosDBContext polizasSegurosDBContext)
        {
            _polizasSegurosDbContext = polizasSegurosDBContext;
        }

        public Poliza Add(Poliza poliza)
        {
            _polizasSegurosDbContext.Polizas.Add(poliza);
            _polizasSegurosDbContext.SaveChanges();
            return poliza;
        }

        public IEnumerable<Poliza> GetAll()
        {
            var polizas = _polizasSegurosDbContext.Polizas.ToList();
            return polizas;
        }
    }
}
