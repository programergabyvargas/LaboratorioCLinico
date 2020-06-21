using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Laboratorio.Models;
using Microsoft.Extensions.Configuration;

namespace Laboratorio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly RepositorioPaciente repositorioPaciente;

        public HomeController(IConfiguration configuration)
        {
            this.configuration = configuration;
            repositorioPaciente = new RepositorioPaciente(configuration);
        }

        public IActionResult Index()
        {
            var lista = repositorioPaciente.ObtenerTodos();
            return View(lista);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
