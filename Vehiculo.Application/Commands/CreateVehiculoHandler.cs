using Vehiculo.Domain.Interfaces;
using Vehiculo.Domain.Entities;
using Vehiculo.Application.DTOs;


namespace Vehiculo.Application.Commands;


public class CreateVehiculoHandler
{
private readonly IVehiculoRepository _repository;


public CreateVehiculoHandler(IVehiculoRepository repository)
{
_repository = repository;
}


public async Task<CreateVehiculoDto> Handle(CreateVehiculoCommand command, CancellationToken cancellationToken = default)
{
var v = new Domain.Entities.Vehiculo
{
Marca = command.Vehiculo.Marca,
Modelo = command.Vehiculo.Modelo,
Year = command.Vehiculo.Year,
Placa = command.Vehiculo.Placa
};


var added = await _repository.AddAsync(v, cancellationToken);


return new CreateVehiculoDto
{
Id = added.Id,
Marca = added.Marca,
Modelo = added.Modelo,
Year = added.Year,
Placa = added.Placa
};
}
}