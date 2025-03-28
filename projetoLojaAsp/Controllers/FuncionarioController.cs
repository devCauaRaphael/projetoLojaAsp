using Microsoft.AspNetCore.Mvc;
using projetoLojaAsp.Models;
using projetoLojaAsp.Repositorio;

namespace projetoLojaAsp.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly FuncionarioRepositorio _funcionarioRepositorio;

         public FuncionarioController(FuncionarioRepositorio funcionarioRepositorio) 
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }
        public IActionResult Funcionario()
        {
            return View();
        }

        public IActionResult CadastroFuncionario() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult CadastroFuncionario(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _funcionarioRepositorio.AdicionarFuncionario(funcionario);
                return RedirectToAction("Funcionario");
            }

            return View("Funcionario");
        }


    }
}
