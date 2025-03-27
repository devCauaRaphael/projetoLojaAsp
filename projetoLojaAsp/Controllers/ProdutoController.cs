using Microsoft.AspNetCore.Mvc;

namespace projetoLojaAsp.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Produto()
        {
            return View();
        }
    }
}
