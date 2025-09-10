using Microsoft.AspNetCore.Mvc;
using Vehiculo.Application.Services;
using Vehiculo.Application.DTOs;
namespace Vehiculo.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiculosController : ControllerBase
{
    private readonly IVehiculoService _service;
    public VehiculosController(IVehiculoService service)
    {
        _service = service;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var list = await _service.GetAllAsync();
        return Ok(list);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateVehiculoDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
    }
}
