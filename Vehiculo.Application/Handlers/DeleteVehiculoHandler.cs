using Vehiculo.Domain.Interfaces;

namespace Vehiculo.Application.Commands;

public class DeleteVehiculoHandler
{
private readonly IVehiculoRepository _repository;
public DeleteVehiculoHandler(IVehiculoRepository repository) => _repository = repository;

public Task<bool> Handle(DeleteVehiculoCommand command, CancellationToken ct = default)
=> _repository.DeleteAsync(command.Id, ct);
}