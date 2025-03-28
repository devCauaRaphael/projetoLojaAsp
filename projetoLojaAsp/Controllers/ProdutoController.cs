using Microsoft.AspNetCore.Mvc;
using projetoLojaAsp.Repositorio;
using projetoLojaAsp.Models;

namespace projetoLojaAsp.Controllers
{
    public class ProdutoController : Controller 
    {
        private readonly ProdutoRepositorio _produtoRepositorio;
        private readonly FuncionarioRepositorio _funcionarioRepositorio;
        public ProdutoController(ProdutoRepositorio produtoRepositorio, FuncionarioRepositorio funcionarioRepositorio)
        { 
            _produtoRepositorio = produtoRepositorio;
            _funcionarioRepositorio = funcionarioRepositorio;
        }

        public IActionResult Produto()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Produto(Produto produto, string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("", "O e-mail do funcionário é obrigatório.");
                return View(produto);
            }

            var funcionario = _funcionarioRepositorio.ObterFuncionario(email);

            if (funcionario == null)
            {
                ModelState.AddModelError("", "Funcionário não encontrado.");
                return View(produto);
            }
            if (ModelState.IsValid)
            {
                _produtoRepositorio.AdicionarProduto(produto);
                return RedirectToAction("Produto");
            }
            ModelState.AddModelError("", "Digite apenas valores válidos");
            return View(produto);  
        }

    }
}
