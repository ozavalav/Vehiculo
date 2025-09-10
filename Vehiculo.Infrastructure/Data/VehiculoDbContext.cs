using Microsoft.EntityFrameworkCore;
using Vehiculo.Domain.Entities;

namespace Vehiculo.Infrastructure.Data;

public class VehiculoDbContext : DbContext
{
public VehiculoDbContext(DbContextOptions<VehiculoDbContext> options) : base(options) { }


public DbSet<Vehiculo.Domain.Entities.Vehiculo> Vehiculos { get; set; }


protected override void OnModelCreating(ModelBuilder modelBuilder)
{
base.OnModelCreating(modelBuilder);
modelBuilder.Entity<Vehiculo.Domain.Entities.Vehiculo>(b => {
b.HasKey(x => x.Id);
b.Property(x => x.Marca).IsRequired();
b.Property(x => x.Modelo).IsRequired();
b.Property(x => x.Placa).IsRequired();
});
}
}