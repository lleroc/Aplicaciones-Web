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
    public class OficinasController : Controller
    {
        private readonly JardineriaDbContext _context;

        public OficinasController(JardineriaDbContext context)
        {
            _context = context;
        }

        // GET: Oficinas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Oficinas.ToListAsync());
        }

        // GET: Oficinas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oficina = await _context.Oficinas
                .FirstOrDefaultAsync(m => m.CodigoOficina == id);
            if (oficina == null)
            {
                return NotFound();
            }

            return View(oficina);
        }

        // GET: Oficinas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Oficinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoOficina,Ciudad,Pais,Region,CodigoPostal,Telefono,LineaDireccion1,LineaDireccion2")] Oficina oficina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oficina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oficina);
        }

        // GET: Oficinas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oficina = await _context.Oficinas.FindAsync(id);
            if (oficina == null)
            {
                return NotFound();
            }
            return View(oficina);
        }

        // POST: Oficinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodigoOficina,Ciudad,Pais,Region,CodigoPostal,Telefono,LineaDireccion1,LineaDireccion2")] Oficina oficina)
        {
            if (id != oficina.CodigoOficina)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oficina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OficinaExists(oficina.CodigoOficina))
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
            return View(oficina);
        }

        // GET: Oficinas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oficina = await _context.Oficinas
                .FirstOrDefaultAsync(m => m.CodigoOficina == id);
            if (oficina == null)
            {
                return NotFound();
            }

            return View(oficina);
        }

        // POST: Oficinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var oficina = await _context.Oficinas.FindAsync(id);
            if (oficina != null)
            {
                _context.Oficinas.Remove(oficina);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OficinaExists(string id)
        {
            return _context.Oficinas.Any(e => e.CodigoOficina == id);
        }
    }
}
