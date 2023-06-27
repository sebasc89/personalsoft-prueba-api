using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalSoft.Prueba.Common.Classes.DTO
{
    public class PolizaDto
    {

        public string NroPoliza { get; set; } = null!;

        public DateTime FechaInicio { get; set; }

        public DateTime FechaVigencia { get; set; }
    }
}
