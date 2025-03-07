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
    public class ClientesController : Controller
    {
        private readonly JardineriaDbContext _context;

        public ClientesController(JardineriaDbContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var jardineriaDbContext = _context.Clientes.Include(c => c.CodigoEmpleadoRepVentasNavigation);
            return View(await jardineriaDbContext.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.CodigoEmpleadoRepVentasNavigation)
                .FirstOrDefaultAsync(m => m.CodigoCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            ViewData["CodigoEmpleadoRepVentas"] = new SelectList(_context.Empleados, "CodigoEmpleado", "CodigoEmpleado");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoCliente,NombreCliente,NombreContacto,ApellidoContacto,Telefono,Fax,LineaDireccion1,LineaDireccion2,Ciudad,Region,Pais,CodigoPostal,CodigoEmpleadoRepVentas,LimiteCredito")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoEmpleadoRepVentas"] = new SelectList(_context.Empleados, "CodigoEmpleado", "CodigoEmpleado", cliente.CodigoEmpleadoRepVentas);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["CodigoEmpleadoRepVentas"] = new SelectList(_context.Empleados, "CodigoEmpleado", "CodigoEmpleado", cliente.CodigoEmpleadoRepVentas);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodigoCliente,NombreCliente,NombreContacto,ApellidoContacto,Telefono,Fax,LineaDireccion1,LineaDireccion2,Ciudad,Region,Pais,CodigoPostal,CodigoEmpleadoRepVentas,LimiteCredito")] Cliente cliente)
        {
            if (id != cliente.CodigoCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.CodigoCliente))
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
            ViewData["CodigoEmpleadoRepVentas"] = new SelectList(_context.Empleados, "CodigoEmpleado", "CodigoEmpleado", cliente.CodigoEmpleadoRepVentas);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.CodigoEmpleadoRepVentasNavigation)
                .FirstOrDefaultAsync(m => m.CodigoCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.CodigoCliente == id);
        }
    }
}
