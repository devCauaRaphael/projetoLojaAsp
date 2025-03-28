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


        public IActionResult Login()
        {
            return View();
        
        }        
        
        
        [HttpPost]
        public IActionResult Login(string password, string email)
        {
            var usuario = _usuarioRepositorio.ObterUsuario(email);
            if (usuario != null && usuario.password == password) {

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Email ou senha inválidos");

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
                return RedirectToAction("Usuario");
            }
            return View(usuario);
        }
    }
}
