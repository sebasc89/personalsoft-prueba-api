using PersonalSoft.Prueba.Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalSoft.Prueba.Infrastructure.Repositories
{
    public interface IRadicadoRepository
    {
        IEnumerable<Radicado> GetAll();
        Radicado GetRadicadoInfoByFilter(string? placa, string? NroPoliza);
        Radicado Add(Radicado radicado);
    }
}
