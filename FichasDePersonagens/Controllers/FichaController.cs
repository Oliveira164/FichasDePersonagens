using Microsoft.AspNetCore.Mvc;
using FichasDePersonagens.Models;
using FichasDePersonagens.Repositorio;

namespace FichasDePersonagens.Controllers
{
    public class FichaController : Controller
    {

        private readonly FichaRepositorio _fichaRepositorio;

        public FichaController(FichaRepositorio fichaRepositorio)
        {
            _fichaRepositorio = fichaRepositorio;
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Ficha ficha)
        {
            if (ModelState.IsValid)
            {
                _fichaRepositorio.AdicionarFicha(ficha);
                return RedirectToAction("Index");
            }
            return View(ficha);
        }
    }
}
