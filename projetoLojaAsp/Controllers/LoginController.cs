using Microsoft.AspNetCore.Mvc;
using projetoLojaAsp.Repositorio;

namespace projetoLojaAsp.Controllers
{
    public class LoginController : Controller
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public LoginController(UsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string password, string email)
        {
            var usuario = _usuarioRepositorio.ObterUsuario(email);
            if (usuario != null && usuario.password == password)
            {

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Email ou senha inválidos");

            return View();
        }
    }
}
