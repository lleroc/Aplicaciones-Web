using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DesdeBDD.Models;

namespace DesdeBDD.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly JardineriaDbContext _context;

        public EmpleadosController(JardineriaDbContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            var jardineriaDbContext = _context.Empleados.Include(e => e.CodigoJefeNavigation).Include(e => e.CodigoOficinaNavigation);
            return View(await jardineriaDbContext.ToListAsync());
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.CodigoJefeNavigation)
                .Include(e => e.CodigoOficinaNavigation)
                .FirstOrDefaultAsync(m => m.CodigoEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            ViewData["CodigoJefe"] = new SelectList(_context.Empleados, "CodigoEmpleado", "CodigoEmpleado");
            ViewData["CodigoOficina"] = new SelectList(_context.Oficinas, "CodigoOficina", "CodigoOficina");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoEmpleado,Nombre,Apellido1,Apellido2,Extension,Email,CodigoOficina,CodigoJefe,Puesto")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoJefe"] = new SelectList(_context.Empleados, "CodigoEmpleado", "CodigoEmpleado", empleado.CodigoJefe);
            ViewData["CodigoOficina"] = new SelectList(_context.Oficinas, "CodigoOficina", "CodigoOficina", empleado.CodigoOficina);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["CodigoJefe"] = new SelectList(_context.Empleados, "CodigoEmpleado", "CodigoEmpleado", empleado.CodigoJefe);
            ViewData["CodigoOficina"] = new SelectList(_context.Oficinas, "CodigoOficina", "CodigoOficina", empleado.CodigoOficina);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoEmpleado,Nombre,Apellido1,Apellido2,Extension,Email,CodigoOficina,CodigoJefe,Puesto")] Empleado empleado)
        {
            if (id != empleado.CodigoEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.CodigoEmpleado))
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
            ViewData["CodigoJefe"] = new SelectList(_context.Empleados, "CodigoEmpleado", "CodigoEmpleado", empleado.CodigoJefe);
            ViewData["CodigoOficina"] = new SelectList(_context.Oficinas, "CodigoOficina", "CodigoOficina", empleado.CodigoOficina);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.CodigoJefeNavigation)
                .Include(e => e.CodigoOficinaNavigation)
                .FirstOrDefaultAsync(m => m.CodigoEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.CodigoEmpleado == id);
        }
    }
}
