using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalSoft.Prueba.Common.Classes.DTO
{
    public class RadicadoDto
    {
        public string NroPoliza { get; set; } = null!;

        public string NombreCliente { get; set; } = null!;
        public string IdentificacionCliente { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }

        public DateTime FechaPoliza { get; set; }

        public List<string> Coberturas { get; set; } = null!;

        public int ValorMaximoCubierto { get; set; }

        public string NombrePlan { get; set; } = null!;

        public string CiudadCliente { get; set; } = null!;

        public string Placa { get; set; } = null!;

        public string Modelo { get; set; } = null!;
        public bool TieneInspeccion { get; set; }
    }
}
