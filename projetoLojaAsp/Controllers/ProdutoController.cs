using Microsoft.AspNetCore.Mvc;

namespace projetoLojaAsp.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
