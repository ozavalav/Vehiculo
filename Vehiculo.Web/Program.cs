using Microsoft.EntityFrameworkCore;
using Vehiculo.Infrastructure.Data;
using Vehiculo.Infrastructure.Repositories;
using Vehiculo.Domain.Interfaces;
using Vehiculo.Application.Services;
using Vehiculo.Application.Commands;
using Vehiculo.Application.Queries;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// EF Core InMemory (para demo). Para producción usar SQL Server, Postgres, etc.
builder.Services.AddDbContext<VehiculoDbContext>(options => options.UseInMemoryDatabase("VehiculosDb"));

// Repositorios
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();
// Handlers
builder.Services.AddScoped<CreateVehiculoHandler>();
builder.Services.AddScoped<GetVehiculosHandler>();
builder.Services.AddScoped<GetVehiculoByIdHandler>();
builder.Services.AddScoped<DeleteVehiculoHandler>();
builder.Services.AddScoped<UpdateVehiculoHandler>();
// Servicio de aplicación
builder.Services.AddScoped<IVehiculoService, VehiculoService>();
var app = builder.Build();
// Seed data opcional
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<VehiculoDbContext>();
    if (!ctx.Vehiculos.Any())
    {
        ctx.Vehiculos.AddRange(new[] {
        new Vehiculo.Domain.Entities.Vehiculo { Marca = "Toyota", Modelo =
        "Corolla", Year = 2010, Placa = "ABC-123" },
        new Vehiculo.Domain.Entities.Vehiculo { Marca = "Honda", Modelo =
        "Civic", Year = 2020, Placa = "XYZ-789" }
        });
        ctx.SaveChanges();
    }
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();