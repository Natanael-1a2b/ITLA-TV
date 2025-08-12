using Database.ItlaTVContexts;
using ITLA_TV.Models;
using Logica_de_Negocio.Servicies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ITLA_TV.Controllers
{
    public class HomeController : Controller
    {
        private readonly SerieService _SerieService;
        private readonly AppContexts _context;

        public HomeController(AppContexts appContexts)
        {
            _SerieService = new SerieService(appContexts);
            _context = appContexts;
        }

        public async Task<IActionResult> Index(string searchString, int? productoraId, int? generoId, string sortOrder)
        {
            
            var series = await _SerieService.GetAllViewModel();

            if (!string.IsNullOrEmpty(searchString))
            {
                series = series.Where(s => s.name.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (productoraId.HasValue)
            {
                series = series.Where(s => s.ProductoraId == productoraId.Value).ToList();
            }

            if (generoId.HasValue)
            {
                series = series.Where(s => s.Genero1Id == generoId.Value || s.Genero2Id == generoId.Value).ToList();
            }

            switch (sortOrder)
            {
                case "Nombre":
                    series = series.OrderBy(s => s.name).ToList();
                    break;
                case "Genero":
                    series = series.OrderBy(s => s.Genero1).ToList();
                    break;
                case "Productora":
                    series = series.OrderBy(s => s.Productora).ToList();
                    break;
                default:
                    series = series.OrderBy(s => s.IdSerie).ToList();
                    break;
            }

            var productoras = await _context.Productoras.ToListAsync();
            var generos = await _context.Generos.ToListAsync();

            ViewBag.Productoras = new SelectList(productoras, "IdProductora", "name");
            ViewBag.Generos = new SelectList(generos, "IdGenero", "name");

            ViewData["CurrentFilter"] = searchString;
            ViewData["SelectedProductora"] = productoraId;
            ViewData["SelectedGenero"] = generoId;
            ViewData["SortOrder"] = sortOrder;

            return View(series);
        }

        public async Task<IActionResult> MantenimientoDeSeries()
        {
            var series = await _SerieService.GetAllViewModel();
            return View(series);
        }

        [HttpPost]
        public async Task<IActionResult> SerieElegida(int id)
        {
            var serieViewModel = await _SerieService.GetByIdViewModelAsync(id);
            if (serieViewModel == null)
            {
                return NotFound();
            }

            return View(serieViewModel); 
        }

    }
}
