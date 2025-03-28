using Microsoft.AspNetCore.Mvc;
using projetoLojaAsp.Models;
using projetoLojaAsp.Repositorio;

namespace projetoLojaAsp.Controllers
{
    public class LoginFuncionarioController : Controller
    {
        private readonly FuncionarioRepositorio _funcionarioRepositorio;

        public LoginFuncionarioController(FuncionarioRepositorio funcionarioRepositorio) 
        { 
            _funcionarioRepositorio = funcionarioRepositorio;
        }
        public IActionResult LoginFuncionario()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginFuncionario(string password, string email)
        {
            var funcionario = _funcionarioRepositorio.ObterFuncionario(email);
            if(funcionario != null && funcionario.password = password)
            {
                return RedirectToAction("Produto", "Produto");
            }
            ModelState.AddModelError("", "Email ou senha inválidos");
            return View();
        }
    }
}
