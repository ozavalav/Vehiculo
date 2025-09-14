using Vehiculo.Application.DTOs;
using Vehiculo.Application.Commands;
using Vehiculo.Application.Queries;
using Vehiculo.Application.Services;


namespace Vehiculo.Application.Services;


public class VehiculoService : IVehiculoService
{
    private readonly CreateVehiculoHandler _createHandler;
    private readonly GetVehiculosHandler _getHandler;
    private readonly GetVehiculoByIdHandler _getById;
    private readonly UpdateVehiculoHandler _update;
    private readonly DeleteVehiculoHandler _delete;


    public VehiculoService(CreateVehiculoHandler createHandler, GetVehiculosHandler getHandler, GetVehiculoByIdHandler getById, UpdateVehiculoHandler update, DeleteVehiculoHandler delete)
    {
        _createHandler = createHandler;
        _getHandler = getHandler;
        _getById = getById;
        _update = update;
        _delete = delete;

    }


    public Task<CreateVehiculoDto> CreateAsync(CreateVehiculoDto dto, CancellationToken cancellationToken = default)
    {
        return _createHandler.Handle(new CreateVehiculoCommand(dto), cancellationToken);
    }


    public Task<IEnumerable<CreateVehiculoDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _getHandler.Handle(new GetVehiculosQuery(), cancellationToken);
    }

    public Task<CreateVehiculoDto?> GetByIdAsync(Guid id, CancellationToken ct = default)
    => _getById.Handle(new GetVehiculoByIdQuery(id), ct);


    public Task<UpdateVehiculoDto?> UpdateAsync(UpdateVehiculoDto dto, CancellationToken ct = default)
    => _update.Handle(new UpdateVehiculoCommand(dto), ct);


    public Task<bool> DeleteAsync(Guid id, CancellationToken ct = default)
    => _delete.Handle(new DeleteVehiculoCommand(id), ct);
}