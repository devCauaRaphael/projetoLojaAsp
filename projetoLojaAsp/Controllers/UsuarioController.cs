using Microsoft.AspNetCore.Mvc;
using projetoLojaAsp.Repositorio;

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
    }
}
