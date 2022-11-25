using Devs2Blu.ProjetosAula.PrimeiroProjetoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Devs2Blu.ProjetosAula.PrimeiroProjetoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Teste");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("home/cadastro")]
        [Route("cadastro")]
        [Route("cadastre-se")]
        public IActionResult Cadastro()
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