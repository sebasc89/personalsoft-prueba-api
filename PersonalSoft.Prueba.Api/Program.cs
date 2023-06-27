using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using MongoFramework;
using PersonalSoft.Prueba.Common.Classes.DTO;
using PersonalSoft.Prueba.Common.Dependencies;
using PersonalSoft.Prueba.Domain.Services;
using PersonalSoft.Prueba.Domain.Validators;
using PersonalSoft.Prueba.Infrastructure.Database.Context;
using PersonalSoft.Prueba.Infrastructure.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

Container.Register(builder.Services, builder.Configuration);

builder.Services.AddTransient<IValidator<RadicadoDto>, RadicadoValidator>();
builder.Services.AddTransient<IValidator<PolizaDto>, PolizaValidator>();

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
//    AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = "",
//            ValidAudience = "",
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(""))
//        };
//    });

builder.Services.AddTransient<IPolizaRepository, PolizaRepository>();
builder.Services.AddTransient<IRadicadoRepository, RadicadoRepository>();
builder.Services.AddTransient<IRadicadoService, RadicadoService>();
builder.Services.AddTransient<IPolizaService, PolizaService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
