using MongoFramework;
using PersonalSoft.Prueba.Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalSoft.Prueba.Infrastructure.Database.Context
{
    public class PolizasSegurosDBContext : MongoDbContext
    {
        public PolizasSegurosDBContext(IMongoDbConnection connection)
        : base(connection)
        {
        }

        public MongoDbSet<Poliza> Polizas { get; set; } = null!;
        public MongoDbSet<Radicado> Radicados { get; set; } = null!;
    }
}
