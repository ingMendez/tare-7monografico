using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MonowebApp.Models;
using MonowebApp.Repositorios.Base;

namespace MonowebApp.Controllers
{
    public class MarcasController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMarcaRepo _repo;

        public MarcasController(AppDbContext context, IMarcaRepo repo)
        {
            _context = context;
            _repo = repo;

        }

        // GET: Marcas
        public IActionResult Index()
       {
            //public async Task<IActionResult> Index()
            // {
               //  return View(await _context.Marca.ToListAsync());
            
            return View(_repo.BuscarPorCondicion(x=>x.Inactivo == false));
        }

        // GET: Marcas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await _repo.BuscarPorId(id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // GET: Marcas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marcas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMarca,Nombre")] Marca marca)
        {
            if (ModelState.IsValid)
            {
              /*  marca.Creado = DateTime.Now;
                marca.Modificado = DateTime.Now;
                marca.Inactivo = false;
                _context.Add(marca);
                await _context.SaveChangesAsync();*/
                await _repo.Crear(marca);
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }

        // GET: Marcas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await _repo.BuscarPorId(id);
            if (marca == null)
            {
                return NotFound();
            }
            return View(marca);
        }

        // POST: Marcas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMarca,Nombre" )] Marca marca)
        {
            if (id != marca.IdMarca)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*_context.Update(marca);
                  _context.Entry(marca).Property(c => c.Creado).IsModified = false; //Especifica que estos no cambian.
                  _context.Entry(marca).Property(c => c.Inactivo).IsModified = false; //Especifica que estos no cambian.
                  marca.Modificado = DateTime.Now;
                  await _context.SaveChangesAsync();

                    _context.Update(marca);*/
                    await _repo.Modificar(marca);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarcaExists(marca.IdMarca))
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
            return View(marca);
        }

        // GET: Marcas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marca = await _context.Marca
                .FirstOrDefaultAsync(m => m.IdMarca == id);
            if (marca == null)
            {
                return NotFound();
            }

            return View(marca);
        }

        // POST: Marcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marca = await _context.Marca.FindAsync(id);
            /* _context.Marca.Remove(marca);
             await _context.SaveChangesAsync();*/
            await _repo.Eliminar(marca);
            return RedirectToAction(nameof(Index));
        }

        private bool MarcaExists(int id)
        {
            return _context.Marca.Any(e => e.IdMarca == id);
        }
    }
}
