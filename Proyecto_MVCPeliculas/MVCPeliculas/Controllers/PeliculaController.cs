
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCPeliculas.Models;
using MVCPeliculas.Data;

public class PeliculaController : Controller
{
    private readonly PeliculasDbContext _context;

    public PeliculaController(PeliculasDbContext context)
    {
        _context = context;
    }

    // GET: PELICULAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Peliculas.ToListAsync());
    }

    // GET: PELICULAS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pelicula = await _context.Peliculas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (pelicula == null)
        {
            return NotFound();
        }

        return View(pelicula);
    }

    // GET: PELICULAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PELICULAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Titulo,FechaLanzamiento,Precio,Director,GeneroId,Genero")] Pelicula pelicula)
    {
        if (ModelState.IsValid)
        {
            _context.Add(pelicula);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(pelicula);
    }

    // GET: PELICULAS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pelicula = await _context.Peliculas.FindAsync(id);
        if (pelicula == null)
        {
            return NotFound();
        }
        return View(pelicula);
    }

    // POST: PELICULAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Titulo,FechaLanzamiento,Precio,Director,GeneroId,Genero")] Pelicula pelicula)
    {
        if (id != pelicula.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(pelicula);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeliculaExists(pelicula.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(pelicula);
    }

    // GET: PELICULAS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var pelicula = await _context.Peliculas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (pelicula == null)
        {
            return NotFound();
        }

        return View(pelicula);
    }

    // POST: PELICULAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var pelicula = await _context.Peliculas.FindAsync(id);
        if (pelicula != null)
        {
            _context.Peliculas.Remove(pelicula);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PeliculaExists(int? id)
    {
        return _context.Peliculas.Any(e => e.Id == id);
    }
}
