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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var v = await _service.GetByIdAsync(id);
        return v == null ? NotFound() : Ok(v);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateVehiculoDto dto)
    {
        if (id != dto.Id) return BadRequest("ID mismatch");
        var updated = await _service.UpdateAsync(dto);
        return updated == null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var ok = await _service.DeleteAsync(id);
        return ok ? NoContent() : NotFound();
    }    

}
