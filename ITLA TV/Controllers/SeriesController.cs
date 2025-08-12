using Database.Entities;
using Database.ItlaTVContexts;
using ITLA_TV.Models;
using Logica_de_Negocio.Servicies;
using Logica_de_Negocio.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ITLA_TV.Controllers
{
    public class SeriesController : Controller
    {
        private readonly SerieService _serieService;
        private readonly AppContexts _context;

        public SeriesController(AppContexts context, SerieService serieService)
        {
            _context = context;
            _serieService = serieService;
        }

        public async Task<IActionResult> CrearSerie()
        {
            // Cargar dropdowns de productoras y géneros
            var productoras = await _context.Productoras.ToListAsync();
            var generos = await _context.Generos.ToListAsync();

            ViewBag.Productoras = new SelectList(productoras, "IdProductora", "name");
            ViewBag.Generos = new SelectList(generos, "IdGenero", "name");

            return View();
        }

        // POST: SeriesController/CrearSerie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearSerie(SerieViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // Recargar dropdowns si hay error
                var productoras = await _context.Productoras.ToListAsync();
                var generos = await _context.Generos.ToListAsync();

                ViewBag.Productoras = new SelectList(productoras, "IdProductora", "name");
                ViewBag.Generos = new SelectList(generos, "IdGenero", "name");

                return View(viewModel);
            }

            // Mapear ViewModel a Entidad
            var serie = new Serie
            {
                name = viewModel.name,
                Imagen = viewModel.Imagen,
                EnlaceYouTube = viewModel.EnlaceYouTube,
                description = viewModel.description,
                IdProductora = viewModel.ProductoraId,
                IdGenero1 = viewModel.Genero1Id,
                IdGenero2 = viewModel.Genero2Id
            };

            await _context.Series.AddAsync(serie);
            await _context.SaveChangesAsync();

            return RedirectToAction("MantenimientoDeSeries", "Home");
        }

        public async Task<IActionResult> EditSerie(int id)
        {
           
            var serieViewModel = await _serieService.GetByIdViewModelAsync(id);
            if (serieViewModel == null)
            {
                return NotFound();
            }

            var productoras = await _context.Productoras.ToListAsync();
            var generos = await _context.Generos.ToListAsync();

            ViewBag.Productoras = new SelectList(productoras, "IdProductora", "name", serieViewModel.ProductoraId);
            ViewBag.Generos = new SelectList(generos, "IdGenero", "name");

            return View(serieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSerie(SerieViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var productoras = await _context.Productoras.ToListAsync();
                var generos = await _context.Generos.ToListAsync();

                ViewBag.Productoras = new SelectList(productoras, "IdProductora", "name", viewModel.ProductoraId);
                ViewBag.Generos = new SelectList(generos, "IdGenero", "name");

                return View(viewModel);
            }

            var serie = await _context.Series.FindAsync(viewModel.IdSerie);
            if (serie == null)
            {
                return NotFound();
            }

            serie.name = viewModel.name;
            serie.Imagen = viewModel.Imagen;
            serie.EnlaceYouTube = viewModel.EnlaceYouTube;
            serie.description = viewModel.description;
            serie.IdProductora = viewModel.ProductoraId;
            serie.IdGenero1 = viewModel.Genero1Id;
            serie.IdGenero2 = viewModel.Genero2Id; 

            _context.Series.Update(serie);
            await _context.SaveChangesAsync();

            return RedirectToAction("MantenimientoDeSeries", "Home");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            try
            {
                Console.WriteLine($"Intentando eliminar la serie con ID: {id}");
                var serie = await _context.Series.FindAsync(id);
                if (serie == null)
                {
                    Console.WriteLine($"No se encontró la serie con ID: {id}");
                    return NotFound();
                }

                _context.Series.Remove(serie);
                await _context.SaveChangesAsync();

                return RedirectToAction("MantenimientoDeSeries", "Home");
            }
            catch
            {
                return RedirectToAction("MantenimientoDeSeries", "Home");
            }
        }

        public async Task<IActionResult> EliminarSerie(int id)
        {
            var serieViewModel = await _serieService.GetByIdViewModelAsync(id);
            if (serieViewModel == null)
            {
                return NotFound();
            }
            return View(serieViewModel);
        }
    }
}