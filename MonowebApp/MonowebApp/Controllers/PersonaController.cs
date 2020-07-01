
using Microsoft.AspNetCore.Mvc;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using System;
using MonowebApp.Models;
using ReflectionIT.Mvc.Paging;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MonowebApp.Controllers;
using Microsoft.Extensions.Options;

namespace MonowebApp.Controllers
{
    [BreadCrumb(Title = "Persona", Url = "/Persona/Index", Order = 0)]
    public class PersonaController : Controller
    {
        private readonly IOptions<GlobalSetting> _gSettings;
        //no es recomendable
        public PersonaController(IOptions<GlobalSetting> gSettings)
        {
            _gSettings = gSettings;
        }
       
        // este es el CRUD   de c# web
         public static List<Persona> personas;
        // GET: PersonaController
        
        [BreadCrumb(Title = "Listado de Personas", Order = 1)]
        public ActionResult Index( string filter, int page = 1,
                                        string sortExpression = "Nombre")
        {
            ViewBag.NombreCompania = _gSettings.Value.NombreCompania;
            _gSettings.Value.DireccionCompania = "calle salcedo esquina duverge";
            _gSettings.Value.NombreCompania = "MendezSoff";


            if (personas == null)
            {
                personas = new List<Persona>() {

                    new Persona() {IdPersona=1, Nombre = "Nelson", Apellido="Abreu", FechaNacimiento=DateTime.Now, Telefono="2223434"},
                    new Persona() { IdPersona=2, Nombre = "Juan", Apellido="De los Palotes", FechaNacimiento=DateTime.Now, Telefono="2223434"},
                    new Persona() {IdPersona=3, Nombre = "Nelson", Apellido="Abreu", FechaNacimiento=DateTime.Now, Telefono="2223434"},
                    new Persona() {IdPersona=4, Nombre = "Juan", Apellido="De los Palotes", FechaNacimiento=DateTime.Now, Telefono="2223434"},
                    new Persona() {IdPersona=5, Nombre = "Nelson", Apellido="Abreu", FechaNacimiento=DateTime.Now, Telefono="2223434"},
                    new Persona() {IdPersona=6, Nombre = "Juan", Apellido="De los Palotes", FechaNacimiento=DateTime.Now, Telefono="2223434"},
                    new Persona() {IdPersona=7, Nombre = "Nelson", Apellido="Abreu", FechaNacimiento=DateTime.Now, Telefono="2223434"},
                    new Persona() {IdPersona=8, Nombre = "Juan", Apellido="De los Palotes", FechaNacimiento=DateTime.Now, Telefono="2223434"},
                    new Persona() {IdPersona=9, Nombre = "Nelson", Apellido="Abreu", FechaNacimiento=DateTime.Now, Telefono="2223434"},
                    new Persona() {IdPersona=10, Nombre = "Juan", Apellido="De los Palotes", FechaNacimiento=DateTime.Now, Telefono="2223434"},
                    new Persona() {IdPersona=11, Nombre = "Nelson", Apellido="Abreu", FechaNacimiento=DateTime.Now, Telefono="2223434"},
                    new Persona() { IdPersona=12, Nombre = "Juan", Apellido="De los Palotes", FechaNacimiento=DateTime.Now, Telefono="2223434"},
                    new Persona() {IdPersona=13, Nombre = "Nelson", Apellido="Abreu", FechaNacimiento=DateTime.Now, Telefono="2223434"},
                    new Persona() {IdPersona=14, Nombre = "Juan", Apellido="De los Palotes", FechaNacimiento=DateTime.Now, Telefono="2223434"},
                    new Persona() {IdPersona=15, Nombre = "Nelson", Apellido="Abreu", FechaNacimiento=DateTime.Now, Telefono="2223434"},
                    new Persona() {IdPersona=16, Nombre = "Juan", Apellido="De los Palotes", FechaNacimiento=DateTime.Now, Telefono="2223434"},
                    new Persona() {IdPersona=17, Nombre = "Nelson", Apellido="Abreu", FechaNacimiento=DateTime.Now, Telefono="2223434"},
                    new Persona() {IdPersona=18, Nombre = "Juan", Apellido="De los Palotes", FechaNacimiento=DateTime.Now, Telefono="2223434"},
                    new Persona() {IdPersona=19, Nombre = "Nelson", Apellido="Abreu", FechaNacimiento=DateTime.Now, Telefono="2223434"},
                    new Persona() {IdPersona=20, Nombre = "Juan", Apellido="De los Palotes", FechaNacimiento=DateTime.Now, Telefono="2223434"}
                };
            }
            StringBuilder filtro = new StringBuilder();
            filtro.Append("Inactivo == false");
            if(!string.IsNullOrWhiteSpace(filter))
            { 
            filtro.AppendFormat("&& Nombre.ToUpper().Contains(\"{0}\")", filter.ToUpper());
            
            }
            var model = PagingList.Create(personas, 10, page, sortExpression, "Nombre");
            model.RouteValue = new RouteValueDictionary{
                { "filter", filter}
            };
            model.Action = "Index";


            return View(model);
        }

        // GET: PersonaController/Details/5
        [BreadCrumb(Title = "Detalle Persona", Order = 2)]
        public ActionResult Details(int id)
        {
            var modelo = personas.Find(x => x.IdPersona == id);
            if (modelo == null)
                return RedirectToAction(nameof(Index));

            return View(modelo); //envia el modelo a la vista
        }

        // GET: PersonaController/Create
        [BreadCrumb(Title = "Crear Persona", Order = 3)]
        public ActionResult Create()
            {

                return View();
            }

          
        // POST: PersonaController/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(Persona modelo)
            {
                try
                {
                if(ModelState.IsValid)
                {
                    personas.Add(modelo);
                    return RedirectToAction(nameof(Index));
                }
                   
                }
                catch
                {
                    return View(modelo);
                }
            return View(modelo);
        }



        // GET: PersonaController/Edit/5
        [BreadCrumb(Title = "EDitar Persona", Order = 4)]

        public ActionResult Edit(int id)
            {
            var modelo = personas.Find(x => x.IdPersona == id);
            if (modelo == null)
                return RedirectToAction(nameof(Index));
            return View(modelo);
        }

           
        
        // POST: PersonaController/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
         
        public ActionResult Edit(int id, Persona modelo)
            {
                try
                {
                if (ModelState.IsValid)
                {
                    int indice = personas.FindIndex(x => x.IdPersona == modelo.IdPersona);
                    personas[indice] = modelo;
                    return RedirectToAction(nameof(Index));
                }
            }
                catch
                {
                    return View(modelo);
                }
            return View(modelo);
        }


        // GET: PersonaController/Delete/5
        [BreadCrumb(Title = "Listado de Personas", Order = 5)]
        public ActionResult Delete(int id)
        {
            var modelo = personas.Find(x => x.IdPersona == id);
            if (modelo == null)
                return RedirectToAction(nameof(Index));
            return View(modelo);
        }

            // POST: PersonaController/Delete/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Delete(int id,Persona modelo)          
        {
            try
            {
                
                    int indice = personas.FindIndex(x => x.IdPersona == modelo.IdPersona);
                    personas.RemoveAt(indice);
                    return RedirectToAction(nameof(Index));
                
            }
            catch
           
            {
                return View(modelo);
            }
     
                            
        }

        public IActionResult AdminLte()
        {
            return View();
        }
       
    }
   
}

