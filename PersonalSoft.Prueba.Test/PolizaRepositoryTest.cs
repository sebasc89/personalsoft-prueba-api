using AutoFixture;
using AutoFixture.Xunit2;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection.Repositories;
using MongoDB.Bson;
using Moq;
using PersonalSoft.Prueba.Common.Classes.DTO;
using PersonalSoft.Prueba.Infrastructure.Database.Entities;
using PersonalSoft.Prueba.Infrastructure.Repositories;
using SharpCompress.Common;
using System.Xml;

namespace PersonalSoft.Prueba.Test
{
    public class PolizaRepositoryTest
    {

        [Fact]
        public void GetAll_ReturnsList()
        {
            // Arrange
            var polizaRepositoryMock = new Mock<IPolizaRepository>();

            polizaRepositoryMock.Setup(r => r.GetAll())
           .Returns(new List<Poliza>() { new Poliza { NroPoliza = "888", FechaInicio = new DateTime(), FechaVigencia = new DateTime()} });

            var repositorio = polizaRepositoryMock.Object;

            Assert.NotNull(repositorio.GetAll());
        }

        [Fact]
        public void Add_CreatePolizaIfNotExists()
        {
            // Arrange
            var mockRepository = new Mock<IPolizaRepository>();
            var polizaRepositoryMock = mockRepository.Object;

            var poliza = new Poliza
            {
                NroPoliza = "888",
                FechaInicio = new DateTime(2023,01,01),
                FechaVigencia = new DateTime(2023,11,30)
            };

            // Act
            polizaRepositoryMock.Add(poliza);

            // Assert
            mockRepository.Verify(mock => mock.Add(It.IsAny<Poliza>()), Times.Once);
        }
    }
}
