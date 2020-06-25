using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Mvc;
using MonowebApp.Models;
using System.Text;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Routing;

namespace MonowebApp.Controllers
{
    public class ProfesorController : Controller
    {
        [BreadCrumb(Title ="Profesor", Url ="/Profesor/Index",Order =0)]
        public static List<Profesor> profesor;
        // GET: ProfesorController
        [BreadCrumb(Title = "Listado de Profesores", Order = 1)]
        public ActionResult Index(string filter, int page = 1,
                                        string sortExpression = "Nombre")
        {
            if (profesor == null)
            {
                profesor = new List<Profesor>() {

                    new Profesor() {IdProfesor=1, Codigo="001",Cedula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com",Dirección="calle los carro",Carrera="ing sistemas", TituloMayor="doctor en redes", CategoríaProfesoral="m5", FacultadPertene="ingenieria"},
                     new Profesor() {IdProfesor=1, Codigo="001",Cedula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com",Dirección="calle los carro",Carrera="ing sistemas", TituloMayor="doctor en redes", CategoríaProfesoral="m5", FacultadPertene="ingenieria"},
                      new Profesor() {IdProfesor=1, Codigo="001",Cedula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com",Dirección="calle los carro",Carrera="ing sistemas", TituloMayor="doctor en redes", CategoríaProfesoral="m5", FacultadPertene="ingenieria"},
                };
            }
            StringBuilder filtro = new StringBuilder();
            filtro.Append("Inactivo == false");
            if (!string.IsNullOrWhiteSpace(filter))
            {
                filtro.AppendFormat("&& Nombre.ToUpper().Contains(\"{0}\")", filter.ToUpper());

            }
            var model = PagingList.Create(profesor, 10, page, sortExpression, "Nombre");
            model.RouteValue = new RouteValueDictionary{
                { "filter", filter}
            };
            model.Action = "Index";


            return View(model);
        }
        // GET: ProfesorController/Details/5
        [BreadCrumb(Title = "Detalle Profesor", Order = 2)]
        public ActionResult Details(int id)
        {
            var modelo = profesor.Find(x => x.IdProfesor == id);
            if (modelo == null)
                return RedirectToAction(nameof(Index));

            return View(modelo); //envia el modelo a la vista
        }

        // GET: ProfesorController/Create
        [BreadCrumb(Title = "Crear Profesor", Order = 3)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfesorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Profesor modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    profesor.Add(modelo);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View(modelo);
            }
            return View(modelo);
        }

        // GET: ProfesorController/Edit/5
        public ActionResult Edit(int id)
        {
            var modelo = profesor.Find(x => x.IdProfesor == id);
            if (modelo == null)
                return RedirectToAction(nameof(Index));
            return View(modelo);
        }

        // POST: ProfesorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Profesor modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int indice = profesor.FindIndex(x => x.IdProfesor == modelo.IdProfesor);
                    profesor[indice] = modelo;
                    profesor.Remove(modelo);
                    return RedirectToAction(nameof(Index));

                }
            }
            catch
            {
                return View(modelo);
            }
            return View(modelo);
        }

        // GET: ProfesorController/Delete/5
        public ActionResult Delete(int id)
        {
            var modelo = profesor.Find(x => x.IdProfesor == id);
            if (modelo == null)
                return RedirectToAction(nameof(Index));
            return View(modelo);
        }

        // POST: ProfesorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Profesor modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int indice = profesor.FindIndex(x => x.IdProfesor == modelo.IdProfesor);
                    profesor[indice] = modelo;
                    profesor.Remove(modelo);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch

            {
                return View(modelo);
            }

            return View(modelo);

        }
    }
}
