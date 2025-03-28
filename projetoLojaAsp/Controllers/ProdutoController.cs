using Microsoft.AspNetCore.Mvc;
using projetoLojaAsp.Repositorio;
using projetoLojaAsp.Models;
using projetoLojaAsp.Helpers; // Importa a classe FuncionarioLogado

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
            // 🔹 Verifica se o usuário é um funcionário antes de permitir acesso
            if (!FuncionarioLogado.EstaLogado)
            {
                return RedirectToAction("LoginFuncionario", "LoginFuncionario");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Produto(Produto produto)
        {
            // 🔹 Verifica novamente no POST se o funcionário está logado
            if (!FuncionarioLogado.EstaLogado)
            {
                return RedirectToAction("LoginFuncionario", "LoginFuncionario");
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
