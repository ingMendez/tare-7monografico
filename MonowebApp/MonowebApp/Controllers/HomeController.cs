using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;
using MonowebApp.Models;

namespace MonowebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<GlobalSetting> _gSettings;
        private readonly IOptions<AppSettings> _appSettings;

        public HomeController(IOptions<GlobalSetting> gSettings, IOptions<AppSettings>appSettings)
        {
            _gSettings = gSettings;
          //  _appSettings = appSettings;
        }
        public IActionResult Index()
        {
            ViewBag.NombreCompania = _gSettings.Value.NombreCompania;
            return View();
        }

        public IActionResult Privacy()
        {
            _gSettings.Value.DireccionCompania = "calle salcedo esquina duverge";
            _gSettings.Value.NombreCompania = "monoWebapp 2020";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
