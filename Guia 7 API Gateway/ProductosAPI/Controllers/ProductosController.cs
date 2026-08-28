using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductosAPI.Models;
using StackExchange.Redis;
using System.Text.Json;

[Route("api/[controller]")]
[ApiController]
public class ProductosController : ControllerBase
{
    private readonly ProductosDbContext _context;
    private readonly IConnectionMultiplexer _redis;

    public ProductosController(
        ProductosDbContext context,
        IConnectionMultiplexer redis)
    {
        _context = context;
        _redis = redis;
    }

    // GET: api/Productos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
    {
        var cacheKey = "productos_list";

        try
        {
            var dbRedis = _redis.GetDatabase();
            var productosCache = await dbRedis.StringGetAsync(cacheKey);

            if (!productosCache.IsNullOrEmpty)
            {
                var cachedList = JsonSerializer.Deserialize<List<Producto>>(productosCache.ToString()!);
                if (cachedList != null) return cachedList;
            }
        }
        catch
        {
            // Fallback a base de datos
        }

        var productos = await _context.Productos.AsNoTracking().ToListAsync();

        try
        {
            var dbRedis = _redis.GetDatabase();
            await dbRedis.StringSetAsync(cacheKey, JsonSerializer.Serialize(productos), TimeSpan.FromMinutes(10));
        }
        catch
        {
        }

        return productos;
    }

    // GET: api/Productos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Producto>> GetProducto(int id)
    {
        var cacheKey = $"producto_{id}";

        try
        {
            var dbRedis = _redis.GetDatabase();
            var productoChace = await dbRedis.StringGetAsync(cacheKey);

            if (!productoChace.IsNullOrEmpty)
            {
                var cachedItem = JsonSerializer.Deserialize<Producto>(productoChace.ToString()!);
                if (cachedItem != null) return cachedItem;
            }
        }
        catch
        {
            // Fallback a base de datos
        }

        var producto = await _context.Productos.FindAsync(id);

        if (producto == null)
        {
            return NotFound();
        }

        try
        {
            var dbRedis = _redis.GetDatabase();
            await dbRedis.StringSetAsync(cacheKey, JsonSerializer.Serialize(producto), TimeSpan.FromMinutes(10));
        }
        catch
        {
        }

        return producto;
    }

    // PUT: api/Productos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProducto(int id, Producto producto)
    {
        if (id != producto.Id)
        {
            return BadRequest();
        }

        _context.Entry(producto).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();

            try
            {
                var dbRedis = _redis.GetDatabase();
                var cacheKeyProducto = $"producto_{id}";
                var cacheKeyLista = "productos_list";

                await dbRedis.KeyDeleteAsync(cacheKeyProducto);
                await dbRedis.KeyDeleteAsync(cacheKeyLista);
            }
            catch
            {
            }
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductoExists(id))
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

    // POST: api/Productos
    [HttpPost]
    public async Task<ActionResult<Producto>> PostProducto(Producto producto)
    {
        _context.Productos.Add(producto);
        await _context.SaveChangesAsync();

        try
        {
            var dbRedis = _redis.GetDatabase();
            var cacheKeyLista = "productos_list";
            await dbRedis.KeyDeleteAsync(cacheKeyLista);
        }
        catch
        {
        }

        return CreatedAtAction("GetProducto", new { id = producto.Id }, producto);
    }

    // DELETE: api/Productos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProducto(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto == null)
        {
            return NotFound();
        }

        _context.Productos.Remove(producto);
        await _context.SaveChangesAsync();

        try
        {
            var dbRedis = _redis.GetDatabase();
            var cacheKeyProducto = $"producto_{id}";
            var cacheKeyLista = "productos_list";

            await dbRedis.KeyDeleteAsync(cacheKeyProducto);
            await dbRedis.KeyDeleteAsync(cacheKeyLista);
        }
        catch
        {
        }

        return NoContent();
    }

    private bool ProductoExists(int? id)
    {
        return _context.Productos.Any(e => e.Id == id);
    }
}
