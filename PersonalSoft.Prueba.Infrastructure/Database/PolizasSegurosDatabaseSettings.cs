using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalSoft.Prueba.Infrastructure.Database
{
    public class PolizasSegurosDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string PolizasCollectionName { get; set; } = null!;
        public string RadicadosCollectionName { get; set; } = null!;
    }
}
