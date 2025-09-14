namespace Vehiculo.Application.DTOs;


public class CreateVehiculoDto
{
    public Guid Id { get; set; }
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Placa { get; set; } = string.Empty;
}

public class UpdateVehiculoDto
{
    public Guid Id { get; set; }
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Placa { get; set; } = string.Empty;
}