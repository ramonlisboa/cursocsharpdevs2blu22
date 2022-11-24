using Microsoft.AspNetCore.Mvc;

namespace Devs2Blu.ProjetosAula.PrimeiroProjetoMVC.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("indicadores")]    
        [Route("numbers")]    
        public IActionResult Indicadores()
        {
            return View();
        }
    }
}
