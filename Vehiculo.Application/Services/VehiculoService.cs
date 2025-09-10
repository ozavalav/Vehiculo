using Vehiculo.Application.DTOs;
using Vehiculo.Application.Commands;
using Vehiculo.Application.Queries;
using Vehiculo.Application.Services;


namespace Vehiculo.Application.Services;


public class VehiculoService : IVehiculoService
{
private readonly CreateVehiculoHandler _createHandler;
private readonly GetVehiculosHandler _getHandler;


public VehiculoService(CreateVehiculoHandler createHandler, GetVehiculosHandler getHandler)
{
_createHandler = createHandler;
_getHandler = getHandler;
}


public Task<CreateVehiculoDto> CreateAsync(CreateVehiculoDto dto, CancellationToken cancellationToken = default)
{
return _createHandler.Handle(new CreateVehiculoCommand(dto), cancellationToken);
}


public Task<IEnumerable<CreateVehiculoDto>> GetAllAsync(CancellationToken cancellationToken = default)
{
return _getHandler.Handle(new GetVehiculosQuery(), cancellationToken);
}
}