using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonowebApp.Models;

namespace MonowebApp.Controllers
{
    public class TesisController : Controller
    {
        public static List<Tesis> tesis;
        // GET: TesisController
        public ActionResult Index()
        {
            if (tesis == null)
            {
                tesis = new List<Tesis>() {

                    new Tesis() {IdTesis=1, Imagen=" ", AutorPersonal="402-264587512-3", AsientoSecundarioAutorPersonal ="", Editorial="santillana", EncabezamientoBajoNombreHeograficos="", EncabezamientoBajoTemasGenerales="", LigaRecursosElectronicos="", NotaBibliografia="", NotaDeContenido="", NotaDeResumen="", NotasGenerales="", NotaSobreOtrosFormulario="", NotaTesis="", Titulo="", VolumenDimension=""}
                           };

            }
            return View(tesis );
        }
        public ActionResult IndexUsuario()
        {
            if (tesis == null)
            {
                tesis = new List<Tesis>() {

                    new Tesis() {IdTesis=1, Imagen=" ", AutorPersonal="402-264587512-3", AsientoSecundarioAutorPersonal ="", Editorial="santillana", EncabezamientoBajoNombreHeograficos="", EncabezamientoBajoTemasGenerales="", LigaRecursosElectronicos="", NotaBibliografia="", NotaDeContenido="", NotaDeResumen="", NotasGenerales="", NotaSobreOtrosFormulario="", NotaTesis="", Titulo="", VolumenDimension=""}
                           };

            }
            return View(tesis);
        }

        // GET: TesisController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TesisController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TesisController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TesisController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TesisController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TesisController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TesisController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
