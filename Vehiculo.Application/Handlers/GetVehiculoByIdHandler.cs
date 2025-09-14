using Vehiculo.Domain.Interfaces;
using Vehiculo.Application.DTOs;


namespace Vehiculo.Application.Queries;


public class GetVehiculoByIdHandler
{
private readonly IVehiculoRepository _repository;
public GetVehiculoByIdHandler(IVehiculoRepository repository) => _repository = repository;


public async Task<CreateVehiculoDto?> Handle(GetVehiculoByIdQuery query, CancellationToken ct = default)
{
var v = await _repository.GetByIdAsync(query.Id, ct);
return v == null ? null : new CreateVehiculoDto
{
Id = v.Id,
Marca = v.Marca,
Modelo = v.Modelo,
Year = v.Year,
Placa = v.Placa
};
}
}