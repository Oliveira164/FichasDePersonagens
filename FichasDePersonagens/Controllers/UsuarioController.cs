using Microsoft.AspNetCore.Mvc;
using FichasDePersonagens.Models;
using FichasDePersonagens.Repositorio;

namespace FichasDePersonagens.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly UsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(UsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string nome, string email, string senha)
        {
            var usuario = _usuarioRepositorio.ObterUsuario(email);

            if (usuario != null && usuario.Senha == senha)
            {
                // Autenticação bem-sucedida
                return RedirectToAction("Index", "Ficha");
            }
            ModelState.AddModelError("", "Email ou senha inválidos.");
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
                return RedirectToAction("Login");
            }
            return View(usuario);
        }
    }
}
