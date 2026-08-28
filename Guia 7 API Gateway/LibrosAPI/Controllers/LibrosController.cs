using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibrosAPI.Models;
using StackExchange.Redis;
using System.Text.Json;

[Route("api/[controller]")]
[ApiController]
public class LibrosController : ControllerBase
{
    private readonly LibrosDbContext _context;
    private readonly IConnectionMultiplexer _redis;

    public LibrosController(LibrosDbContext context, IConnectionMultiplexer redis)
    {
        _context = context;
        _redis = redis;
    }

    // GET: api/Libros
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Libro>>> GetLibros()
    {
        var cacheKey = "libros_list";

        try
        {
            var dbRedis = _redis.GetDatabase();
            var librosCache = await dbRedis.StringGetAsync(cacheKey);

            if (!librosCache.IsNullOrEmpty)
            {
                var cachedList = JsonSerializer.Deserialize<List<Libro>>(librosCache.ToString()!);
                if (cachedList != null) return cachedList;
            }
        }
        catch
        {
            // Fallback a base de datos
        }

        var libros = await _context.Libros.AsNoTracking().ToListAsync();

        try
        {
            var dbRedis = _redis.GetDatabase();
            await dbRedis.StringSetAsync(cacheKey, JsonSerializer.Serialize(libros), TimeSpan.FromMinutes(10));
        }
        catch
        {
        }

        return libros;
    }

    // GET: api/Libros/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Libro>> GetLibro(int id)
    {
        var cacheKey = $"libro_{id}";

        try
        {
            var dbRedis = _redis.GetDatabase();
            var libroCache = await dbRedis.StringGetAsync(cacheKey);

            if (!libroCache.IsNullOrEmpty)
            {
                var cachedItem = JsonSerializer.Deserialize<Libro>(libroCache.ToString()!);
                if (cachedItem != null) return cachedItem;
            }
        }
        catch
        {
            // Fallback a base de datos
        }

        var libro = await _context.Libros.FindAsync(id);

        if (libro == null)
        {
            return NotFound();
        }

        try
        {
            var dbRedis = _redis.GetDatabase();
            await dbRedis.StringSetAsync(cacheKey, JsonSerializer.Serialize(libro), TimeSpan.FromMinutes(10));
        }
        catch
        {
        }

        return libro;
    }

    // PUT: api/Libros/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutLibro(int id, Libro libro)
    {
        if (id != libro.Id)
        {
            return BadRequest();
        }

        _context.Entry(libro).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();

            try
            {
                var dbRedis = _redis.GetDatabase();
                var cacheKeyLibro = $"libro_{id}";
                var cacheKeyLista = "libros_list";

                await dbRedis.KeyDeleteAsync(cacheKeyLibro);
                await dbRedis.KeyDeleteAsync(cacheKeyLista);
            }
            catch
            {
            }
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LibroExists(id))
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

    // POST: api/Libros
    [HttpPost]
    public async Task<ActionResult<Libro>> PostLibro(Libro libro)
    {
        _context.Libros.Add(libro);
        await _context.SaveChangesAsync();

        try
        {
            var dbRedis = _redis.GetDatabase();
            var cacheKeyLista = "libros_list";
            await dbRedis.KeyDeleteAsync(cacheKeyLista);
        }
        catch
        {
        }

        return CreatedAtAction("GetLibro", new { id = libro.Id }, libro);
    }

    // DELETE: api/Libros/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLibro(int id)
    {
        var libro = await _context.Libros.FindAsync(id);
        if (libro == null)
        {
            return NotFound();
        }

        _context.Libros.Remove(libro);
        await _context.SaveChangesAsync();

        try
        {
            var dbRedis = _redis.GetDatabase();
            var cacheKeyLibro = $"libro_{id}";
            var cacheKeyLista = "libros_list";

            await dbRedis.KeyDeleteAsync(cacheKeyLibro);
            await dbRedis.KeyDeleteAsync(cacheKeyLista);
        }
        catch
        {
        }

        return NoContent();
    }

    private bool LibroExists(int id)
    {
        return _context.Libros.Any(e => e.Id == id);
    }
}
