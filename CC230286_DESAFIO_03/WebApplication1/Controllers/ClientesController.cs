using CC230286_DESAFIO_03.BL.Interfaces;
using CC230286_DESAFIO_03.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CC230286_DESAFIO_03.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClientesController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ClienteDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll()
    {
        var clientes = await _clienteService.GetAllAsync();
        return clientes.Count > 0 ? Ok(clientes) : NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var cliente = await _clienteService.GetByIdAsync(id);
        return cliente != null ? Ok(cliente) : NotFound(new { mensaje = $"Cliente con Id {id} no encontrado." });
    }

    [HttpPost]
    [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] ClienteDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = await _clienteService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Put(int id, [FromBody] ClienteDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _clienteService.UpdateAsync(id, dto);
        return updated != null ? Ok(updated) : NotFound(new { mensaje = $"Cliente con Id {id} no encontrado." });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _clienteService.DeleteAsync(id);
        return result ? Ok(new { mensaje = $"Cliente con Id {id} eliminado correctamente." }) : NotFound(new { mensaje = $"Cliente con Id {id} no encontrado." });
    }
}
