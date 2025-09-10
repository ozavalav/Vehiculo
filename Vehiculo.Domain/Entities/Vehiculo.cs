namespace Vehiculo.Domain.Entities;


public class Vehiculo
{
public Guid Id { get; set; } = Guid.NewGuid();
public string Marca { get; set; } = string.Empty; // Marca
public string Modelo { get; set; } = string.Empty;
public int Year { get; set; }
public string Placa { get; set; } = string.Empty;
}