using Database.Entities;
using Database.ItlaTVContexts;
using Logica_de_Negocio.Repository;
using Logica_de_Negocio.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Logica_de_Negocio.Servicies
{
    public class GeneroService
    {
        private readonly GeneroRepository _generoRepository;

        public GeneroService(AppContexts context)
        {
            _generoRepository = new GeneroRepository(context);
        }

        public async Task<List<GeneroViewModel>> GetAllViewModel()
        {
            var generos = await _generoRepository.GetAllAsync().ToListAsync();
            return generos.Select(g => new GeneroViewModel
            {
                IdGenero = g.IdGenero,
                name = g.name,
                description = g.description
            }).ToList();
        }

        public async Task<GeneroViewModel> GetByIdViewModel(int id)
        {
            var genero = await _generoRepository.GetByIdAsync(id);
            return new GeneroViewModel
            {
                IdGenero = genero.IdGenero,
                name = genero.name,
                description = genero.description
            };
        }
    }
}