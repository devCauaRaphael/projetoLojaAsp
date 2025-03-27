using Microsoft.AspNetCore.Mvc;

namespace projetoLojaAsp.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Produto()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Produto()
        {
            if (ModelState.IsValid) 
            { 
                    _pro
            }
            
            return View(); 
        
        }

    }
}
