using Microsoft.AspNetCore.Mvc;

namespace projetoLojaAsp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
