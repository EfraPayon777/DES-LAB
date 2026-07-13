using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCPeliculas.Models;
using MVCPeliculas.Data;

public class GenerosController : Controller
{
    private readonly PeliculasDbContext _context;

    public GenerosController(PeliculasDbContext context)
    {
        _context = context;
    }

    // GET: GENEROS
    public async Task<IActionResult> Index()
    {
        return View(await _context.Generos.ToListAsync());
    }

    // GET: GENEROS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var genero = await _context.Generos.FirstOrDefaultAsync(g => g.Id == id);
        if (genero == null) return NotFound();

        return View(genero);
    }

    // GET: GENEROS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: GENEROS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nombre")] Genero genero)
    {
        if (ModelState.IsValid)
        {
            _context.Add(genero);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(genero);
    }

    // GET: GENEROS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var genero = await _context.Generos.FindAsync(id);
        if (genero == null) return NotFound();
        return View(genero);
    }

    // POST: GENEROS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nombre")] Genero genero)
    {
        if (id != genero.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(genero);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Generos.Any(e => e.Id == genero.Id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(genero);
    }

    // GET: GENEROS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var genero = await _context.Generos.FirstOrDefaultAsync(g => g.Id == id);
        if (genero == null) return NotFound();

        return View(genero);
    }

    // POST: GENEROS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var genero = await _context.Generos.FindAsync(id);
        if (genero != null)
        {
            _context.Generos.Remove(genero);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
