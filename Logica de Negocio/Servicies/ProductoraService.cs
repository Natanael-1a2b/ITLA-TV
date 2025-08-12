using Database.Entities;
using Database.ItlaTVContexts;
using Logica_de_Negocio.Repository;
using Logica_de_Negocio.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Logica_de_Negocio.Servicies
{
    public class ProductoraService
    {
        private readonly ProductoraRepository _productoraRepository;

        public ProductoraService(AppContexts context)
        {
            _productoraRepository = new ProductoraRepository(context);
        }

        public async Task<List<ProductoraViewModel>> GetAllViewModel()
        {
            var productoras = await _productoraRepository.GetAllAsync().ToListAsync();
            return productoras.Select(p => new ProductoraViewModel
            {
                IdProductora = p.IdProductora,
                name = p.name,
                description = p.description

            }).ToList();
        }

        public async Task<ProductoraViewModel> GetByIdViewModel(int id)
        {
            var productora = await _productoraRepository.GetByIdAsync(id);
            return new ProductoraViewModel
            {
                IdProductora = productora.IdProductora,
                name = productora.name,
                description = productora.description
            };
        }
    }
}