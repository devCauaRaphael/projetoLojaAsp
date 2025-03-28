using Microsoft.AspNetCore.Mvc;
using projetoLojaAsp.Repositorio;
using projetoLojaAsp.Models;

namespace projetoLojaAsp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(UsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Usuario()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepositorio.AdicionarUsuario(usuario);
                return RedirectToAction("Login", "Login");
            }
            return View(usuario);
        }
    }
}
