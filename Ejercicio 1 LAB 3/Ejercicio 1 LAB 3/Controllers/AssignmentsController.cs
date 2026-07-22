using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ejercicio_1_LAB_3.Data;
using Ejercicio_1_LAB_3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ejercicio_1_LAB_3.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly AppDbContext _context;

        public AssignmentsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? searchString)
        {
            var assignments = _context.Assignments
                .Include(a => a.Employee)
                .Include(a => a.Project)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                searchString = searchString.Trim();
                assignments = assignments.Where(a => a.Role.Contains(searchString)
                    || a.Employee.FirstName.Contains(searchString)
                    || a.Employee.LastName.Contains(searchString)
                    || a.Project.Name.Contains(searchString));
                ViewData["CurrentFilter"] = searchString;
            }

            return View(await assignments.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var assignment = await _context.Assignments
                .Include(a => a.Employee)
                .Include(a => a.Project)
                .FirstOrDefaultAsync(a => a.Id == id);
            if (assignment == null) return NotFound();
            return View(assignment);
        }

        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,ProjectId,AssignedDate,Role")] Assignment assignment)
        {
            // Basic server-side validations
            if (assignment.AssignedDate > DateTime.Today)
            {
                ModelState.AddModelError(nameof(assignment.AssignedDate), "La fecha de asignación no puede ser posterior a hoy.");
            }

            // Prevent duplicate assignment for same employee and project
            if (_context.Assignments.Any(a => a.EmployeeId == assignment.EmployeeId && a.ProjectId == assignment.ProjectId))
            {
                ModelState.AddModelError(string.Empty, "Este empleado ya está asignado a este proyecto.");
            }

            // Ensure employee and project exist and dates make sense
            var employee = await _context.Employees.FindAsync(assignment.EmployeeId);
            var project = await _context.Projects.FindAsync(assignment.ProjectId);
            if (employee == null) ModelState.AddModelError(nameof(assignment.EmployeeId), "Empleado no encontrado.");
            if (project == null) ModelState.AddModelError(nameof(assignment.ProjectId), "Proyecto no encontrado.");

            if (employee != null && assignment.AssignedDate < employee.HireDate)
            {
                ModelState.AddModelError(nameof(assignment.AssignedDate), "La fecha de asignación no puede ser anterior a la fecha de contratación del empleado.");
            }
            if (project != null && assignment.AssignedDate < project.StartDate)
            {
                ModelState.AddModelError(nameof(assignment.AssignedDate), "La fecha de asignación no puede ser anterior a la fecha de inicio del proyecto.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(assignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", assignment.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", assignment.ProjectId);
            return View(assignment);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null) return NotFound();
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", assignment.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", assignment.ProjectId);
            return View(assignment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,ProjectId,AssignedDate,Role")] Assignment assignment)
        {
            if (id != assignment.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Assignments.Any(a => a.Id == assignment.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName", assignment.EmployeeId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", assignment.ProjectId);
            return View(assignment);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var assignment = await _context.Assignments
                .Include(a => a.Employee)
                .Include(a => a.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignment == null) return NotFound();
            return View(assignment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment != null)
            {
                _context.Assignments.Remove(assignment);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
