﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Get_Post.Data;
using Get_Post.Models;

namespace Get_Post.Controllers
{
    public class PreguntasController : Controller
    {
        private readonly Get_PostDbContext _context;

        public PreguntasController(Get_PostDbContext context)
        {
            _context = context;
        }

        // GET: Preguntas
        public async Task<IActionResult> Index()
        {
            var get_PostDbContext = _context.Preguntas.Include(p => p.TipoPreguntaModel);
            return View(await get_PostDbContext.ToListAsync());
        }

        // GET: Preguntas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preguntasModel = await _context.Preguntas
                .Include(p => p.TipoPreguntaModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (preguntasModel == null)
            {
                return NotFound();
            }

            return View(preguntasModel);
        }

        // GET: Preguntas/Create
        public IActionResult Create()
        {
            ViewData["TipoPreguntaModelId"] = new SelectList(_context.TipoPreguntas,"Id","Detalle");
            return View();
        }

        // POST: Preguntas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Enunciado,TipoPreguntaModelId,CreateAdd,UpdateAdd")] PreguntasModel preguntasModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(preguntasModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoPreguntaModelId"] = new SelectList(_context.TipoPreguntas, "Id", "Detalle", preguntasModel.TipoPreguntaModelId);
            return View(preguntasModel);
        }

        // GET: Preguntas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preguntasModel = await _context.Preguntas.FindAsync(id);
            if (preguntasModel == null)
            {
                return NotFound();
            }
            ViewData["TipoPreguntaModelId"] = new SelectList(_context.TipoPreguntas, "Id", "Detalle", preguntasModel.TipoPreguntaModelId);
            return View(preguntasModel);
        }

        // POST: Preguntas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Enunciado,TipoPreguntaModelId,CreateAdd,UpdateAdd")] PreguntasModel preguntasModel)
        {
            if (id != preguntasModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(preguntasModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreguntasModelExists(preguntasModel.Id))
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
            ViewData["TipoPreguntaModelId"] = new SelectList(_context.TipoPreguntas, "Id", "Detalle", preguntasModel.TipoPreguntaModelId);
            return View(preguntasModel);
        }

        // GET: Preguntas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preguntasModel = await _context.Preguntas
                .Include(p => p.TipoPreguntaModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (preguntasModel == null)
            {
                return NotFound();
            }

            return View(preguntasModel);
        }

        // POST: Preguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var preguntasModel = await _context.Preguntas.FindAsync(id);
            if (preguntasModel != null)
            {
                _context.Preguntas.Remove(preguntasModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PreguntasModelExists(int id)
        {
            return _context.Preguntas.Any(e => e.Id == id);
        }
    }
}
