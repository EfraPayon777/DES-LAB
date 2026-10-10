using CC230286_DESAFIO_03.BL.Interfaces;
using CC230286_DESAFIO_03.Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CC230286_DESAFIO_03.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private readonly IPedidoService _pedidoService;

    public PedidosController(IPedidoService pedidoService)
    {
        _pedidoService = pedidoService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PedidoDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll()
    {
        var pedidos = await _pedidoService.GetAllAsync();
        return pedidos.Count > 0 ? Ok(pedidos) : NoContent();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PedidoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var pedido = await _pedidoService.GetByIdAsync(id);
        return pedido != null ? Ok(pedido) : NotFound(new { mensaje = $"Pedido con Id {id} no encontrado." });
    }

    [HttpPost]
    [ProducesResponseType(typeof(PedidoDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Post([FromBody] PedidoDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var created = await _pedidoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { mensaje = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _pedidoService.DeleteAsync(id);
        return result ? Ok(new { mensaje = $"Pedido con Id {id} eliminado correctamente." }) : NotFound(new { mensaje = $"Pedido con Id {id} no encontrado." });
    }
}
