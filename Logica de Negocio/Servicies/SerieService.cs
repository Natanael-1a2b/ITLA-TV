using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Database.ItlaTVContexts;
using Logica_de_Negocio.Repository;
using Logica_de_Negocio.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Logica_de_Negocio.Servicies
{
    public class SerieService
    {
        private readonly SeriesRepository _seriesRepository;

        public SerieService (AppContexts appContexts)
        {
            _seriesRepository = new(appContexts);
        }

        public async Task<List<SerieViewModel>> GetAllViewModel()
        {
            var serieList = await _seriesRepository.GetAllAsync()
                .Include(s => s.Genero1)
                .Include(s => s.Genero2)
                .Include(s => s.Productora)
                .ToListAsync();

            return serieList.Select(serie => new SerieViewModel
            {
                IdSerie = serie.IdSerie,
                Imagen = serie.Imagen,
                EnlaceYouTube = serie.EnlaceYouTube,
                description = serie.description,
                name = serie.name,
                Genero1 = serie.Genero1?.name,
                Genero2 = serie.Genero2?.name,
                Genero1Id = serie.Genero1?.IdGenero ?? 0, 
                Genero2Id = serie.Genero2?.IdGenero ?? 0, 
                Productora = serie.Productora?.name,
                ProductoraId = serie.Productora?.IdProductora ?? 0 
            }).ToList();
        }

        //------------------------------------------------------------------------------------
        public async Task<SerieViewModel> GetByIdViewModelAsync(int id)
        {
            var serie = await _seriesRepository.GetByIdAsync(id);
            if (serie == null)
            {
                return null; // Retorna null si no se encuentra la serie
            }
            return new SerieViewModel
            {
                IdSerie = serie.IdSerie,
                Imagen = serie.Imagen,
                EnlaceYouTube = serie.EnlaceYouTube,
                name = serie.name,
                description = serie.description,
                Genero1 = serie.Genero1?.name,
                Genero2 = serie.Genero2?.name,
                Productora = serie.Productora?.name
            };
        }

    }
}
