using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MonowebApp.Models;
using ReflectionIT.Mvc.Paging;

namespace MonowebApp.Controllers
{
    public class EstudianteController : Controller
    {
        [BreadCrumb(Title = "Estudiante", Url = "/Estudiante/Index", Order = 0)]
        public static List<Estudiantes> estudiante;
        // GET: EstudianteController
        [BreadCrumb(Title = "Listado de Profesores", Order = 1)]
        public ActionResult Index(string filter, int page = 1,
                                        string sortExpression = "Nombre")
        {
            if (estudiante == null)
            {
                estudiante = new List<Estudiantes>() {

                    new Estudiantes() {IdEstudiante=1, Matricula="2016-0460", Cédula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com", NombrePadre="julian", NombreMadre="julia", Dirección="calle los carro", TipoColegio="publico", Carrera="ing sistemas", Observaciones="lo mas duro"},
                    new Estudiantes() {IdEstudiante=2, Matricula="2016-0460", Cédula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com", NombrePadre="julian", NombreMadre="julia", Dirección="calle los carro", TipoColegio="publico", Carrera="ing sistemas", Observaciones="lo mas duro"},
                    new Estudiantes() {IdEstudiante=3, Matricula="2016-0460", Cédula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com", NombrePadre="julian", NombreMadre="julia", Dirección="calle los carro", TipoColegio="publico", Carrera="ing sistemas", Observaciones="lo mas duro"},
                    new Estudiantes() {IdEstudiante=1, Matricula="2016-0460", Cédula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com", NombrePadre="julian", NombreMadre="julia", Dirección="calle los carro", TipoColegio="publico", Carrera="ing sistemas", Observaciones="lo mas duro"},
                    new Estudiantes() {IdEstudiante=2, Matricula="2016-0460", Cédula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com", NombrePadre="julian", NombreMadre="julia", Dirección="calle los carro", TipoColegio="publico", Carrera="ing sistemas", Observaciones="lo mas duro"},
                    new Estudiantes() {IdEstudiante=3, Matricula="2016-0460", Cédula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com", NombrePadre="julian", NombreMadre="julia", Dirección="calle los carro", TipoColegio="publico", Carrera="ing sistemas", Observaciones="lo mas duro"},
                    new Estudiantes() {IdEstudiante=1, Matricula="2016-0460", Cédula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com", NombrePadre="julian", NombreMadre="julia", Dirección="calle los carro", TipoColegio="publico", Carrera="ing sistemas", Observaciones="lo mas duro"},
                    new Estudiantes() {IdEstudiante=2, Matricula="2016-0460", Cédula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com", NombrePadre="julian", NombreMadre="julia", Dirección="calle los carro", TipoColegio="publico", Carrera="ing sistemas", Observaciones="lo mas duro"},
                    new Estudiantes() {IdEstudiante=3, Matricula="2016-0460", Cédula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com", NombrePadre="julian", NombreMadre="julia", Dirección="calle los carro", TipoColegio="publico", Carrera="ing sistemas", Observaciones="lo mas duro"},
                    new Estudiantes() {IdEstudiante=1, Matricula="2016-0460", Cédula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com", NombrePadre="julian", NombreMadre="julia", Dirección="calle los carro", TipoColegio="publico", Carrera="ing sistemas", Observaciones="lo mas duro"},
                    new Estudiantes() {IdEstudiante=2, Matricula="2016-0460", Cédula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com", NombrePadre="julian", NombreMadre="julia", Dirección="calle los carro", TipoColegio="publico", Carrera="ing sistemas", Observaciones="lo mas duro"},
                    new Estudiantes() {IdEstudiante=3, Matricula="2016-0460", Cédula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com", NombrePadre="julian", NombreMadre="julia", Dirección="calle los carro", TipoColegio="publico", Carrera="ing sistemas", Observaciones="lo mas duro"},
                    new Estudiantes() {IdEstudiante=1, Matricula="2016-0460", Cédula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com", NombrePadre="julian", NombreMadre="julia", Dirección="calle los carro", TipoColegio="publico", Carrera="ing sistemas", Observaciones="lo mas duro"},
                    new Estudiantes() {IdEstudiante=2, Matricula="2016-0460", Cédula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com", NombrePadre="julian", NombreMadre="julia", Dirección="calle los carro", TipoColegio="publico", Carrera="ing sistemas", Observaciones="lo mas duro"},
                    new Estudiantes() {IdEstudiante=3, Matricula="2016-0460", Cédula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com", NombrePadre="julian", NombreMadre="julia", Dirección="calle los carro", TipoColegio="publico", Carrera="ing sistemas", Observaciones="lo mas duro"},
                    new Estudiantes() {IdEstudiante=1, Matricula="2016-0460", Cédula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com", NombrePadre="julian", NombreMadre="julia", Dirección="calle los carro", TipoColegio="publico", Carrera="ing sistemas", Observaciones="lo mas duro"},
                    new Estudiantes() {IdEstudiante=2, Matricula="2016-0460", Cédula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com", NombrePadre="julian", NombreMadre="julia", Dirección="calle los carro", TipoColegio="publico", Carrera="ing sistemas", Observaciones="lo mas duro"},
                    new Estudiantes() {IdEstudiante=3, Matricula="2016-0460", Cédula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com", NombrePadre="julian", NombreMadre="julia", Dirección="calle los carro", TipoColegio="publico", Carrera="ing sistemas", Observaciones="lo mas duro"},
                           };
               
            }
            StringBuilder filtro = new StringBuilder();
            filtro.Append("Inactivo == false");
            if (!string.IsNullOrWhiteSpace(filter))
            {
                filtro.AppendFormat("&& Nombre.ToUpper().Contains(\"{0}\")", filter.ToUpper());

            }
            var model = PagingList.Create(estudiante, 10, page, sortExpression, "Nombre");
            model.RouteValue = new RouteValueDictionary{
                { "filter", filter}
            };
            model.Action = "Index";


            return View(model);
        
    }

        // GET: EstudianteController/Details/5
        [BreadCrumb(Title = "Detalle Estudiante", Order = 2)]
        public ActionResult Details(int id)
        {
            var modelo = estudiante.Find(x => x.IdEstudiante == id);
            if (modelo == null)
                return RedirectToAction(nameof(Index));

            return View(modelo); //envia el modelo a la vista
        }

        // GET: EstudianteController/Create
        [BreadCrumb(Title = "Crear Estudiante", Order = 3)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstudianteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Estudiantes modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    estudiante.Add(modelo);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View(modelo);
            }
            return View(modelo);
        }

        // GET: EstudianteController/Edit/5
        public ActionResult Edit(int id)
        {
            var modelo = estudiante.Find(x => x.IdEstudiante == id);
            if (modelo == null)
                return RedirectToAction(nameof(Index));
            return View(modelo);
        }

        // POST: EstudianteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Estudiantes modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int indice = estudiante.FindIndex(x => x.IdEstudiante == modelo.IdEstudiante);
                    estudiante[indice] = modelo;
                    estudiante.Remove(modelo);
                    estudiante.Add(modelo);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(modelo);
            }
            return View(modelo);
        }

        // GET: EstudianteController/Delete/5
        public ActionResult Delete(int id)
        {
            var modelo = estudiante.Find(x => x.IdEstudiante == id);
            if (modelo == null)
                return RedirectToAction(nameof(Index));
            return View(modelo);
        }

        // POST: EstudianteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Estudiantes modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int indice = estudiante.FindIndex(x => x.IdEstudiante == modelo.IdEstudiante);
                    estudiante[indice] = modelo;
                    estudiante.Remove(modelo);
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
