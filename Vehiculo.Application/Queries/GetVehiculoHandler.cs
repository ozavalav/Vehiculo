using Vehiculo.Domain.Interfaces;
using Vehiculo.Application.DTOs;

namespace Vehiculo.Application.Queries;

public class GetVehiculosHandler
{
private readonly IVehiculoRepository _repository;


public GetVehiculosHandler(IVehiculoRepository repository)
{
_repository = repository;
}

public async Task<IEnumerable<CreateVehiculoDto>> Handle(GetVehiculosQuery query, CancellationToken cancellationToken = default)
{
var list = await _repository.GetAllAsync(cancellationToken);
return list.Select(v => new CreateVehiculoDto
{
Id = v.Id,
Marca = v.Marca,
Modelo = v.Modelo,
Year = v.Year,
Placa = v.Placa
});
}
}