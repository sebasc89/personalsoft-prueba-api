using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalSoft.Prueba.Infrastructure.Database.Entities
{
    [Table("Radicados")]
    public class Radicado
    {
        public ObjectId Id { get; set; }

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
