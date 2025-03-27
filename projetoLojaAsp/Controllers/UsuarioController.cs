using Microsoft.AspNetCore.Mvc;

namespace projetoLojaAsp.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
