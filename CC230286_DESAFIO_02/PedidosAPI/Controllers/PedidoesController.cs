using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidosAPI.Models;

[Route("api/pedidos")]
[ApiController]
public class PedidoesController : ControllerBase
{
    private readonly PedidosDbContext _context;
    public PedidoesController(PedidosDbContext context)
    {
        _context = context;
    }

    // GET: api/Pedido
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pedido>>> GetPedido()
    {
        return await _context.Pedidos.ToListAsync();
    }

    // GET: api/Pedido/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Pedido>> GetPedido(int id)
    {
        var pedido = await _context.Pedidos.FindAsync(id);

        if (pedido == null)
        {
            return NotFound();
        }

        return pedido;
    }

    // PUT: api/Pedido/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPedido(int? id, Pedido pedido)
    {
        if (id != pedido.Id)
        {
            return BadRequest();
        }

        _context.Entry(pedido).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PedidoExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Pedido
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
    {
        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPedido", new { id = pedido.Id }, pedido);
    }

    // DELETE: api/Pedido/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePedido(int? id)
    {
        var pedido = await _context.Pedidos.FindAsync(id);
        if (pedido == null)
        {
            return NotFound();
        }

        _context.Pedidos.Remove(pedido);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PedidoExists(int? id)
    {
        return _context.Pedidos.Any(e => e.Id == id);
    }
}
