using Vehiculo.Application.DTOs;
using Vehiculo.Application.Commands;
using Vehiculo.Application.Queries;


namespace Vehiculo.Application.Services;

public interface IVehiculoService
{
Task<CreateVehiculoDto> CreateAsync(CreateVehiculoDto dto, CancellationToken cancellationToken = default);
Task<IEnumerable<CreateVehiculoDto>> GetAllAsync(CancellationToken cancellationToken = default);
}