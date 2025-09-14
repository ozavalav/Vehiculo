using Vehiculo.Domain.Interfaces;
using Vehiculo.Application.DTOs;


namespace Vehiculo.Application.Commands;


public class UpdateVehiculoHandler
{
private readonly IVehiculoRepository _repository;
public UpdateVehiculoHandler(IVehiculoRepository repository) => _repository = repository;


public async Task<UpdateVehiculoDto?> Handle(UpdateVehiculoCommand command, CancellationToken ct = default)
{
var updated = await _repository.UpdateAsync(new Vehiculo.Domain.Entities.Vehiculo
{
    Id = command.Vehiculo.Id,
    Marca = command.Vehiculo.Marca,
    Modelo = command.Vehiculo.Modelo,
    Year = command.Vehiculo.Year,
    Placa = command.Vehiculo.Placa
}, ct);
return updated == null ? null : new UpdateVehiculoDto
{
    Id = updated.Id,
    Marca = updated.Marca,
    Modelo = updated.Modelo,
    Year = updated.Year,
    Placa = updated.Placa
};
}
}