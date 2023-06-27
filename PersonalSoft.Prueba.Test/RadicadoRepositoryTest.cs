using Moq;
using PersonalSoft.Prueba.Infrastructure.Database.Entities;
using PersonalSoft.Prueba.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalSoft.Prueba.Test
{
    public class RadicadoRepositoryTest
    {
        [Fact]
        public void GetAll_ReturnsList()
        {
            // Arrange
            var radicadoRepositoryMock = new Mock<IRadicadoRepository>();

            var radicado = new Radicado
            {
                NroPoliza = "888",
                NombreCliente = "Luis perez",
                IdentificacionCliente = "24234234",
                FechaNacimiento = new DateTime(1988,03,12),
                FechaPoliza = new DateTime(),
                Coberturas = new List<string> { "Prueba"},
                ValorMaximoCubierto = 435435345,
                NombrePlan = "Plan de prueba",
                CiudadCliente = "Bogota",
                Placa = "XXX100",
                Modelo = "2023",
                TieneInspeccion = true
            };

            radicadoRepositoryMock.Setup(r => r.GetAll())
           .Returns(new List<Radicado>() { radicado });

            var repositorio = radicadoRepositoryMock.Object;

            Assert.NotNull(repositorio.GetAll());
        }
    }
}
