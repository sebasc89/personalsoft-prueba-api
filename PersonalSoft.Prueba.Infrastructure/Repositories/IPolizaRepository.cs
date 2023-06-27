using PersonalSoft.Prueba.Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalSoft.Prueba.Infrastructure.Repositories
{
    public interface IPolizaRepository
    {
        IEnumerable<Poliza> GetAll();
        Poliza Add(Poliza poliza);
    }
}
