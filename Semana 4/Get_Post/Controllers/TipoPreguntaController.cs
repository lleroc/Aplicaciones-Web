using Get_Post.Data;
using Get_Post.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Get_Post.Controllers
{
    public class TipoPreguntaController : Controller
    {
        private readonly Get_PostDbContext _context;
        public TipoPreguntaController(Get_PostDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            //Select * from tipopregunta
            return View(await _context.TipoPreguntas.ToListAsync());
        }

        //un procedimieento es para mostrar la pagina

        public IActionResult nuevo() {
            return View();  
        }

        //segundo para guardar la pagina
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> nuevo([Bind("Detalle")]TipoPreguntaModel tipoPregunta) {
            if (ModelState.IsValid) {
                _context.Add(tipoPregunta);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipoPregunta);
        }

        //procedimeinto 1 - para levantar la vista
        public async Task<IActionResult> Editar(int? id) {
            if (id == null) return NotFound();
            var tipopreguntaModel = await _context.TipoPreguntas.FindAsync(id);
            if (tipopreguntaModel == null) return NotFound();
            return View(tipopreguntaModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id, Detalle")] TipoPreguntaModel tipoPreguntaModel)
        { 
            if(id != tipoPreguntaModel.Id) return NotFound();
            if (ModelState.IsValid) {
                try
                {
                    _context.Update(tipoPreguntaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPpreguntaExiste(tipoPreguntaModel.Id))
                    {
                        return NotFound();
                    }
                    else { 
                    return BadRequest();
                    }
                }
                //return RedirectToAction("Index");   
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPreguntaModel);
        }


        public bool TipoPpreguntaExiste(int id) { 
        return _context.TipoPreguntas.Any(e => e.Id == id);
        }
        //1 para mostar la vista
        public async Task<IActionResult> Eliminar(int id) {
            if (id == null) return NotFound();
            var tipopreguntaModel = await _context.TipoPreguntas.FirstOrDefaultAsync(tp => tp.Id == id);
            if (tipopreguntaModel == null) return NotFound();
            return View(tipopreguntaModel);
        }
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmacionEliminar(int id) {
            var tipopreguntaModel = await _context.TipoPreguntas.FindAsync(id);
            if (tipopreguntaModel == null) return BadRequest();
            try
            {
                _context.TipoPreguntas.Remove(tipopreguntaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
