using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Entities;
using Database.ItlaTVContexts;
using Microsoft.EntityFrameworkCore;


namespace Logica_de_Negocio.Repository
{
    public class SeriesRepository
    {
        private readonly AppContexts _AppContexts;

        public SeriesRepository(AppContexts appContexts)
        {
            _AppContexts = appContexts;
        }
        
        public async Task AddAsync(Serie serie)//Insert
        {
            await _AppContexts.AddAsync(serie);
            await _AppContexts.SaveChangesAsync();
        }

        public async Task UpdateAsync(Serie serie)//Update
        {
            _AppContexts.Entry(serie).State = EntityState.Modified;
            await _AppContexts.SaveChangesAsync();
        }

        public async Task DeleteAsync(Serie serie)//Delete
        {
            _AppContexts.Set<Serie>().Remove(serie);
            await _AppContexts.SaveChangesAsync();
        }

        public IQueryable<Serie> GetAllAsync()//select all
        {
            return _AppContexts.Set<Serie>().AsQueryable();
        }

        public async Task<Serie> GetByIdAsync(int id)
        {
            return await _AppContexts.Set<Serie>()
                .Include(s => s.Genero1)
                .Include(s => s.Genero2)
                .Include(s => s.Productora)
                .FirstOrDefaultAsync(s => s.IdSerie == id);
        }

    }
}
