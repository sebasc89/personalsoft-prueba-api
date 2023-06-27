using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoFramework;
using PersonalSoft.Prueba.Common.Classes.DTO;
using PersonalSoft.Prueba.Infrastructure.Database.Context;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;

namespace PersonalSoft.Prueba.Common.Dependencies
{
    public class Container
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            #region Mapper

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            var mapper = configMapper.CreateMapper();

            services.AddSingleton(mapper);

            #endregion

            #region Database 

            // Add services to the container.
            services.AddTransient<IMongoDbConnection>(sp =>
                MongoDbConnection.FromConnectionString(configuration.GetConnectionString("PolizasSegurosDbConnection")));
            services.AddTransient<PolizasSegurosDBContext>();

            #endregion

            #region FluentValidation

            services.AddControllers().AddFluentValidation(options =>
            {
                options.ImplicitlyValidateChildProperties = true;
                options.ImplicitlyValidateRootCollectionElements = true;
                options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });
            #endregion
        }
    }
}
