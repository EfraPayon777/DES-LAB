using System.Threading.Tasks;
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

        public async Task<IActionResult> Index()
        {
            var assignments = _context.Assignments
                .Include(a => a.Employee)
                .Include(a => a.Project);
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
