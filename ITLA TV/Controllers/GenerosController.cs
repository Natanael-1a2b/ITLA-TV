using Database.Entities;
using Database.ItlaTVContexts;
using Logica_de_Negocio.Servicies;
using Logica_de_Negocio.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITLA_TV.Controllers
{
    public class GenerosController : Controller
    {
        private readonly GeneroService _generoService;
        private readonly AppContexts _context;

        public GenerosController(AppContexts context, GeneroService generoService)
        {
            _context = context;
            _generoService = generoService;
        }

        // Mantenimiento
        public async Task<IActionResult> MantenimientoDeGeneros()
        {
            var generos = await _generoService.GetAllViewModel();
            return View(generos);
        }

        // Crear
        public IActionResult CrearGenero()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearGenero(GeneroViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var genero = new Genero
            {
                name = viewModel.name,
                description = viewModel.description
            };
            await _context.Generos.AddAsync(genero);
            await _context.SaveChangesAsync();

            return RedirectToAction("MantenimientoDeGeneros");
        }

        // Editar
        public async Task<IActionResult> EditarGenero(int id)
        {
            var genero = await _context.Generos.FindAsync(id);
            if (genero == null) return NotFound();

            var viewModel = new GeneroViewModel
            {
                IdGenero = genero.IdGenero,
                name = genero.name,
                description = genero.description
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarGenero(GeneroViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var genero = await _context.Generos.FindAsync(viewModel.IdGenero);
            genero.name = viewModel.name;
            genero.description = viewModel.description;

            _context.Generos.Update(genero);
            await _context.SaveChangesAsync();

            return RedirectToAction("MantenimientoDeGeneros");
        }

        // Eliminar
        public async Task<IActionResult> EliminarGenero(int id)
        {
            var genero = await _context.Generos.FindAsync(id);
            if (genero == null) return NotFound();

            var viewModel = new GeneroViewModel
            {
                IdGenero = genero.IdGenero,
                name = genero.name,
                description = genero.description
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminarGenero(int id)
        {
            var genero = await _context.Generos.FindAsync(id);
            if (genero == null) return NotFound();

            _context.Generos.Remove(genero);
            await _context.SaveChangesAsync();

            return RedirectToAction("MantenimientoDeGeneros");
        }
    }
}