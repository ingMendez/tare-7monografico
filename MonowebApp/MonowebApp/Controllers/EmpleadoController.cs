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
    public class EmpleadoController : Controller
    {
        [BreadCrumb(Title = "Empleado", Url = "/Empleado/Index", Order = 0)]
        public static List<Empleado> empleados;
        // GET: EmpleadoController
        [BreadCrumb(Title = "Listado de Empleados", Order = 1)]
        public ActionResult Index(string filter, int page = 1,
                                        string sortExpression = "Nombre")
        {
            if (empleados == null)
            {
                empleados = new List<Empleado>() {

                 new Empleado() {IdEmpleado=1, Codigo="001",Cedula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com",Dirección="calle los carro",SalarioM="1,000", DepartamentoPertene="RRHH", NombreContactSos="maria", TelefonoContactSos="809-444-4789", AfpPertenece="siembra", ArsPertenece="senansa", Observaciones="soy yo" },
                 new Empleado() {IdEmpleado=2, Codigo="001",Cedula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com",Dirección="calle los carro",SalarioM="1,000", DepartamentoPertene="RRHH", NombreContactSos="maria", TelefonoContactSos="809-444-4789", AfpPertenece="siembra", ArsPertenece="senansa", Observaciones="soy yo" },
                 new Empleado() {IdEmpleado=3, Codigo="001",Cedula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com",Dirección="calle los carro",SalarioM="1,000", DepartamentoPertene="RRHH", NombreContactSos="maria", TelefonoContactSos="809-444-4789", AfpPertenece="siembra", ArsPertenece="senansa", Observaciones="soy yo" },
                 new Empleado() {IdEmpleado=4, Codigo="001",Cedula="402-264587512-3", FechaNacimiento = DateTime.Now, FechaIngreso= DateTime.Now, Nombre="juan", Apellido="peres",Sexo="H", EstadoCivil="S",  Ocupación="alba;il",TipoSangre="o+", Nacionalidad="dominic", Religión="catolico", Teléfono="409-444-4113", Email="casa@gmail.com",Dirección="calle los carro",SalarioM="1,000", DepartamentoPertene="RRHH", NombreContactSos="maria", TelefonoContactSos="809-444-4789", AfpPertenece="siembra", ArsPertenece="senansa", Observaciones="soy yo" },
                };
            }
            StringBuilder filtro = new StringBuilder();
            filtro.Append("Inactivo == false");
            if (!string.IsNullOrWhiteSpace(filter))
            {
                filtro.AppendFormat("&& Nombre.ToUpper().Contains(\"{0}\")", filter.ToUpper());

            }
            var model = PagingList.Create(empleados, 10, page, sortExpression, "Nombre");
            model.RouteValue = new RouteValueDictionary{
                { "filter", filter}
            };
            model.Action = "Index";

            return View(model);
        }

        // GET: EmpleadoController/Details/5
        [BreadCrumb(Title = "Detalle de Empleados", Order = 2)]
        public ActionResult Details(int id)
        {
            Empleado modelo = empleados.Find(x => x.IdEmpleado == id);
            return View(modelo);
        }

        // GET: EmpleadoController/Create
        [BreadCrumb(Title = "Crear de Empleados", Order = 3)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Empleado modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    empleados.Add(modelo);
                    return RedirectToAction(nameof(Index));
                }

            }
            catch
            {
                return View(modelo);
            }
            return View(modelo);
        }

        // GET: EmpleadoController/Edit/5
        public ActionResult Edit(int id)
        {
            Empleado modelo = empleados.Find(x => x.IdEmpleado == id);
            return View(modelo);
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Empleado modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int indice = empleados.FindIndex(x => x.IdEmpleado == modelo.IdEmpleado);
                    empleados[indice] = modelo;
                    empleados.Remove(modelo);
                    empleados.Add(modelo);
                    return RedirectToAction(nameof(Index));

                }
            }
            catch
            {
                return View(modelo);
            }
            return View(modelo);
        }

        // GET: EmpleadoController/Delete/5
        public ActionResult Delete(int id)
        {
            Empleado modelo = empleados.Find(x => x.IdEmpleado == id);
            return View(modelo);
        }

        // POST: EmpleadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Empleado modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int indice = empleados.FindIndex(x => x.IdEmpleado == modelo.IdEmpleado);
                    empleados[indice] = modelo;
                    empleados.RemoveAt(indice);
                   
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
