using Microsoft.EntityFrameworkCore;
using Vehiculo.Domain.Interfaces;
using Vehiculo.Domain.Entities;
using Vehiculo.Infrastructure.Data;


namespace Vehiculo.Infrastructure.Repositories;


public class VehiculoRepository : IVehiculoRepository
{
private readonly VehiculoDbContext _context;


public VehiculoRepository(VehiculoDbContext context)
{
_context = context;
}


public async Task<Vehiculo.Domain.Entities.Vehiculo> AddAsync(Vehiculo.Domain.Entities.Vehiculo Vehiculo, CancellationToken cancellationToken = default)
{
var entry = await _context.Vehiculos.AddAsync(Vehiculo, cancellationToken);
await _context.SaveChangesAsync(cancellationToken);
return entry.Entity;
}


public async Task<IEnumerable<Vehiculo.Domain.Entities.Vehiculo>> GetAllAsync(CancellationToken cancellationToken = default)
{
return await _context.Vehiculos.AsNoTracking().ToListAsync(cancellationToken);
}
}