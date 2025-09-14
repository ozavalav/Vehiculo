using Vehiculo.Domain.Entities;

namespace Vehiculo.Domain.Interfaces;

public interface IVehiculoRepository
{
    Task<Vehiculo.Domain.Entities.Vehiculo> AddAsync(Vehiculo.Domain.Entities.Vehiculo vehiculo, CancellationToken cancellationToken = default);
    Task<IEnumerable<Vehiculo.Domain.Entities.Vehiculo>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Vehiculo.Domain.Entities.Vehiculo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Vehiculo.Domain.Entities.Vehiculo?> UpdateAsync(Vehiculo.Domain.Entities.Vehiculo vehiculo, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}