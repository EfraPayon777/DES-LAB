using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ejercicio_1_LAB_3.Data;
using Ejercicio_1_LAB_3.Models;

namespace Ejercicio_1_LAB_3.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(AppDbContext context, ILogger<EmployeesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string? searchString)
        {
            var q = _context.Employees.AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                searchString = searchString.Trim();
                q = q.Where(e => e.FirstName.Contains(searchString) || e.LastName.Contains(searchString) || e.Position.Contains(searchString));
                ViewData["CurrentFilter"] = searchString;
            }
            return View(await q.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,HireDate,Position")] Employee employee)
        {
            // Server-side validation: HireDate cannot be in the future
            if (employee.HireDate > DateTime.Today)
            {
                ModelState.AddModelError(nameof(employee.HireDate), "La fecha de contratación no puede ser posterior a hoy.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Collect ModelState errors to show on page
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            ViewData["ServerErrors"] = errors;

            // Log ModelState errors for debugging
            _logger.LogWarning("ModelState invalid when creating Employee");
            foreach (var kv in ModelState)
            {
                if (kv.Value.Errors.Count > 0)
                {
                    _logger.LogWarning("Field {Field} has {Count} errors: {Errors}", kv.Key, kv.Value.Errors.Count, string.Join(";", kv.Value.Errors.Select(e => e.ErrorMessage)));
                }
            }
            _logger.LogDebug("Employee values: FirstName={FirstName}, LastName={LastName}, HireDate={HireDate}, Position={Position}", employee.FirstName, employee.LastName, employee.HireDate, employee.Position);

            return View(employee);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,HireDate,Position")] Employee employee)
        {
            if (id != employee.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
