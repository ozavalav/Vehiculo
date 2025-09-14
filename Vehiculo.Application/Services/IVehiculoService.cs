using Vehiculo.Application.DTOs;
using Vehiculo.Application.Commands;
using Vehiculo.Application.Queries;


namespace Vehiculo.Application.Services;

public interface IVehiculoService
{
    Task<CreateVehiculoDto> CreateAsync(CreateVehiculoDto dto, CancellationToken cancellationToken = default);
    Task<IEnumerable<CreateVehiculoDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<CreateVehiculoDto?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<UpdateVehiculoDto?> UpdateAsync(UpdateVehiculoDto dto, CancellationToken ct = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken ct = default);
}