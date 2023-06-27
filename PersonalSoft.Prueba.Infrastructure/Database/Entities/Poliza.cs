using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalSoft.Prueba.Infrastructure.Database.Entities
{
    [Table("Polizas")]
    public class Poliza
    {
        public ObjectId Id { get; set; }

        public string NroPoliza { get; set; } = null!;

        public DateTime FechaInicio { get; set; }

        public  DateTime FechaVigencia { get; set; }

    }
}
