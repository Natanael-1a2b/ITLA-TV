using Database.Entities;
using Database.ItlaTVContexts;
using Microsoft.EntityFrameworkCore;

namespace Logica_de_Negocio.Repository
{
    public class GeneroRepository
    {
        private readonly AppContexts _context;

        public GeneroRepository(AppContexts context)
        {
            _context = context;
        }

        public async Task AddAsync(Genero genero)
        {
            await _context.Generos.AddAsync(genero);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Genero genero)
        {
            _context.Entry(genero).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Genero genero)
        {
            _context.Generos.Remove(genero);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Genero> GetAllAsync()
        {
            return _context.Generos.AsQueryable();
        }

        public async Task<Genero> GetByIdAsync(int id)
        {
            return await _context.Generos.FindAsync(id);
        }
    }
}