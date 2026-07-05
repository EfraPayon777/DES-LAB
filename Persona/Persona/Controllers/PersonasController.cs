using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persona.Data;
using PersonaApp.Models;
using System.Threading.Tasks;

namespace Persona.Controllers
{
    public class PersonasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _context.Personas.AsNoTracking().ToListAsync();
            return View(list);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return NotFound();
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null) return NotFound();
            return View(persona);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonaApp.Models.Persona persona)
        {
            if (ModelState.IsValid)
            {
                if (await _context.Personas.FindAsync(persona.DUI) == null)
                {
                    _context.Personas.Add(persona);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null) return NotFound();
            return View(persona);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, PersonaApp.Models.Persona persona)
        {
            if (id != persona.DUI) return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Personas.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _context.Personas.FindAsync(id) == null)
                        return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null) return NotFound();
            return View(persona);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
