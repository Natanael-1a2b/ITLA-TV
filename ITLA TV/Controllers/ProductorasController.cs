using Database.Entities;
using Database.ItlaTVContexts;
using Logica_de_Negocio.Servicies;
using Logica_de_Negocio.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITLA_TV.Controllers
{
    public class ProductorasController : Controller
    {
        private readonly ProductoraService _productoraService;
        private readonly AppContexts _context;

        public ProductorasController(AppContexts context, ProductoraService productoraService)
        {
            _context = context;
            _productoraService = productoraService;
        }

        // Mantenimiento
        public async Task<IActionResult> MantenimientoDeProductoras()
        {
            var productoras = await _productoraService.GetAllViewModel();
            return View(productoras);
        }

        // Crear
        public IActionResult CrearProductora()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearProductora(ProductoraViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var productora = new Productora { name = viewModel.name, description = viewModel.description };
            await _context.Productoras.AddAsync(productora);
            await _context.SaveChangesAsync();

            return RedirectToAction("MantenimientoDeProductoras");
        }

        // Editar
        public async Task<IActionResult> EditarProductora(int id)
        {
            var productora = await _context.Productoras.FindAsync(id);
            if (productora == null) return NotFound();

            var viewModel = new ProductoraViewModel
            {
                IdProductora = productora.IdProductora,
                name = productora.name,
                description = productora.description
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarProductora(ProductoraViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var productora = await _context.Productoras.FindAsync(viewModel.IdProductora);
            productora.name = viewModel.name;
            productora.description = viewModel.description;

            _context.Productoras.Update(productora);
            await _context.SaveChangesAsync();

            return RedirectToAction("MantenimientoDeProductoras");
        }

        // Eliminar
        public async Task<IActionResult> EliminarProductora(int id)
        {
            var productora = await _context.Productoras.FindAsync(id);
            if (productora == null) return NotFound();

            var viewModel = new ProductoraViewModel
            {
                IdProductora = productora.IdProductora,
                name = productora.name,
                description = productora.description
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminarProductora(int id)
        {
            var productora = await _context.Productoras.FindAsync(id);
            if (productora == null) return NotFound();

            _context.Productoras.Remove(productora);
            await _context.SaveChangesAsync();

            return RedirectToAction("MantenimientoDeProductoras");
        }
    }
}