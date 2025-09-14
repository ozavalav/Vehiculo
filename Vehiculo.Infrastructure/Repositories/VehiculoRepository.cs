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

    public async Task<Vehiculo.Domain.Entities.Vehiculo?> GetByIdAsync(Guid id, CancellationToken ct = default)
=> await _context.Vehiculos.AsNoTracking().FirstOrDefaultAsync(v => v.Id == id, ct);

    public async Task<Vehiculo.Domain.Entities.Vehiculo?> UpdateAsync(Vehiculo.Domain.Entities.Vehiculo vehiculo, CancellationToken ct = default)
    {
        var existing = await _context.Vehiculos.FindAsync(new object?[] { vehiculo.Id }, ct);
        if (existing == null) return null;
        _context.Entry(existing).CurrentValues.SetValues(vehiculo);
        await _context.SaveChangesAsync(ct);
        return existing;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var existing = await _context.Vehiculos.FindAsync(new object?[] { id }, ct);
        if (existing == null) return false;
        _context.Vehiculos.Remove(existing);
        await _context.SaveChangesAsync(ct);
        return true;
    }

}