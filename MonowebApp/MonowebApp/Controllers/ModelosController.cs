using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MonowebApp.Models;
using MonowebApp.Repositorios;
using MonowebApp.Repositorios.Base;

namespace MonowebApp.Controllers
{
    public class ModelosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMarcaRepo _repo;
        private readonly IModeloRepo _repoModelo;
        private readonly ModeloRepo _repoModeloPrueba;

        public ModelosController(AppDbContext context, IMarcaRepo repo, IModeloRepo repoModelo)
        {
            _context = context;
            _repo = repo;
            _repoModelo = repoModelo;
            _repoModeloPrueba = new ModeloRepo(context);
        }

        // GET: Modelos
        public async Task<IActionResult> Index()
        {
            var oldDbContext = _context.Modelo.Include(m => m.Marca);
            return View(await oldDbContext.ToListAsync());
        }

        // GET: Modelos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*  var modelo = await _context.Modelo
                  .Include(m => m.Marca)
                  .FirstOrDefaultAsync(m => m.IdModelo == id);*/
            var modelo = await _repoModelo.BuscarPorId(id);

            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // GET: Modelos/Create
        public async Task<IActionResult> Create()
        {
            // ViewData["IdMarca"] = new SelectList(_context.Marca, "IdMarca", "Nombre");

            // ViewData["IdMarca"] = new SelectList(_repo.BuscarTodo(), "IdMarca", "Nombre");

            ViewData["IdMarca"] = new SelectList(await _repo.GetGenericList(), "Id", "Name");
            return View();
        }

        // POST: Modelos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdModelo,IdMarca,Nombre,Año,Version,Creado,Modificado,Inactivo")] Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMarca"] = new SelectList(_context.Marca, "IdMarca", "IdMarca", modelo.IdMarca);
            return View(modelo);
        }

        // GET: Modelos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelo.FindAsync(id);
            if (modelo == null)
            {
                return NotFound();
            }
            ViewData["IdMarca"] = new SelectList(_context.Marca, "IdMarca", "IdMarca", modelo.IdMarca);
            return View(modelo);
        }

        // POST: Modelos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdModelo,IdMarca,Nombre,Año,Version,Creado,Modificado,Inactivo")] Modelo modelo)
        {
            if (id != modelo.IdModelo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloExists(modelo.IdModelo))
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
            ViewData["IdMarca"] = new SelectList(_context.Marca, "IdMarca", "IdMarca", modelo.IdMarca);
            return View(modelo);
        }

        // GET: Modelos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelo
                .Include(m => m.Marca)
                .FirstOrDefaultAsync(m => m.IdModelo == id);
            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // POST: Modelos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modelo = await _context.Modelo.FindAsync(id);
            _context.Modelo.Remove(modelo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloExists(int id)
        {
            return _context.Modelo.Any(e => e.IdModelo == id);
        }
    }
}
