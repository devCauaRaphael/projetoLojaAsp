using Microsoft.AspNetCore.Mvc;
using projetoLojaAsp.Repositorio;

using projetoLojaAsp.Models;

namespace projetoLojaAsp.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoRepositorio _produtoRepositorio;
        public ProdutoController(ProdutoRepositorio produtoRepositorio)
        { 
            _produtoRepositorio = produtoRepositorio;
        }
        public IActionResult Produto()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Produto(Produtos produto)
        {
            if (ModelState.IsValid)
            {
                _produtoRepositorio.AdicionarProduto(produto);
            }  
            return View();  
        }

    }
}
